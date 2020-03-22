using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrangeWindows.Settings
{
    public partial class settingsForm : Form
    {

        ContextMenu favoritesWinsMenu;


        public settingsForm(Settings settings)
        {
            InitializeComponent();
            TopMost = true;
            favoritesWinsMenu = new ContextMenu();
            favoritesWinsMenu.MenuItems.Add(new MenuItem("remove", new EventHandler((object sender, EventArgs e) =>
            {
                settings.FavoritesWins.Remove(favoritesWinsList.SelectedItem.ToString());
                settings.updateFavoritesList();
            })));
            favoritesWinsList.DataSource = settings.FavoritesWins;
            favoritesListPathLbl.Text ="Favorites Dir:"+Settings.FavoritesListPath;
            workSetsPathLbl.Text ="Worksets Dir:"+Settings.WorkSetPath;

            ToolTip tt = new ToolTip();
            favoritesListPathLbl.MouseHover += new EventHandler((object sender, EventArgs e) =>
            {
                tt.Show(Settings.FavoritesListPath, favoritesListPathLbl, 5000);
            });
            workSetsPathLbl.MouseHover += new EventHandler((object sender, EventArgs e) =>
            {
                tt.Show(Settings.WorkSetPath, workSetsPathLbl, 5000);
            });
            this.settings = settings;


        }

        Settings settings;
        private void addWinNameBtn_Click(object sender, EventArgs e)
        {

            string winName = addWinTxt.Text.Trim();
            if (winName == "")
                return;
            if (!settings.FavoritesWins.Contains(winName))
            {
                settings.FavoritesWins.Add(winName);
                settings.updateFavoritesList();
            }
        }

        private void updateWinsBtn_Click(object sender, EventArgs e)
        {
            settings.updateFavoritesList();
        }
        private void favoritesListMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (favoritesWinsList.SelectedItem != null)
                    favoritesWinsMenu.Show(favoritesWinsList, e.Location);
            }

        }

        private void browserBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "program files (*.exe)|*.exe";
            DialogResult dr= openFileDialog.ShowDialog();
            if (dr != DialogResult.OK)
                return;
            Regex re = new Regex(@".+\\(?<programName>.+)(\.exe)");
            
            foreach (string proPath in openFileDialog.FileNames)
            {
                Match m = re.Match(proPath);
                if(m.Groups["programName"].Success)
                if (!settings.FavoritesWins.Contains(m.Groups["programName"].Value))
                    settings.FavoritesWins.Add(m.Groups["programName"].Value);
            }
            if(openFileDialog.FileNames.Length>0)
               settings.updateFavoritesList();


        }

        private void favoritesListBrowserBtn_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog openFolderDialog=new FolderBrowserDialog();
            openFolderDialog.ShowNewFolderButton = true;
            DialogResult dr = openFolderDialog.ShowDialog();
            if (dr != DialogResult.OK)
                return;
            if (openFolderDialog.SelectedPath.Length > 0)
            {
                Settings.FavoritesListPath = openFolderDialog.SelectedPath;
                favoritesListPathLbl.Text = "Favorites Dir:" + Settings.FavoritesListPath;
                settings.updatePaths();
            }
        }

        private void workSetsPathBrowserBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
            openFolderDialog.ShowNewFolderButton = true;
            DialogResult dr = openFolderDialog.ShowDialog();
            if (dr != DialogResult.OK)
                return;
            if (openFolderDialog.SelectedPath.Length > 0)
            {
                Settings.WorkSetPath = openFolderDialog.SelectedPath;
                workSetsPathLbl.Text = "Worksets Dir:" + Settings.WorkSetPath;
                settings.updatePaths();
            }
        }
    }
}
