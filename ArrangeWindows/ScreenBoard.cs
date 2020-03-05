using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

    public static class Extension
    {
        public static Point copy(this Point p)
        {
            return new Point(p.X, p.Y);
        }
    public static Size copy(this Size s)
    {
        return new Size(s.Width, s.Height);
    }
}

namespace ArrangeWindows
{
    //represents a application location and size on screen.
   public class ScreenBoard
    {
        public int Index { set; get; }
        public ScreenBoard Parent { set; get; }
        public ScreenBoard First { set; get; }
        public ScreenBoard Second { set; get; }
        private Ancor topLeft;
        private Ancor bottomRight;
        private Size size;
        public Ancor TopLeft {
            get
            {
                return topLeft;
            }
            set
            {
                size = new Size(bottomRight.X - value.X, bottomRight.Y - value.Y);
                topLeft = value;
            }
        }
        public Ancor BottomRight {
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
                bottomRight = new Ancor(value.Width - TopLeft.X, value.Height - TopLeft.Y);
                size = value;
            }
        }

        public ScreenBoard()
        {
            this.topLeft = new Ancor(0, 0);
            this.bottomRight = new Ancor(0, 0);
            this.size = new Size(0, 0);
        }
        public ScreenBoard(int x1,int y1,int x2,int y2)
        {
          topLeft = new Ancor(x1, y1);
          bottomRight = new Ancor(x2, y2);
          size = new Size(x2-x1, y2-y1);
        }
        public ScreenBoard(Ancor topLeft, Ancor bottomRight)
        {
            this.topLeft = new Ancor(topLeft.X, topLeft.Y);
            this.bottomRight = new Ancor(bottomRight.X, bottomRight.Y);
            size = new Size(bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);
        }
        public ScreenBoard addChild(ScreenBoard second, int t, string type)
        {
            ScreenBoard first;
            if (type == "v")
            {
                // first = new ScreenBoard(TopLeft, new Ancor(t, this.BottomRight.Y));
                first = new ScreenBoard();
                first.TopLeft = TopLeft;
                first.BottomRight = new Ancor(t, this.BottomRight.Y);
            }

            else
                first = new ScreenBoard(TopLeft, new Ancor(this.BottomRight.X, t));
            First = first;
            first.Parent = this;
            Second = second;
            second.Parent = this;
            return first;
        }
        /* public ScreenBoard addChild(Ancor ancorSplit,string type)
         {
             ScreenBoard first;
             ScreenBoard second;
             if (type == "v")
             {
                 second = new ScreenBoard(ancorSplit.X, selected.TopLeft.Y, selected.BottomRight.X, selected.BottomRight.Y);

                 first = new ScreenBoard();
                 first.TopLeft = TopLeft;
                 first.BottomRight = new Ancor(t, this.BottomRight.Y);
             }

             else
                 first = new ScreenBoard(TopLeft, new Ancor(this.BottomRight.X, t));
             First = first;
             first.Parent = this;
             Second = second;
             second.Parent = this;
             return First;
         }*/
        //update x propery's variable to new value of n
        public void updateX(int n, int m,string proertyName)
        {
          Ancor p=(Ancor)typeof(ScreenBoard).GetProperty(proertyName).GetValue(this);
            if (m != p.X)
                return;

            if (First != null)
            {
                First.updateX(n, m, proertyName);
                Second.updateX(n, m, proertyName);
            }
           typeof(ScreenBoard).GetProperty(proertyName).SetValue(this, new Ancor(n, p.Y));
        }

        public void updateY(int n, int m, string proertyName)
        {
            Ancor p = (Ancor)typeof(ScreenBoard).GetProperty(proertyName).GetValue(this);
            if (m != p.Y)
                return;

            if (First != null)
            {
                First.updateX(n, m, proertyName);
                Second.updateX(n, m, proertyName);
            }
            typeof(ScreenBoard).GetProperty(proertyName).SetValue(this, new Ancor(p.X, n));
        }
        public void replace(ScreenBoard sb)
        {
            
            TopLeft = sb.TopLeft.copy();
            BottomRight = sb.BottomRight.copy();
            First = sb.First;
            Second = sb.Second;
            Parent = sb.Parent;
        }


        public void removeChild(ScreenBoard child)
        {
            
            if (First != null)
            {
                //int cmp = compareScreenBoard(First,child);
                ScreenBoard otherChild;
                if (child.isFirst())
                {
                    if (First.TopLeft.Y == Second.TopLeft.Y)
                        Second.updateX(child.TopLeft.X, child.BottomRight.X, "TopLeft");
                    else
                        Second.updateY(child.TopLeft.Y, child.BottomRight.Y, "TopLeft");
                    otherChild = Second;

                }
                else
                {
                    if(First.TopLeft.Y==Second.TopLeft.Y)
                    First.updateX(child.BottomRight.X, child.TopLeft.X, "BottomRight");
                    else
                        First.updateY(child.BottomRight.Y, child.TopLeft.Y, "BottomRight");
                    otherChild = First;

                }

                ScreenBoard parent = Parent;
                if (parent != null)
                {
                    //cmp = ScreenBoard.compareScreenBoard(this, parent.First);
                    if (this.isFirst())
                        parent.First = otherChild;
                    else
                        parent.Second = otherChild;
                    otherChild.Parent = parent;
                }
                else
                {
                    otherChild.Parent = null;
                    replace(otherChild);
                }
               
            }
            else
            {
                 Parent.remove();
            }
        }

        public void remove()
        {
             Parent?.removeChild(this);
        }
        public bool isFirst()
        {
            
            return ScreenBoard.compareScreenBoard(this.Parent.First, this)== 0;
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
