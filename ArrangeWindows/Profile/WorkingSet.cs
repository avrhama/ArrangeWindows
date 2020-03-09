using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrangeWindows.Profile
{
    [Serializable]
    public struct WorkingSet
    {
        public Profile[] profiles;
        public string name;
        public override string ToString()
        {
            return name;
        }
    }
    [Serializable]
    public struct Profile
    {
        public SplitSpot splitSpotSet;
        public string monitorName;
        public Point resolution;
    }
}
