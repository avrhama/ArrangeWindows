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
        public ScreenController.Monitor Monitor { set; get; }
        public WindowItem WindowItem {set;get;}
        public int Index { set; get; }
        public ScreenBoard Parent { set; get; }
        public ScreenBoard First { set; get; }
        public ScreenBoard Second { set; get; }
        private Ancor topLeft;
        private Ancor topRight=new Ancor(0,0);
        private Ancor bottomRight;
        private Ancor bottomLeft=new Ancor(0,0);
        private Size size;
        public Ancor TopLeft {
            get
            {
                return topLeft;
            }
            set
            {
                topLeft = value;
            }
        }


        public Ancor TopRight
        {
            get
            {
                return topRight;
            }
            set
            {

                topRight = value;

            }
        }
        
        public Ancor BottomRight {
            get
            {
                return bottomRight;
            }
            set
            {
                bottomRight = value;
            }
        }

        public Ancor BottomLeft
        {
            get
            {
                return bottomLeft;
            }
            set
            {
                bottomLeft=value;
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
                size = value;
            }
        }
        public Rect Rect { set; get; }
        public ScreenBoard(int x1,int y1,int x2,int y2)
        {
            topLeft = new Ancor(x1, y1);
            registerCoordinateChangedEvent(topLeft);
            bottomRight = new Ancor(x2, y2);
            registerCoordinateChangedEvent(bottomRight);
            topRight = new Ancor(bottomRight.X, topLeft.Y);       
            bottomLeft = new Ancor(topLeft.X, bottomRight.Y);
            size = new Size(x2-x1, y2-y1);   
        }
        public ScreenBoard(Ancor topLeft,Ancor topRight,Ancor bottomRight,Ancor bottomLeft)
        {
            this.topLeft = topLeft;
            this.topRight = topRight;
            this.bottomRight = bottomRight;
            this.bottomLeft = bottomLeft;
            size = new Size(bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);

            registerCoordinateChangedEvent(topLeft);
            registerCoordinateChangedEvent(topRight);
            registerCoordinateChangedEvent(bottomLeft);
            registerCoordinateChangedEvent(bottomRight);

        }
        public void registerCoordinateChangedEvent(Ancor a,bool register=true)
        {
            if (register)
            {
                a.CoordinateX.CoordinateChanged += coordinateChanged;
                a.CoordinateY.CoordinateChanged += coordinateChanged;
            }
            else
            {
                if (register)
                {
                    a.CoordinateX.CoordinateChanged -= coordinateChanged;
                    a.CoordinateY.CoordinateChanged -= coordinateChanged;
                }
            }
        }
        public void addChild(int x, int y, string type)
        {
            ScreenBoard first;
            ScreenBoard second;
            Ancor a1;
            Ancor a2;
            registerCoordinateChangedEvent(topLeft, false);
            registerCoordinateChangedEvent(topRight, false);
            registerCoordinateChangedEvent(bottomLeft, false);
            registerCoordinateChangedEvent(bottomRight, false);
            if (type == "v")
            {
                //topright fot first and topleft for second.
                 a1 = new Ancor(x, TopLeft.CoordinateY);
                //bottomright for first and bottomleft for second.
                 a2 = new Ancor(a1.CoordinateX, BottomLeft.CoordinateY);
                first = new ScreenBoard(TopLeft, a1, a2, BottomLeft);
                second = new ScreenBoard(a1, TopRight, BottomRight, a2);
            }
            else
            {
                //bottomleft fot first and topleft for second.
                 a1 = new Ancor(BottomLeft.CoordinateX, y);
                //bottomright for first and topright for second.
                 a2 = new Ancor(BottomRight.CoordinateX, a1.CoordinateY);
                first = new ScreenBoard(TopLeft, TopRight, a2, a1);
                second = new ScreenBoard(a1, a2, BottomRight, BottomLeft);
            }

            first.Monitor = Monitor;
            second.Monitor = Monitor;
            
            if (WindowItem != null)
            {
                first.WindowItem = WindowItem;
                WindowItem.ScreenBoard = first;
                first.WindowItem.setWinPreview();
            }
               
            WindowItem = null;
            First = first;
            first.Parent = this;
            Second = second;
            second.Parent = this;
            
        }
 
        public void replace(ScreenBoard sb)
        {
            sb.registerCoordinateChangedEvent(sb.topLeft,false);
            sb.registerCoordinateChangedEvent(sb.bottomRight, false);
            sb.registerCoordinateChangedEvent(sb.topRight, false);
            sb.registerCoordinateChangedEvent(sb.bottomLeft, false);
            topLeft.setXY(sb.topLeft);
            bottomRight.setXY(sb.bottomRight);
            topRight.setXY(sb.topRight);
            bottomLeft.setXY(sb.bottomLeft);
            registerCoordinateChangedEvent(topLeft);
            registerCoordinateChangedEvent(bottomRight);
            registerCoordinateChangedEvent(topRight);
            registerCoordinateChangedEvent(bottomLeft);

            First = sb.First;
            Second = sb.Second;
            Parent = sb.Parent;
        }

        public void removeChild(ScreenBoard child)
        {       
            if (First != null)
            {
                ScreenBoard otherChild;
                if (child.isFirst())
                {
                    if (First.TopLeft.Y == Second.TopLeft.Y)
                    {
                        First.registerCoordinateChangedEvent(First.topLeft, false);
                        First.registerCoordinateChangedEvent(First.bottomLeft, false);
                        First.topRight.setXY(First.topLeft);
                        First.bottomRight.setXY(First.bottomLeft);
                        Second.bottomLeft = First.bottomLeft;
                        Second.registerCoordinateChangedEvent(Second.topLeft);
                        Second.registerCoordinateChangedEvent(Second.bottomLeft);
                    }  
                    else
                    {
                        First.registerCoordinateChangedEvent(First.topLeft, false);
                        First.registerCoordinateChangedEvent(First.topRight, false);
                        First.bottomLeft.setXY(First.topLeft);
                        First.bottomRight.setXY(First.topRight);
                        Second.topLeft = First.topLeft;
                        Second.topRight = First.topRight;
                        Second.registerCoordinateChangedEvent(First.topLeft);
                        Second.registerCoordinateChangedEvent(First.topRight);
                    }
                        
                    otherChild = Second;

                }
                else
                {
                    if (First.TopLeft.Y == Second.TopLeft.Y)
                    {
                        
                        //Second.registerCoordinateChangedEvent(Second.topRight,false);
                        Second.registerCoordinateChangedEvent(Second.bottomRight, false);
                        Second.topLeft.setXY(Second.topRight);
                        Second.bottomLeft.setXY(Second.bottomRight);
                        First.topRight = Second.topRight;
                        First.bottomRight = Second.bottomRight;
                        First.registerCoordinateChangedEvent(First.topRight);
                        First.registerCoordinateChangedEvent(First.bottomRight);
                    }
                    else
                    {
                        Second.registerCoordinateChangedEvent(Second.bottomRight, false);
                        Second.registerCoordinateChangedEvent(Second.bottomLeft, false);
                        Second.topLeft.setXY(Second.bottomLeft);
                        Second.topRight.setXY(Second.bottomRight);
                        First.bottomRight = Second.bottomRight;
                        First.bottomLeft = Second.bottomLeft;
                        First.registerCoordinateChangedEvent(First.bottomRight);
                        First.registerCoordinateChangedEvent(First.bottomLeft);
                    }
                    otherChild = First;
                }
                ScreenBoard parent = Parent;
                if (parent != null)
                {
                    if (isFirst())
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
            return compareScreenBoard(this.Parent.First, this)== 0;
        }
        public void coordinateChanged()
        {
            int i = Index;
            Size temp = new Size(bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);
            if(size!= temp)
            {
                if (WindowItem != null)
                    WindowItem.setWinPreview();
                size = temp;
               
                Monitor.Draw?.Invoke();
           }        
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
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;
            ScreenBoard sb = (ScreenBoard)obj;
            return (sb.Monitor.Index == Monitor.Index && sb.Index == Index);
        }
    }
}
