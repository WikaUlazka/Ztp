interface IDatabaseConnection
{
    int AddRecord(string name, int age);

    void UpdateRecord(int id, string newName, int newAge);

    void DeleteRecord(int id);

    Record? GetRecord(int id);

    void ShowAllRecords();
}

interface IConnectionManager
{
    IDatabaseConnection GetConnection(string databaseName);
}

// Prosty rekord w bazie danych
class Record
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Record(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"Record [ID={Id}, Name={Name}, Age={Age}]";
    }
}

// Prosta baza danych
class Database
{
    private static Dictionary<string, Database> instances = new Dictionary<string, Database>();

    private readonly List<Record> records; // Lista przechowująca rekordy
    private int nextId = 1; // Licznik do generowania unikalnych ID

    private Database()
    {
        records = new();
    }

    public static Database GetInstance(string key)
    {
        if (instances.TryGetValue(key, out var bd))
        {
            return bd;
        }
        instances.Add(key, new Database());
        return instances[key];
    }

    // Zwraca implementację interfejsu DatabaseConnection
    public IDatabaseConnection GetConnection()
    {
        return new DatabaseConnection(this);
    }

    // Prywatna klasa wewnętrzna implementująca interfejs DatabaseConnection
    // W Javie korzystamy z cech klas wewnętrznych, w C# ta klasa musiałaby posiadać
    // referencję na obiekt klasy Database
    private class DatabaseConnection : IDatabaseConnection
    {
        private readonly Database db;

        public DatabaseConnection(Database database)
        {
            db = database;
        }

        // Dodawanie nowego rekordu
        public int AddRecord(string name, int age)
        {
            Record newRecord = new(db.nextId++, name, age);
            db.records.Add(newRecord);
            Console.WriteLine($"Inserted: {newRecord}");
            return db.nextId - 1; // zwracamy id dodanego rekordu
        }

        // Pobieranie rekordu po ID
        public Record? GetRecord(int id)
        {
            return db.records.Where(rec => rec.Id == id).FirstOrDefault();
        }

        // Aktualizowanie rekordu po ID
        public void UpdateRecord(int id, string newName, int newAge)
        {
            Record? optionalRecord = GetRecord(id);

            if (optionalRecord != null)
            {
                Record record = optionalRecord;
                record.Name = newName;
                record.Age = newAge;
                Console.WriteLine($"Updated: {record}");
            }
            else
            {
                Console.WriteLine($"Record with ID {id} not found.");
            }
        }

        // Usuwanie rekordu po ID
        public void DeleteRecord(int id)
        {
            Record? optionalRecord = GetRecord(id);

            if (optionalRecord != null)
            {
                db.records.Remove(optionalRecord);
                Console.WriteLine($"Deleted record with ID {id}");
            }
            else
            {
                Console.WriteLine($"Record with ID {id} not found.");
            }
        }

        // Wyświetlanie wszystkich rekordów
        public void ShowAllRecords()
        {
            if (db.records.Any())
            {
                Console.WriteLine("All records:");
                db.records.ForEach(r => Console.WriteLine(r));
            }
            else
            {
                Console.WriteLine("No records in the database.");
            }
        }
    }
}

class ConnectionManager : IConnectionManager
{

    private static ConnectionManager instance;
    private Dictionary<string, ConnectionPool> pools = new Dictionary<string, ConnectionPool>();
    private ConnectionManager()
    {

    }

    public IDatabaseConnection GetConnection(string databaseName)
    {
        if (pools.TryGetValue(databaseName, out var pool))
        {
            return pool.GetConnection();
        }
        ConnectionPool newPool = new ConnectionPool(databaseName);
        pools.Add(databaseName, newPool);
        return newPool.GetConnection();
    }

    public static ConnectionManager getInstance()
    {
        if (instance == null)
        {
            instance = new ConnectionManager();
        }
        return instance;
    }

    private class ConnectionPool
    {
        private int connectionNumber = 0;
        private List<IDatabaseConnection> connections = new List<IDatabaseConnection>();
        private string databaseName;

        public ConnectionPool(string databaseName)
        {
            this.databaseName = databaseName;
        }

        public IDatabaseConnection GetConnection()
        {
            int index = connectionNumber % 3;
            connectionNumber++;
            if (connections.Count <= index)
            {
                Database db = Database.GetInstance(databaseName);
                IDatabaseConnection connection = db.GetConnection();
                connections.Add(connection);
            }
            return connections[index];
        }

    }
}