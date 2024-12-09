public abstract class BaseMessageBoxDecorator : IMessageBox
{
    protected IMessageBox messageBox;

    public BaseMessageBoxDecorator(IMessageBox messageBox)
    {
        this.messageBox = messageBox;
    }

    virtual public void AddMessage(IMessage message)
    {
        messageBox.AddMessage(message);
    }

    virtual public IMessage GetMessageById(int id)
    {
        return messageBox.GetMessageById(id);
    }

    virtual public void DisplayAllMessageTitles()
    {
        messageBox.DisplayAllMessageTitles();
    }
}

