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
        public ScreenController()
        {
            InitializeComponent();

            screenBoards = new List<ScreenBoard>();
            ScreenBoard sb1 = new ScreenBoard(0, 0, scrnPanel.Width - 1, scrnPanel.Height - 1);

            // ScreenBoard sb1 = new ScreenBoard(0, 0, (scrnPanel.Width - 1) / 2, scrnPanel.Height - 1);
            ScreenBoard sb2 = new ScreenBoard((scrnPanel.Width - 1) / 2, 0, scrnPanel.Width - 1, scrnPanel.Height - 1);
            screenBoards.Add(sb1);
            //screenBoards.Add(sb2);
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
            /*           int index=ScreenBoard.findScreenBoad(screenBoards, 0, screenBoards.Count-1, splitPoint);
                        if (index < 0)
                        {
                           index = ScreenBoard.findScreenBoad(screenBoards, 0, screenBoards.Count-1, splitPoint);
                        }*/
            int index = getScreenBoardIndexContainsPoint(splitPoint);


            ScreenBoard selected = screenBoards[index];
            selected = getScreenBoardContainsPoint(screenBoards[0], splitPoint);
            ScreenBoard sb;
            if (mi.Name == "v")
            {
                 sb = new ScreenBoard(splitPoint.X, selected.TopLeft.Y, selected.BottomRight.X, selected.BottomRight.Y);
                ScreenBoard first = selected.addChild(splitPoint.X,splitPoint.Y, "v");
                // screenBoards[index] = first;
                Point p = new Point(sb.BottomRight.X + 1, splitPoint.Y);
                index = getScreenBoardIndexContainsPoint(p);
                
                /*  if (index == -1)
                      screenBoards.Add(sb);
                  else
                  {
                      screenBoards.Insert(index, sb);
                  }*/

            }
            else
            {
                 sb = new ScreenBoard(selected.TopLeft.X, splitPoint.Y, selected.BottomRight.X, selected.BottomRight.Y);
                ScreenBoard first = selected.addChild(splitPoint.X, splitPoint.Y, "h");
              
                // screenBoards[index] = first;
                //screenBoards.Insert(index + 1, sb);
            }
            //MessageBox.Show(index.ToString());
            screenBoards.Sort(ScreenBoard.compareScreenBoard);
          scrnPanel.Invalidate();
          //draw(screenBoards[0], 0);
            focused = sb;
            getFocusedScreenBoard(splitPoint);

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
                    /*bool isFirst = resized.isFirst();
                    switch (arrowStatus)
                    {
                        case 2:
                            resized.updateX(e.X, resized.TopLeft.X, "TopLeft");
                            if (!isFirst)
                            {
                                resized.Parent.First.updateX(e.X, resized.Parent.First.BottomRight.X, "BottomRight");
                            }
                            break;
                        case 3:
                            resized.updateX(e.X, resized.BottomRight.X, "BottomRight");
                            if (isFirst)
                            {
                                resized.Parent.Second.updateX(e.X, resized.Parent.Second.TopLeft.X, "TopLeft");
                            }
                            break;


                    }*/
                    switch (cursorStatus)
                    {
                        case CursorStatus.Left:
                            resized.TopLeft.CoordinateX.Value = e.X;
                            resized.BottomLeft.CoordinateX.Value = e.X;
                          //  resized.setTopLeft(resized.TopLeft.setX(e.X));
                           // resized.setBottomLeft(resized.BottomLeft.setX(e.X));
                            break;
                        case CursorStatus.Right:
                            resized.TopRight.CoordinateX.Value = e.X;
                            resized.BottomRight.CoordinateX.Value = e.X;
                           // resized.setTopRight(resized.TopRight.setX(e.X));
                          ///  resized.setBottomRight(resized.BottomRight.setX(e.X));
                            break;
                        case CursorStatus.Top:
                            resized.TopLeft.CoordinateY.Value = e.Y;
                            resized.TopRight.CoordinateY.Value = e.Y;
                            // resized.setTopLeft(resized.TopLeft.setY(e.Y));
                            // resized.setTopRight( resized.TopRight.setY(e.Y));
                            break;
                        case CursorStatus.Bottom:
                            resized.BottomLeft.CoordinateY.Value = e.Y;
                            resized.BottomRight.CoordinateY.Value = e.Y;
                            // resized.setBottomLeft (resized.BottomLeft.setY(e.Y));
                            // resized.setBottomRight(resized.BottomRight.setY(e.Y));
                            break;

                    }



                    resized = null;
                    //draw(screenBoards[0], 0);
                    scrnPanel.Invalidate();
                   
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
                Graphics g = scrnPanel.CreateGraphics();
                g.DrawLine(Pens.Blue, e.X, resized.TopLeft.Y, e.X, resized.TopRight.Y);
                
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
        Font f = new Font(FontFamily.GenericSansSerif, 12);
        protected void DrawScreenBoards(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            draw(screenBoards[0],0);

            return;
            Graphics g = e.Graphics;
            for (int i = 0; i < screenBoards.Count; i++)
            {
                ScreenBoard sb = screenBoards[i];
                g.DrawRectangle(Pens.Red, sb.TopLeft.X, sb.TopLeft.Y, sb.Size.Width, sb.Size.Height);
                g.DrawString(i.ToString(), f, Brushes.Red, sb.TopLeft.X + 10, sb.TopLeft.Y + 10);
            }

        }
        public int draw( ScreenBoard sb,int i)
        {
            Graphics g = scrnPanel.CreateGraphics();
            if (sb.First == null)
            {
                g.DrawRectangle(Pens.Red, sb.TopLeft.X, sb.TopLeft.Y, sb.BottomRight.X-sb.TopLeft.X, sb.BottomRight.Y - sb.TopLeft.Y);
                /*g.DrawLine(Pens.Red, sb.TopLeft.X, sb.TopLeft.Y, sb.TopRight.X, sb.TopRight.Y);
                g.DrawLine(Pens.Red, sb.TopLeft.X, sb.TopLeft.Y, sb.BottomLeft.X, sb.BottomLeft.Y);
                g.DrawLine(Pens.Red, sb.TopRight.X, sb.TopRight.Y, sb.BottomRight.X, sb.BottomRight.Y);
                g.DrawLine(Pens.Red, sb.BottomRight.X, sb.BottomRight.Y, sb.BottomLeft.X, sb.BottomLeft.Y);*/
                // g.DrawRectangle(Pens.Red,)
                g.DrawString(i.ToString(), f, Brushes.Red, sb.TopLeft.X + 10, sb.TopLeft.Y + 10);
              //  string ancors = String.Format("tl:{0}  tr:{1}\nbl:{2}  br:{3}",sb.TopLeft,sb.TopRight,sb.BottomLeft,sb.BottomRight);
                //g.DrawString(ancors, f, Brushes.Red, sb.TopLeft.X + 10, sb.TopLeft.Y + 40);
                sb.Index = i;
                return i + 1;
            }
            else
            {
              int j=  draw(sb.First, i);

              return draw(sb.Second, j);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            screenBoards.Sort(ScreenBoard.compareScreenBoard);
            scrnPanel.Invalidate();
        }
    }
}
