using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            return new List<Square>
            {
                Square.At(3,3), Square.At(3,4), Square.At(3,5), Square.At(4,3),
                Square.At(4,5), Square.At(5,3), Square.At(5,4), Square.At(5,5)
            };
        }
    }
}