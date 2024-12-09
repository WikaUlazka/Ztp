public interface ITaskComponent
{
    public void MarkAsCompleted(DateTime completionDate);
    public string GetStatus();
    public string Name { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public bool IsCompleted { get; }
    public bool IsLate { get; }
}