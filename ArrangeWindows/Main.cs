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
using System.Windows;

namespace ArrangeWindows
{
    public partial class Main : Form
    {
        ContextMenu favoritesWinsMenu;
        public Main()
        {
            InitializeComponent();
           
            if (System.IO.File.Exists(Environment.CurrentDirectory + @"\filteredList.bin"))
                favoritesWins = SerializeModel.DeSerializeObject<BindingList<string>>(Environment.CurrentDirectory + @"\filteredList.bin");
            else
                favoritesWins = new BindingList<string>();
            favoritesWinsList.DataSource = favoritesWins;
            favoritesWinsMenu = new ContextMenu();
            favoritesWinsMenu.MenuItems.Add(new MenuItem("remove", new EventHandler((object sender, EventArgs e) =>
            {
                favoritesWins.Remove(favoritesWinsList.SelectedItem.ToString());
                updateFavoritesList();
            })));

            var device = new User32.DISPLAY_DEVICE();
            for (int i = 0; i < Screen.AllScreens.Length; i++)
                {
                Screen screen = Screen.AllScreens[i];
                   
                    device.cb = Marshal.SizeOf(device);
                    User32.EnumDisplayDevices(device.DeviceName, 0, ref device, 0);
                ScreenController scrnControl = new ScreenController(screen,device.DeviceString,i);
                    scrnCtrlsLayout.Controls.Add(scrnControl);

                Profile.WorkingSetForm.setMonitor(screen.Bounds.Width,screen.Bounds.Height, device.DeviceString);
                } 
                
            

            
        }


       
        private void Main_Load(object sender, EventArgs e)
        {
             LoadWindows();
            subscribesEvents();
        }
        public void subscribesEvents()
        {
           
            saveBtn.Click += new EventHandler((object sender, EventArgs e) =>
            {
               
                Profile.WorkingSet workingSet = new Profile.WorkingSet();
                workingSet.profiles = new Profile.Profile[scrnCtrlsLayout.Controls.Count];
                for(int i=0; i< workingSet.profiles.Length;i++)
                {
                    ScreenController screenCtrl = (ScreenController)scrnCtrlsLayout.Controls[i];
                    Profile.Profile p = screenCtrl.createProfile();
                    workingSet.profiles[i] = p;
                }
                Profile.WorkingSetForm.setWorkingSet(workingSet);
                Profile.WorkingSetForm.open();
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
                ScreenController[] screenControllers = new ScreenController[scrnCtrlsLayout.Controls.Count];
                for (int i = 0; i < screenControllers.Length; i++)
                {
                    screenControllers[i] = (ScreenController)scrnCtrlsLayout.Controls[i];
                    screenControllers[i].createRestore();
                }
                Profile.WorkingSetForm.loadWorkSets(screenControllers);
                Profile.WorkingSetForm.open();


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
        List<WindowItem> winItems = new List<WindowItem>();
        public void LoadWindows()
        {
            listBox1.Sorted = true;
            foreach (Process p in Process.GetProcesses())
            {
                try
                {
                    // if (!winsNames.Contains(p.ProcessName))
                    //     continue;
                    if (p.MainWindowHandle.Equals(IntPtr.Zero))
                        continue;

                    Window win = new Window(p.MainWindowHandle, p.MainWindowTitle);
                   // bool exists = winItems.Exists(x=>x.Win.Equals(win));
                    WindowItem existsWinItm = winItems.Find(x => x.Win.Equals(win));
                    bool favorite = favoritesWins.Contains(p.ProcessName);
                    if (existsWinItm==null && (showAllCheck.Checked||favorite))
                    {
                        
                        Icon icon = Icon.ExtractAssociatedIcon(p.MainModule.FileName);
                        win.Icon = icon;
                        win.Name = p.ProcessName;
                        WindowItem winItem = new WindowItem(win, favorite);
                        winItem.AddFavoritEvent += addFavorite;
                        winsLayout.Controls.Add(winItem);
                        winItems.Add(winItem);
                        p.EnableRaisingEvents = true;
                        p.Exited += windowClosed;
                    }
                    else if (existsWinItm!=null)
                    {
                        if (!showAllCheck.Checked)
                            if (!favoritesWins.Contains(p.ProcessName))
                            {
                                winItems.Remove(existsWinItm);
                                winsLayout.Controls.Remove(existsWinItm);

                                continue;
                            }
                                
                        WindowItem winItem = winItems.Find(x => x.Win.Equals(win));
                        winItem.setTitle(win.Title);
                    }

                }
                catch (Exception ex)
                {

                }

            }

            
          
            foreach (ScreenController screenController in scrnCtrlsLayout.Controls)
            {
                foreach (WindowItem winItem in winItems)
                {
                    screenController.screenBoardSelected -= winItem.screenBoardSelected;
                    screenController.screenBoardSelected += winItem.screenBoardSelected;
                }
            }

        }

        private void windowClosed(object sender, EventArgs e)
        {
            Process p = (Process)sender;
            Window win = new Window(p.MainWindowHandle, p.ProcessName);
            
            WindowItem existsWinItm = winItems.Find(x => x.Win.Equals(win));
            if(existsWinItm!=null)
            {
                winsLayout.Controls.Remove(existsWinItm);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            //Graphics g = CreateGraphics();

            // MoveWindow(p, 0, 0, 1280, 720, true);

            //Text = p.ToString();
        }
        BindingList<string> favoritesWins;
        private void addWinNameBtn_Click(object sender, EventArgs e)
        {

            string winName = addWinTxt.Text.Trim();
            if (!favoritesWins.Contains(winName))
            {
                favoritesWins.Add(winName);
                updateFavoritesList();
                LoadWindows();
            }

        }
        public void addFavorite(WindowItem winItem,bool favorite)
        {
            if (favorite)
            {
                favoritesWins.Remove(winItem.Win.Name);
                if(!showAllCheck.Checked)
                LoadWindows();
            }
            else
            {
                winItem.Favorite = true;
               favoritesWins.Add(winItem.Win.Name);

            }
            updateFavoritesList();

        }
        private void filterListMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (favoritesWinsList.SelectedItem != null)
                    favoritesWinsMenu.Show(favoritesWinsList, e.Location);
            }

        }
        public void updateFavoritesList()
        {
            SerializeModel.SerializeObject<BindingList<string>>(favoritesWins, Environment.CurrentDirectory + @"\filteredList.bin");
        }

        private void updateWinsBtn_Click(object sender, EventArgs e)
        {
            LoadWindows();
        }

        private void showAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            
            LoadWindows();
        }
        private void profilesBtn_Click(object sender, EventArgs e)
        {

            Profile.WorkingSetForm.open();
        }

        private void workingSetBtn_Click(object sender, EventArgs e)
        {
            Profile.WorkingSetForm.open();
        }
    }
}
