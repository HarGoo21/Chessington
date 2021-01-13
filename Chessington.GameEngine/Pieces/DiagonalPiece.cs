using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public static class DiagonalPiece
    {
        public static IEnumerable<Square> GetDiagonalMoves(Square square, Board board)
        {
            var availableMoves = new List<Square>();
            for (var i = 0; i < GameSettings.BoardSize; i++)
            {
                availableMoves.Add(Square.At(i, i));
            }

            for (var i = 1; i < GameSettings.BoardSize; i++)
            {
                availableMoves.Add(Square.At(i, GameSettings.BoardSize - i));
            }

            availableMoves.RemoveAll(s => s == Square.At(square.Row, square.Col));
            return availableMoves;
        }
    }
}