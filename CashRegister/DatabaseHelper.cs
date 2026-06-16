// Автор: Старосветским М. А., группа ПРОГ-С-25
// Дата: 23.05.2026
// Файл: работа с базой данных SQLite supermarket.db

using Microsoft.Data.Sqlite;

namespace CashRegister;

/// <summary>
/// Статический класс для подключения к SQLite и загрузки справочников.
/// </summary>
public static class DatabaseHelper
{
  private static readonly string DbFileName = "supermarket.db";

  private static string DatabasePath =>
    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbFileName);

  /// <summary>
  /// Инициализирует БД: создаёт файл, таблицы и тестовые данные при первом запуске.
  /// </summary>
  public static void Initialize()
  {
    if (!File.Exists(DatabasePath))
    {
      CreateDatabaseWithSeedData();
    }
    else
    {
      EnsureSchema();
    }
  }

  /// <summary>
  /// Создаёт файл БД, таблицы и заполняет тестовыми данными.
  /// </summary>
  private static void CreateDatabaseWithSeedData()
  {
    using var connection = OpenConnection();
    using var command = connection.CreateCommand();

    command.CommandText = """
      CREATE TABLE Products (
        Barcode TEXT PRIMARY KEY,
        Name TEXT NOT NULL,
        Price REAL NOT NULL,
        IsWeighted INTEGER NOT NULL,
        IsAlcohol INTEGER NOT NULL
      );

      CREATE TABLE Cashiers (
        CardBarcode TEXT PRIMARY KEY,
        Password TEXT NOT NULL,
        FullName TEXT NOT NULL
      );

      CREATE TABLE AppSettings (
        SettingKey TEXT PRIMARY KEY,
        SettingValue TEXT NOT NULL
      );
      """;
    command.ExecuteNonQuery();

    InsertCashier(connection, "1001", "1111", "Иванова Анна Сергеевна");
    InsertCashier(connection, "1002", "2222", "Петров Иван Иванович");
    InsertCashier(connection, "1003", "3333", "Сидорова Мария Константиновна");

    InsertProduct(connection, "4601234567890", "Хлеб белый нарезка", 45.50, false, false);
    InsertProduct(connection, "4602345678901", "Молоко 2.5% 1 л", 89.90, false, false);
    InsertProduct(connection, "4603456789012", "Яйца С1 10 шт", 119.00, false, false);
    InsertProduct(connection, "4604567890123", "Сок апельсиновый 1 л", 129.00, false, false);
    InsertProduct(connection, "2789012345678", "Яблоки Гала", 189.90, true, false);
    InsertProduct(connection, "2790123456789", "Сыр Российский", 549.00, true, false);
    InsertProduct(connection, "4605678901234", "Водка 0.5 л", 599.00, false, true);
    InsertProduct(connection, "4606789012345", "Вино красное сухое 0.75 л", 449.00, false, true);

    SaveRevenue(0);
  }

  /// <summary>
  /// Проверяет наличие таблиц в существующей БД.
  /// </summary>
  private static void EnsureSchema()
  {
    using var connection = OpenConnection();
    using var command = connection.CreateCommand();
    command.CommandText = """
      CREATE TABLE IF NOT EXISTS Products (
        Barcode TEXT PRIMARY KEY,
        Name TEXT NOT NULL,
        Price REAL NOT NULL,
        IsWeighted INTEGER NOT NULL,
        IsAlcohol INTEGER NOT NULL
      );

      CREATE TABLE IF NOT EXISTS Cashiers (
        CardBarcode TEXT PRIMARY KEY,
        Password TEXT NOT NULL,
        FullName TEXT NOT NULL
      );

      CREATE TABLE IF NOT EXISTS AppSettings (
        SettingKey TEXT PRIMARY KEY,
        SettingValue TEXT NOT NULL
      );
      """;
    command.ExecuteNonQuery();
  }

  /// <summary>
  /// Открывает соединение с SQLite.
  /// </summary>
  private static SqliteConnection OpenConnection()
  {
    var connectionString = $"Data Source={DatabasePath}";
    var connection = new SqliteConnection(connectionString);
    connection.Open();
    return connection;
  }

  private static void InsertCashier(SqliteConnection connection, string card, string password, string fullName)
  {
    using var cmd = connection.CreateCommand();
    cmd.CommandText = "INSERT INTO Cashiers (CardBarcode, Password, FullName) VALUES ($c, $p, $f)";
    cmd.Parameters.AddWithValue("$c", card);
    cmd.Parameters.AddWithValue("$p", password);
    cmd.Parameters.AddWithValue("$f", fullName);
    cmd.ExecuteNonQuery();
  }

  private static void InsertProduct(SqliteConnection connection, string barcode, string name, double price,
    bool isWeighted, bool isAlcohol)
  {
    using var cmd = connection.CreateCommand();
    cmd.CommandText =
      "INSERT INTO Products (Barcode, Name, Price, IsWeighted, IsAlcohol) VALUES ($b, $n, $p, $w, $a)";
    cmd.Parameters.AddWithValue("$b", barcode);
    cmd.Parameters.AddWithValue("$n", name);
    cmd.Parameters.AddWithValue("$p", price);
    cmd.Parameters.AddWithValue("$w", isWeighted ? 1 : 0);
    cmd.Parameters.AddWithValue("$a", isAlcohol ? 1 : 0);
    cmd.ExecuteNonQuery();
  }

  /// <summary>
  /// Загружает список всех товаров.
  /// </summary>
  /// <returns>Список товаров.</returns>
  public static List<Product> GetAllProducts()
  {
    var products = new List<Product>();
    using var connection = OpenConnection();
    using var command = connection.CreateCommand();
    command.CommandText = "SELECT Barcode, Name, Price, IsWeighted, IsAlcohol FROM Products ORDER BY Name";
    using var reader = command.ExecuteReader();
    while (reader.Read())
    {
      products.Add(new Product
      {
        Barcode = reader.GetString(0),
        Name = reader.GetString(1),
        Price = reader.GetDouble(2),
        IsWeighted = reader.GetInt32(3) == 1,
        IsAlcohol = reader.GetInt32(4) == 1
      });
    }

    return products;
  }

  /// <summary>
  /// Загружает список кассиров.
  /// </summary>
  /// <returns>Список кассиров.</returns>
  public static List<Cashier> GetAllCashiers()
  {
    var cashiers = new List<Cashier>();
    using var connection = OpenConnection();
    using var command = connection.CreateCommand();
    command.CommandText = "SELECT CardBarcode, Password, FullName FROM Cashiers ORDER BY FullName";
    using var reader = command.ExecuteReader();
    while (reader.Read())
    {
      cashiers.Add(new Cashier
      {
        CardBarcode = reader.GetString(0),
        Password = reader.GetString(1),
        FullName = reader.GetString(2)
      });
    }

    return cashiers;
  }

  /// <summary>
  /// Ищет товар по штрих-коду.
  /// </summary>
  /// <param name="barcode">Штрих-код.</param>
  /// <returns>Товар или null.</returns>
  public static Product? FindProductByBarcode(string barcode)
  {
    using var connection = OpenConnection();
    using var command = connection.CreateCommand();
    command.CommandText =
      "SELECT Barcode, Name, Price, IsWeighted, IsAlcohol FROM Products WHERE Barcode = $b";
    command.Parameters.AddWithValue("$b", barcode);
    using var reader = command.ExecuteReader();
    if (!reader.Read())
    {
      return null;
    }

    return new Product
    {
      Barcode = reader.GetString(0),
      Name = reader.GetString(1),
      Price = reader.GetDouble(2),
      IsWeighted = reader.GetInt32(3) == 1,
      IsAlcohol = reader.GetInt32(4) == 1
    };
  }

  /// <summary>
  /// Ищет кассира по штрих-коду карты.
  /// </summary>
  /// <param name="cardBarcode">Штрих-код карты.</param>
  /// <returns>Кассир или null.</returns>
  public static Cashier? FindCashierByCard(string cardBarcode)
  {
    using var connection = OpenConnection();
    using var command = connection.CreateCommand();
    command.CommandText = "SELECT CardBarcode, Password, FullName FROM Cashiers WHERE CardBarcode = $c";
    command.Parameters.AddWithValue("$c", cardBarcode);
    using var reader = command.ExecuteReader();
    if (!reader.Read())
    {
      return null;
    }

    return new Cashier
    {
      CardBarcode = reader.GetString(0),
      Password = reader.GetString(1),
      FullName = reader.GetString(2)
    };
  }

  /// <summary>
  /// Сохраняет накопленную выручку в БД.
  /// </summary>
  /// <param name="revenue">Сумма выручки в кассе.</param>
  public static void SaveRevenue(double revenue)
  {
    using var connection = OpenConnection();
    using var command = connection.CreateCommand();
    command.CommandText = """
      INSERT INTO AppSettings (SettingKey, SettingValue) VALUES ('TotalRevenue', $v)
      ON CONFLICT(SettingKey) DO UPDATE SET SettingValue = $v;
      """;
    command.Parameters.AddWithValue("$v", revenue.ToString(System.Globalization.CultureInfo.InvariantCulture));
    command.ExecuteNonQuery();
  }

  /// <summary>
  /// Загружает выручку из БД.
  /// </summary>
  /// <returns>Сумма выручки.</returns>
  public static double LoadRevenue()
  {
    using var connection = OpenConnection();
    using var command = connection.CreateCommand();
    command.CommandText = "SELECT SettingValue FROM AppSettings WHERE SettingKey = 'TotalRevenue'";
    var result = command.ExecuteScalar();
    if (result is null or DBNull)
    {
      return 0;
    }

    return double.Parse(result.ToString()!, System.Globalization.CultureInfo.InvariantCulture);
  }
}
