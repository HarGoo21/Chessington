using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            return new List<Square> {Square.At(3,2), Square.At(3,6), Square.At(2,3), Square.At(2,5),
                Square.At(5,2), Square.At(5, 6), Square.At(6,3), Square.At(6,5)};
        }
    }
}