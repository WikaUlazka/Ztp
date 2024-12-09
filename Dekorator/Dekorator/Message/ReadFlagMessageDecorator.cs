public class ReadFlagMessageDecorator : BaseMessageDecorator
{
    public bool IsRead { get; set; } = false;
    public void MarkAsRead()
    {
        IsRead = true;
    }
    public ReadFlagMessageDecorator(IMessage message) : base(message)
    {
    }

    override public string Title { get => $"{message.Title} {(IsRead ? "Odczytana" : "Nieodczytana")}"; set => message.Title = value; }


}
