using System;
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
            var availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            var knightMoves = new List<(int, int)>() {
                (1, 2), (1,-2), (-1, 2), (-1, -2), (2, 1), (2, -1), (-2, 1), (-2, -1)
            };
            

            foreach (var (item1, item2) in knightMoves)
            {
                if (Enumerable.Range(0, GameSettings.BoardSize).Contains(currentSquare.Row + item1) &&
                    Enumerable.Range(0, GameSettings.BoardSize).Contains(currentSquare.Col + item2))
                {
                    availableMoves.Add(Square.At(currentSquare.Row + item1, currentSquare.Col + item2));
                }
            }

            return availableMoves;
        }
    }
}