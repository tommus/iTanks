using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameFramework;
using GameFramework.Implementation;
using System.IO;
using System.IO.IsolatedStorage;

namespace iTanks.Game
{
    public class Highscores
    {
        #region Fields
        private static int[] starting = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private static int[] scores = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private static String filename = ".highscores";
        #endregion
        #region Methods
        /// <summary>
        /// Metoda sprawdza czy plik z wynikami jest ju� utworzony.
        /// </summary>
        /// <returns>'true' - je�eli plik istnieje, 'false' - je�eli plik nie istnieje.</returns>
        public static Boolean IsCreated()
        {
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();

            Boolean isCreated = file.FileExists(filename);
            file.Dispose();

            return isCreated;
        }

        /// <summary>
        /// Metoda zwraca punktacj� w postaci tablicy s��w.
        /// </summary>
        /// <returns>Reprezentacj� tekstow� tablicy punkt�w.</returns>
        public static String[] GetScores()
        {
            SortScores();

            String[] Sscores = new String[10];
            for (int i = 0; i < scores.Length; ++i )
            {
                Sscores[i] = "" + scores[i];
            }

            return Sscores;
        }

        /// <summary>
        /// Sortuje punktacj� od najwy�szych wynik�w do najni�szych.
        /// </summary>
        public static void SortScores()
        {
            Array.Sort(scores);
            Array.Reverse(scores);
        }

        /// <summary>
        /// Dodaje wynik do punktacji.
        /// </summary>
        /// <param name="score">Wynik, jaki nale�y doda� do punktacji.</param>
        /// <returns>'true' - je�eli wynik zosta� dodany, 'false' - je�eli wynik nie zosta� dodany.</returns>
        public static Boolean Add(int score)
        {
            Boolean added = false;

            if(scores[scores.Length - 1] < score)
            {
                added = true;
                scores[scores.Length - 1] = score;
            }

            SortScores();

            return added;
        }

        /// <summary>
        /// Metoda resetuje punktacj� i tworzy nowy plik przechowuj�cy informacje o punktacji.
        /// </summary>
        public static void Reset()
        {
            for(int i = 0; i < scores.Length; ++i)
            {
                scores[i] = starting[i];
            }
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
            file.DeleteFile(filename);
            file.Dispose();
            CreateFile();
        }

        /// <summary>
        /// Metoda tworzy nowy, pusty plik przechowuj�cy informacje o punktacji.
        /// </summary>
        public static void CreateFile()
        {
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream filestream = file.OpenFile(filename, FileMode.CreateNew);
            StreamWriter writer = new StreamWriter(filestream);

            for (int i = 0; i < starting.Length; ++i)
            {
                writer.WriteLine(starting[i]);
            }

            writer.Close();
            writer.Dispose();
            filestream.Close();
            filestream.Dispose();
            file.Dispose();
        }

        /// <summary>
        /// Metoda zapisuje aktualn� punktacj� do pliku.
        /// </summary>
        public static void SaveHighscores()
        {
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream filestream = file.OpenFile(filename, FileMode.Create);
            StreamWriter writer = new StreamWriter(filestream);

            for (int i = 0; i < scores.Length; ++i)
            {
                writer.WriteLine(scores[i]);
            }

            writer.Close();
            writer.Dispose();
            filestream.Close();
            filestream.Dispose();
            file.Dispose();
        }

        /// <summary>
        /// Metoda odczytuje punktacj� z pliku.
        /// </summary>
        public static void LoadHighscores()
        {
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream filestream = file.OpenFile(filename, FileMode.Open);
            StreamReader reader = new StreamReader(filestream);

            for (int i = 0; i < scores.Length; ++i)
            {
                scores[i] = int.Parse(reader.ReadLine());
            }

            reader.Close();
            reader.Dispose();
            filestream.Close();
            filestream.Dispose();
            file.Dispose();
        }
        #endregion
    }
}