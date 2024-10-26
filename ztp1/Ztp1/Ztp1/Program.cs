public class Program
{
    public static void Main()
    {

        ConnectionManager connectionManager = ConnectionManager.getInstance();


        IDatabaseConnection db1connection1 = connectionManager.GetConnection("DB1");

        if (db1connection1 != null)
        {

            db1connection1.AddRecord("Karol", 23);
            db1connection1.ShowAllRecords();

        }

        IDatabaseConnection db2connection1 = connectionManager.GetConnection("DB2");

        if (db2connection1 != null)
        {

            db2connection1.AddRecord("Mateusz", 26);
            db2connection1.ShowAllRecords();
        }

        Console.WriteLine("W DB1 jest Karol w DB2 jest Mateusz");
        Console.WriteLine();


        IDatabaseConnection db1connection2 = connectionManager.GetConnection("DB1");
        if (db1connection2 != null)
        {

            db1connection2.AddRecord("Jacek", 8);
            db1connection2.ShowAllRecords();

        }
        Console.WriteLine("W DB1 jest Karol oraz Jacek");
        Console.WriteLine();

        IDatabaseConnection db1connection3 = connectionManager.GetConnection("DB1");
        IDatabaseConnection db1connection4 = connectionManager.GetConnection("DB1");

        Console.WriteLine($"db1connection1 == db1connection2: {db1connection1 == db1connection2}");
        Console.WriteLine($"db1connection1 == db1connection3: {db1connection1 == db1connection3}");
        Console.WriteLine($"db1connection1 == db1connection4: {db1connection1 == db1connection4}");
    }
}