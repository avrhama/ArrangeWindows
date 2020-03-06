using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrangeWindows
{
    public class Ancor
    {

        public Int16 Xoffset { set; get; }
        //Xoffset=new Coordinate(0);
        public Int16 Yoffset { set; get; }
       // Yoffset=new Coordinate(0);
        Coordinate x; Coordinate y;
        public int X
        {
            get
            {
                return x.Value + Xoffset;
            }
            set
            {
                x.Value = value;
            }
        }
        public int Y
        {
            get
            {
                return y.Value + Yoffset;
            }
            set
            {
                y.Value = value;
            }
        }

        public Coordinate CoordinateX
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public Coordinate CoordinateY
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        
        
        public Ancor(int x,int y)
        {
            CoordinateX = new Coordinate(x);
            CoordinateY = new Coordinate(y);
        }
        public Ancor(Coordinate x, Coordinate y)
        {
            CoordinateX = x;
            CoordinateY = y;
        }
        public Ancor(int x, Coordinate y)
        {
            CoordinateX = new Coordinate(x);
            CoordinateY = y;
        }
        public Ancor(Coordinate x, int y)
        {
            CoordinateX = x;
            CoordinateY = new Coordinate(y);
        }
        public Ancor copy()
        {
            return new Ancor(X, Y);
        }
        public Ancor setX(int x)
        {
            X = x;
            return this;
        }
        public Ancor setY(int y)
        {
            Y = y;
            return this;
        }
        public void setXY(Ancor a)
        {
            X = a.X;
            Y = a.Y;
          
        }
        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            Ancor a =(Ancor)obj;
            return (x==a.x&&y==a.y);
        }
    }
    public class Coordinate
    {
        public Action CoordinateChanged;
        int value_;
        public int Value
        {
            get
            {
                return value_;
            }
            set
            {
                if (value != value_)
                {
                    value_ = value;
                    CoordinateChanged?.Invoke();
                }
                else
                {
                    value_ = value;
                }
                  
              
            }
        }
        public Coordinate(int v)
        {
            Value = v;
        }
    }
   
}
