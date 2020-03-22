using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrangeWindows.Settings
{
   public class Settings
    {
        public BindingList<string> FavoritesWins { set; get; }
       public Action listUpdated;
        public static String WorkSetPath { set; get; }
        public static String FavoritesListPath { set; get; }
        public Settings()
        {
            if (System.IO.File.Exists(Environment.CurrentDirectory + @"\paths.txt"))
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(Environment.CurrentDirectory + @"\paths.txt");
                FavoritesListPath =sr.ReadLine();
                WorkSetPath = sr.ReadLine();
                sr.Close();

            }
            else
            {
                FavoritesListPath = Environment.CurrentDirectory;
                WorkSetPath = Environment.CurrentDirectory;
                updatePaths();

            }
            if (System.IO.File.Exists( FavoritesListPath + @"\favoritesList.bin"))
                FavoritesWins = SerializeModel.DeSerializeObject<BindingList<string>>(FavoritesListPath + @"\favoritesList.bin");
            else
                FavoritesWins = new BindingList<string>();
               
                
        }
        public void updatePaths()
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(Environment.CurrentDirectory + @"\paths.txt");
            sw.WriteLine(FavoritesListPath);
            sw.WriteLine(WorkSetPath);
            sw.Close();
        }
        public void updateFavoritesList()
        {
            SerializeModel.SerializeObject<BindingList<string>>(FavoritesWins, FavoritesListPath + @"\favoritesList.bin");
            listUpdated?.Invoke();
        }

    }
}
