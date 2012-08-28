using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejeweledBlitzBot.Rules
{
  public abstract class BaseRule
  {
    public abstract List<ClickMove> GetMoves(Shape[,] board);

    protected float RateMove(Shape[,] board, Shape target, int column, int row)
    {
      int columnCount = board.GetLength(0);
      int rowCount = board.GetLength(1);

      bool isVertical3_1 = false;
      if (row > 1 && (board[column, row - 2] == board[column, row - 1] && board[column, row - 1] == target))
        isVertical3_1 = true;

      bool isVertical3_2 = false;
      if ((row > 0 && row < rowCount - 1) && (board[column, row - 1] == target && target == board[column, row + 1]))
        isVertical3_2 = true;

      bool isVertical3_3 = false;
      if ((row < rowCount - 2) && (target == board[column, row + 1] && board[column, row + 1] == board[column, row + 2]))
        isVertical3_3 = true;

      if (isVertical3_1 || isVertical3_2 || isVertical3_3)
        return 1;

      bool isHorizontal3_1 = false;
      if (column > 1 && (board[column - 2, row] == board[column - 1, row] && board[column - 1, row] == target))
        isHorizontal3_1 = true;

      bool isHorizontal3_2 = false;
      if ((column > 0 && column < columnCount - 1) && (board[column - 1, row] == target && target == board[column + 1, row]))
        isHorizontal3_2 = true;

      bool isHorizontal3_3 = false;
      if ((column < columnCount - 2) && (target == board[column + 1, row] && board[column + 1, row] == board[column + 2, row]))
        isHorizontal3_3 = true;

      if (isHorizontal3_1 || isHorizontal3_2 || isHorizontal3_3)
        return 1;

      return 0;
    }
  }
}
