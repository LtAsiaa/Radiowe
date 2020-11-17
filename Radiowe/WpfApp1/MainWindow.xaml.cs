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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<PlaceholderInfoClass> InfoList = new List<PlaceholderInfoClass>();
        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNazwaUzytkownika.Text.ToString() == "" || TextBoxLokalizacjaX.Text.ToString() == "" || TextBoxLokalizacjaY.Text.ToString() == "" || TextBoxMocNadawcza.Text.ToString() == "" || TextBoxNumerKanalu.Text.ToString() == "" || TextBoxZyskAnteny.Text.ToString() == "")
                MessageBox.Show("Wprowadź poprawnie dane");
            else {
                ListBoxUzytkownicy.Items.Add(TextBoxNazwaUzytkownika.Text);
                InfoList.Add(new PlaceholderInfoClass(TextBoxNazwaUzytkownika.Text,TextBoxLokalizacjaX.Text,TextBoxLokalizacjaY.Text,TextBoxMocNadawcza.Text,TextBoxZyskAnteny.Text,TextBoxNumerKanalu.Text));
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlaceholderInfoClass usr = InfoList[ListBoxUzytkownicy.SelectedIndex];
            string msg = "nazwa uzytkownika: " + usr.nazwa + Environment.NewLine + "Lokalizacja x: " + usr.x + Environment.NewLine + "Lokalizacja y: " + usr.y + Environment.NewLine + "Moc nadawcza: " + usr.moc + Environment.NewLine + "Zysk: " + usr.zysk + Environment.NewLine + "Nr kanalu: " + usr.nrkanalu;
            MessageBox.Show(msg);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
