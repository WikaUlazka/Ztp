internal class ArrayAdapter : ITableDataSource
{
    private int[] numbersArray;

    public ArrayAdapter(int[] numbersArray)
    {
        this.numbersArray = numbersArray;
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