using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BejeweledBlitzBot
{
  [SuppressUnmanagedCodeSecurity]
  internal static class PInvoke
  {

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
      private int _Left;
      private int _Top;
      private int _Right;
      private int _Bottom;

      public RECT(RECT Rectangle)
        : this(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom)
      {
      }

      public RECT(int Left, int Top, int Right, int Bottom)
      {
        _Left = Left;
        _Top = Top;
        _Right = Right;
        _Bottom = Bottom;
      }

      public int X
      {
        get { return _Left; }
        set { _Left = value; }
      }
      public int Y
      {
        get { return _Top; }
        set { _Top = value; }
      }
      public int Left
      {
        get { return _Left; }
        set { _Left = value; }
      }
      public int Top
      {
        get { return _Top; }
        set { _Top = value; }
      }
      public int Right
      {
        get { return _Right; }
        set { _Right = value; }
      }
      public int Bottom
      {
        get { return _Bottom; }
        set { _Bottom = value; }
      }
      public int Height
      {
        get { return _Bottom - _Top; }
        set { _Bottom = value + _Top; }
      }
      public int Width
      {
        get { return _Right - _Left; }
        set { _Right = value + _Left; }
      }
      public Point Location
      {
        get { return new Point(Left, Top); }
        set
        {
          _Left = value.X;
          _Top = value.Y;
        }
      }
      public Size Size
      {
        get { return new Size(Width, Height); }
        set
        {
          _Right = value.Width + _Left;
          _Bottom = value.Height + _Top;
        }
      }

      public static implicit operator Rectangle(RECT Rectangle)
      {
        return new Rectangle(Rectangle.Left, Rectangle.Top, Rectangle.Width, Rectangle.Height);
      }
      public static implicit operator RECT(Rectangle Rectangle)
      {
        return new RECT(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom);
      }
      public static bool operator ==(RECT Rectangle1, RECT Rectangle2)
      {
        return Rectangle1.Equals(Rectangle2);
      }
      public static bool operator !=(RECT Rectangle1, RECT Rectangle2)
      {
        return !Rectangle1.Equals(Rectangle2);
      }

      public override string ToString()
      {
        return "{Left: " + _Left + "; " + "Top: " + _Top + "; Right: " + _Right + "; Bottom: " + _Bottom + "}";
      }

      public override int GetHashCode()
      {
        return ToString().GetHashCode();
      }

      public bool Equals(RECT Rectangle)
      {
        return Rectangle.Left == _Left && Rectangle.Top == _Top && Rectangle.Right == _Right && Rectangle.Bottom == _Bottom;
      }

      public override bool Equals(object Object)
      {
        if (Object is RECT)
        {
          return Equals((RECT)Object);
        }
        else if (Object is Rectangle)
        {
          return Equals(new RECT((Rectangle)Object));
        }

        return false;
      }
    }

    [Flags]
    public enum MouseEventFlags : int
    {
      LEFTDOWN = 0x00000002,
      LEFTUP = 0x00000004,
      MIDDLEDOWN = 0x00000020,
      MIDDLEUP = 0x00000040,
      MOVE = 0x00000001,
      ABSOLUTE = 0x00008000,
      RIGHTDOWN = 0x00000008,
      RIGHTUP = 0x00000010,
      WHEEL = 0x00000800,
      XDOWN = 0x00000080,
      XUP = 0x00000100
    }

    //Use the values of this enum for the 'dwData' parameter
    //to specify an X button when using MouseEventFlags.XDOWN or
    //MouseEventFlags.XUP for the dwFlags parameter.
    public enum MouseEventDataXButtons : int
    {
      XBUTTON1 = 0x00000001,
      XBUTTON2 = 0x00000002
    }

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    internal static extern int GetWindowText(IntPtr hWnd, [Out] StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll", SetLastError = true)]
    internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
    internal static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

    [DllImport("user32.dll")]
    internal static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

    [DllImport("user32.dll")]
    internal static extern bool SetCursorPos(int X, int Y);
  }
}
