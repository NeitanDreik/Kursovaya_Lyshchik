using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursovaya
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();   //loading user interface
            if (DataFile.Check==false)   //checking "firstOrNot" opening the app
            {
                DataFile.Initialize();
            }
            fieldOfWrites = Zametki.Output(fieldOfWrites);    //call the method which shows main page      
        }

        private void newWrite_Click(object sender, RoutedEventArgs e)    //event handler of the creating new note
        {
            Vvod vvod=new Vvod();
            vvod.Show();
        }

        private void SearchPanel(object sender, TextChangedEventArgs e)    //event handler of the searching notes in the search panel
        {
            if(nameSearch.Text=="")
            {
                fieldOfWrites.Items.Clear();
                fieldOfWrites = Zametki.Output(fieldOfWrites);       //call the method which shows main page              
            }
            else
            {
                fieldOfWrites = Zametki.Search(fieldOfWrites, nameSearch.Text);     //call the method which searching the notes
            }
        }
    }
}
