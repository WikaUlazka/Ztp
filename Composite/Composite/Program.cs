public class Program
{
    public static void Main()
    {
        // Przykładowe zadania
        var task1 = new Task("1A - Implementacja algorytmu sortowania", new DateTime(2024, 10, 21), new DateTime(2024, 10, 27));
        var task2 = new Task("1B - Analiza złożoności czasowej", new DateTime(2024, 10, 24), new DateTime(2024, 10, 31));
        var task3 = new Task("2A - Projektowanie schematu bazy danych", new DateTime(2024, 10, 28), new DateTime(2024, 11, 3));
        var task4 = new Task("2B - Tworzenie zapytań SQL", new DateTime(2024, 11, 1), new DateTime(2024, 11, 30));

        // Oznaczanie przykładowych zadań jako wykonane (z różnymi datami ukończenia)
        task1.MarkAsCompleted(new DateTime(2024, 10, 25)); // Wykonane na czas
        task2.MarkAsCompleted(new DateTime(2024, 11, 1)); // Wykonane z opóźnieniem
                                                          // task3 i task4 są jeszcze niewykonane

        // Lista zadań (przykładowa organizacja wyłącznie według nazw)
        var taskGroup = new TaskGroup("LIsta zadań");
        taskGroup.Add(task1);
        taskGroup.Add(task2);
        taskGroup.Add(task3);
        taskGroup.Add(task4);
        //var tasks = new List<Task> { task1, task2, task3, task4 };

        // Wyświetlanie listy zadań i ich statusów
        Console.WriteLine(taskGroup);


        // Zliczanie wykonanych, opóźnionych i oczekujących zadań


        Console.WriteLine("\nPodsumowanie zadań:");
        Console.WriteLine($"Zadania wykonane na czas: {taskGroup.CompletedOnTime}");
        Console.WriteLine($"Zadania wykonane z opóźnieniem: {taskGroup.CompletedLate}");
        Console.WriteLine($"Zadania oczekujące: {taskGroup.Pending}");
        Console.WriteLine($"Zadania oczekujące z przekroczonym terminem: {taskGroup.PendingLate}");
    }
}

