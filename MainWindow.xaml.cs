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
        private bool iscookievisible = false;
        public static List<string> achievements = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += timer_Tick;
            timer.Start();
            DispatcherTimer goldencookie = new DispatcherTimer();
            goldencookie.Interval = TimeSpan.FromMinutes(1);
            goldencookie.Tick += goldencookie_tick;
            goldencookie.Start();
        }

        private void goldencookie_tick(object sender, EventArgs e)
        {
            Random cookieRandom = new Random();
            if (cookieRandom.Next(1, 101) <= 30)
            {
                if (!iscookievisible)
                {

                    Image goldencookie = new Image
                    {
                        Source = new BitmapImage(new Uri("pack://application:,,,/goldencookie.png")),
                        Width = 35,
                        Height = 35,
                        Cursor = Cursors.Hand
                    };
                    Canvas.SetLeft(goldencookie, cookieRandom.Next((int)ActualWidth - 40));
                    Canvas.SetTop(goldencookie, cookieRandom.Next((int)ActualHeight - 40));


                    goldencookie.MouseLeftButtonDown += GoldenCookie_MouseLeftButtonDown;


                    CanvasGoldencookie.Children.Add(goldencookie);


                    iscookievisible = true;
                }
            }
        }

        private void GoldenCookie_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            totaal_score += (passiefInkomen * 900);
            iscookievisible = false;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            LblCookies.Content = returnAantalCookies();
            this.Title = returnAantalCookies();
            checkIfBuyable();
            updatePrijs();
            opbrengstPassief();
            totaal_score += passiefInkomen;
            checkAchievements();
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
                    ImgAddChilds("cursorbg.jpg","cursor.png",StackCursor);
                    break;
                case ("Btnshop2"):
                    prijs[1] = investeringPrijs(prijs[1], shop[1]);
                    totaal_score -= prijs[1];
                    ImgAddChilds("grandmabg.jpg", "grandma.png", StackGrandma);
                    shop[1]++;
                    break;
                case ("Btnshop3"):
                    prijs[2] = investeringPrijs(prijs[2], shop[2]);
                    totaal_score -= prijs[2];
                    ImgAddChilds("farmbg.jpg", "farm.jpg", StackFarm);
                    shop[2]++;
                    break;
                case ("Btnshop4"):
                    prijs[3] = investeringPrijs(prijs[3], shop[3]);
                    totaal_score -= prijs[3];
                    ImgAddChilds("minebg.jpg", "mine.png", StackMine);
                    shop[3]++;
                    break;
                case ("Btnshop5"):
                    prijs[4] = investeringPrijs(prijs[4], shop[4]);
                    totaal_score -= prijs[4];
                    ImgAddChilds("factorybg.jpg", "factory.jpg", StackFactory);
                    shop[4]++;
                    break;
                case ("Btnshop6"):
                    prijs[5] = investeringPrijs(prijs[5], shop[5]);
                    totaal_score -= prijs[5];
                    ImgAddChilds("bankbg.jpg", "bank.jpg", StackBank);
                    shop[5]++;
                    break;
                case ("Btnshop7"):
                    prijs[6] = investeringPrijs(prijs[6], shop[6]);
                    totaal_score -= prijs[6];
                    ImgAddChilds("templebg.jpg", "temple.jpg", StackMine);
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
            TxtAankoop1.Text = afkortingenGetallen(prijs[0]).ToString();
            TxtAankoop2.Text = afkortingenGetallen(prijs[1]).ToString();
            TxtAankoop3.Text = afkortingenGetallen(prijs[2]).ToString();
            TxtAankoop4.Text = afkortingenGetallen(prijs[3]).ToString();
            TxtAankoop5.Text = afkortingenGetallen(prijs[4]).ToString();
            TxtAankoop6.Text = afkortingenGetallen(prijs[5]).ToString();
            TxtAankoop7.Text = afkortingenGetallen(prijs[6]).ToString();
            Txtklik1.Text = afkortingenGetallen(shop[0]).ToString();
            Txtklik2.Text = afkortingenGetallen(shop[1]).ToString();
            Txtklik3.Text = afkortingenGetallen(shop[2]).ToString();
            Txtklik4.Text = afkortingenGetallen(shop[3]).ToString();
            Txtklik5.Text = afkortingenGetallen(shop[4]).ToString();
            Txtklik6.Text = afkortingenGetallen(shop[5]).ToString();
            Txtklik7.Text = afkortingenGetallen(shop[6]).ToString();
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
            string bakery = Interaction.InputBox("Geef een naam in: ", "Change name");

            if (bakery.Contains(" ") || bakery.Length == 0)
            {
                MessageBox.Show("Geef een naam in zonder witruimte er in", "Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                LblBakery.Content = bakery;
            }
        }


        private void ImgAddChilds(string backgroundname, string imagename,StackPanel panel)
        {
            ImageBrush imgBackground = new ImageBrush();
            imgBackground.ImageSource = new BitmapImage(new Uri($"pack://application:,,,/{backgroundname}"));
            imgBackground.Stretch = Stretch.Fill;
            imgBackground.TileMode = TileMode.Tile;
            panel.Background = imgBackground;
            Image imagechild = new Image();
            imagechild.Source = new BitmapImage(new Uri($"pack://application:,,,/{imagename}"));
            imagechild.Height = 100;
            imagechild.Width = 100;
            panel.Children.Add(imagechild);
        }

        private void checkAchievements() { 
            if(totaal_score > 10 && (achievements.Contains("10 score gehaald!") == false))
            {
                achievements.Add("10 score gehaald!");
                MessageBox.Show("10 score gehaald!");
            }
            else if (totaal_score > 100 && (achievements.Contains("100 score gehaald!") == false))
            {
                achievements.Add("100 score gehaald!");
                MessageBox.Show("100 score gehaald!");
            }
            else if (totaal_score > 1000 && (achievements.Contains("1000 score gehaald!") == false))
            {
                achievements.Add("1000 score gehaald!");
                MessageBox.Show("1000 score gehaald!");
            }
            else if (totaal_score > 10000 && (achievements.Contains("10000 score gehaald!") == false))
            {
                achievements.Add("10000 score gehaald!");
                MessageBox.Show("10000 score gehaald!");
            }
            else if (totaal_score > 10000 && (achievements.Contains("10000 score gehaald!") == false))
            {
                achievements.Add("10000 score gehaald!");
                MessageBox.Show("10000 score gehaald!");
            }
            else if (totaal_score > 100000 && (achievements.Contains("100000 score gehaald!") == false))
            {
                achievements.Add("100000 score gehaald!");
                MessageBox.Show("100000 score gehaald!");
            }
            else if (shop[0] == 10 && (achievements.Contains("10 cursors gekocht!") == false))
            {
                achievements.Add("10 cursors gekocht!");
                MessageBox.Show("10 cursors gekocht!");
            }
            else if (shop[1] == 10 && (achievements.Contains("10 grandmas gekocht!") == false))
            {
                achievements.Add("10 grandmas gekocht!");
                MessageBox.Show("10 grandmas gekocht!");
            }
            else if (shop[2] == 10 && (achievements.Contains("10 farms gekocht!") == false))
            {
                achievements.Add("10 farms gekocht!");
                MessageBox.Show("10 farms gekocht!");
            }
            else if (shop[3] == 10 && (achievements.Contains("10 factories gekocht!") == false))
            {
                achievements.Add("10 factories gekocht!");
                MessageBox.Show("10 factories gekocht!");
            }
            else if (shop[4] == 10 && (achievements.Contains("10 banks gekocht!") == false))
            {
                achievements.Add("10 banks gekocht!");
                MessageBox.Show("10 banks gekocht!");
            }
            else if (shop[5] == 10 && (achievements.Contains("10 temples gekocht!") == false))
            {
                achievements.Add("10 temples gekocht!");
                MessageBox.Show("10 temples gekocht!");
            }
            else if (shop[0] == 1 && shop[1] == 1 && shop[2] == 1 && shop[3] == 1 && shop[4] == 1 && shop[5] == 1 && shop[6] == 1 && (achievements.Contains("Van alles wat gekocht!") == false))
            {
                achievements.Add("Van alles wat gekocht!");
                MessageBox.Show("Van alles wat gekocht!");
            }
            else if (shop[0] == 1 && (achievements.Contains("begin met de upgrades!") == false))
            {
                achievements.Add("begin met de upgrades!");
                MessageBox.Show("begin met de upgrades!");
            }
            else if (shop[1] == 20 && (achievements.Contains("je kan je eigen rusthuis beginnen!") == false))
            {
                achievements.Add("je kan je eigen rusthuis beginnen!");
                MessageBox.Show("je kan je eigen rusthuis beginnen!");
            }
            else if (shop[2] == 50 && (achievements.Contains("een rijke boer!") == false))
            {
                achievements.Add("een rijke boer!");
                MessageBox.Show("een rijke boer!");
            }
            else if (shop[5] == 5 && (achievements.Contains("je eigen geloof starten!") == false))
            {
                achievements.Add("je eigen geloof starten!");
                MessageBox.Show("je eigen geloof starten!");
            }
            else if (totaal_score > 314314 && (achievements.Contains("de meester van pi!") == false))
            {
                achievements.Add("de meester van pi!");
                MessageBox.Show("de meester van pi!");
            }
            else if (totaal_score > 100000000 && (achievements.Contains("de beste speler!") == false))
            {
                achievements.Add("de beste speler!");
                MessageBox.Show("de beste speler!");
            }


        }

        private void BtnAchievements_Click(object sender, RoutedEventArgs e)
        {
            Window1 f = new Window1();
            f.ShowDialog();
        }
    }
}
