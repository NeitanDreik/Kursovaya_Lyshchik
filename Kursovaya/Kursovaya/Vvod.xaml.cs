using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kursovaya
{

    public partial class Vvod : Window
    {
        private double sum;       
        private bool isOpened=false;      //field to check visibility of panel
        public Vvod()         //constructor of class for creating a new note
        {
            InitializeComponent();
            date.Text = DateTime.Now.ToString();       //filling the date field
            Button button = new Button();              
            button.Click += More_Click;                //creating an event handler for button which calling the method which creating textboxes and so on in the panel "autocalculator of purchases"
            button.Height = 24;
            button.Width = 64;
            button.FontSize = 10;
            button.Margin = new Thickness(15, 12, 0, 0);
            button.Content = "Добавить";
            costs.Items.Add(button);
        }
        public Vvod(string date, string write, string sums)     //constructor of class for editing notes
        {
            InitializeComponent();
            this.date.Text = date;         //update the date field
            fieldToWrite.Text = write;      //update the text field
            string[] s = sums.Split(",");    //split array in "," symbol
            for (int j=4;j<s.Length;j++)   //creating a new textbox for cost if it need
            {
                 TextBox textbox = new TextBox();
                 textbox.Height = 16;
                 textbox.Width = 95;
                 textbox.TextChanged += Sum_TextChanged;
                 costs.Items.Add(textbox);
            }
            Button button = new Button();
            button.Click += More_Click;
            button.Height = 24;
            button.Width = 64;
            button.FontSize = 10;
            button.Margin = new Thickness(15, 12, 0, 0);
            button.Content = "Добавить";
            costs.Items.Add(button);
            for (int i = 0; i < costs.Items.Count - 1; i++)               //filling textboxes with text
            {
                if (s[i] != "")
                {
                    ((TextBox)costs.Items[i]).Text = s[i];
                }
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)           //event handler for the button "delete"
        {
            for (int i = 0; i < Zametki.Writes.Count; i++)                     
            {
                if (date.Text == Zametki.Writes[i].Substring(0, 19))           //compares data from notes with data from note that should be deleted
                {
                    Zametki.Writes.Remove(Zametki.Writes[i]);                  //removing note
                    Zametki.Sums.Remove(Zametki.Sums[i]);
                    DataFile.Delete(i);                                        //call the method of deleting note from file
                    break;
                }
            }
            foreach (Window wind in App.Current.Windows)                       //checking opened windows and closing it if it's the main
            {
                if (wind is MainWindow)
                    wind.Close();
            }
            MainWindow window = new MainWindow();                              //creating and opening new main window
            window.Show();
            Close();
        }
            private void Save_Click(object sender, RoutedEventArgs e)          //event hadler for the button "save"
            {         
            for(int i=0;i<Zametki.Writes.Count;i++)
            {
                if(date.Text==Zametki.Writes[i].Substring(0,19))               //deleting the old note
                {
                    Zametki.Writes.Remove(Zametki.Writes[i]);
                    Zametki.Sums.Remove(Zametki.Sums[i]);
                    break;
                } 
            }           
                date.Text = DateTime.Now.ToString();
                Zametki.Writes.Add(date.Text + fieldToWrite.Text);             //adding edited note
                string s = "";
                for(int i=0; i<costs.Items.Count-1; i++)
                {
                    TextBox textbox = (TextBox)costs.Items[i];
                    if (textbox.Text == "")
                    {
                        s += " ,";
                    }
                    else
                    {
                        s += textbox.Text + ",";
                    }
                }
                Zametki.Sums.Add(s);
                DataFile.Save();                                             //call the method of saving note in the file
            foreach (Window wind in App.Current.Windows)                     //checking opened windows and closing it if it's the main
            {
                if (wind is MainWindow)
                    wind.Close();
            }
            MainWindow window = new MainWindow();                            //creating and opening new main window
            window.Show();
            Close();
        }
        private void Autocal_Click(object sender, RoutedEventArgs e)        //event handler for the button "autocalculator purchases"
        {           
            if (isOpened==true)
            {
                fieldOfNumbers.Visibility = Visibility.Hidden;              //if it's closed it is hidden
                isOpened = false;
            }
            else
            {
                fieldOfNumbers.Visibility = Visibility.Visible;             //if it's opened it's visible
                isOpened = true;

            }
        }
        private void More_Click(object sender, RoutedEventArgs e)          //event handler for the button "add more"
        {
            TextBox textbox = new TextBox();
            textbox.Height = 16;
            textbox.Width = 95;
            textbox.TextChanged += Sum_TextChanged;
            Button button = new Button();
            button.Click += More_Click;
            button.Height = 24;
            button.Width = 64;
            button.FontSize = 10;
            button.Margin = new Thickness(15, 12, 0, 0);
            button.Content = "Добавить";
            costs.Items.RemoveAt(costs.Items.Count-1);
            costs.Items.Add(textbox);
            costs.Items.Add(button);
        }

        private void Sum_TextChanged(object sender, TextChangedEventArgs e)          //event handler for changing text in textboxes in the costs panel
        {
            SumText.Text = "Сумма: ";
            sum = 0;
            for (int i = 0; i < costs.Items.Count-1; i++)
            {
                    TextBox textbox = (TextBox)costs.Items[i];
                    if (double.TryParse(textbox.Text, out _))                         //converts the string representation to its integer equivalent // _ help us not to create a special variable before converting
                {                                                                     
                        double a = double.Parse(textbox.Text);
                        sum += a;
                    } 
            }
            SumText.Text += $"\n{sum}";                                                //printing sum of costs in textbox
        }
    }
}
