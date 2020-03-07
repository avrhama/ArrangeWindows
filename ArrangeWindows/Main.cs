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

        }



        private void Main_Load(object sender, EventArgs e)
        {

            LoadWindows();
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

            
            foreach (WindowItem winItem in winItems)
            {
                scrnCtrl.screenBoardSelected -= winItem.screenBoardSelected;
                scrnCtrl.screenBoardSelected += winItem.screenBoardSelected;
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
    }
}
