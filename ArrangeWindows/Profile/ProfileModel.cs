using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrangeWindows
{
   public class ProfileModel
    {
        public static SplitSpot getSplitSpot(ScreenBoard sb)
        {
            SplitSpot splitSpot=null;
            if (sb.First != null)
            {
                splitSpot = new SplitSpot();
                if (sb.First.TopLeft.Y == sb.Second.TopLeft.Y)
                    splitSpot.setSplitSpot(sb.Second.TopLeft.X, sb.Second.TopLeft.Y, true);
                else
                    splitSpot.setSplitSpot(sb.Second.TopLeft.X, sb.Second.TopLeft.Y, false);
                splitSpot.FirstSplit = getSplitSpot(sb.First);
                splitSpot.SecondSplit = getSplitSpot(sb.Second);
            }
            return splitSpot;
        }
        public static void saveProfile(ScreenBoard sb,string profilePath)
        {
            SplitSpot s = getSplitSpot(sb);
            SerializeModel.SerializeObject<SplitSpot>(s, profilePath);
            int x = 0;
        }
        public static SplitSpot loadProfile(string profilePath)
        {
            SplitSpot s = SerializeModel.DeSerializeObject<SplitSpot>(profilePath);
            return s;
        }

    }
    [Serializable]
    public class SplitSpot
    {
        public SplitSpot FirstSplit { set; get; }
        public SplitSpot SecondSplit { set; get; }
       public int X { set; get; }
        public int Y { set; get; }
        //seems like its unnessary.
        public bool IsVertical { set; get; }
       
       public void setSplitSpot (int x,int y,bool isVertical)
        {
            X = x;
            Y = y;
            this.IsVertical = isVertical;
        }
    }
}
