
internal class DictionaryAdapter : ITableDataSource
{
    private Dictionary<string, int> dictionary;

    public DictionaryAdapter(Dictionary<string, int> dictionary)
    {
        this.dictionary = dictionary;
    }

    public string GetCellData(int rowIndex, int columnIndex)
    {
        throw new NotImplementedException();
    }

    public int GetColumnCount()
    {
        throw new NotImplementedException();
    }

    public string GetColumnName(int columnIndex)
    {
        throw new NotImplementedException();
    }

    public int GetRowCount()
    {
        throw new NotImplementedException();
    }
}