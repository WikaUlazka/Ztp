public class DateMessageDecorator : BaseMessageDecorator
{

    public DateTime SendDate { get; set; }

    override public string Content { get => $"{message.Content} {SendDate}"; set => message.Content = value; }
    public DateMessageDecorator(IMessage message, DateTime sendDate) : base(message)
    {
        SendDate = sendDate;
    }


}
