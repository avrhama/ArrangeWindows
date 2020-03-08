using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrangeWindows.Profile
{
    public partial class ProfileForm : Form
    {
        private static ProfileForm singalton;
      static private bool isClosed=true;
       static private WorkingSet workingSet;
        string workingSetPath = @"C:\Users\Brain\Pictures\temp\workingset\";
      private  ProfileForm()
        {        
            InitializeComponent();
            TopMost = true;
            FormClosed += new FormClosedEventHandler((object sender,FormClosedEventArgs e) => { isClosed = true; });
            saveBtn.Click += new EventHandler((object sender, EventArgs e) =>
            {
                string filePath = String.Format(@"{0}{1}.bin",workingSetPath, profileNameTxt.Text.Trim());
                SerializeModel.SerializeObject<WorkingSet>(workingSet, filePath);
            });
            saveBtn.MouseEnter += new EventHandler((object sender, EventArgs e) =>
            {
                saveBtn.setImage(true);
            });
            saveBtn.MouseLeave += new EventHandler((object sender, EventArgs e) =>
            {
                saveBtn.setImage();
            });
            loadBtn.Click += new EventHandler((object sender, EventArgs e) =>
            {

            });
            loadBtn.MouseEnter += new EventHandler((object sender, EventArgs e) =>
            {
                loadBtn.setImage(true);
            });
            loadBtn.MouseLeave += new EventHandler((object sender, EventArgs e) =>
            {
                loadBtn.setImage();
            });
        }
        public static void open()
        {
            if (isClosed)
            {
                singalton = new ProfileForm();
               foreach(Monitor m in monitors)
                singalton.monitorsCombo.Items.Add(m);
                singalton.Show();
                isClosed = false;
            }
            
        }
       static public void setWorkingSet(WorkingSet arg)
        {
            workingSet = arg;
        }
       static List<Monitor> monitors;
        public static void setMonitor(int x, int y, string deviceString)
        {
            if (monitors == null)
                monitors = new List<Monitor>();
            monitors.Add(new Monitor(new Point(x, y), deviceString));
        }
        private class Monitor
        {
            string toString;
            public Point Resolution { set; get; }
            public string Name { set; get; }
            public Monitor(Point res,string name)
            {
                Resolution = res;
                Name = name;
                toString =String.Format("{0}({1}x{2})",name, res.X,res.Y);
            }
            public override string ToString()
            {
                return toString;
            }
        }
    }
}
