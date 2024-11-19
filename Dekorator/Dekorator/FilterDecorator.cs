public class FilterDecorator : BaseMessageBoxDecorator
{
    private string _forbiddenWord;
    public FilterDecorator(IMessageBox messageBox, string forbiddenWord) : base(messageBox)
    {
        _forbiddenWord = forbiddenWord;
    }

    public override void AddMessage(IMessage message)
    {

        if (message.Content.Contains(_forbiddenWord) || message.Title.Contains(_forbiddenWord))
        {
            throw new Exception("Contains forbbiden word.");
        }
        DateMessageDecorator newMessage = new DateMessageDecorator(message, DateTime.Now);
        base.AddMessage(newMessage);
    }

    public override IMessage GetMessageById(int id)
    {
        IMessage message = base.GetMessageById(id);

        if (message.Content.Contains(_forbiddenWord) || message.Title.Contains(_forbiddenWord))
        {
            return new Message(null, null);
        }

        return message;
    }
}

