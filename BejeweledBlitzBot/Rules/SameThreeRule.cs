using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejeweledBlitzBot.Rules
{
  public class SameThreeRule:BaseRule
  {
    public override List<ClickMove> GetMoves(Shape[,] board)
    {
      int columnCount = board.GetLength(0);
      int rowCount = board.GetLength(1);
      int totalSize = rowCount * columnCount;
      List<ClickMove> result = new List<ClickMove>();

      for (int j = rowCount - 1; j >= 0; j--)
      {
        for (int i = columnCount - 1; i >= 0; i--)
        {
          
          if (i < columnCount - 1)
          {
            float right = RateMove(board, board[i + 1, j], i, j);
            if (right > 0)
              result.Add(new ClickMove(i, j, i + 1, j));
          }

          if (i > 0)
          {
            float left = RateMove(board, board[i -1, j], i, j);
            if (left > 0)
              result.Add(new ClickMove(i, j, i - 1, j));
          }

          if (j < rowCount - 1)
          {
            float down = RateMove(board, board[i, j+1], i, j);
            if (down > 0)
              result.Add(new ClickMove(i, j, i, j+1));
          }

          if (j > 0)
          {
            float up = RateMove(board, board[i, j - 1], i, j);
            if (up > 0)
              result.Add(new ClickMove(i, j, i, j - 1));
          }

        }
      }

      return result;

    }
  }
}
