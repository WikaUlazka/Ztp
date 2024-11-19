public class MessageBox : IMessageBox
{
    private List<IMessage> messages = new List<IMessage>();
    private int nextId = 1;

    public void AddMessage(IMessage message)
    {
        message.Id = nextId++;
        messages.Add(message);
    }

    public IMessage GetMessageById(int id)
    {
        return messages.Find(m => m.Id == id);
    }
    public void DisplayAllMessageTitles()
    {
        Console.WriteLine("\nLista wiadomości:");
        if (messages.Count == 0)
        {
            Console.WriteLine("Brak wiadomości w skrzynce.");
        }
        else
        {
            foreach (var message in messages)
            {
                Console.WriteLine($"ID: {message.Id} - {message.Title}");
            }
        }
    }
}