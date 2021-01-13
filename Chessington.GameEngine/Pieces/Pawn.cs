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
                if (currentSquare.Row == 0)
                {
                    return new List<Square>();
                }
                else if (currentSquare.Row == 7 && board.GetPiece(Square.At(5, currentSquare.Col)) == null && board.GetPiece(Square.At(6, currentSquare.Col)) == null)
                {
                    return new List<Square> {Square.At(currentSquare.Row - 2, currentSquare.Col), Square.At(currentSquare.Row - 1, currentSquare.Col)};
                }
                else if (board.GetPiece(Square.At(currentSquare.Row - 1, currentSquare.Col)) == null)
                {
                    return new List<Square> {Square.At(currentSquare.Row - 1, currentSquare.Col)};
                }
            }
            else
            {
                if (currentSquare.Row == 7)
                {
                    return new List<Square>();
                }
                else if (currentSquare.Row == 1 && board.GetPiece(Square.At(3, currentSquare.Col)) == null && board.GetPiece(Square.At(2, currentSquare.Col)) == null)
                {
                    return new List<Square> {Square.At(currentSquare.Row + 2, currentSquare.Col), Square.At(currentSquare.Row + 1, currentSquare.Col)};
                }
                else if (board.GetPiece(Square.At(currentSquare.Row + 1, currentSquare.Col)) == null)
                {
                    return new List<Square> {Square.At(currentSquare.Row + 1, currentSquare.Col)};
                }
                    
                
            }

            return new List<Square>();
        }
    }
}