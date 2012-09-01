using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejeweledBlitzBot
{
  public enum ShapeType
  { Triangle, Square, Rhombus, Diamond, Hexagon, Octagon, Circle, Special, Unknown };

  public enum SpecialType
  { None, Flame, Light, Lightning, Coin }

  public class Shape
  {
    private ShapeType _type;
    private SpecialType _special;

    public Shape(ShapeType type, SpecialType special = SpecialType.None)
    {
      _type = type;
      _special = special;
    }

    public ShapeType Type
    {
      get { return _type; }
    }

    internal SpecialType Special
    {
      get { return _special; }
    }

    public override int GetHashCode()
    {
      return _type.GetHashCode();
    }

    public override bool Equals(object obj)
    {
      if (obj is Shape)
      {
        if (_type == ShapeType.Unknown || ((Shape)obj)._type == ShapeType.Unknown)
          return false;
        return _type == ((Shape)obj)._type;
      }
      return false;
    }

    public static bool operator ==(Shape first, Shape second)
    {
      if (((object)first) == null && (((object)second) == null))
       return true;
      if (((object)first) == null)
        return false;
      if (((object)second) == null)
        return false;

      if (first.Type == ShapeType.Unknown || second.Type == ShapeType.Unknown)
        return false;
      return first.Type == second.Type;
    }

    public static bool operator !=(Shape first, Shape second)
    {
      return !(first == second);
    }



  }
}
