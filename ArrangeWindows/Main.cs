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
                    bool exists = winItems.Exists(x=>x.Win.Equals(win));
                    if (!exists && winsNames.Contains(p.ProcessName))
                    {
                        
                        Icon icon = Icon.ExtractAssociatedIcon(p.MainModule.FileName);
                        win.Icon = icon;
                        win.Name = p.ProcessName;
                        WindowItem winItem = new WindowItem(win);
                        winsLayout.Controls.Add(winItem);
                        winItems.Add(winItem);
                    }
                    else if (exists)
                    {
                        // Window win_=wins.Find(x => x.Equals(win));
                        WindowItem winItem = winItems.Find(x => x.Win.Equals(win));
                        winItem.setTitle(win.Title);
                        // win_.Title = win.Title;
                        //WindowItem winItem;
                      /*  foreach (Control c in winsLayout.Controls)
                        {
                           winItem = (WindowItem)c;
                            if (winItem.win.Equals(win))
                            {
                                winItem.setTitle(win.Title);
                                break;
                            }
                                

                        }*/
                        // Control winItem =winsLayout.Controls.F


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

        


        
        public void getImage(IntPtr p)
        {

            

            var r = new User32.WINDOWPLACEMENT();
            User32.GetWindowPlacement(p,ref r);
            var rect = r.rcNormalPosition;
            int width =(int)Math.Floor((rect.right - rect.left) * 2.5);
            int height = (int)Math.Floor((rect.bottom - rect.top) * 2.5);

            //width=width*2;
            // height = height*2;
            Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics gfxBmp = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfxBmp.GetHdc();

            bool restore = false; ;
            User32.WindowState showCmd = (User32.WindowState)r.showCmd;
            switch (showCmd)
            {
                case User32.WindowState.SW_HIDE:
                case User32.WindowState.SW_MINIMIZE:
                case User32.WindowState.SW_SHOWMINIMIZED:
                    restore = true;
                    break;
            }
            if (restore)
            {
                User32.ChangeTransparent(p);
                User32.ShowWindow(p, (UInt32)User32.WindowState.SW_RESTORE);
            }
            User32.PrintWindow(p, hdcBitmap, 0);
            if (restore)
            {
                User32.ShowWindow(p, r.showCmd);
                User32.ChangeTransparent(p);
            }

            gfxBmp.ReleaseHdc(hdcBitmap);
            gfxBmp.Dispose();

            bmp.Save(@"C:\Users\Brain\Pictures\temp\vlc.png", System.Drawing.Imaging.ImageFormat.Png);
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
           

            //Graphics g = CreateGraphics();

            // MoveWindow(p, 0, 0, 1280, 720, true);

            //Text = p.ToString();
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
