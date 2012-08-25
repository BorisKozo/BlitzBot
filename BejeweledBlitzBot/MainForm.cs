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

    private void timer1_Tick(object sender, EventArgs e)
    {
      UpdateImage();
    }
  }
}
