using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public List<Square> movesToTake(Player player, Square square, Board board)
        {
            var takingMoves = new List<Square>();
            if (player == Player.White)
            {
                if (square.Col < 7)
                {
                    if(board.GetPiece(Square.At(square.Row - 1, square.Col + 1)) != null)
                    {
                        if (board.GetPiece(Square.At(square.Row - 1, square.Col + 1)).Player == Player.Black)
                        {
                            takingMoves.Add(Square.At(square.Row - 1, square.Col + 1));
                        }
                            
                    }
                }
                if (square.Col > 0)
                {
                    if(board.GetPiece(Square.At(square.Row - 1, square.Col - 1)) != null)
                    {
                        if (board.GetPiece(Square.At(square.Row - 1, square.Col - 1)).Player == Player.Black)
                        {
                            takingMoves.Add(Square.At(square.Row - 1, square.Col - 1));
                        }
                        
                    }
                }
            }
            else
            {
                if (square.Col < 7)
                {
                    if(board.GetPiece(Square.At(square.Row + 1, square.Col + 1)) != null)
                    {
                        if (board.GetPiece(Square.At(square.Row + 1, square.Col + 1)).Player == Player.White)
                        {
                            takingMoves.Add(Square.At(square.Row + 1, square.Col + 1));
                        }
                        
                    }
                }
                if (square.Col > 0)
                {
                    if(board.GetPiece(Square.At(square.Row + 1, square.Col - 1)) != null)
                    {
                        if (board.GetPiece(Square.At(square.Row + 1, square.Col - 1)).Player == Player.White)
                        {
                            takingMoves.Add(Square.At(square.Row + 1, square.Col - 1));
                        }
                        
                    }
                }
            }

            return takingMoves;
        }
        

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
                    var availableMoves = new List<Square> {Square.At(currentSquare.Row - 2, currentSquare.Col), Square.At(currentSquare.Row - 1, currentSquare.Col)};
                    availableMoves.AddRange(movesToTake(this.Player, currentSquare, board));
                    return availableMoves;
                }
                else if (board.GetPiece(Square.At(currentSquare.Row - 1, currentSquare.Col)) == null)
                {
                    var availableMoves = new List<Square> {Square.At(currentSquare.Row - 1, currentSquare.Col)};
                    availableMoves.AddRange(movesToTake(this.Player, currentSquare, board));
                    return availableMoves;
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
                    var availableMoves = new List<Square> {Square.At(currentSquare.Row + 2, currentSquare.Col), Square.At(currentSquare.Row + 1, currentSquare.Col)};
                    availableMoves.AddRange(movesToTake(this.Player, currentSquare, board));
                    return availableMoves;
                }
                else if (board.GetPiece(Square.At(currentSquare.Row + 1, currentSquare.Col)) == null)
                {
                    var availableMoves = new List<Square> {Square.At(currentSquare.Row + 1, currentSquare.Col)};
                    availableMoves.AddRange(movesToTake(this.Player, currentSquare, board));
                    return availableMoves;
                }
                    
                
            }

            return new List<Square>();
        }
    }
}