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

        List<ScreenBoard> screenBoards;
        //screenBoard split's menu to show when right button clicked.
        ContextMenu splitBoardMenu;
       // public  EventHandler screenBoardSelected;
        public event Action screenBoardSelected;
        public static ScreenBoard selectedScreenBoard;
        int index;

        public ScreenController()
        {
            InitializeComponent();
            screenBoards = new List<ScreenBoard>();
            ScreenBoard sb = new ScreenBoard(0, 0, scrnPanel.Width - 1, scrnPanel.Height - 1);
            Monitor monitor;
            monitor.index = 0;
            monitor.Size = new Ancor(scrnPanel.Width, scrnPanel.Height);
            monitor.Resolution = new Ancor(3840, 2160);
            monitor.ScaleDown = Math.Min((float)monitor.Size.X / monitor.Resolution.X, (float)monitor.Size.Y / monitor.Resolution.Y);
            monitor.ScaleUp = Math.Min(1/((float)monitor.Size.X / monitor.Resolution.X),1/( (float)monitor.Size.Y / monitor.Resolution.Y));
            monitor.ScaleWidth = (float)monitor.Size.X / monitor.Resolution.X;
            monitor.ScaleHeight = (float)monitor.Size.Y / monitor.Resolution.Y;
            monitor.Draw = Draw;
            monitor.DrawScreenBord = drawScreenBoard;
            sb.Monitor = monitor;
            screenBoards.Add(sb);
            screenBoards.Sort(ScreenBoard.compareScreenBoard);
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
            scrnPanel.Paint += DrawScreenBoards;
            
        }


        //returns the screenBoard's index that contains the given point.
        public int getScreenBoardIndexContainsPoint(Point p)
        {
            for (int i = 0; i < screenBoards.Count; i++)
            {
                if (screenBoards[i].containsPoint(p))
                    return i;

            }
            return -1;
        }
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
            int index = getScreenBoardIndexContainsPoint(clickedPoint);
            ScreenBoard selected = screenBoards[index];
            selected = getScreenBoardContainsPoint(screenBoards[0], clickedPoint);
            selected.remove();
            // screenBoards.RemoveAt(index);
            screenBoards.Remove(selected);
            //screenBoards[index - 1] = sb;
            screenBoards.Sort(ScreenBoard.compareScreenBoard);
            scrnPanel.Invalidate();
            focused = null;
        }
        public void splitScreen(object sender, EventArgs e)
        {

            MenuItem mi = (MenuItem)sender;
            Point splitPoint = (Point)mi.Parent.Tag;
            ScreenBoard selected = getScreenBoardContainsPoint(screenBoards[0], splitPoint);
      
            ScreenBoard sb;
            if (mi.Name == "v")
            {
                 sb = new ScreenBoard(splitPoint.X, selected.TopLeft.Y, selected.BottomRight.X, selected.BottomRight.Y);
               selected.addChild(splitPoint.X,splitPoint.Y, "v");

            }
            else
            {
                 sb = new ScreenBoard(selected.TopLeft.X, splitPoint.Y, selected.BottomRight.X, selected.BottomRight.Y);
               selected.addChild(splitPoint.X, splitPoint.Y, "h");
            }
            screenBoards.Sort(ScreenBoard.compareScreenBoard);
          scrnPanel.Invalidate();
            focused = sb;
            getFocusedScreenBoard(splitPoint);

            WindowItem.selectedScreenBoard = selected;
            screenBoardSelected?.Invoke();
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
                    WindowItem.selectedScreenBoard = getScreenBoardContainsPoint(screenBoards[0],e.Location);
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
                   /* switch (cursorStatus)
                    {
                        case CursorStatus.Left:
                        case CursorStatus.Right:
                            borderP1 = new Ancor(e.X, resized.TopLeft.Y);
                            borderP2 = new Ancor(e.X, resized.BottomLeft.Y);
                            break;
                        case CursorStatus.Top:
                        case CursorStatus.Bottom:
                            borderP1 = new Ancor(resized.TopLeft.X, e.Y);
                            borderP2 = new Ancor(resized.TopRight.X, e.Y);
                            break;

                    }*/
                }
          
                //Invalidate();

                
            }

        }
        ScreenBoard focused;
        public void MouseMoved(object sender, MouseEventArgs e)
        {

           
            if (focused == null || focused.First != null || !focused.containsPoint(e.Location))
            {

                focused = getScreenBoardContainsPoint(screenBoards[0], e.Location);

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
               // Graphics g = scrnPanel.CreateGraphics();
                //g.Clip = new Region(new Rectangle(resized.TopLeft.X, resized.TopLeft.Y+1, resized.BottomRight.X - resized.TopLeft.X, resized.BottomRight.Y - resized.TopLeft.Y-1));
                //g.Clear(BackColor);
                switch (cursorStatus)
                {
                    case CursorStatus.Left:
                        resized.TopLeft.X = e.X;
                        break;
                    case CursorStatus.Right:
                       
                       // borderP1.X = e.X;
                        //borderP2.X = e.X;
                        resized.TopRight.X = e.X;
                        break;
                    case CursorStatus.Top:
                        resized.TopRight.Y = e.Y;
                        break;
                    case CursorStatus.Bottom:
                        resized.BottomRight.Y = e.Y;
                        break;

                }
                //Graphics g = scrnPanel.CreateGraphics();
                //g.Clip = new Region(new Rectangle(borderP1.X, borderP1.Y, 1, borderP2.Y - borderP1.Y));
                //scrnPanel.Invalidate();
                //drawBorderLine();
                /*                g.Clear(BackColor);
                                g = scrnPanel.CreateGraphics();
                                if (borderP1 != null)
                                {
                                    g.DrawLine(Pens.Blue, borderP1.X, borderP1.Y, borderP2.X, borderP2.Y);

                                }*/
            }

        }
      
        CursorStatus cursorStatus = CursorStatus.Default;
        public  void getFocusedScreenBoard(Point p)
        {

            if (resized != null)
                return;
            bool diff1 = p.X- focused.TopLeft.X<5;
            bool diff2 = p.Y-focused.TopLeft.Y < 5;
            bool diff3= focused.BottomRight.X-p.X < 5;
            bool diff4 = focused.BottomRight.Y - p.Y < 5;
           
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
        Font f = new Font(FontFamily.GenericSansSerif, 8);
        protected void DrawScreenBoards(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            Draw();

            return;
            Graphics g = e.Graphics;
            for (int i = 0; i < screenBoards.Count; i++)
            {
                ScreenBoard sb = screenBoards[i];
                g.DrawRectangle(Pens.Red, sb.TopLeft.X, sb.TopLeft.Y, sb.Size.Width, sb.Size.Height);
                g.DrawString(i.ToString(), f, Brushes.Red, sb.TopLeft.X + 10, sb.TopLeft.Y + 10);
            }

        }
        Ancor borderP1=null;
        Ancor borderP2 = null;
        public void Draw()
        {
            Graphics g = scrnPanel.CreateGraphics();
            g.Clear(BackColor);
            drawScreenBoards(screenBoards[0],g);
           /* if (borderP1 != null)
            {
                g.DrawLine(Pens.Blue, borderP1.X, borderP1.Y, borderP2.X, borderP2.Y);

            }*/

        }
        public void drawBorderLine()
        {
            /*Graphics g = scrnPanel.CreateGraphics();
            g.Clip = new Region(new Rectangle(,));
            g.Clear(BackColor);

            if (borderP1 != null)
            {
                g.DrawLine(Pens.Blue, borderP1.X, borderP1.Y, borderP2.X, borderP2.Y);

            }*/
        }
        public void drawScreenBoard(ScreenBoard sb)
        {

            Graphics g = scrnPanel.CreateGraphics();

            if (sb.First == null)
            {

                if (sb.WindowItem != null)
                {
                    g.DrawImage(sb.WindowItem.Preview, sb.TopLeft.X, sb.TopLeft.Y, sb.WindowItem.Preview.Width, sb.WindowItem.Preview.Height);
                }
                else
                {
                    g.DrawString(sb.Index.ToString(), f, Brushes.Red, sb.TopLeft.X + 10, sb.TopLeft.Y + 10);
                }
                g.DrawRectangle(Pens.Red, sb.TopLeft.X, sb.TopLeft.Y, sb.BottomRight.X - sb.TopLeft.X, sb.BottomRight.Y - sb.TopLeft.Y);

            }
           

        }
        public int drawScreenBoards( ScreenBoard sb, Graphics g,int i=0)
        {
            
            if (sb.First == null)
            {
                /*g.DrawLine(Pens.Red, sb.TopLeft.X, sb.TopLeft.Y, sb.TopRight.X, sb.TopRight.Y);
                g.DrawLine(Pens.Red, sb.TopLeft.X, sb.TopLeft.Y, sb.BottomLeft.X, sb.BottomLeft.Y);
                g.DrawLine(Pens.Red, sb.TopRight.X, sb.TopRight.Y, sb.BottomRight.X, sb.BottomRight.Y);
                g.DrawLine(Pens.Red, sb.BottomRight.X, sb.BottomRight.Y, sb.BottomLeft.X, sb.BottomLeft.Y);*/
                // g.DrawRectangle(Pens.Red,)
                
                if (sb.WindowItem != null)
                {
                    g.DrawImage(sb.WindowItem.Preview, sb.TopLeft.X, sb.TopLeft.Y, sb.WindowItem.Preview.Width, sb.WindowItem.Preview.Height);
                   // g.DrawString(sb.WindowItem.Win.Name, f, Brushes.Red, sb.TopLeft.X + 10, sb.TopLeft.Y + 40);
                }
                else
                {
                    g.DrawString(i.ToString(), f, Brushes.Red, sb.TopLeft.X + 10, sb.TopLeft.Y + 10);
                }
                g.DrawRectangle(Pens.Red, sb.TopLeft.X, sb.TopLeft.Y, sb.BottomRight.X - sb.TopLeft.X, sb.BottomRight.Y - sb.TopLeft.Y);

                  string ancors = String.Format("tl:{0}  tr:{1}\nbl:{2}  br:{3}",sb.TopLeft,sb.TopRight,sb.BottomLeft,sb.BottomRight);
                g.DrawString(ancors, f, Brushes.Red, sb.TopLeft.X + 10, sb.TopLeft.Y + 40);
                sb.Index = i;
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
            public int index;
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
            public Action<ScreenBoard> DrawScreenBord;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            screenBoards.Sort(ScreenBoard.compareScreenBoard);
            scrnPanel.Invalidate();
        }
        bool drawing = true;
        private void drawingTimer_Tick(object sender, EventArgs e)
        {
            drawing = true;
            drawingTimer.Stop();
        }
    }
}
