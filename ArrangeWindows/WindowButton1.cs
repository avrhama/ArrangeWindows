using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrangeWindows
{
   public class WindowButton:PictureBox
    {
        WindowButtonType type = WindowButtonType.Add;
        public WindowButtonType Type {
            set
            {
                type = value;
                setImage();
            }
            get
            {
                return type;
            }
        }
        public void setImage(bool turn=false)
        {
            switch (type)
            {
                case WindowButtonType.Add:
                    if (!turn)
                        Image = Resource1.addWindowOff;
                    else
                        Image = Resource1.addWindowOn;
                    break;
                 case   WindowButtonType.Remove:
                    if (!turn)
                        Image = Resource1.removeWindowOff;
                    else
                        Image = Resource1.removeWindowOn;
                    break;
            }
           
        }

    }
    public enum WindowButtonType
    {
        Add,Remove
    }
}
