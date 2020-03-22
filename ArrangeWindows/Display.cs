using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ArrangeWindows
{
    public class Display
    {
        string toString;
        public Point Resolution { set; get; }
        public string Name { set; get; }
        public Display(Point res, string name)
        {
            Resolution = res;
            Name = name;
            toString = String.Format("{0}({1}x{2})", name, res.X, res.Y);
        }
        public override string ToString()
        {
            return toString;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;
            Display other = (Display)obj;
            return other.Name == Name;

        }
    }
}
