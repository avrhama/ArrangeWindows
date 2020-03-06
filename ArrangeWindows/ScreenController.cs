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
                if (resized != null && resized.Parent!=null)
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
                    resized.TopLeft.X = e.X;
                    resized.BottomLeft.X = e.X;


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
                if (arrowStatus != -1)
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
        int arrowStatus = -1;
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
                arrowStatus = (diff1 && diff2) ? 0 : 1;
                Cursor.Current = Cursors.SizeNWSE;
            }   
            else if (diff1 || diff3)
            {
                arrowStatus = diff1 ? 2 : 3;
                Cursor.Current = Cursors.SizeWE;
            }  
            else if (diff2 || diff4)
            {
                arrowStatus = diff2 ? 4 : 5;
                Cursor.Current = Cursors.SizeNS;
            }
            else
            {
                arrowStatus = -1;
                Cursor.Current = Cursors.Arrow;
            }
            label1.Text = "Welcome to " + focused.Index+"\narrow:"+arrowStatus;
         

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
                //g.DrawRectangle(Pens.Red, sb.TopLeft.X, sb.TopLeft.Y, sb.Size.Width, sb.Size.Height);
                g.DrawLine(Pens.Red, sb.TopLeft.X, sb.TopLeft.Y, sb.TopRight.X, sb.TopRight.Y);
                g.DrawLine(Pens.Red, sb.TopLeft.X, sb.TopLeft.Y, sb.BottomLeft.X, sb.BottomLeft.Y);
                g.DrawLine(Pens.Red, sb.TopRight.X, sb.TopRight.Y, sb.BottomRight.X, sb.BottomRight.Y);
                g.DrawLine(Pens.Red, sb.BottomRight.X, sb.BottomRight.Y, sb.BottomLeft.X, sb.BottomLeft.Y);
                // g.DrawRectangle(Pens.Red,)
                g.DrawString(i.ToString(), f, Brushes.Red, sb.TopLeft.X + 10, sb.TopLeft.Y + 10);
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
