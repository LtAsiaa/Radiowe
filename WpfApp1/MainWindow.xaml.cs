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
        private void ButtonDodajUzytkownika_Click(object sender, RoutedEventArgs e)
        {


            if (TextBoxLokalizacjaX.Text.ToString() == "" ||
                TextBoxLokalizacjaY.Text.ToString() == "" ||
                TextBoxMocNadawcza.Text.ToString() == "" ||
                TextBoxNumerKanalu.Text.ToString() == "" ||
                TextBoxZyskAnteny.Text.ToString() == "" ||
                System.Text.RegularExpressions.Regex.IsMatch(TextBoxLokalizacjaX.Text, "[^0-9]") ||
                System.Text.RegularExpressions.Regex.IsMatch(TextBoxLokalizacjaY.Text, "[^0-9]") ||
                System.Text.RegularExpressions.Regex.IsMatch(TextBoxMocNadawcza.Text, "[^.,0-9]") ||
                System.Text.RegularExpressions.Regex.IsMatch(TextBoxNumerKanalu.Text, "[^0-9]") ||
                System.Text.RegularExpressions.Regex.IsMatch(TextBoxZyskAnteny.Text, "[^.,0-9]"))
            {
                MessageBox.Show("Wprowadź poprawnie dane. Akceptowalne są tylko liczby(0-9) w polach Lokalizacja(X,Y) i Numer kanału, w polach Moc nadawcza i Zysk anteny dodatkowo dostępne są znaki('.' i ',')");
            }
            else
            {
                double _mocNadawcza = Convert.ToDouble(TextBoxMocNadawcza.Text.Replace('.', ','));
                if (ComboBoxM.Text == "µW")
                {
                    _mocNadawcza /= 1000000;
                }
                else if (ComboBoxM.Text == "mW")
                {
                    _mocNadawcza /= 1000;
                }
                else if (ComboBoxM.Text == "kW")
                {
                    _mocNadawcza *= 1000;
                }
                else if (ComboBoxM.Text == "dBm")
                {
                    _mocNadawcza = Math.Pow(10, (_mocNadawcza - 30) / 10);
                }
                //TextBoxTest.Text = f.ToString();

                double _zyskAnteny = Convert.ToDouble(TextBoxZyskAnteny.Text.Replace('.', ','));
                if (ComboBoxZ.Text == "µW")
                {
                    _zyskAnteny /= 1000000;
                }
                else if (ComboBoxZ.Text == "mW")
                {
                    _zyskAnteny /= 1000;
                }
                else if (ComboBoxZ.Text == "kW")
                {
                    _zyskAnteny *= 1000;
                }
                else if (ComboBoxZ.Text == "dBm")
                {
                    _zyskAnteny = Math.Pow(10, (_zyskAnteny - 30) / 10);
                }
                //TextBoxTest.Text = f.ToString();
                ListBoxUzytkownicy.Items.Add(TextBoxNazwaUzytkownika.Text);
                InfoList.Add(new PlaceholderInfoClass(TextBoxNazwaUzytkownika.Text,
                    int.Parse(TextBoxLokalizacjaX.Text),
                    int.Parse(TextBoxLokalizacjaY.Text),
                    _mocNadawcza,
                    _zyskAnteny,
                    int.Parse(TextBoxNumerKanalu.Text)));
            }


        }
        private void ComboBoxM_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxM.SelectedItem = "W";
            ComboBoxM.Items.Add("µW");
            ComboBoxM.Items.Add("mW");
            ComboBoxM.Items.Add("W");
            ComboBoxM.Items.Add("kW");
            ComboBoxM.Items.Add("dBm");
        }

        private void ComboBoxZ_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxZ.SelectedItem = "W";
            ComboBoxZ.Items.Add("µW");
            ComboBoxZ.Items.Add("mW");
            ComboBoxZ.Items.Add("W");
            ComboBoxZ.Items.Add("kW");
            ComboBoxZ.Items.Add("dBm");
        }

        private void ButtonUsunUzytkownika_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxUzytkownicy.SelectedItem != null)
            {
                InfoList.RemoveAt(ListBoxUzytkownicy.SelectedIndex);
                ListBoxUzytkownicy.Items.Remove(ListBoxUzytkownicy.SelectedItem);
                //TextBoxTest.Text = ListBoxUzytkownicy.SelectedIndex.ToString();

                //ListBoxUzytkownicy.Items.Add(TextBoxNazwaUzytkownika.Text);
                TextBoxTest.Text = "ok";
            }
            else
            {
                TextBoxTest.Text = "null";
            }
        }

        private void ButtonPokazDaneUzytkownika_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxUzytkownicy.SelectedItem != null)
            {
                PlaceholderInfoClass usr = InfoList[ListBoxUzytkownicy.SelectedIndex];
                string msg = "nazwa uzytkownika: " + usr.nazwa + Environment.NewLine + "Lokalizacja x: " + usr.x + Environment.NewLine + "Lokalizacja y: " + usr.y + Environment.NewLine + "Moc nadawcza: " + usr.moc + " W" + Environment.NewLine + "Zysk: " + usr.zysk + " W" + Environment.NewLine + "Nr kanalu: " + usr.nrkanalu;
                MessageBox.Show(msg);
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
            ///
        }



    }
}
