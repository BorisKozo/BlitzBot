using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejeweledBlitzBot
{
  internal enum ShapeType
  { Triangle, Square, Rhombus, Diamond, Hexagon, Octagon, Circle, Special };

  internal enum SpecialType
  { None, Flame, Light, Lightning }

  internal class Shape
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


  }
}
