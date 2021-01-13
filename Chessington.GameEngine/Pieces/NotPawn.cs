using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public static class NotPawn
    {

        public static IEnumerable<Square> TakeOnlyOpponent(List<Square> availableMoves, Board board)
        {
            var invalidAvailableMoves = new List<Square>();
            foreach (var move in availableMoves)
            {
                if (board.GetPiece(move) != null)
                {
                    if (board.GetPiece(move).Player == board.CurrentPlayer)
                    {
                        invalidAvailableMoves.Add(move); 
                    }
                    
                }
            }

            return invalidAvailableMoves;
        }
    }
}