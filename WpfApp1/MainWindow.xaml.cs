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
        BaseStation Base = null;
        User user = null;

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
            else
            {
                ListBoxUzytkownicy.Items.Add(TextBoxNazwaUzytkownika.Text);
                InfoList.Add(new PlaceholderInfoClass(TextBoxNazwaUzytkownika.Text, TextBoxLokalizacjaX.Text, TextBoxLokalizacjaY.Text, TextBoxMocNadawcza.Text, TextBoxZyskAnteny.Text, TextBoxNumerKanalu.Text));
            }

        }
        //wytłumacznie zmiennych dla kontrolera, gui i bazy danych:
        //x_b - położenie stacji w osi x (zakładamy rodzaj podanych danych 0 - 200 każdemy indeksowi odpowiada 100 metrów tj. 0 - 0m 1 - 100m, 2 - 200m
        //y_b to samo co wyżej tylko w osi y 
        // przykład
        // 0 1 2 3 4
        // 1              S- stacja bazowa - to oznaczenie oznacza, że stacja bazowa znajduje się 400 metrów od prawej krawedzi i 400 metrów od górnej krawedzi
        // 2
        // 3
        // 4       S
        // antena_gain_base - zysk anteny dla stacji nadawczej
        // power_base -moc nadawcza stacji bazowej
        private void BaseStationInitialization(int x_b, int y_b,int antena_gain_base,int power_base)
        {
            // stworzenie stacji nadawczej:
            Base = new BaseStation(x_b, y_b, antena_gain_base, power_base);
        }
        // oznaczenia te same co dla stacji 
        // channel_number - numer kanału - warto aby GUI dodało sprawdzanie wpisywanych danych bo my w żaden sposob nie sprawdzamy czy kanał znajduje się w zakresie 1-10 - jeśli nie dacie rady to dajcie znać my zrobimy mechanizm sprawdzjący
        private void UserInitialization(int x_u,int y_u, int antena_gain_user,int channel_number)
        {
            user = new User(x_u, y_u, antena_gain_user, channel_number);
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
