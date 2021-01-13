using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public static class DiagonalPiece
    {
        public static IEnumerable<Square> GetDiagonalMoves(Square square, Board board)
        {
            var availableMoves = new List<Square>();

            var rowcolDelta = square.Row - square.Col;
            var downDiagClear = true;

            if (rowcolDelta >= 0)
            {
                for (var i = 0; i < GameSettings.BoardSize - rowcolDelta; i++)
                {
                    if (board.GetPiece(Square.At(i + rowcolDelta, i)) != null &&
                        board.GetPiece(Square.At(i + rowcolDelta, i)) != board.GetPiece(square))
                    {
                        if (i < square.Col)
                        {
                            for (var j = 0; j < i; j++)
                            {
                                availableMoves.Remove(Square.At(j + rowcolDelta, j));
                            }
                        }
                        else
                        {
                            downDiagClear = false;
                            availableMoves.Add(Square.At(i + rowcolDelta, i));
                        }
                    }

                    if (downDiagClear)
                    {
                        availableMoves.Add(Square.At(i + rowcolDelta, i));
                    }
                }
            }
            else
            {
                for (var i = 0; i < GameSettings.BoardSize + rowcolDelta; i++)
                {
                    if (board.GetPiece(Square.At(i, i - rowcolDelta)) != null &&
                        board.GetPiece(Square.At(i, i - rowcolDelta)) != board.GetPiece(square))
                    {
                        if (i < square.Row)
                        {
                            for (var j = 0; j < i; j++)
                            {
                                availableMoves.Remove(Square.At(j, j - rowcolDelta));
                            }
                        }
                        else
                        {
                            {
                                downDiagClear = false;
                                availableMoves.Add(Square.At(i, i - rowcolDelta));
                            }
                        }
                    }

                    if (downDiagClear)
                    {
                        availableMoves.Add(Square.At(i, i - rowcolDelta));
                    }
                }
            }

            var rowcolSum = square.Row + square.Col;
            var upDiagClear = true;

            if (rowcolSum >= GameSettings.BoardSize - 1)
            {
                for (var i = rowcolSum - (GameSettings.BoardSize - 1); i < GameSettings.BoardSize; i++)
                {
                    if (board.GetPiece(Square.At(rowcolSum - i, i)) != null &&
                        board.GetPiece(Square.At(rowcolSum - i, i)) != board.GetPiece(square))
                    {
                        if (i < square.Col)
                        {
                            for (var j = 0; j < i; j++)
                            {
                                availableMoves.Remove(Square.At(rowcolSum - j, j));
                            }
                        }
                        else
                        {
                            upDiagClear = false;
                            availableMoves.Add(Square.At(rowcolSum - i, i));
                        }
                    }

                    if (upDiagClear)
                    {
                        availableMoves.Add(Square.At(rowcolSum - i, i));
                    }
                }
            }
            else
            {
                for (var i = 0; i < rowcolSum + 1; i++)
                {
                    if (board.GetPiece(Square.At(rowcolSum - i, i)) != null &&
                        board.GetPiece(Square.At(rowcolSum - i, i)) != board.GetPiece(square))
                    {
                        if (i < square.Col)
                        {
                            for (var j = 0; j < i; j++)
                            {
                                availableMoves.Remove(Square.At(rowcolSum - j, j));
                            }
                        }
                        else
                        {
                            upDiagClear = false;
                            availableMoves.Add(Square.At(rowcolSum - i, i));
                        }
                    }

                    if (upDiagClear)
                    {
                        availableMoves.Add(Square.At(rowcolSum - i, i));
                    }
                }
            }

            availableMoves.RemoveAll(s => s == Square.At(square.Row, square.Col));
            
            return availableMoves;
        }
    }
}