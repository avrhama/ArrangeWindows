using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ArrangeWindows
{
    public partial class Main : Form
    {
        ContextMenu filteredWinNamesMenu;
        public Main()
        {
            InitializeComponent();
            if (System.IO.File.Exists(Environment.CurrentDirectory + @"\filteredList.bin"))
                winsNames = SerializeModel.DeSerializeObject<BindingList<string>>(Environment.CurrentDirectory + @"\filteredList.bin");
            else
                winsNames = new BindingList<string>();
            filteredWinsList.DataSource = winsNames;
            filteredWinNamesMenu = new ContextMenu();
            filteredWinNamesMenu.MenuItems.Add(new MenuItem("remove", new EventHandler((object sender, EventArgs e) =>
            {
                winsNames.Remove(filteredWinsList.SelectedItem.ToString());
                updateFilterList();
            })));

        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool Repaint);

        private void Main_Load(object sender, EventArgs e)
        {

            LoadWindows();
        }
        List<Window> wins = new List<Window>();
        public void LoadWindows()
        {
            listBox1.Sorted = true;
            IntPtr none = new IntPtr(0);
            foreach (Process p in Process.GetProcesses())
            {
                try
                {
                    // if (!winsNames.Contains(p.ProcessName))
                    //     continue;
                    if (p.MainWindowHandle == none)
                        continue;

                    Window win = new Window(p.MainWindowHandle, p.MainWindowTitle);
                    bool exists = wins.Contains(win);
                    if (!exists && winsNames.Contains(p.ProcessName))
                    {
                        Icon icon = Icon.ExtractAssociatedIcon(p.MainModule.FileName);
                        win.Icon = icon;
                        win.Name = p.ProcessName;
                        WindowItem winItem = new WindowItem(win);
                        winsLayout.Controls.Add(winItem);
                        wins.Add(win);
                        //listBox1.Items.Add(win);
                    }
                    else if (exists)
                    {
                        // Window win_=wins.Find(x => x.Equals(win));
                        wins.Find(x => x.Equals(win));
                        // win_.Title = win.Title;
                        WindowItem winItem;
                        foreach (Control c in winsLayout.Controls)
                        {
                           winItem = (WindowItem)c;
                            if (winItem.win.Equals(win))
                            {
                                winItem.setTitle(win.Title);
                                break;
                            }
                                

                        }
                        // Control winItem =winsLayout.Controls.F


                    }

                }
                catch (Exception ex)
                {

                }

            }
            int y = 0;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Window win = (Window)listBox1.SelectedItem;
            IntPtr p = win.Win;
            MoveWindow(p, 0, 0, 1280, 720, true);
           
            Text = p.ToString();
        }
        BindingList<string> winsNames;
        private void addWinNameBtn_Click(object sender, EventArgs e)
        {

            string winName = addWinTxt.Text.Trim();
            if (!winsNames.Contains(winName))
            {
                winsNames.Add(winName);
                updateFilterList();
                LoadWindows();
            }



        }

        private void filterListMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (filteredWinsList.SelectedItem != null)
                    filteredWinNamesMenu.Show(filteredWinsList, e.Location);
            }

        }
        public void updateFilterList()
        {
            SerializeModel.SerializeObject<BindingList<string>>(winsNames, Environment.CurrentDirectory + @"\filteredList.bin");
        }

        private void updateWinsBtn_Click(object sender, EventArgs e)
        {
            LoadWindows();
        }
    }
}
