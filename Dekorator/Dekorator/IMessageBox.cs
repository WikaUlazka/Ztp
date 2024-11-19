public interface IMessageBox
{

    public void AddMessage(IMessage message);
    public IMessage GetMessageById(int id);
    public void DisplayAllMessageTitles();
}