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
using System.Windows.Shapes;
using Repository;
using Models;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for WindowEventAdd.xaml
    /// </summary>
    public partial class WindowEventAdd : Window
    {
        private MovieRepository movierepo;
        private EventRepository eventrepo;
        private CinemaRepository cinemarepo;
        public WindowEventAdd()
        {
            InitializeComponent();
            movierepo = new MovieRepository();
            cinemarepo = new CinemaRepository();
            eventrepo = new EventRepository();
            dpEventDate.SelectedDate = DateTime.Today;
            dpEventDate.DisplayDateStart = DateTime.Today;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
        }
        private void EnableButtons(bool movie, bool movietheatre, bool cinema, bool confirm)
        {
            cbEventMovie.IsEnabled = movie;
            cbEventMovieTheatre.IsEnabled = movietheatre;
            cbEventCinema.IsEnabled = cinema;
            btnEventConfirm.IsEnabled = confirm;
        }
        private void ClearComboBoxes(int status)
        {
            switch(status)
            {
                case 1:
                    cbEventCinema.Items.Clear();
                    break;
                case 2:
                    cbEventMovieTheatre.Items.Clear();
                    cbEventCinema.Items.Clear();
                    break;
                case 3:
                    cbEventMovie.Items.Clear();
                    cbEventMovieTheatre.Items.Clear();
                    cbEventCinema.Items.Clear();
                    break;
            }
        }
        private void dpEventDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearComboBoxes(3);
            movierepo.GetMoviesByReleaseDate(dpEventDate.SelectedDate.Value).ForEach(movie => cbEventMovie.Items.Add(movie));
            EnableButtons(true, false, false, false);
        }
        private void cbEventMovie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbEventMovie.SelectedIndex > -1)
            {
                ClearComboBoxes(2);
                cinemarepo.GetMovieTheatresByType(((Movie)cbEventMovie.SelectedItem).D3).ForEach(movietheatre => cbEventMovieTheatre.Items.Add(movietheatre));
                EnableButtons(true, true, false, false);
            }
        }
        private void cbEventMovieTheatre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbEventMovieTheatre.SelectedIndex > -1)
            {
                ClearComboBoxes(1);
                ((MovieTheatre)cbEventMovieTheatre.SelectedItem).Cinemas.Where(cinema => cinema.D3 == ((Movie)cbEventMovie.SelectedItem).D3).ToList().ForEach(cinema => cbEventCinema.Items.Add(cinema));
                EnableButtons(true, true, true, false);
            }
        }

        private void cbEventCinema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbEventCinema.SelectedIndex > -1)
            {
                EnableButtons(true, true, true, true);
            }
        }

        private void btnEventConfirm_Click(object sender, RoutedEventArgs e)
        {
            eventrepo.InsertEvent(dpEventDate.SelectedDate.Value.Add(((DateTime)tpEventTime.Value).TimeOfDay),((Cinema)cbEventCinema.SelectedItem).Id,((Movie)cbEventMovie.SelectedItem).Id);
            this.Close();
        }
    }
}
