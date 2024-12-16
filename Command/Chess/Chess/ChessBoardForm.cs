namespace Chess
{
    public partial class ChessBoardForm : Form
    {
        private CommandManager commandManager = new CommandManager();

        private readonly ChessBoard board; // Instancja szachownicy
        private const string defaultNotation = @"
            ra8 nb8 bc8 qd8 ke8 bf8 ng8 rh8
            pa7 pb7 pc7 pd7 pe7 pf7 pg7 ph7
            Pa2 Pb2 Pc2 Pd2 Pe2 Pf2 Pg2 Ph2
            Ra1 Nb1 Bc1 Qd1 Ke1 Bf1 Ng1 Rh1
        ";
        public ChessBoardForm()
        {
            InitializeComponent();

            // Tworzenie i inicjalizacja szachownicy
            board = new ChessBoard(commandManager);
            board.InitializeFromString(defaultNotation);

            // Przekazanie szachownicy do wyświetlającej ją kontrolki
            chessBoardControl.ChessBoard = board;
            chessBoardControl.CommandManager = commandManager;

        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            commandManager.Undo();
            chessBoardControl.Invalidate();
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            commandManager.Redo();
            chessBoardControl.Invalidate();
        }

        private void replayButton_Click(object sender, EventArgs e)
        {
            commandManager.Replay(chessBoardControl);
            chessBoardControl.Invalidate();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            board.InitializeFromString(defaultNotation);
            commandManager = new CommandManager();
            chessBoardControl.CommandManager = commandManager;
            chessBoardControl.Invalidate();
        }
    }
}
