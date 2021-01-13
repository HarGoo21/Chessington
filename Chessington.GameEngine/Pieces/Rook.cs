using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var movesAvailable = new List<Square>();
            for (var i = 0; i < GameSettings.BoardSize; i++)
            {
                movesAvailable.Add(Square.At(4,i));
                movesAvailable.Add(Square.At(i,4));
            }

            return movesAvailable;
        }
    }
}