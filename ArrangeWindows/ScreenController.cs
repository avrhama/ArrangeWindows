using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArrangeWindows.Enums;

namespace ArrangeWindows
{
    public partial class ScreenController : UserControl
    {

      //  List<ScreenBoard> screenBoards;
        //screenBoard split's menu to show when right button clicked.
        ContextMenu splitBoardMenu;
        public event Action screenBoardSelected;
        public static ScreenBoard selectedScreenBoard;
        int monitorIndex;
        Monitor monitor;
        ScreenBoard root;
        ScreenBoard restore;
        public ScreenController(Screen screen,string name,int index)
        {
            InitializeComponent();
          //  screenBoards = new List<ScreenBoard>();
            scrnCtrlNameLbl.Text = name;
            monitorIndex = index;
            root = new ScreenBoard(0, 0, scrnPanel.Width - 1, scrnPanel.Height - 1);
            monitor.Name = name;
            monitor.Index = index;
            monitor.Size = new Ancor(scrnPanel.Width, scrnPanel.Height);
            monitor.Resolution = new Ancor(3840, 2160);
            monitor.Resolution = new Ancor(screen.Bounds.Width, screen.Bounds.Height);
            monitor.ScaleDown = Math.Min((float)monitor.Size.X / monitor.Resolution.X, (float)monitor.Size.Y / monitor.Resolution.Y);
            monitor.ScaleUp = Math.Min(1/((float)monitor.Size.X / monitor.Resolution.X),1/( (float)monitor.Size.Y / monitor.Resolution.Y));
            monitor.ScaleWidth = (float)monitor.Size.X / monitor.Resolution.X;
            monitor.ScaleHeight = (float)monitor.Size.Y / monitor.Resolution.Y;
            monitor.Draw = Draw;
            monitor.DrawScreenBoard = drawScreenBoard;
            monitor.X = screen.Bounds.X;
            monitor.Y = screen.Bounds.Y;
            root.Monitor = monitor;
            selectedScreenBoard = root;
            focused = root;
            //initialize menu
            splitBoardMenu = new ContextMenu();
            MenuItem verticalSplit = new MenuItem("vertical split", splitScreen);
            verticalSplit.Name = "v";
            MenuItem horizionSplit = new MenuItem("horizion split", splitScreen);
            horizionSplit.Name = "h";
            MenuItem removeSplit = new MenuItem("remove split", removeScreenBoard);
            splitBoardMenu.MenuItems.Add(verticalSplit);
            splitBoardMenu.MenuItems.Add(horizionSplit);
            splitBoardMenu.MenuItems.Add(removeSplit);
          

            subscribesEvent();
        }
        public void subscribesEvent()
        {
            scrnPanel.Paint += DrawScreenBoards;
            applayBtn.Click += new EventHandler((object sender, EventArgs e) =>
            {
                applyWindowsPositions(root);
            });
            applayBtn.MouseEnter += new EventHandler((object sender, EventArgs e) =>
            {
                applayBtn.setImage(true);
            });
            applayBtn.MouseLeave += new EventHandler((object sender, EventArgs e) =>
            {
                applayBtn.setImage();
            });
            saveBtn.Click += new EventHandler((object sender, EventArgs e) =>
            {

                Profile.WorkingSet workingSet=new Profile.WorkingSet();
                Profile.Profile p = createProfile();
                workingSet.profiles = new Profile.Profile[] { p };
                Profile.WorkingSetForm.setWorkingSet(workingSet);
                Profile.WorkingSetForm.open();
            });
            saveBtn.MouseEnter += new EventHandler((object sender, EventArgs e) =>
            {
                saveBtn.setImage(true);
            });
            saveBtn.MouseLeave += new EventHandler((object sender, EventArgs e) =>
            {
                saveBtn.setImage();
            });
            loadBtn.Click += new EventHandler((object sender, EventArgs e) =>
            {

                createRestore();
                Profile.WorkingSetForm.loadWorkSets(new ScreenController[] { this});
                Profile.WorkingSetForm.open();                
            });
            loadBtn.MouseEnter += new EventHandler((object sender, EventArgs e) =>
            {
                loadBtn.setImage(true);
            });
            loadBtn.MouseLeave += new EventHandler((object sender, EventArgs e) =>
            {
                loadBtn.setImage();
            });
        }

        public Profile.Profile createProfile()
        {
            Profile.Profile p;
            p.splitSpotSet = ProfileModel.getSplitSpot(root);
            p.monitorName = monitor.Name;
            p.resolution = new Point(monitor.Resolution.X, monitor.Y);
            return p;
        }

        public void createRestore()
        {
            if (restore == null)
            {
                restore = new ScreenBoard(0, 0, scrnPanel.Width - 1, scrnPanel.Height - 1);
                restore.First = root.First;
                restore.Second = root.Second;
            }
        }

        //returns the screenBoard that contains the given point.
        public ScreenBoard getScreenBoardContainsPoint(ScreenBoard sb,Point p)
        {
            if (sb.containsPoint(p))
            {
                if (sb.First == null)
                {
                    return sb;
                }
                else
                {
                    ScreenBoard sb1 = getScreenBoardContainsPoint(sb.First, p);
                    ScreenBoard sb2 = getScreenBoardContainsPoint(sb.Second, p);
                    if (sb1 != null)
                        return sb1;
                    else if (sb2 != null)
                        return sb2;
                }
            }
                return null;
        }
        public void removeScreenBoard(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            Point clickedPoint = (Point)mi.Parent.Tag;
            ScreenBoard  selected = getScreenBoardContainsPoint(root, clickedPoint);
            selected.remove();
            scrnPanel.Invalidate();
            focused = null;
        }
    
        public void splitScreen(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            Point splitPoint = (Point)mi.Parent.Tag;
            bool isVertical = false;
            if (mi.Name == "v")
                isVertical = true;
            createScreenBoard(splitPoint,isVertical);

        }
        public ScreenBoard createScreenBoard(Point splitPoint, bool isVertical)
        {
            ScreenBoard selected = getScreenBoardContainsPoint(root, splitPoint);

            ScreenBoard sb;
            if (isVertical)
            {
                sb = new ScreenBoard(splitPoint.X, selected.TopLeft.Y, selected.BottomRight.X, selected.BottomRight.Y);
                selected.addChild(splitPoint.X, splitPoint.Y, "v");

            }
            else
            {
                sb = new ScreenBoard(selected.TopLeft.X, splitPoint.Y, selected.BottomRight.X, selected.BottomRight.Y);
                selected.addChild(splitPoint.X, splitPoint.Y, "h");
            }
            
            scrnPanel.Invalidate();
            focused = sb;

            WindowItem.selectedScreenBoard = selected;
            screenBoardSelected?.Invoke();
            return sb;
        }
        public void MouseUpClicked(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                splitBoardMenu.Tag = e.Location;
                splitBoardMenu.Show(this, e.Location);


            }
            else
            {

                if (resized != null )
                {

                    switch (cursorStatus)
                    {
                        case CursorStatus.Left:
                            resized.TopLeft.CoordinateX.Value = e.X;
                            resized.BottomLeft.CoordinateX.Value = e.X;
                            break;
                        case CursorStatus.Right:
                            resized.TopRight.CoordinateX.Value = e.X;
                            resized.BottomRight.CoordinateX.Value = e.X;
                            break;
                        case CursorStatus.Top:
                            resized.TopLeft.CoordinateY.Value = e.Y;
                            resized.TopRight.CoordinateY.Value = e.Y;
                            break;
                        case CursorStatus.Bottom:
                            resized.BottomLeft.CoordinateY.Value = e.Y;
                            resized.BottomRight.CoordinateY.Value = e.Y;
                            break;

                    }
                    resized = null;

                    resized?.WindowItem.setWinPreview();
                    scrnPanel.Invalidate();
                }
                else
                {
                    WindowItem.selectedScreenBoard = getScreenBoardContainsPoint(root, e.Location);
                    screenBoardSelected?.Invoke();
                }

            }
        }
        ScreenBoard resized;
        public void MouseDownClicked(object sender, MouseEventArgs e)
        {
       
            if (e.Button == MouseButtons.Left)
            {

                if (cursorStatus != CursorStatus.Default)
                {
                    resized = focused;
                }
               // drawScreenBoard(selectedScreenBoard, Pens.Red);
                selectedScreenBoard.Monitor.DrawScreenBoard(selectedScreenBoard, Pens.Red);
                selectedScreenBoard = focused;
                drawScreenBoard(selectedScreenBoard, Pens.Blue);
            }

        }
        ScreenBoard focused;
        public void MouseMoved(object sender, MouseEventArgs e)
        {

           
            if (focused == null || focused.First != null || !focused.containsPoint(e.Location))
            {

                focused = getScreenBoardContainsPoint(root, e.Location);

            }
            if (focused != null)
                getFocusedScreenBoard(e.Location);
            if (resized != null)
            {

                if (!drawing)
                    return;
                else
                {
                    drawing = false;
                    drawingTimer.Start();
                }
               
                    
                switch (cursorStatus)
                {
                    case CursorStatus.Left:
                        resized.TopLeft.X = e.X;
                        break;
                    case CursorStatus.Right:
                        resized.TopRight.X = e.X;
                        break;
                    case CursorStatus.Top:
                        resized.TopRight.Y = e.Y;
                        break;
                    case CursorStatus.Bottom:
                        resized.BottomRight.Y = e.Y;
                        break;

                }
            }

        }
      
        CursorStatus cursorStatus = CursorStatus.Default;
        public  void getFocusedScreenBoard(Point p)
        {
            int offset = 5;
            if (p.X < 5 || p.X > scrnPanel.Width - 1 - offset || p.Y < offset || p.Y > scrnPanel.Height - 1 - offset)
                resized = null;
            if (resized != null)
                return;
           


            bool diff1 = p.X- focused.TopLeft.X< offset;
            bool diff2 = p.Y-focused.TopLeft.Y < offset;
            bool diff3= focused.BottomRight.X-p.X < offset;
            bool diff4 = focused.BottomRight.Y - p.Y < offset;
            
            if ((diff1 && diff2) || (diff3 && diff4))
            {
                cursorStatus = (diff1) ?CursorStatus.TopLeft : CursorStatus.BottomRight;
                Cursor.Current = Cursors.SizeNWSE;
            }else if((diff1 && diff4) || (diff2 && diff3))
            {
                cursorStatus = (diff1) ? CursorStatus.BottomLeft : CursorStatus.TopRight;
                Cursor.Current = Cursors.SizeNESW;
            }
            else if (diff1 || diff3)
            {
                cursorStatus = diff1 ? CursorStatus.Left : CursorStatus.Right;
                Cursor.Current = Cursors.SizeWE;
            }  
            else if (diff2 || diff4)
            {
                cursorStatus = diff2 ? CursorStatus.Top : CursorStatus.Bottom;
                Cursor.Current = Cursors.SizeNS;
            }
            else
            {
                cursorStatus = CursorStatus.Default;
                Cursor.Current = Cursors.Arrow;
            }
            label1.Text = "Welcome to " + focused.Index+"\narrow:"+ cursorStatus;
         

        }
        Font font = new Font(FontFamily.GenericSansSerif, 8);
        protected void DrawScreenBoards(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            Draw();
        }

        public void Draw()
        {
            Graphics g = scrnPanel.CreateGraphics();
            g.Clear(BackColor);
            drawScreenBoards(root, g);
            if (selectedScreenBoard.Monitor.Index == monitorIndex)
                drawScreenBoard(selectedScreenBoard,Pens.Blue);

        }

        public void drawScreenBoard(ScreenBoard sb,Pen p)
        {

            Graphics g = scrnPanel.CreateGraphics();

            if (sb.First == null)
            {

/*                if (sb.WindowItem != null)
                {
                    g.DrawImage(sb.WindowItem.Preview, sb.TopLeft.X, sb.TopLeft.Y, sb.WindowItem.Preview.Width, sb.WindowItem.Preview.Height);
                }
                else
                {
                    g.DrawString(sb.Index.ToString(), f, Brushes.Red, sb.TopLeft.X + 10, sb.TopLeft.Y + 10);
                }*/
                g.DrawRectangle(p, sb.TopLeft.X, sb.TopLeft.Y, sb.BottomRight.X - sb.TopLeft.X, sb.BottomRight.Y - sb.TopLeft.Y);

            }
           

        }
        public int drawScreenBoards( ScreenBoard sb, Graphics g,int i=0)
        {
            
            if (sb.First == null)
            { 
                if (sb.WindowItem != null)
                {
                    g.DrawImage(sb.WindowItem.Preview, sb.TopLeft.X, sb.TopLeft.Y, sb.WindowItem.Preview.Width, sb.WindowItem.Preview.Height);
                }
                else
                {
                    g.DrawString(i.ToString(), font, Brushes.Red, sb.TopLeft.X + 10, sb.TopLeft.Y + 10);
                }
                sb.Index = i;

                g.DrawRectangle(Pens.Red, sb.TopLeft.X, sb.TopLeft.Y, sb.BottomRight.X - sb.TopLeft.X, sb.BottomRight.Y - sb.TopLeft.Y);

                 // string ancors = String.Format("tl:{0}  tr:{1}\nbl:{2}  br:{3}",sb.TopLeft,sb.TopRight,sb.BottomLeft,sb.BottomRight);
                //g.DrawString(ancors, f, Brushes.Red, sb.TopLeft.X + 10, sb.TopLeft.Y + 40);
            
                return i + 1;
            }
            else
            {
              int j=  drawScreenBoards(sb.First,  g,i);

              return drawScreenBoards(sb.Second, g,j);
            }
           
        }
        public struct Monitor
        {
            public int Index;
            public string Name;
            //screencontroller control size.
            public Ancor Size;
            //monitor resolution.
            public Ancor Resolution;
            //scale.
            public float ScaleDown;
            public float ScaleUp;
            public float ScaleWidth;
            public float ScaleHeight;
            public Action Draw;
            public Action<ScreenBoard, Pen> DrawScreenBoard;
            public int X;
            public int Y;
        }
       
        bool drawing = true;
        private void drawingTimer_Tick(object sender, EventArgs e)
        {
            drawing = true;
            drawingTimer.Stop();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string profilePath = String.Format(@"C:\Users\Brain\Documents\{0}.bin",monitor.Name);
            ProfileModel.saveProfile(root, profilePath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string profilePath = String.Format(@"C:\Users\Brain\Documents\{0}.bin", monitor.Name);
            SplitSpot splitSpot = ProfileModel.loadProfile(profilePath);
            root.First = null;
            root.Second = null;
            loadProfile(splitSpot);

        }

        private void loadProfile(SplitSpot splitSpot)
        {
            if (splitSpot == null)
                return;     
                createScreenBoard(new Point(splitSpot.X, splitSpot.Y), splitSpot.IsVertical);       
                loadProfile(splitSpot.FirstSplit);
                loadProfile(splitSpot.SecondSplit);
        
        }
        public void previewProfile(SplitSpot splitSpot)
        {
            root.First = null;
            root.Second = null;
            loadProfile(splitSpot);
        }
        public void restoreProfile()
        {
            if (restore == null)
                return;
            root.First = restore.First;
            root.Second = restore.Second;
            restore = null;
            Draw();
        }
        public void applyProfile()
        {
            restore = root;
            restore = null;
        }
        public void applyWindowsPositions(ScreenBoard sb)
        {
            if (sb.First != null)
            {
                applyWindowsPositions(sb.First);
                applyWindowsPositions(sb.Second);
            }
            else if (sb.WindowItem != null)
                sb.WindowItem.setWinPreview(false);


        }
       
       
    }
}
