using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ArrangeWindows
{
    //represents a application location and size on screen.
   public class ScreenBoard
    {
        public ScreenBoard Parent { set; get; }
        public ScreenBoard First { set; get; }
        public ScreenBoard Second { set; get; }
        private Point bottomRight;
        private Size size;
        public Point TopLeft { get; set; }
        public Point BottomRight {
            get
            {
                return bottomRight;
            }
            set
            {
                size = new Size(value.X - TopLeft.X, value.Y - TopLeft.Y);
                bottomRight = value;
            }
        }
        public Size Size
        {
            get
            {
                return size;
            }
            set
            {   
                bottomRight = new Point(value.Width - TopLeft.X, value.Height - TopLeft.Y);
                size = value;
            }
        }

        public ScreenBoard()
        {
            this.TopLeft = new Point(0, 0);
            this.bottomRight = new Point(0, 0);
            this.size = new Size(0, 0);
        }
        public ScreenBoard(int x1,int y1,int x2,int y2)
        {
            this.TopLeft = new Point(x1, y1);
            this.bottomRight = new Point(x2, y2);
            this.size = new Size(x2-x1, y2-y1);
        }
        public ScreenBoard(Point topLeft,Point bottomRight)
        {
            this.TopLeft = new Point(topLeft.X, topLeft.Y);
            this.bottomRight = new Point(bottomRight.X, bottomRight.Y);
            this.size = new Size(bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);
        }
        public ScreenBoard addChild(ScreenBoard second, int t,string type)
        {
            ScreenBoard first;
            if (type == "v")
                first = new ScreenBoard(this.TopLeft, new Point(t, this.BottomRight.Y));
            else
                first = new ScreenBoard(this.TopLeft, new Point(this.BottomRight.X, t));
            First = first;
            first.Parent = this;
            Second = second;
            second.Parent = this;
            return first;
        }
        public void updateBottomRight(int x, int y, int t)
        {
            if (t != BottomRight.X)
                return;
            BottomRight = new Point(x, y);
            if (Second != null)
            {
                First.updateBottomRight(x, y, t);
                Second.updateBottomRight(x, y, t);
            }
            
            
        }
        public ScreenBoard removeChild(ScreenBoard child)
        {
            
            if (Second != null)
            {
                int cmp = ScreenBoard.compareScreenBoard(First,child);
                if(cmp == 0)
                {

                }
                else
                {
                    First.updateBottomRight(child.BottomRight.X, child.BottomRight.Y, child.TopLeft.X);
                    if (First.Parent.Parent != null)
                        First.Parent = First.Parent.Parent;
                    child.Parent = null;
                    return First;
                }
                First = null;
                Second = null;
                return this;
            }
            else
            {
                return Parent.remove();
            }
        }
        public ScreenBoard remove()
        {
            return Parent?.removeChild(this);
        }
        static public int compareScreenBoard(ScreenBoard a, ScreenBoard b)
        {
            if (a.TopLeft.X == b.TopLeft.X)
                return a.TopLeft.Y.CompareTo(b.TopLeft.Y);
            return a.TopLeft.X.CompareTo(b.TopLeft.X);
        }
        public bool containsPoint(Point p)
        {
            return (this.TopLeft.X <= p.X && this.BottomRight.X >= p.X && this.TopLeft.Y <= p.Y && this.BottomRight.Y >= p.Y);

        }
        //find the screenBoad that contains the given point.
        static public int findScreenBoad(List<ScreenBoard> list,int i,int j,Point goal)
        {
            if (i > j)
                return -1;
            int n = (j - i) / 2+i;
            if (n == list.Count)
                n = 0;
            ScreenBoard mid = list[n];
            if (mid.containsPoint(goal))
                return n;
            if (goal.X < mid.TopLeft.X||n > 0&&list[n-1].BottomRight.X>=goal.X&& mid.TopLeft.X<=goal.X)
                return findScreenBoad(list, i, n - 1, goal);
            else
                return findScreenBoad(list, n + 1, j, goal);

           /* if (goal.X <mid.TopLeft.X||(goal.X== mid.TopLeft.X && mid.TopLeft.Y > goal.Y))
                return findScreenBoad(list, i, n-1,goal);
            else if(goal.X > mid.TopLeft.X || (goal.X == mid.TopLeft.X && mid.TopLeft.Y < goal.Y))
                return findScreenBoad(list, n+1, j, goal);*/

           // return -1;
        }
      


    }
}
