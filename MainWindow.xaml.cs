using System;
using Microsoft.VisualBasic;
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
using System.Windows.Threading;

namespace CookieClicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double totaal_score = 500000000;
        private double som_optellen = 1;
        private double imgwidth;
        private double passiefInkomen = 0;
        private int[] shop = new int[7] { 0, 0, 0, 0, 0,0,0};
        private double[] prijs = new double[7] { 15, 100, 1100, 12000, 130000,1400000,20000000 };
        private double[] passiefinkomen = new double[7] { 0.001, 0.01, 0.08, .47, 2.60,1.4,7.8};
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            LblCookies.Content = returnAantalCookies();
            this.Title = returnAantalCookies();
            checkIfBuyable();
            updatePrijs();
            opbrengstPassief();
            totaal_score += passiefInkomen;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            imgwidth = ImgCookie.ActualWidth;
        }
        private void ImgCookie_MouseDown(object sender, MouseButtonEventArgs e)
        {

            ImgCookie.Width = imgwidth - 50;
            totaal_score += som_optellen;
        }

        private void ImgCookie_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ImgCookie.Width = imgwidth;

        }

        private void ImgCookie_MouseEnter(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void ImgCookie_MouseLeave(object sender, MouseEventArgs e)
        {
            ImgCookie.Width = imgwidth;
        }

        private string returnAantalCookies()
        {
            return $"{afkortingenGetallen(Math.Round(totaal_score))} cookies";
        }

        private void Btnshop_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case ("Btnshop1"):
                    prijs[0] = investeringPrijs(prijs[0], shop[0]);
                    totaal_score -= prijs[0];
                    shop[0]++;
                    break;
                case ("Btnshop2"):
                    prijs[1] = investeringPrijs(prijs[1], shop[1]);
                    totaal_score -= prijs[1];
                    shop[1]++;
                    break;
                case ("Btnshop3"):
                    prijs[2] = investeringPrijs(prijs[2], shop[2]);
                    totaal_score -= prijs[2];
                    shop[2]++;
                    break;
                case ("Btnshop4"):
                    prijs[3] = investeringPrijs(prijs[3], shop[3]);
                    totaal_score -= prijs[3];
                    shop[3]++;
                    break;
                case ("Btnshop5"):
                    prijs[4] = investeringPrijs(prijs[4], shop[4]);
                    totaal_score -= prijs[4];
                    shop[4]++;
                    break;
                case ("Btnshop6"):
                    prijs[5] = investeringPrijs(prijs[5], shop[5]);
                    totaal_score -= prijs[5];
                    shop[5]++;
                    break;
                case ("Btnshop7"):
                    prijs[6] = investeringPrijs(prijs[6], shop[6]);
                    totaal_score -= prijs[6];
                    shop[6]++;
                    break;
            }
          }

        private void Btnshop_TouchEnter(object sender, TouchEventArgs e)
        {
            ((Button)sender).ToolTip = returnAantalCookies();
        }

        private void checkIfBuyable() {
            Btnshop1.IsEnabled = false;
            Btnshop2.IsEnabled = false;
            Btnshop3.IsEnabled = false;
            Btnshop4.IsEnabled = false;
            Btnshop5.IsEnabled = false;
            Btnshop6.IsEnabled = false;
            Btnshop7.IsEnabled = false;
            if (totaal_score > prijs[0])
            {
                Btnshop1.Visibility = Visibility.Visible;
                Btnshop1.IsEnabled = true;
            }
            if (totaal_score > prijs[1])
            {
                Btnshop2.Visibility = Visibility.Visible;
                Btnshop2.IsEnabled = true;
            }
            if (totaal_score > prijs[2])
            {
                Btnshop3.Visibility = Visibility.Visible;
                Btnshop3.IsEnabled = true;
            }
            if (totaal_score > prijs[3])
            {
                Btnshop4.Visibility = Visibility.Visible;
                Btnshop4.IsEnabled = true;
            }
            if (totaal_score > prijs[4])
            {
                Btnshop5.Visibility = Visibility.Visible;
                Btnshop5.IsEnabled = true;
            }
            if (totaal_score > prijs[5])
            {
                Btnshop6.Visibility = Visibility.Visible;
                Btnshop6.IsEnabled = true;
            }
            if (totaal_score > prijs[6])
            {
                Btnshop7.Visibility = Visibility.Visible;
                Btnshop7.IsEnabled = true;
            }

        }

        private double investeringPrijs(double prijs,int aantalgekocht) {
            if (aantalgekocht == 0) {
                return Math.Round(prijs * 1.15 * 1);
            }
            else
            {
                return Math.Round(prijs * 1.15 * aantalgekocht);
            }
        }

        private void updatePrijs()
        {
            TxtAankoop1.Text = prijs[0].ToString();
            TxtAankoop2.Text = prijs[1].ToString();
            TxtAankoop3.Text = prijs[2].ToString();
            TxtAankoop4.Text = prijs[3].ToString();
            TxtAankoop5.Text = prijs[4].ToString();
            Txtklik1.Text = shop[0].ToString();
            Txtklik2.Text = shop[1].ToString();
            Txtklik3.Text = shop[2].ToString();
            Txtklik4.Text = shop[3].ToString();
            Txtklik5.Text = shop[4].ToString();
        }

        private void opbrengstPassief() {
            passiefInkomen = 0;
            for (int i = 0; i < 7; i++)
            {
                if (totaal_score >= prijs[i])
                {
                    passiefInkomen += (passiefinkomen[i] * shop[i]);
                }
            }
            lblInkomen.Content = $"Passief inkomen: {passiefInkomen.ToString()}";
        }

        private string afkortingenGetallen(double getal)
        {
            string[] afkortingen = new string[7] { "", "", "Miljoen", "Miljard", "Biljoen", "Biljard", "Triljoen" };
            string tekstGetal = "";
            int i = 0;
            if (getal >= 1000000)
            {
                while (getal >= 1000 && i < afkortingen.Length - 1)
                {
                    getal *= 1000;
                    getal /= 1000;
                    getal = Math.Floor(getal);
                    getal /= 1000;
                    i++;
                }
                tekstGetal = $"{getal} {afkortingen[i]}";
            }
            else if (getal >= 1000 && getal <= 1000000)
            {
                tekstGetal = getal.ToString("### ###");
            }
            else
            {
                tekstGetal = $"{getal}";
            }
            return tekstGetal;
        }

        private void LblBakery_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string bakery = Interaction.InputBox("geef een geldige naam in", "toevoegen");

            if (bakery.Contains(" ") || bakery.Length == 0)
            {
                MessageBox.Show("Geef een naam in zonder witruimte er in", "Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                LblBakery.Content = bakery;
            }
        }
    }
}
