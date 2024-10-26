using System.Text;

// Klasa reprezentująca komórkę tabeli
public abstract class Cell
{

}

public class TextCell : Cell
{
    private string value;

    public TextCell(string value)
    {
        this.value = value;
    }

    public override string ToString()
    {
        return value.PadRight(15);
    }
}

public class NumberCell : Cell
{
    private int value;

    public NumberCell(int value)
    {
        this.value = value;
    }

    public override string ToString()
    {
        return value.ToString().PadRight(15);
    }
}

public class BooleanCell : Cell
{
    private bool value;

    public BooleanCell(bool value)
    {

        this.value = value;
    }

    public override string ToString()
    {
        return value.ToString().PadRight(15);
    }
}



// Klasa reprezentująca nagłówek kolumny w tabeli
public abstract class Header
{
    public abstract Cell CreateCell(object value);
    public abstract Cell CreateDefaultCell();
    public string Name { get; set; }
    protected Header(string name)
    {
        Name = name;
    }
}
public class TextHeader : Header
{
    public TextHeader(string name) : base(name)
    {
    }

    public override Cell CreateCell(object value)
    {
        return new TextCell((string)value);
    }

    public override Cell CreateDefaultCell()
    {
        return new TextCell("");
    }
}

class NumberHeader : Header
{
    public NumberHeader(string name) : base(name)
    {
    }

    public override Cell CreateCell(object value)
    {
        return new NumberCell((int)value);
    }

    public override Cell CreateDefaultCell()
    {
        return new NumberCell(0);
    }
}

class BooleanHeader : Header
{
    public BooleanHeader(string name) : base(name)
    {
    }

    public override Cell CreateCell(object value)
    {
        return new BooleanCell((bool)value);
    }

    public override Cell CreateDefaultCell()
    {
        return new BooleanCell(false);
    }
}

// Klasa reprezentująca tabelę
class Table
{
    private readonly List<Header> headers;  // Lista nagłówków kolumn
    private readonly List<List<Cell>> rows; // Lista wierszy (każdy wiersz to lista komórek)

    public Table()
    {
        headers = new List<Header>();
        rows = new List<List<Cell>>();
    }

    public void AddColumn(Header header)
    {
        headers.Add(header);

        // Dodajemy puste komórki do każdego z istniejących wierszy
        foreach (var row in rows)
        {
            row.Add(header.CreateDefaultCell());
        }
    }

    public void AddRow(params object[] cellValues)
    {
        if (cellValues.Length != headers.Count)
        {
            throw new ArgumentException("Liczba wartości nie zgadza się z liczbą kolumn.");
        }

        // Dodajemy wiersz wypełniony komórkami z wartością
        var newRow = new List<Cell>();
        for (int i = 0; i < headers.Count; i++)
        {
            var header = headers[i];
            object value = cellValues[i];
            newRow.Add(header.CreateCell(value));
        }

        rows.Add(newRow);
    }


    public override string ToString()
    {
        var sb = new StringBuilder();

        // Dodajemy nagłówki
        foreach (var header in headers)
        {
            sb.Append(header.Name.PadRight(15));
        }
        sb.AppendLine();

        // Dodajemy separator
        sb.AppendLine(new string('-', headers.Count * 15));

        // Dodajemy wiersze
        foreach (var row in rows)
        {
            foreach (var cell in row)
            {
                sb.Append(cell.ToString());
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tworzymy nową tabelę
        Table table = new Table();

        // Dodajemy kolumny
        table.AddColumn(new TextHeader("Name"));
        table.AddColumn(new NumberHeader("Age"));
        table.AddColumn(new BooleanHeader("Is Student"));

        // Dodajemy wiersze
        table.AddRow("Alice", 30, false);
        table.AddRow("Bob", 25, true);
        table.AddRow("Charlie", 35, false);

        // Wyświetlamy tabelę
        Console.WriteLine(table.ToString());

        Console.ReadKey();
    }
}
