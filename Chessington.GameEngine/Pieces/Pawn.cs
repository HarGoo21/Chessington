using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            if (this.Player == Player.White)
            {
                if (currentSquare.Row == 7)
                {
                    return new List<Square> {Square.At(currentSquare.Row - 2, currentSquare.Col), Square.At(currentSquare.Row - 1, currentSquare.Col)};
                }
                else
                {
                    return new List<Square> {Square.At(currentSquare.Row - 1, currentSquare.Col)};
                }
            }
            else
            {
                if (currentSquare.Row == 1)
                {
                    return new List<Square> {Square.At(currentSquare.Row + 2, currentSquare.Col), Square.At(currentSquare.Row + 1, currentSquare.Col)};
                }
                else
                {
                    return new List<Square> {Square.At(currentSquare.Row + 1, currentSquare.Col)};
                }
                    
                
            }
            return new List<Square> {Square.At(6, 0), Square.At(2, 0)};
        }
    }
}