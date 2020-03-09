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
        public Action<WorkingSet> WorkingSetItemAction;
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
                WorkingSetItemAction?.Invoke(WorkingSet);
                }
                else
                {
                    BackgroundImage = Resource1.windowCase;
                    //call to restrore handler at working form.

                }
            });
            MouseEnter += new EventHandler((object sender, EventArgs e) => {
                if (!Selected&&!WorkingSetForm.SaveMode)
                    BackgroundImage = Resource1.windowCase;
            });
            MouseLeave += new EventHandler((object sender, EventArgs e) => {
                if (!Selected)
                    BackgroundImage = Resource1.windowCaseOff;
            });
          closeBtn.Click += new EventHandler((object sender, EventArgs e) => {

            });
            closeBtn.MouseEnter += new EventHandler((object sender, EventArgs e) => {
                if (!Selected)
                    closeBtn.Image = Resource1.closeOn;
            });
            closeBtn.MouseLeave += new EventHandler((object sender, EventArgs e) => {
                if (!Selected)
                    closeBtn.Image = Resource1.closeOff;
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
