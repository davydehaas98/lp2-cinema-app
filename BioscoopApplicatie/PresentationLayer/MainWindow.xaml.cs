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
using LogicLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MovieTheatreLogic movieTheatreLogic;
        private CinemaLogic cinemalogic;
        private MovieLogic movielogic;
        private EventLogic eventlogic;
        private BookingLogic bookingLogic;
        public MainWindow()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("nl");
            InitializeComponent();
            movieTheatreLogic = new MovieTheatreLogic();
            cinemalogic = new CinemaLogic();
            movielogic = new MovieLogic();
            eventlogic = new EventLogic();
            bookingLogic = new BookingLogic();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            movieTheatreLogic.GetMovieTheatres();
            MessageBox.Show((movieTheatreLogic.MovieTheatres.Count()).ToString());
            movielogic.GetMovies();
        }

        private void dgEvents_Loaded(object sender, RoutedEventArgs e)
        {
            dgEvents.ItemsSource = eventlogic.GetEvents();
            dgEvents.Items.Refresh();
        }
    }
}
