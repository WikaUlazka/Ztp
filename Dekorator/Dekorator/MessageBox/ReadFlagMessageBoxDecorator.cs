public class ReadFlagMessageBoxDecorator : BaseMessageBoxDecorator
{

    public ReadFlagMessageBoxDecorator(IMessageBox messageBox) : base(messageBox)
    {

    }

    override public IMessage GetMessageById(int id)
    {
        IMessage message = messageBox.GetMessageById(id);
        if (message is ReadFlagMessageDecorator readFlagMessage)
        {
            readFlagMessage.MarkAsRead();
        }
        return message;
    }

    override public void AddMessage(IMessage message)
    {
        ReadFlagMessageDecorator newMessge = new ReadFlagMessageDecorator(message);
        base.AddMessage(newMessge);
    }
}