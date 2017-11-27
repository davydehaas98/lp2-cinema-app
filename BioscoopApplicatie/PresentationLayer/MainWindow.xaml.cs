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
using System.Windows.Forms;
using LogicLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CinemaLogic cinemalogic;
        private MovieLogic movielogic;
        private EventLogic eventlogic;
        private BookingLogic bookinglogic;
        public MainWindow()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            InitializeComponent();
            cinemalogic = new CinemaLogic();
            movielogic = new MovieLogic();
            eventlogic = new EventLogic();
            bookinglogic = new BookingLogic();
        }
        public void RefreshData()
        {
            dgEvents.ItemsSource = eventlogic.GetEvents();
            dgMovies.ItemsSource = movielogic.GetMovies();
        }
        public void GenerateSeats(int eventid)
        {
            List<Seat> seats = new List<Seat>();
            seats = eventlogic.GetEvent(eventid).Seats;
            canvasEventSeats.Children.Clear();
            int x = 0;
            int y = 0;
            for (int i = 1; i <= 100; i++)
            {
                Ellipse ell = new Ellipse();
                ell.Height = 20;
                ell.Width = 20;
                if (seats.Exists(seat => seat.Id == i))
                {
                    ell.Fill = Brushes.Yellow;
                }
                else
                {
                    ell.Fill = Brushes.Black;
                }
                Canvas.SetLeft(ell, x);
                Canvas.SetTop(ell, y);
                canvasEventSeats.Children.Add(ell);
                x += 20;
                if (i % 10 == 0)
                {
                    x = 0;
                    y += 20;
                }
            }
        }
        private void dgEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgEvents.SelectedIndex > -1)
            {
                GenerateSeats(((Event)dgEvents.SelectedItem).Id);
            }
        }

        private void dgMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgMovies.SelectedIndex > -1)
            {
                tbMovieInfo.Text = ((Movie)dgMovies.SelectedItem).GetInfo() + Environment.NewLine + Environment.NewLine + "Genres:";
                foreach (Genre g in ((Movie)dgMovies.SelectedItem).Genres)
                {
                    tbMovieInfo.Text += Environment.NewLine + g.Name;
                }
                try
                {
                    imgMovie.Source = ((Movie)dgMovies.SelectedItem).Image;
                }
                catch
                {
                    imgMovie.Source = null;
                }
            }
        }

        private void btnEventAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowEventAdd w = new WindowEventAdd();
            w.Show();
            this.Close();
        }
        private void btnMovieAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowMovieAdd w = new WindowMovieAdd();
            w.Show();
            this.Close();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void btnBookSeats_Click(object sender, RoutedEventArgs e)
        {
            WindowBooking w = new WindowBooking();
            w.Show();
            this.Close();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }
    }
}
