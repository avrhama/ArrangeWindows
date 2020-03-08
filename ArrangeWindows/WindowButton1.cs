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
        WindowButtonType type;
        public System.Drawing.Bitmap[] BtnImages { set; get; }
        
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
            int index = 2*(int)type;
            if (turn)
                index++;       
            Image = BtnImages[index];
        }

    }

}
