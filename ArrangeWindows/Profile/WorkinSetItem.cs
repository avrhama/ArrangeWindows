using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrangeWindows.Profile
{
    public partial class WorkinSetItem : UserControl
    {
        
        public WorkingSet WorkingSet { set; get; }
        public bool Selected{ set; get; }
        public Action<WorkingSet> workingSetItemAction;
       public  Action<string> deleteWorkingSetItemAction;

        public WorkinSetItem()
        {
            InitializeComponent();
        }
        public WorkinSetItem(WorkingSet workingSet)
        {
            InitializeComponent();
           
            workingSetName.Text = workingSet.name;
            WorkingSet = workingSet;
            subscribesEvents();
        }
        public void subscribesEvents()
        {
            Click += new EventHandler((object sender, EventArgs e) => {
                Selected = !Selected;
                if (Selected) { 
                BackgroundImage = Resource1.windowCaseSelectedGrey;
                workingSetItemAction?.Invoke(WorkingSet);
                }
                else
                {
                    BackgroundImage = Resource1.windowCase;
                    //call to restrore handler at working form.

                }
            });
            MouseEnter += new EventHandler((object sender, EventArgs e) =>
            {
                if (!Selected && !WorkingSetForm.SaveMode)
                    BackgroundImage = Resource1.windowCase;
            });
            MouseLeave += new EventHandler((object sender, EventArgs e) =>
            {
                if (!Selected)
                    BackgroundImage = Resource1.windowCaseOff;
            });
            deleteBtn.Click += new EventHandler((object sender, EventArgs e) =>
            {
               DialogResult dr=MessageBox.Show($"Are you sure you want to delete:\n{WorkingSet.name}?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                    deleteWorkingSetItemAction?.Invoke(WorkingSet.name);
            });
            deleteBtn.MouseEnter += new EventHandler((object sender, EventArgs e) =>
            {
                if (!Selected)
                    deleteBtn.Image = Resource1.closeOn;
            });
            deleteBtn.MouseLeave += new EventHandler((object sender, EventArgs e) =>
            {
                if (!Selected)
                    deleteBtn.Image = Resource1.closeOff;
            });
        }
        public void WorkingSetItemSelected(string name)
        {
            if (WorkingSet.name != name)
            {
                Selected = false;
                BackgroundImage = Resource1.windowCaseOff;
            }

        }
    }
}
