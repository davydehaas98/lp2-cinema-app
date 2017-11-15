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
        private void dgEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgEvents.SelectedIndex > -1)
            {
                
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

        private void btnMovieAdd_Click(object sender, RoutedEventArgs e)
        {
            //List<Genre> allgenres = movielogic.GetGenres();
            //List<Genre> genres = new List<Genre>();
            //genres.Add(allgenres[3]);
            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.ShowDialog();
            //movielogic.InsertMovie("King Kong", "2D", 200, 16, DateTime.Now, System.Drawing.Image.FromFile(dialog.FileName), movielogic.GetGenres());
            this.Hide();
            WindowAddMovie waddmovie = new WindowAddMovie();
            waddmovie.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgEvents.ItemsSource = eventlogic.GetEvents();
            dgMovies.ItemsSource = movielogic.GetMovies();
        }
    }
}
