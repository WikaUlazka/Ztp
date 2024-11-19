public abstract class BaseMessageDecorator : IMessage
{
    protected IMessage message;

    public BaseMessageDecorator(IMessage message)
    {
        this.message = message;
    }

    virtual public int Id { get => message.Id; set => message.Id = value; }
    virtual public string Title { get => message.Title; set => message.Title = value; }
    virtual public string Content { get => message.Content; set => message.Content = value; }

}