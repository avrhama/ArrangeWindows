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
        public Int16 Yoffset { set; get; }
        int x; int y;
        public int X
        {
            get
            {
                return x + Xoffset;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y + Yoffset;
            }
            set
            {
                y = value;
            }
        }
        
        public Ancor(int x,int y)
        {
            X = x;
            Y = y;
        }
        public Ancor copy()
        {
            return new Ancor(X, Y);
        }
    }
   
}
