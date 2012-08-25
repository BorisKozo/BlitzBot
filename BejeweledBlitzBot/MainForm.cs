using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BejeweledBlitzBot
{
  public partial class MainForm : Form
  {
    private IntPtr _windowPointer = IntPtr.Zero;
    private Analyzer _analyzer;

    public MainForm()
    {
      InitializeComponent();
      UpdateWindow(); 
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
        screen.CopyFromScreen(windowRect.Left + Convert.ToInt32(OffsetXSelector.Value),
                                windowRect.Top + Convert.ToInt32(OffsetYSelector.Value),
                                0,
                                0,
                                screenShot.Size,
                                CopyPixelOperation.SourceCopy);
        CroppedImage.Image = screenShot;
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Size squaresCount = new Size(Convert.ToInt32(GridXSelector.Value), Convert.ToInt32(GridYSelector.Value));
      Size boardSize = new Size(Convert.ToInt32(WidthSelector.Value), Convert.ToInt32(HeightSelector.Value));
      _analyzer = new Analyzer(squaresCount, 10, boardSize);
      UpdateImage();
      ColorBoard.Image = _analyzer.GetGridData(CroppedImage.Image as Bitmap);
    }


  }
}
