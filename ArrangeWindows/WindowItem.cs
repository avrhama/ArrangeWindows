using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrangeWindows
{
    public partial class WindowItem : UserControl
    {
        Window win;
        public Window Win
        {
            set
            {
                win = value;
            }
            get
            {
                return win;
            }
        }
        public ScreenBoard ScreenBoard { set; get; }
        
        public WindowItem()
        {
            InitializeComponent();
        }
        public WindowItem(Window win)
        {
            InitializeComponent();
            this.win = win;
            windowIconPic.Image = win.Icon.ToBitmap();
            ToolTip tt = new ToolTip();
            windowTitleLbl.MouseHover += new EventHandler((object sender, EventArgs e) =>
            {
                tt.Show(win.Title, windowTitleLbl, 5000);

            });
            windowTitleLbl.Text = win.Title.Substring(0, 15);

            addWindowPic.Click += addWinPicClicked;
        }
        public void setTitle(string title)
        {
            win.Title = title;
            windowTitleLbl.Text = win.Title.Substring(0, 15);
        }
        public static ScreenBoard selectedScreenBoard;
        public void screenBoardSelected()
        {
            if (ScreenBoard != null && selectedScreenBoard.Index == ScreenBoard.Index)
            {
                addWindowPic.Image = Resource1.Remove_icon;
            }
            else
            {
                addWindowPic.Image = Resource1.Add_icon;
            }
        }
        public void changeAddIcon()
        {
            addWindowPic.Image = Resource1.Add_icon;
        }
        public void addWinPicClicked(object sender,EventArgs e)
        {
            if (ScreenBoard != null)
                ScreenBoard.WindowItem = null;
            if (selectedScreenBoard.WindowItem != null)
            {
                selectedScreenBoard.WindowItem.ScreenBoard = null;
                selectedScreenBoard.WindowItem.changeAddIcon();
            }
                
            selectedScreenBoard.WindowItem = this;
            ScreenBoard = selectedScreenBoard;
            addWindowPic.Image = Resource1.Remove_icon;
            setWinPreview();
            selectedScreenBoard.Monitor.Draw();
        }
        public Bitmap Preview { set; get; }
        public void setWinPreview()
        {
           // Preview = User32.getWindowImage(win.Win);
            float factor = (float)2.5;
            float widthx = 3840/factor;
            float heihtx = 2160 / factor;
            //User32.MoveWindow(win.Win, 0, 0,(int)widthx, (int)heihtx, true);
            //return;
            int screenBoadWidth = ScreenBoard.BottomRight.X - ScreenBoard.TopLeft.X;
            int screenBoadHeight = ScreenBoard.BottomRight.Y - ScreenBoard.TopLeft.Y;

            float width = 1/selectedScreenBoard.Monitor.ScaleWidth * screenBoadWidth / factor;
            float height = 1 / selectedScreenBoard.Monitor.ScaleHeight * screenBoadHeight / factor;

           // Application.Exit();
           // User32.MoveWindow(win.Win, ScreenBoard.TopLeft.X, ScreenBoard.TopLeft.Y, (int)width, (int)height, true);
            Bitmap image = User32.getWindowImage(win.Win, ScreenBoard.TopLeft.X, ScreenBoard.TopLeft.Y, (int)width, (int)height);
           //var scaleWidth = (int)(image.Width * selectedScreenBoard.Monitor.Scale);
           //var scaleHeight = (int)(image.Height * selectedScreenBoard.Monitor.Scale);
            Preview = new Bitmap(image, new Size(screenBoadWidth, screenBoadHeight));
        }



    }
    public class Window
    {
        public IntPtr Win { get; set; }
        public Icon Icon { set; get; }
        public string Name { set; get; }
        public string Title { set; get; }
        public Window(IntPtr p,string title)
        {
            Win = p;
            Title = title;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;
            return Win.Equals(((Window)obj).Win);
        }
        public override string ToString()
        {
            return Name;
        }
        public static int compare(string a, string b)
        {
            return a.CompareTo(b);
        }
    }
}
