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
using System.Windows.Threading;

namespace CookieClicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double totaal_score = 0;
        private double som_optellen = 1;
        private double imgwidth;
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
            return $"{Math.Round(totaal_score)} cookies";
        }

    }
}
