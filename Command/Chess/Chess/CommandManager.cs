public class CommandManager
{
    public Stack<MoveCommand> executedCommands = new Stack<MoveCommand>();
    public Stack<MoveCommand> undoneCommands = new Stack<MoveCommand>();

    public void Move(MoveCommand moveCommand)
    {
        moveCommand.Execute();
        executedCommands.Push(moveCommand);
        undoneCommands.Clear();
    }

    public void Undo()
    {
        MoveCommand command = executedCommands.Pop();
        command.Undo();
        undoneCommands.Push(command);
    }
    public void Redo()
    {
        MoveCommand command = undoneCommands.Pop();
        command.Execute();
        executedCommands.Push(command);
    }

}
