using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Kursovaya
{
    class Zametki
    {
        private static List<string> sums = new List<string>();       //list of costs in notes
        public static List<string> Sums                                              
        { 
            get
            {
                return sums;
            }

        }
        private static List<string> writes = new List<string>();      //list of notes
        public static List<string> Writes
        {
            get
            {
                return writes;
            }
        }       
        public static ListBox Output(ListBox listbox)                 //method which shows the main page and creating there existing notes
        {
            if (writes.Count != 0)
            {
                for (int i = writes.Count-1; i >=0; i--)
                {
                    Button button = new Button();
                    button.Width = 778;
                    button.Height = 23;
                    button.HorizontalContentAlignment = HorizontalAlignment.Left;
                    button.Content = "(" + writes[i].Substring(0, 19) + ") " + writes[i].Substring(19);
                    button.AddHandler(Button.ClickEvent, new RoutedEventHandler(openWrite));
                    listbox.Items.Add(button);
                }
            }
            return listbox;
        }
        private static void openWrite(object sender, RoutedEventArgs e)        //event handler for opening the note from the list of them
        {
            for (int i = 0; i < writes.Count; i++)
            { 
                if (((Button)e.OriginalSource).Content.ToString().Substring(1,19) == writes[i].Substring(0,19))     //compares date on button with date of note you want to edit
                {
                    Vvod vvod = new Vvod(writes[i].Substring(0, 19), writes[i].Substring(19), sums[i]); 
                    vvod.Show();
                    break;
                }
            }
        }
        public static ListBox Search(ListBox listbox, string stroka)        //method which searching notes in list
        {
            listbox.Items.Clear();
            List<int> ind = new List<int>();
            for(int i=0;i<writes.Count;i++)           //number of notes
            {               
                string s = writes[i].Substring(19);     
                int t = s.Length;
                for (int j = 0; j <= s.Length - 1; j++)   //length of note
                {
                    for (int q = t; q >= 1; q--)          //cycle for checking all the word and every symbol
                    {                                     //record the substring from note from j symbol to q symbols ahead
                        string c = s.Substring(j, q);     //checking user text in searh field with this substring
                        if (stroka == c)
                        {
                            ind.Add(i);
                        }
                    }
                if (t > 1)
                      t--;
                else
                     break;
                }
            }
            int p;
            for (int i = 0; i < ind.Count; i++)          //cycle for deleting repeating letters
            {
                p = ind[i];
                ind.RemoveAll(x => x == ind[i]);
                ind.Add(p);
            }
            for(int k=0;k<ind.Count;k++)                 //cycle for output found notes
            {
                Button button = new Button();
                button.Width = 778;
                button.Height = 22;
                button.HorizontalContentAlignment = HorizontalAlignment.Left;
                button.Content = "(" + writes[ind[k]].Substring(0, 19) + ") " + writes[ind[k]].Substring(19);
                button.AddHandler(Button.ClickEvent, new RoutedEventHandler(openWrite));
                listbox.Items.Add(button);
            }
            if (listbox.Items.Count==0)      //condition in which there weren't found some coincidences
            {     
                listbox.Items.Add(new TextBlock().Text="Совпадений не найдено:(");
            }
            return listbox;
        }
    }
}
