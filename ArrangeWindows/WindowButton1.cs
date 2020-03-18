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
        public WindowButton()
        {
            SizeMode = PictureBoxSizeMode.StretchImage;
            MouseEnter += new EventHandler((object sender, EventArgs e) =>
            {
               setImage(true);
            });
            MouseLeave += new EventHandler((object sender, EventArgs e) =>
            {
                setImage();
            });
            MouseUp += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {

                        setImage(true);
            });
            MouseDown += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                setImage();
            });

        }
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
    public enum WindowButtonType
    {
        Add, Remove, Apply,Settings
    }

}
