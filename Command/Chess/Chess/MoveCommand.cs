using Chess;

public class MoveCommand : ICommand
{


    public int StartCol { get; set; }
    public int EndCol { get; set; }
    public int StartRow { get; set; }
    public int EndRow { get; set; }
    public ChessPiece ChessPiece { get; set; }
    public required ChessBoard ChessBoard { get; set; }

    public bool Execute()
    {
        ChessPiece = ChessBoard.GetPiece(EndRow, EndCol);
        return ChessBoard.MovePiece(StartRow, StartCol, EndRow, EndCol);

    }

    public void Undo()
    {
        ChessBoard.MovePiece(EndRow, EndCol, StartRow, StartCol);
        ChessBoard.SetPiece(EndRow, EndCol, ChessPiece);
    }

}