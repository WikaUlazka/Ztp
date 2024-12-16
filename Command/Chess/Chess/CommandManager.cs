using Chess;

public class CommandManager
{
    public Stack<MoveCommand> executedCommands = new Stack<MoveCommand>();
    public Stack<MoveCommand> undoneCommands = new Stack<MoveCommand>();

    public bool Move(MoveCommand moveCommand)
    {
        var result = moveCommand.Execute();
        executedCommands.Push(moveCommand);
        undoneCommands.Clear();
        return result;
    }

    public void Undo()
    {
        if (executedCommands.Count != 0)
        {
            MoveCommand command = executedCommands.Pop();
            command.Undo();
            undoneCommands.Push(command);
        }
    }
    public void Redo()
    {
        if (undoneCommands.Count != 0)
        {
            MoveCommand command = undoneCommands.Pop();
            command.Execute();
            executedCommands.Push(command);
        }
    }

    public void Replay(ChessBoardControl chessBoardControl)
    {

        IMemento currentState = Save();

        Stack<MoveCommand> commendsToRun = new Stack<MoveCommand>();

        while (executedCommands.Any())
        {
            var commend = executedCommands.Pop();
            commend.Undo();
            commendsToRun.Push(commend);
        }

        while (commendsToRun.Any())
        {
            var command = commendsToRun.Pop();
            command.Execute();
            chessBoardControl.Invalidate();
            Thread.Sleep(1000);
        }

        Restore(currentState);
    }

    public IMemento Save()
    {
        Memento chessMemento = new(executedCommands, undoneCommands);
        return chessMemento;
    }
    public class Memento : IMemento
    {
        public Stack<MoveCommand> executedCommands = new Stack<MoveCommand>();
        public Stack<MoveCommand> undoneCommands = new Stack<MoveCommand>();

        public Memento(Stack<MoveCommand> executedCommands, Stack<MoveCommand> undoneCommands)
        {
            this.executedCommands = new Stack<MoveCommand>(executedCommands.Reverse());
            this.undoneCommands = new Stack<MoveCommand>(undoneCommands.Reverse());
        }


        public Stack<MoveCommand> GetExecutedState()
        {
            return this.executedCommands;
        }

        public Stack<MoveCommand> GetUndoneState()
        {
            return this.undoneCommands;
        }

    }

    public void Restore(IMemento memento)
    {
        if (memento is not Memento chessMemento)
        {
            throw new ArgumentException("Invalid memento type.");
        }

        var executedState = chessMemento.GetExecutedState();
        executedCommands = executedState;

        var undoneState = chessMemento.GetUndoneState();
        undoneCommands = undoneState;
        Console.WriteLine("State restored.");
    }
}
