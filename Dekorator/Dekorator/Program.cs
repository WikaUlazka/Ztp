
class Program
{
    static void Main(string[] args)
    {
        IMessageBox messageBox = new FilterDecorator(new MessageBox(), "Lorem");

        // Dodanie przykładowych wiadomości
        messageBox.AddMessage(new Message("Powiadomienie o spotkaniu", "Spotkanie zespołu odbędzie się w piątek o godzinie 10:00."));
        messageBox.AddMessage(new Message("Nowe zasady pracy zdalnej", "Od przyszłego miesiąca obowiązują nowe zasady pracy zdalnej."));
        messageBox.AddMessage(new Message("Wyniki kwartalne", "Wyniki finansowe za ostatni kwartał pokazują wzrost o 15%."));

        bool running = true;
        while (running)
        {
            // Wyświetlanie wszystkich tematów wiadomości
            messageBox.DisplayAllMessageTitles();

            Console.WriteLine("\nWybierz ID wiadomości do wyświetlenia (lub 0, aby zakończyć): ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (id == 0)
                {
                    running = false;
                    Console.WriteLine("Koniec programu.");
                }
                else
                {
                    var message = messageBox.GetMessageById(id);
                    if (message != null)
                    {
                        Console.WriteLine($"\nTytuł: {message.Title}");
                        Console.WriteLine($"Treść: {message.Content}");
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono wiadomości o podanym ID.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Nieprawidłowy wybór.");
            }
        }
    }
}

