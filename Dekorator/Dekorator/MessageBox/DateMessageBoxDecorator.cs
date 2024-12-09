public class DateMessageBoxDecorator : BaseMessageBoxDecorator
{
    public DateMessageBoxDecorator(IMessageBox messageBox) : base(messageBox)
    {

    }

    public override void AddMessage(IMessage message)
    {
        DateMessageDecorator newMessage = new DateMessageDecorator(message, DateTime.Now);
        base.AddMessage(newMessage);
    }
}