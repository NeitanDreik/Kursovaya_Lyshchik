using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Markup;

namespace Kursovaya
{
    static class DataFile
    {
        public static bool Check { get; set; }          //field for checking times of openning the file
        private const string FilePath = "writes.txt"; 
        private static StreamReader fileReader;
        private static StreamWriter fileWriter;

        public static void Initialize()               //method for reading info from file
        {
            fileReader = new StreamReader(FilePath);
            string[] writes;
            string[] costs;
            if (string.IsNullOrEmpty(fileReader.ReadLine()))       //checking on file occupancy
            {
            }
            else 
            {
                fileReader.Close();
                fileReader = new StreamReader(FilePath);
                writes = fileReader.ReadLine().Split("%^@");       //spliting the notes by special separate symbols
                costs = fileReader.ReadLine().Split("%^@");
                for (int i = 0; i < writes.Length - 1; i++)
                { 
                    Zametki.Writes.Add(writes[i]);      //adding notes to lists from file
                    Zametki.Sums.Add(costs[i]);
                }
            }
            Check = true;
            fileReader.Close();
        }
        public static void Save()       //method for saving notes in file
        {
            fileWriter = new StreamWriter(FilePath);
            string writes = "";
            string costs = "";
            for (int i = 0; i < Zametki.Writes.Count; i++)
            {
                writes += Zametki.Writes[i] + "%^@";
            }
            fileWriter.WriteLine(writes);
            for (int i = 0; i < Zametki.Sums.Count; i++)
            {
                costs += Zametki.Sums[i] + "%^@";
            }
            fileWriter.WriteLine(costs);

            fileWriter.Close();
        }
        public static void Delete(int v)             //method for deleting notes from file
        { 
            fileWriter = new StreamWriter(FilePath);
            string writes = "";
            string costs = "";
            for (int i = 0; i < Zametki.Writes.Count; i++)
            {
                if (i != v)
                {
                    writes += Zametki.Writes[i] + "%^@";
                }
            }
            fileWriter.WriteLine(writes);
            for (int i = 0; i < Zametki.Sums.Count; i++)
            {
                if (i != v)
                {
                    costs += Zametki.Sums[i] + "%^@";
                }
            }
            fileWriter.WriteLine(costs);

            fileWriter.Close();
        }
    }
}

