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
        public int getScreenBoardContainsPoint(Point p)
        {
            for (int i = 0; i < screenBoards.Count; i++)
            {
                if (screenBoards[i].containsPoint(p))
                    return i;

            }
            return -1;
        }
        public void removeScreenBoard(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            Point clickedPoint = (Point)mi.Parent.Tag;
            int index = getScreenBoardContainsPoint(clickedPoint);
            ScreenBoard selected = screenBoards[index];
            ScreenBoard sb = selected.remove();
            screenBoards.RemoveAt(index);
            //screenBoards[index - 1] = sb;
            screenBoards.Sort(ScreenBoard.compareScreenBoard);
            scrnPanel.Invalidate();
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
            int index = getScreenBoardContainsPoint(splitPoint);


            ScreenBoard selected = screenBoards[index];
            if (mi.Name == "v")
            {
                ScreenBoard sb = new ScreenBoard(splitPoint.X, selected.TopLeft.Y, selected.BottomRight.X, selected.BottomRight.Y);
                ScreenBoard first = selected.addChild(sb, splitPoint.X, "v");
                screenBoards[index] = first;
                splitPoint = new Point(sb.BottomRight.X + 1, splitPoint.Y);
                index = getScreenBoardContainsPoint(splitPoint);
                if (index == -1)
                    screenBoards.Add(sb);
                else
                {
                    screenBoards.Insert(index, sb);
                }

            }
            else
            {
                ScreenBoard sb = new ScreenBoard(selected.TopLeft.X, splitPoint.Y, selected.BottomRight.X, selected.BottomRight.Y);
                ScreenBoard first = selected.addChild(sb, splitPoint.Y, "h");
                screenBoards[index] = first;
                screenBoards.Insert(index + 1, sb);
            }
            //MessageBox.Show(index.ToString());
            screenBoards.Sort(ScreenBoard.compareScreenBoard);
            scrnPanel.Invalidate();


        }
        public void MouseClicked(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                splitBoardMenu.Tag = e.Location;
                splitBoardMenu.Show(this, e.Location);


            }
            else
            {
                int index = getScreenBoardContainsPoint(e.Location);
                MessageBox.Show(index.ToString());
            }
        }
        Font f = new Font(FontFamily.GenericSansSerif, 12);
        protected void DrawScreenBoards(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            for (int i = 0; i < screenBoards.Count; i++)
            {
                ScreenBoard sb = screenBoards[i];
                g.DrawRectangle(Pens.Red, sb.TopLeft.X, sb.TopLeft.Y, sb.Size.Width, sb.Size.Height);
                g.DrawString(i.ToString(), f, Brushes.Red, sb.TopLeft.X + 10, sb.TopLeft.Y + 10);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            screenBoards.Sort(ScreenBoard.compareScreenBoard);
            scrnPanel.Invalidate();
        }
    }
}
