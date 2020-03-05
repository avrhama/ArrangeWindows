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
        public Window win;
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
        }
        public void setTitle(string title)
        {
            win.Title = title;
            windowTitleLbl.Text = win.Title.Substring(0, 15);
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
