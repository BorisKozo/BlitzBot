using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejeweledBlitzBot
{
  public struct ClickMove : IEquatable<ClickMove>, IComparable<ClickMove>
  {
    public float Rating { get; set; }
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
      Rating = 0;
    }

    public override bool Equals(object obj)
    {
      if (obj is ClickMove)
      {
        ClickMove other = (ClickMove)obj;
        return this.Equals(other);
      }

      return false;
    }

    public override int GetHashCode()
    {
      return FromColumn.GetHashCode() ^ ToColumn.GetHashCode() ^ FromRow.GetHashCode() ^ ToRow.GetHashCode();
    }

    public override string ToString()
    {
      return String.Format("({0},{1})->({2},{3})",FromColumn,FromRow,ToColumn,ToRow);
    }

    public ClickMove Flipped
    {
      get
      {
        return new ClickMove(ToColumn, ToRow, FromColumn, FromRow);
      }
    }
    public bool Equals(ClickMove other)
    {
      if (other.FromColumn == FromColumn && other.FromRow == FromRow)
        return true;

      if (other.FromColumn == ToColumn && other.FromRow == ToRow)
        return true;

      if (other.ToColumn == FromColumn && other.ToRow == FromRow)
        return true;

      if (other.ToColumn == ToColumn && other.ToRow == ToRow)
        return true;

      return false;

    }

    public int CompareTo(ClickMove other)
    {
      return Rating.CompareTo(other.Rating);
    }
  }
}
