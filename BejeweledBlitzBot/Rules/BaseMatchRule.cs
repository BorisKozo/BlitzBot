using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejeweledBlitzBot.Rules
{
  public abstract class BaseMatchRule : BaseRule
  {
    public HashSet<ClickMove> GetMoves(Shape[,] board, Func<Shape[,],int,int,bool> predicate)
    {
      int columnCount = board.GetLength(0);
      int rowCount = board.GetLength(1);
      int totalSize = rowCount * columnCount;
      HashSet<ClickMove> result = new HashSet<ClickMove>();

      for (int j = rowCount - 1; j >= 0; j--)
      {
        for (int i = columnCount - 1; i >= 0; i--)
        {
          if (!predicate(board, i, j))
            continue;
          if (i < columnCount - 1)
          {
            ClickMove rightMove = new ClickMove(i + 1, j, i, j);
            float right = RateMove(board, rightMove);

            if (right > 0 && !result.Contains(rightMove))
            {
              rightMove.Rating = right;
              result.Add(rightMove);
            }
          }

          if (i > 0)
          {
            ClickMove leftMove = new ClickMove(i - 1, j, i, j);
            float left = RateMove(board, leftMove);
            if (left > 0 && !result.Contains(leftMove))
            {
              leftMove.Rating = left;
              result.Add(leftMove);
            }
          }

          if (j < rowCount - 1)
          {
            ClickMove downMove = new ClickMove(i, j + 1, i, j);
            float down = RateMove(board, downMove);
            if (down > 0 && !result.Contains(downMove))
            {
              downMove.Rating = down;
              result.Add(downMove);
            }
          }

          if (j > 0)
          {
            ClickMove upMove = new ClickMove(i, j - 1, i, j);
            float up = RateMove(board, upMove);
            if (up > 0 && !result.Contains(upMove))
            {
              upMove.Rating = up;
              result.Add(upMove);
            }
          }

        }
      }

      return result;

    }

  }
}
