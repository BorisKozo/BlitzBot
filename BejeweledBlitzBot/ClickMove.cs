using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejeweledBlitzBot
{
  public struct ClickMove
  {
    public int FromColumn { get; set; }
    public int FromRow { get; set; }
    public int ToColumn { get; set; }
    public int ToRow { get; set; }

    public ClickMove(int fromColumn, int fromRow, int toColumn, int toRow):this()
    {
      FromColumn = fromColumn;
      FromRow = fromRow;
      ToColumn = toColumn;
      ToRow = toRow;
    }

  }
}
