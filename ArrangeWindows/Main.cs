using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrangeWindows
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ScreenBoard s = new ScreenBoard();
            s.TopLeft = new Point(0, 0);
            s.BottomRight = new Point(2, 1);

            ScreenBoard s2 = new ScreenBoard();
            s2.TopLeft = new Point(10, 0);
            s2.BottomRight = new Point(21, 10);

            int m = ScreenBoard.compareScreenBoard(s2,s2);
            ScreenBoard s3 = new ScreenBoard();
            s3.TopLeft = new Point(3, 0);
            s3.BottomRight = new Point(12, 1);

            List<ScreenBoard> b = new List<ScreenBoard>();
            b.Add(s2);
            b.Add(s);
            b.Add(s3);
            b.Sort(ScreenBoard.compareScreenBoard);
            Text = (b[1].TopLeft).ToString();
        }
    }
}
