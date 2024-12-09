using System.Text;

public class TaskGroup : ITaskComponent
{

    private List<ITaskComponent> _tasks = new();

    private string _name;

    public int CompletedOnTime => _tasks.Count(t => t.IsCompleted && !t.IsLate);

    public int CompletedLate => _tasks.Count(t => t.IsLate);

    public int Pending => _tasks.Count(t => !t.IsCompleted);

    public int PendingLate => _tasks.Count(t => !t.IsCompleted && DateTime.Now > t.EndDate);

    public DateTime StartDate => _tasks.MinBy(t => t.StartDate).StartDate;

    public DateTime EndDate => _tasks.MaxBy(t => t.EndDate).EndDate;

    public bool IsCompleted => _tasks.All(t => t.IsCompleted);

    public bool IsLate => _tasks.Any(t => t.IsLate);

    public string Name => _name;

    public TaskGroup(string name)
    {
        _name = name;
    }

    public void Add(ITaskComponent component)
    {
        _tasks.Add(component);
    }
    public void Remove(ITaskComponent component)
    {
        _tasks.Remove(component);
    }

    public string GetStatus()
    {
        bool islate = false;
        foreach (ITaskComponent task in _tasks)
        {
            if (!task.IsCompleted)
            {
                return "[Pending]";
            }
            else if (task.IsLate)
            {
                islate = true;
            }
        }
        if (islate)
        {
            return "[Completed Late]";
        }
        else
        {
            return "[Completed]";
        }
    }

    public void MarkAsCompleted(DateTime completionDate)
    {
        foreach (ITaskComponent task in _tasks)
        {
            if (!task.IsCompleted)
            {
                task.MarkAsCompleted(completionDate);
            }
        }

    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(Name);
        foreach (ITaskComponent task in _tasks)
        {
            sb.AppendLine($"\t{task}");
        }

        return sb.ToString();
    }
}