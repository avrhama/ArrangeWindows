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
        public Action<WindowItem,bool> AddFavoritEvent;
        public bool Favorite { set; get; }
        ContextMenu windowItemMenu;
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

        public WindowItem(Window win,bool favorite)
        {
            InitializeComponent();
            this.win = win;
            Favorite = favorite;
            

            windowIconPic.Image = win.Icon.ToBitmap();
           
            windowTitleLbl.Text = win.Title.Substring(0, 15);
          
            windowItemMenu = new ContextMenu();
            string addItemText="add favorite";
            if(favorite)
                addItemText = "remove favorite";
            windowItemMenu.MenuItems.Add(new MenuItem(addItemText, new EventHandler((object sender, EventArgs e) => {
                addItemText = "add favorite";
                if (!Favorite)
                    addItemText = "remove favorite";
                ((MenuItem)sender).Text = addItemText;
                AddFavoritEvent?.Invoke(this, Favorite);
                

            })));

            subscribsEvents();

        }
        public void subscribsEvents()
        {
            ToolTip tt = new ToolTip();
            windowTitleLbl.MouseHover += new EventHandler((object sender, EventArgs e) =>
            {
                tt.Show(win.Title, windowTitleLbl, 5000);
            });

            addWindowPic.Click += addWinPicClicked;
            addWindowPic.MouseEnter += new EventHandler((object sender, EventArgs e) =>
            {
                addWindowPic.setImage(true);
                BackgroundImage = Resource1.windowCaseOnBlue;
            });
            addWindowPic.MouseLeave += new EventHandler((object sender, EventArgs e) =>
            {
                addWindowPic.setImage();
                BackgroundImage = Resource1.windowCaseOffBlue;
            });
            MouseUp += windowItemShowMenu;
            windowIconPic.MouseUp += windowItemShowMenu;
            windowTitleLbl.MouseUp += windowItemShowMenu;
            MouseEnter += new EventHandler((object sender, EventArgs e) =>
            {
                BackgroundImage = Resource1.windowCaseOnBlue;
            });

            MouseLeave += new EventHandler((object sender, EventArgs e) =>
            {
                BackgroundImage = Resource1.windowCaseOffBlue;

            });
            windowIconPic.MouseEnter += new EventHandler((object sender, EventArgs e) =>
            {
                BackgroundImage = Resource1.windowCaseOnBlue;
            });
            windowTitleLbl.MouseEnter += new EventHandler((object sender, EventArgs e) =>
            {
                BackgroundImage = Resource1.windowCaseOnBlue;
            });
            addWindowPic.MouseEnter += new EventHandler((object sender, EventArgs e) =>
            {
                BackgroundImage = Resource1.windowCaseOnBlue;
            });
        }
        public void windowItemShowMenu(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                windowItemMenu.Show(this, e.Location);


        }
        public void setTitle(string title)
        {
            win.Title = title;
            windowTitleLbl.Text = win.Title.Substring(0, 15);
        }
        public static ScreenBoard selectedScreenBoard;
        public void screenBoardSelected()
        {
            if (ScreenBoard != null &&ScreenBoard.Equals(selectedScreenBoard))
            {
                addWindowPic.Type = WindowButtonType.Remove;
            }
            else
            {
                addWindowPic.Type = WindowButtonType.Add;
            }
        }
       

        public void addWinPicClicked(object sender, EventArgs e)
        {
            if (ScreenBoard != null)
                ScreenBoard.WindowItem = null;

            if (addWindowPic.Type == WindowButtonType.Add)
            {

                if (selectedScreenBoard.WindowItem != null)
                {
                    selectedScreenBoard.WindowItem.ScreenBoard = null;
                    selectedScreenBoard.WindowItem.addWindowPic.Type = WindowButtonType.Add;
                    //selectedScreenBoard.WindowItem.addWindowPic.setImage();
                }

                selectedScreenBoard.WindowItem = this;
                ScreenBoard = selectedScreenBoard;
                addWindowPic.Type = WindowButtonType.Remove;
                //addWindowPic.setImage();
                setWinPreview();
                //addWindowPic.Tag = "d";
                // selectedScreenBoard.Monitor.Draw();
            }
            else
            {
                addWindowPic.Type = WindowButtonType.Add;
               // addWindowPic.setImage();
                ScreenBoard = null;

            }
            selectedScreenBoard.Monitor.Draw();
        }
        public Bitmap Preview { set; get; }
        public void setWinPreview(bool preview=true)
        {

            int screenBoadWidth = ScreenBoard.BottomRight.X - ScreenBoard.TopLeft.X;
            int screenBoadHeight = ScreenBoard.BottomRight.Y - ScreenBoard.TopLeft.Y;

            float widthFactor = 1/ selectedScreenBoard.Monitor.ScaleWidth;
            float heightFactor = 1/ selectedScreenBoard.Monitor.ScaleHeight;

            float width = widthFactor * screenBoadWidth ;
            float height = heightFactor * screenBoadHeight ;
            
            Bitmap image = User32.getWindowImage(win.Win,(int)(selectedScreenBoard.Monitor.X +ScreenBoard.TopLeft.X* widthFactor),
                (int)(selectedScreenBoard.Monitor.Y+ScreenBoard.TopLeft.Y*heightFactor),
                (int)width, (int)height, preview);


            Preview = new Bitmap(image, new Size(screenBoadWidth, screenBoadHeight));
        }



    }
    public class Window
    {
        public IntPtr Win { get; set; }
        public Icon Icon { set; get; }
        public string Name { set; get; }
        public string Title { set; get; }
        public Window(IntPtr p, string title)
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
