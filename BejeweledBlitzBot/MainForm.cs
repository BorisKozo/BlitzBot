using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BejeweledBlitzBot.Rules;

namespace BejeweledBlitzBot
{
  public partial class MainForm : Form
  {
    private IntPtr _windowPointer = IntPtr.Zero;
    private Analyzer _analyzer;
    private Graphics _colorBoardGraphics;
    private int _boardTop;
    private int _boardLeft;
    private DateTime _gameStartTime;

    private Random _random = new Random();

    public MainForm()
    {
      InitializeComponent();
      UpdateWindow();
      MainTimer.Interval = 300;
    }

    private void UpdateWindow()
    {
      _windowPointer = PInvoke.FindWindowByCaption(IntPtr.Zero, WindowNameTextBox.Text);
      if (_windowPointer != IntPtr.Zero)
      {
        WindowNameStatusLabel.Text = "Found";
      }
      else
      {
        WindowNameStatusLabel.Text = "Not Found";
      }

    }

    private void WindowNameTextBox_TextChanged(object sender, EventArgs e)
    {
      UpdateWindow();
    }

    private void UpdateImage()
    {
      if (_windowPointer == IntPtr.Zero)
        return;

      PInvoke.RECT windowRect;
      if (PInvoke.GetWindowRect(_windowPointer, out windowRect))
      {

        Bitmap screenShot = new Bitmap(Convert.ToInt32(WidthSelector.Value),
                                       Convert.ToInt32(HeightSelector.Value),
                                       PixelFormat.Format32bppArgb);
        Graphics screen = Graphics.FromImage(screenShot);
        _boardLeft = windowRect.Left + Convert.ToInt32(OffsetXSelector.Value);
        _boardTop = windowRect.Top + Convert.ToInt32(OffsetYSelector.Value);
        screen.CopyFromScreen(_boardLeft, _boardTop
                                ,
                                0,
                                0,
                                screenShot.Size,
                                CopyPixelOperation.SourceCopy);
        CroppedImage.Image = screenShot;
      }
    }

    private void StartButton_Click(object sender, EventArgs e)
    {
      if (MainTimer.Enabled)
      {
        MainTimer.Enabled = false;
        StartButton.Text = "Start";
      }
      else
      {
        Size squaresCount = new Size(Convert.ToInt32(GridXSelector.Value), Convert.ToInt32(GridYSelector.Value));
        Size boardSize = new Size(Convert.ToInt32(WidthSelector.Value), Convert.ToInt32(HeightSelector.Value));
        _analyzer = new Analyzer(squaresCount, 10, boardSize);

        Bitmap tempImage = new Bitmap(boardSize.Width, boardSize.Height);
        _colorBoardGraphics = Graphics.FromImage(tempImage);
        ColorBoard.Image = tempImage;
        _gameStartTime = DateTime.Now;
        MainTimer.Enabled = true;
        StartButton.Text = "Stop";
      }
    }

    private void MainTimer_Tick(object sender, EventArgs e)
    {
      
      UpdateImage();
      Shape[,] shapesGrid = _analyzer.GetGridData(CroppedImage.Image as Bitmap,_colorBoardGraphics);
      HashSet<ClickMove> moves = RulesManager.GetMoves(shapesGrid);
      foreach (ClickMove move in moves)
      {
        //Thread.Sleep(100);
        MoveSquares(move);
      }
      ColorBoard.Refresh();
      TimeSpan diff = DateTime.Now.Subtract(_gameStartTime);
      if (diff.TotalSeconds > 80)
        StartButton_Click(StartButton, new EventArgs());
    }

    private void MoveSquares(int fromColumn, int fromRow, int toColumn, int toRow)
    {
      SimulateMouseClick(_boardLeft + fromColumn*_analyzer.SquareSize.Width + 1, _boardTop + fromRow*_analyzer.SquareSize.Height + 1);
      SimulateMouseClick(_boardLeft + toColumn * _analyzer.SquareSize.Width + 1, _boardTop + toRow * _analyzer.SquareSize.Height + 1);
    }

    private void MoveSquares(ClickMove move)
    {
      MoveSquares(move.FromColumn, move.FromRow, move.ToColumn, move.ToRow);
    }

    private void SimulateMouseClick(int x, int y)
    {
      PInvoke.SetCursorPos(x, y);
      PInvoke.mouse_event((int)PInvoke.MouseEventFlags.LEFTDOWN, 0, 0, 0, IntPtr.Zero);
      PInvoke.mouse_event((int)PInvoke.MouseEventFlags.LEFTUP, 0, 0, 0, IntPtr.Zero);
    }

    private void ClipButton_Click(object sender, EventArgs e)
    {
      UpdateImage();
    }


  }
}
