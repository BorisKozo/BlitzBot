using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejeweledBlitzBot
{

  //Color map
  //Circle - Color [A=255, R=235, G=235, B=235]
  //triangle - Color [A=255, R=223, G=49, B=223]

  /// <summary>
  /// This class is responsible for transforming an image into a grid of values.
  /// </summary>
  internal class Analyzer
  {

    private Size _squareCount;
    private int _sampleSize;
    private Size _boardSize;
    private Size _squareSize;


    private Size _sampleOffset;
    private int _sampleSizeSquared;

    private Stopwatch _stopWatch;

    public Analyzer(Size squareCount, int sampleSize, Size boardSize)
    {
      _squareCount = squareCount;
      _sampleSize = sampleSize;
      _sampleSizeSquared = sampleSize * sampleSize;
      _boardSize = boardSize;
      _squareSize = new Size(boardSize.Width / squareCount.Width, boardSize.Height / squareCount.Height);
      _sampleOffset = new Size((_squareSize.Width - sampleSize) / 2, (_squareSize.Height - sampleSize) / 2);
      _stopWatch = new Stopwatch();
    }


    public Shape[,] GetGridData(Bitmap image, Graphics graphics)
    {
      _stopWatch.Restart();
      Shape[,] result = new Shape[_squareCount.Width, _squareCount.Height];
      for (int i = 0; i < _squareCount.Width; i++)
      {
        for (int j = 0; j < _squareCount.Height; j++)
        {
          int squareLeft = i * SquareSize.Width;
          int squareTop = j * SquareSize.Height;
          int whiteCount = 0;
          int blackCount = 0;
          if (IsMultiplier(squareLeft, squareTop, image))
          {
            Color multiplierColor = GetMultiplierColor(squareLeft, squareTop, image);
            graphics.FillRectangle(new SolidBrush(multiplierColor), new Rectangle(squareLeft, squareTop, SquareSize.Width, SquareSize.Height));
            Shape shape = FromMultiplierColor(multiplierColor);
            result[i, j] = shape;
            if (shape.Type == ShapeType.Unknown)
            {
              Console.Out.WriteLine(String.Format("Multiplier at - {0} {1}", i, j));
              Console.Out.WriteLine(String.Format("Type {0} Color {1} {2} {3}", shape.Type, multiplierColor.R, multiplierColor.G, multiplierColor.B));
            }
          }
          else
          {
            Color tempColor = GetAverageColor(squareLeft, squareTop, image, out whiteCount, out blackCount);
            graphics.FillRectangle(new SolidBrush(tempColor), new Rectangle(squareLeft, squareTop, SquareSize.Width, SquareSize.Height));
            Shape shape = FromColor(tempColor);
            result[i, j] = shape;
          }
        }
      }

      _stopWatch.Stop();
      //Console.Out.WriteLine("Get data time " + _stopWatch.ElapsedMilliseconds);
      return result;
    }

    private Shape FromMultiplierColor(Color color)
    {
      if (L(color.R, 164) && L(color.G, 15) && L(color.B, 165))
        return new Shape(ShapeType.Triangle, SpecialType.Multiplier);

      if (L(color.R, 211) && L(color.G, 13) && L(color.B, 25))
        return new Shape(ShapeType.Square, SpecialType.Multiplier);

      if (L(color.R, 191) && L(color.G, 11) && L(color.B, 22))
        return new Shape(ShapeType.Square, SpecialType.Multiplier);


      if (L(color.R, 11) && L(color.G, 115) && L(color.B, 208))
        return new Shape(ShapeType.Diamond, SpecialType.Multiplier);

      if (L(color.R, 183) && L(color.G, 181) && L(color.B, 0))
        return new Shape(ShapeType.Rhombus, SpecialType.Multiplier);

      if (L(color.R, 208) && L(color.G, 93) && L(color.B, 18))
        return new Shape(ShapeType.Hexagon, SpecialType.Multiplier);

      if (L(color.R, 0) && L(color.G, 148) && L(color.B, 8))
        return new Shape(ShapeType.Octagon, SpecialType.Multiplier);

      if (L(color.R, 157) && L(color.G, 157) && L(color.B, 157))
        return new Shape(ShapeType.Circle, SpecialType.Multiplier);


      return new Shape(ShapeType.Unknown);
    }

    private Color GetMultiplierColor(int squareLeft, int squareTop, Bitmap image)
    {
      return image.GetPixel(squareLeft + 9, squareTop + + 20);
    }

    private bool IsMultiplier(int squareLeft, int squareTop, Bitmap image)
    {
      Color tempColor = Color.Wheat;
      int innerOffsetX = 12;
      int innerOffsetY = 18;
      bool result = true;
      for (int i = 0; i < 3 && result; i++)
      {
        for (int j = 0; j < 3 && result; j++)
        {
          tempColor = image.GetPixel(squareLeft +  innerOffsetX + i, squareTop + innerOffsetY + j);
          if (tempColor.R != 255 || tempColor.G != 255 || tempColor.B != 255)
            result = false;
        }
      }

      return result;
    }

    private Color GetAverageColor(int left, int top, Bitmap image, out int whiteCount, out int blackCount)
    {
      Dictionary<Color, int> result = new Dictionary<Color, int>();
      int r = 0;
      int g = 0;
      int b = 0;
      whiteCount = 0;
      blackCount = 0;
      int count = 0;
      for (int i = 0; i < _sampleSize; i++)
      {
        for (int j = 0; j < _sampleSize; j++)
        {
          Color tempColor = image.GetPixel(left + _sampleOffset.Width + i, top + _sampleOffset.Height + j);
          
          //This is to avoid counting numbers in multipliers
          if (tempColor.R == 255 && tempColor.G == 255 && tempColor.B == 255)
          {
            whiteCount++;
            continue;
          }

          if (tempColor.R == 0 && tempColor.G == 0 && tempColor.B == 0)
          {
            blackCount++;
            continue;
          }

          count++;
          if (result.ContainsKey(tempColor))
            result[tempColor] = result[tempColor] + 1;
          else
            result.Add(tempColor, 1);
          r += tempColor.R;
          g += tempColor.G;
          b += tempColor.B;
        }
      }

      if (count == 0)
        return Color.FromArgb(0);
      return Color.FromArgb(r / count, g / count, b / count);

    }

    private bool L(byte a, byte b)
    {
      return Math.Abs(Convert.ToInt32(a) - Convert.ToInt32(b)) < 15;
    }

    private Shape FromColor(Color color)
    {

      if (L(color.R, 227) && L(color.G, 37) && L(color.B, 227))
        return new Shape(ShapeType.Triangle);

      if (L(color.R, 246) && L(color.G, 26) && L(color.B, 55))
        return new Shape(ShapeType.Square);

      if (L(color.R, 10) && L(color.G, 121) && L(color.B, 235))
        return new Shape(ShapeType.Diamond);

      if (L(color.R, 251) && L(color.G, 231) && L(color.B, 31))
        return new Shape(ShapeType.Rhombus);

      if (L(color.R, 243) && L(color.G, 146) && L(color.B, 54))
        return new Shape(ShapeType.Hexagon);

      if (L(color.R, 33) && L(color.G, 206) && L(color.B, 62))
        return new Shape(ShapeType.Octagon);

      if (L(color.R, 225) && L(color.G, 225) && L(color.B, 225))
        return new Shape(ShapeType.Circle);

      if (L(color.R, 197) && L(color.G, 160) && L(color.B, 38))
        return new Shape(ShapeType.Rhombus,SpecialType.Coin);

      if (L(color.R, 150) && L(color.G, 150) && L(color.B, 100))
        return new Shape(ShapeType.Special,SpecialType.Lightning);

      return new Shape(ShapeType.Unknown);
    }

    public Size BoardSize
    {
      get { return _boardSize; }
    }

    public Size SquareSize
    {
      get { return _squareSize; }
    }

  }
}
