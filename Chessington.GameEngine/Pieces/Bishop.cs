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
            availableMoves.AddRange(DiagonalPiece.GetDiagonalMoves(currentSquare, board));
            var invalidMoves = NotPawn.TakeOnlyOpponent(availableMoves, board);
            foreach (var move in invalidMoves)
            {
                availableMoves.Remove(move);
            }
            return availableMoves;
        }
    }
}