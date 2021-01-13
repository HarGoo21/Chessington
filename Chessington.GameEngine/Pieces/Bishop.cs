using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMoves = new List<Square>();
            for (var i = 0; i < GameSettings.BoardSize; i++)
            {
                availableMoves.Add(Square.At(i, i));
            }

            for (var i = 1; i < GameSettings.BoardSize; i++)
            {
                availableMoves.Add(Square.At(i, GameSettings.BoardSize - i));
            }

            availableMoves.RemoveAll(s => s == Square.At(currentSquare.Row, currentSquare.Col));
            return availableMoves;
        }
    }
}