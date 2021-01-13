using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public static class LateralPiece
    {
        public static IEnumerable<Square> GetLateralMoves(Square square, Board board)
        {
            var movesAvailable = new List<Square>();
            var rowsFlag = true;
            var colsFlag = true;
            for (var i = 0; i < GameSettings.BoardSize; i++)
            {
                if (board.GetPiece(Square.At(i, square.Col)) != null &&
                    board.GetPiece(Square.At(i, square.Col)) != board.GetPiece(square))
                {
                    if (i < square.Row)
                    {
                        for (var j = 0; j < i; j++)
                        {
                            movesAvailable.Remove(Square.At(j, square.Col));
                        }

                        if (board.GetPiece(Square.At(i, square.Col)).Player == board.CurrentPlayer)
                        {
                            rowsFlag = false;
                        }
                    }
                    else
                    {
                        
                        if (board.GetPiece(Square.At(i, square.Col)).Player != board.CurrentPlayer && rowsFlag == true)
                        {
                            movesAvailable.Add(Square.At(i, square.Col));
                        }
                        rowsFlag = false;
                    }
                }

                if (rowsFlag)
                {
                    movesAvailable.Add(Square.At(i, square.Col));
                }
                else if (i < square.Row)
                {
                    rowsFlag = true;
                }


                if (board.GetPiece(Square.At(square.Row, i)) != null &&
                        board.GetPiece(Square.At(square.Row, i)) != board.GetPiece(square))
                {
                    if (i < square.Col)
                    {
                        for (var j = 0; j < i; j++)
                        {
                            movesAvailable.Remove(Square.At(square.Row, j));
                        }

                        if (board.GetPiece(Square.At(square.Row, i)).Player == board.CurrentPlayer)
                        {
                            colsFlag = false;
                        }
                    }
                    else
                    {
                        if (board.GetPiece(Square.At(square.Row, i)).Player != board.CurrentPlayer && colsFlag == true)
                        {
                            movesAvailable.Add(Square.At(square.Row, i));
                        }
                        colsFlag = false;
                    }
                    
                }
                
                if (colsFlag)
                {
                    movesAvailable.Add(Square.At(square.Row, i));

                    if (i < square.Col)
                    {
                        colsFlag = true;
                    }
                }
            }
            
            movesAvailable.RemoveAll(s => s == square);

            return movesAvailable;
        }
    }
}