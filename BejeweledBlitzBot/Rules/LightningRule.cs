using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejeweledBlitzBot.Rules
{
  public class LightningRule:BaseRule
  {
    public override HashSet<ClickMove> GetMoves(Shape[,] board)
    {
      int columnCount = board.GetLength(0);
      int rowCount = board.GetLength(1);
      int totalSize = rowCount * columnCount;
      HashSet<ClickMove> result = new HashSet<ClickMove>();

      for (int j = rowCount - 1; j >= 0; j--)
      {
        for (int i = columnCount - 1; i >= 0; i--)
        {
          if (board[i, j].Type == ShapeType.Special && board[i, j].Special == SpecialType.Lightning)
          {
            ShapeType maxShape = GetMaxShape(board);
            Point maxShapePosition = GetMaxShapePosition(board, maxShape);
            result.Add(new ClickMove(i,j,maxShapePosition.X, maxShapePosition.Y));
            return result;
          }
        }
      }
      return result;
    }

    private Point GetMaxShapePosition(Shape[,] board, ShapeType maxShape)
    {
      int columnCount = board.GetLength(0);
      int rowCount = board.GetLength(1);
      

      for (int j = rowCount - 1; j >= 0; j--)
      {
        for (int i = columnCount - 1; i >= 0; i--)
        {
          if (board[i, j].Type == maxShape)
            return new Point(i, j);
        }
      }

      return new Point();

    }

    private ShapeType GetMaxShape(Shape[,] board)
    {
      Dictionary<ShapeType, int> data = new Dictionary<ShapeType,int>();
      int columnCount = board.GetLength(0);
      int rowCount = board.GetLength(1);

      for (int j = rowCount - 1; j >= 0; j--)
      {
        for (int i = columnCount - 1; i >= 0; i--)
        {
          if (data.ContainsKey(board[i, j].Type))
            data[board[i, j].Type] += 1;
          else
            data.Add(board[i, j].Type, 1);
        }
      }

      int max = 0;
      ShapeType result = ShapeType.Unknown;
      foreach (ShapeType key in data.Keys)
      {
        if (data[key] > max)
        {
          result = key;
          max = data[key];
        }
      }

      return result;

    }
  }
}
