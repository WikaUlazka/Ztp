
internal class UserListAdapter : ITableDataSource
{
    private List<User> users;

    public UserListAdapter(List<User> users)
    {
        this.users = users;
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