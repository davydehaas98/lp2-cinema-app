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
            int x = 0;
            int y = 0;
            foreach (Seat seat in eventlogic.GetEvents().First(eve => eve.Id == eventid).Seats)
            {
                Ellipse ell = new Ellipse();
                ell.Height = 20;
                ell.Width = 20;
                ell.Fill = Brushes.Black;
                if (seat.Booked == true)
                {
                    ell.Fill = Brushes.Gray;
                }
                Canvas.SetLeft(ell, x);
                Canvas.SetTop(ell, y);
                canvasEventSeats.Children.Add(ell);
                x += 20;
                if (seat.Number % 10 == 0)
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
            WindowEventAdd windoweventadd = new WindowEventAdd();
            this.Hide();
            windoweventadd.Show();
        }
        private void btnMovieAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowMovieAdd windowmovieadd = new WindowMovieAdd();
            this.Hide();
            windowmovieadd.Show();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnBookSeats_Click(object sender, RoutedEventArgs e)
        {
            WindowBooking w = new WindowBooking();
            this.Hide();
            w.Show();
        }
    }
}
