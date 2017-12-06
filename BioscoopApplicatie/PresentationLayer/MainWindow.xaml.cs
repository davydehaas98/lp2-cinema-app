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
using Repository.Interfaces;
using Repository.Repositories;
using Models;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IBookingRepository bookingrepo;
        private ICinemaRepository cinemarepo;
        private IEventRepository eventrepo;
        private IMovieRepository movierepo;
        public MainWindow() : this(new BookingRepository(), new CinemaRepository(), new EventRepository(), new MovieRepository()) { }
        public MainWindow(IBookingRepository bookingrepo, ICinemaRepository cinemarepo, IEventRepository eventrepo, IMovieRepository movierepo)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            InitializeComponent();
            this.bookingrepo = bookingrepo;
            this.cinemarepo = cinemarepo;
            this.eventrepo = eventrepo;
            this.movierepo = movierepo;
        }
        public void RefreshData()
        {
            dgEvents.ItemsSource = eventrepo.GetAll();
            dgMovies.ItemsSource = movierepo.GetAll();
        }
        public void GenerateSeats(int eventid)
        {
            List<Seat> seats = new List<Seat>();
            seats = eventrepo.GetEvent(eventid).Seats;
            canvasEventSeats.Children.Clear();
            int x = 0;
            int y = 0;
            int currentseatid = 0;
            for (int i = 1; i <= 100; i++)
            {
                Ellipse ell = new Ellipse();
                ell.Height = 20;
                ell.Width = 20;
                Canvas.SetLeft(ell, x);
                Canvas.SetTop(ell, y);
                if (seats.Count > currentseatid && seats[currentseatid].Id == i)
                {
                    ell.Fill = Brushes.Yellow;
                    currentseatid++;
                }
                else
                {
                    ell.Fill = Brushes.Black;
                }
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
                imgEvent.Source = ((Event)dgEvents.SelectedItem).Movie.Image;
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
