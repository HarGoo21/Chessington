using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public static class LateralPiece
    {
        public static IEnumerable<Square> GetLateralMoves(Square square)
        {
            var movesAvailable = new List<Square>();
            for (var i = 0; i < GameSettings.BoardSize; i++)
            {
                movesAvailable.Add(Square.At(i, square.Col));
                movesAvailable.Add(Square.At(square.Row,i));
            }
            
            movesAvailable.RemoveAll(s => s == square);

            return movesAvailable;
        }
    }
}