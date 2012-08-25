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


    public Bitmap GetGridData(Bitmap image)
    {
      _stopWatch.Restart();
      Bitmap result = new Bitmap(_boardSize.Width, _boardSize.Height);
      Graphics graphics = Graphics.FromImage(result);
      //Shape[,] result = new Shape[_squareCount.Width, _squareCount.Height];
      for (int i = 0; i < _squareCount.Width; i++)
      {
        for (int j = 0; j < _squareCount.Height; j++)
        {
          int squareLeft = i * _squareSize.Width;
          int squareTop = j * _squareSize.Height;
          Color tempColor = GetAverageColor(squareLeft, squareTop, image);
          graphics.FillRectangle(new SolidBrush(tempColor), new Rectangle(squareLeft, squareTop, _squareSize.Width, _squareSize.Height));
        }
      }

      _stopWatch.Stop();
      Console.Out.WriteLine("Get data time " + _stopWatch.ElapsedMilliseconds);
      return result;
    }

    private Color GetAverageColor(int left, int top, Bitmap image)
    {
      int r = 0;
      int g = 0;
      int b = 0;
      for (int i = 0; i < _sampleSize; i++)
      {
        for (int j = 0; j < _sampleSize; j++)
        {
          Color tempColor = image.GetPixel(left + _sampleOffset.Width + i, top + _sampleOffset.Height + j);
          r += tempColor.R;
          g += tempColor.G;
          b += tempColor.B;
        }
      }


      return Color.FromArgb(r / _sampleSizeSquared, g / _sampleSizeSquared, b / _sampleSizeSquared);
    }
  }
}
