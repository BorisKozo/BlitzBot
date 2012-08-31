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
          Color tempColor = GetAverageColor(squareLeft, squareTop, image);
          graphics.FillRectangle(new SolidBrush(tempColor), new Rectangle(squareLeft, squareTop, SquareSize.Width, SquareSize.Height));
          result[i, j] = FromColor(tempColor);
        }
      }

      _stopWatch.Stop();
      Console.Out.WriteLine("Get data time " + _stopWatch.ElapsedMilliseconds);
      return result;
    }

    private Color GetAverageColor(int left, int top, Bitmap image)
    {
      Dictionary<Color, int> result = new Dictionary<Color, int>();
      int r = 0;
      int g = 0;
      int b = 0;
      for (int i = 0; i < _sampleSize; i++)
      {
        for (int j = 0; j < _sampleSize; j++)
        {
          Color tempColor = image.GetPixel(left + _sampleOffset.Width + i, top + _sampleOffset.Height + j);
          if (result.ContainsKey(tempColor))
            result[tempColor] = result[tempColor] + 1;
          else
            result.Add(tempColor, 1);
          r += tempColor.R;
          g += tempColor.G;
          b += tempColor.B;
        }
      }

      return Color.FromArgb(r / _sampleSizeSquared, g / _sampleSizeSquared, b / _sampleSizeSquared);

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
