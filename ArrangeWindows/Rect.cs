using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrangeWindows
{
    public class Rect
    {
        public Action sizeChanged;
        Coordinate top;
        Coordinate bottom;
        Coordinate left;
        Coordinate right;
        public Coordinate Top {
            get
            {
                return top;
            }
            set
            {
                if (top != value)
                {
                    sizeChanged.Invoke();
                    top = value;
                }
            }
        }
        public Coordinate Bottom
        {
            get
            {
                return bottom;
            }
            set
            {
                if (bottom != value)
                {
                    sizeChanged.Invoke();
                    bottom = value;
                }
            }
        }
        public Coordinate Left
        {
            get
            {
                return left;
            }
            set
            {
                if (left != value)
                {
                    sizeChanged.Invoke();
                    left = value;
                }
            }
        }
        public Coordinate Right
        {
            get
            {
                return right;
            }
            set
            {
                if (right != value)
                {
                    sizeChanged.Invoke();
                    right = value;
                }
            }
        }

    }
}
