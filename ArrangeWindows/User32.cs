using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ArrangeWindows
{
    public class User32
    {

        public struct Point
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        public struct WINDOWPLACEMENT
        {
            public UInt32 length;
            public UInt32 flags;
            public UInt32 showCmd;
            Point ptMinPosition;
            Point ptMaxPosition;
            public Rect rcNormalPosition;
            public Rect rcDevice;
        }
        [Flags()]
        public enum DisplayDeviceStateFlags : int
        {
            /// <summary>The device is part of the desktop.</summary>
            AttachedToDesktop = 0x1,
            MultiDriver = 0x2,
            /// <summary>The device is part of the desktop.</summary>
            PrimaryDevice = 0x4,
            /// <summary>Represents a pseudo device used to mirror application drawing for remoting or other purposes.</summary>
            MirroringDriver = 0x8,
            /// <summary>The device is VGA compatible.</summary>
            VGACompatible = 0x10,
            /// <summary>The device is removable; it cannot be the primary display.</summary>
            Removable = 0x20,
            /// <summary>The device has more display modes than its output devices support.</summary>
            ModesPruned = 0x8000000,
            Remote = 0x4000000,
            Disconnect = 0x2000000
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct DISPLAY_DEVICE
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cb;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string DeviceName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string DeviceString;
            [MarshalAs(UnmanagedType.U4)]
            public DisplayDeviceStateFlags StateFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string DeviceID;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string DeviceKey;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
        [DllImport("user32.dll")]
        public static extern IntPtr GetClientRect(IntPtr hWnd, ref Rect rect);
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);
        [DllImport("user32.dll")]
        public static extern int ShowWindow(IntPtr hWnd, uint Msg);
        [DllImport("user32.dll")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool Repaint);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);
        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_LAYERED = 0x80000;
        public const int LWA_ALPHA = 0x02;
        public static void ChangeTransparent(IntPtr hWnd)
        {
            User32.SetWindowLong(hWnd, GWL_EXSTYLE, User32.GetWindowLong(hWnd, GWL_EXSTYLE) ^ WS_EX_LAYERED);
            User32.SetLayeredWindowAttributes(hWnd, 0, 0, LWA_ALPHA);
        }


        public enum WindowState
        {
            SW_HIDE, SW_SHOWNORMAL, SW_SHOWMINIMIZED, SW_SHOWMAXIMIZED, SW_SHOWNOACTIVATE, SW_SHOW, SW_MINIMIZE,
            SW_SHOWMINNOACTIVE, SW_SHOWNA, SW_RESTORE
        }
        public static Bitmap getWindowImage(IntPtr p,int x,int y,int w,int h,bool preview)
        {


           
            var r = new User32.WINDOWPLACEMENT();
            //get current window's attributes.
            User32.GetWindowPlacement(p, ref r);
            var rect = r.rcNormalPosition;
            float factor =(float)2.5;
            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;



            bool restore = false; ;
            User32.WindowState showCmd = (User32.WindowState)r.showCmd;
            switch (showCmd)
            {
                case User32.WindowState.SW_HIDE:
                case User32.WindowState.SW_MINIMIZE:
                case User32.WindowState.SW_SHOWMINIMIZED:
                    restore = true;
                    break;
            }
            if (preview)
            {
                User32.ChangeTransparent(p);
                User32.ShowWindow(p, (UInt32)User32.WindowState.SW_RESTORE);
            }

            Bitmap bmp = new Bitmap((int)(factor*w),(int)(factor*h), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics gfxBmp = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfxBmp.GetHdc();
            User32.MoveWindow(p, x, y, w, h, true);
            User32.PrintWindow(p, hdcBitmap, 0);
            
           if (preview)
           {
                    User32.MoveWindow(p, rect.left, rect.top, width, height, true);
                    User32.ShowWindow(p, r.showCmd);
                User32.ChangeTransparent(p);
            }

            gfxBmp.ReleaseHdc(hdcBitmap);
            gfxBmp.Dispose();
          //  bmp.Save(@"C:\Users\Brain\Pictures\temp\vlc.png", System.Drawing.Imaging.ImageFormat.Png);

            return bmp;

        }
        public static Bitmap getWindowImage(IntPtr p)
        {



            var r = new User32.WINDOWPLACEMENT();
            User32.GetWindowPlacement(p, ref r);
            var rect = r.rcNormalPosition;
            int width = (int)Math.Floor((rect.right - rect.left) * 2.5);
            int height = (int)Math.Floor((rect.bottom - rect.top) * 2.5);

            Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics gfxBmp = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfxBmp.GetHdc();

            bool restore = false; ;
            User32.WindowState showCmd = (User32.WindowState)r.showCmd;
            switch (showCmd)
            {
                case User32.WindowState.SW_HIDE:
                case User32.WindowState.SW_MINIMIZE:
                case User32.WindowState.SW_SHOWMINIMIZED:
                    restore = true;
                    break;
            }
            if (restore)
            {
                User32.ChangeTransparent(p);
                User32.ShowWindow(p, (UInt32)User32.WindowState.SW_RESTORE);
            }
            User32.PrintWindow(p, hdcBitmap, 0);
            if (restore)
            {
                User32.ShowWindow(p, r.showCmd);
                User32.ChangeTransparent(p);
            }

            gfxBmp.ReleaseHdc(hdcBitmap);
            gfxBmp.Dispose();
            bmp.Save(@"C:\Users\Brain\Pictures\temp\vlc.png", System.Drawing.Imaging.ImageFormat.Png);
            return bmp;

        }
    }
}
