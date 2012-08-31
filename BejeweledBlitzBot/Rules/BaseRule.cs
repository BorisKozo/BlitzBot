using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejeweledBlitzBot.Rules
{
  public abstract class BaseRule
  {
    public abstract HashSet<ClickMove> GetMoves(Shape[,] board);

    private void Swap(Shape[,] board, ClickMove move)
    {
      Shape temp = board[move.ToColumn, move.ToRow];
      board[move.ToColumn, move.ToRow] = board[move.FromColumn, move.FromRow];
      board[move.FromColumn, move.FromRow] = temp;
    }

    protected float RateMove(Shape[,]  board, ClickMove testMove)
    {
      
      int columnCount = board.GetLength(0);
      int rowCount = board.GetLength(1);
      Shape target = board[testMove.FromColumn, testMove.FromRow];
      Swap(board, testMove);
      try
      {
        bool isVertical3_1 = false;
        if (testMove.ToRow > 1 && (board[testMove.ToColumn, testMove.ToRow - 2] == board[testMove.ToColumn, testMove.ToRow - 1] && board[testMove.ToColumn, testMove.ToRow - 1] == target))
          isVertical3_1 = true;

        bool isVertical3_2 = false;
        if ((testMove.ToRow > 0 && testMove.ToRow < rowCount - 1) && (board[testMove.ToColumn, testMove.ToRow - 1] == target && target == board[testMove.ToColumn, testMove.ToRow + 1]))
          isVertical3_2 = true;

        bool isVertical3_3 = false;
        if ((testMove.ToRow < rowCount - 2) && (target == board[testMove.ToColumn, testMove.ToRow + 1] && board[testMove.ToColumn, testMove.ToRow + 1] == board[testMove.ToColumn, testMove.ToRow + 2]))
          isVertical3_3 = true;

        if (isVertical3_1 || isVertical3_2 || isVertical3_3)
          return 1;

        bool isHorizontal3_1 = false;
        if (testMove.ToColumn > 1 && (board[testMove.ToColumn - 2, testMove.ToRow] == board[testMove.ToColumn - 1, testMove.ToRow] && board[testMove.ToColumn - 1, testMove.ToRow] == target))
          isHorizontal3_1 = true;

        bool isHorizontal3_2 = false;
        if ((testMove.ToColumn > 0 && testMove.ToColumn < columnCount - 1) && (board[testMove.ToColumn - 1, testMove.ToRow] == target && target == board[testMove.ToColumn + 1, testMove.ToRow]))
          isHorizontal3_2 = true;

        bool isHorizontal3_3 = false;
        if ((testMove.ToColumn < columnCount - 2) && (target == board[testMove.ToColumn + 1, testMove.ToRow] && board[testMove.ToColumn + 1, testMove.ToRow] == board[testMove.ToColumn + 2, testMove.ToRow]))
          isHorizontal3_3 = true;

        if (isHorizontal3_1 || isHorizontal3_2 || isHorizontal3_3)
          return 1;

        return 0;
      }
      finally
      {
        Swap(board, testMove.Flipped);
      }
    }
  }
}
