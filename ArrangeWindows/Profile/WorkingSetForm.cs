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
    public partial class WorkingSetForm : Form
    {
        private static WorkingSetForm singalton;
        WorkingSet workingSet;
        Action<string> WorkingSetItemSelectedAction;
        ScreenController[] screenControllers;
   
       public static bool SaveMode { set; get; }
        private WorkingSetForm()
        {
            InitializeComponent();
            TopMost = true;
            Location = new Point(0, 0);

            subscribesEvents();
        }
        public void subscribesEvents()
        {
            FormClosed += new FormClosedEventHandler((object sender, FormClosedEventArgs e) => {
                foreach (ScreenController screen in screenControllers)
                    screen.restoreProfile();

            });
            saveBtn.Click += new EventHandler((object sender, EventArgs e) =>
            {
                workingSet.name = profileNameTxt.Text.Trim();
                string filePath = String.Format(@"{0}\{1}.bin", Settings.Settings.WorkSetPath, workingSet.name);
                SerializeModel.SerializeObject(workingSet, filePath);
                WorkinSetItem workinSetItem = new WorkinSetItem(workingSet);
                workingSetsLayout.Controls.Add(workinSetItem);
            });
           
            loadBtn.Click += new EventHandler((object sender, EventArgs e) =>
            {

            });
           
            applayBtn.Click += new EventHandler((object sender, EventArgs e) =>
            {
                foreach (ScreenController screen in screenControllers)
                    screen.applyProfile();
            });
          
        }
        private static void cerateSinglton()
        {
            if (singalton == null || singalton.IsDisposed)
            {
                singalton = new WorkingSetForm();
                //for future development.
                foreach (Display d in displays)
                    singalton.monitorsCombo.Items.Add(d);
                singalton.loadWorkSetsItems();
                
            }
        }
        public static void open()
        {
           cerateSinglton();
            singalton.Show();
         
        }
        private void loadWorkSetsItems()
        {
            List<WorkingSet> list = new List<WorkingSet>();
            foreach (string path in System.IO.Directory.GetFiles(Settings.Settings.WorkSetPath))
                try
                {
                    if (!path.EndsWith(".bin"))
                        continue;
                    WorkingSet workingSet_ = SerializeModel.DeSerializeObject<WorkingSet>(path);
                    WorkinSetItem workinSetItem = new WorkinSetItem(workingSet_);
                    workinSetItem.Name = workingSet_.name;
                    WorkingSetItemSelectedAction += workinSetItem.WorkingSetItemSelected;
                    workinSetItem.workingSetItemAction += WorkingSetItemSelected;
                    workinSetItem.deleteWorkingSetItemAction += deleteWorkingSet;
                    workingSetsLayout.Controls.Add(workinSetItem);
                    list.Add(workingSet_);
                }
                catch (Exception e) { }
        }
        static public void loadWorkSets(ScreenController [] screenControllers)
        {
            cerateSinglton();
            //for future development.
            if (screenControllers.Length == 1)
            {
               int x= singalton.monitorsCombo.Items.IndexOf(screenControllers[0].Monitor_.display);
                singalton.monitorsCombo.SelectedIndex = singalton.monitorsCombo.Items.IndexOf(screenControllers[0].Monitor_.display);
            }
            
            singalton.screenControllers = screenControllers;
            //singalton.loadBtn.Visible = true;
            singalton.profileNameTxt.Visible = false;
            singalton.saveBtn.Visible = false;
            SaveMode = false;
            foreach(WorkinSetItem workinSetItem in singalton.workingSetsLayout.Controls)
            {
                if (workinSetItem.WorkingSet.profiles.Length != screenControllers.Length)
                    workinSetItem.Visible = false;
                else
                    workinSetItem.Visible = true;
            }
        }
        static public void setWorkingSet(WorkingSet workingSet)
        {
            cerateSinglton();
            singalton.workingSet = workingSet;
           // singalton.loadBtn.Visible = false;
            singalton.profileNameTxt.Visible = true;
            singalton.saveBtn.Visible = true;
            SaveMode = true;
            foreach (WorkinSetItem workinSetItem in singalton.workingSetsLayout.Controls)
            {
              
                    workinSetItem.Visible = true;
            }
        }
        static List<Display> displays;
        public static void setMonitor(int x, int y, string deviceString)
        {
            if (displays == null)
                displays = new List<Display>();
            displays.Add(new Display(new Point(x, y), deviceString));
        }
        public void WorkingSetItemSelected(WorkingSet workingSet)
        {
            for (int i=0;i< screenControllers.Length;i++)
            {

                screenControllers[i].previewProfile(workingSet.profiles[i].splitSpotSet);
            }
            
            WorkingSetItemSelectedAction?.Invoke(workingSet.name);

        }
        public void deleteWorkingSet(string workingSetName)
        {
            WorkinSetItem workinSetItem =(WorkinSetItem)workingSetsLayout.Controls.Find(workingSetName, false)[0];
            workingSetsLayout.Controls.Remove(workinSetItem);
            System.IO.File.Delete(String.Format(@"{0}\{1}.bin", Settings.Settings.WorkSetPath, workingSetName));


        }


    }
}
