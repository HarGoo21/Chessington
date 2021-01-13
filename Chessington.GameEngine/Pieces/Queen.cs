using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMoves = new List<Square>();

            availableMoves.AddRange(LateralPiece.GetLateralMoves(currentSquare));
            availableMoves.AddRange(DiagonalPiece.GetDiagonalMoves(currentSquare));
            
            return availableMoves;
        }
    }
}