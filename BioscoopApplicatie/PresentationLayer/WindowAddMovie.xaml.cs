using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Forms;
using System.Collections.ObjectModel;
using LogicLayer;
using System.ComponentModel;

namespace PresentationLayer
{
    public partial class WindowAddMovie : Window
    {
        private MovieLogic movielogic;
        private System.Drawing.Image image;

        public ObservableCollection<Genre> GenreList { get; set; }
        private List<int> SelectedGenresID;

        public WindowAddMovie()
        {
            InitializeComponent();
            movielogic = new MovieLogic();
            GenreList = new ObservableCollection<Genre>();
            SelectedGenresID = new List<int>();
            GetAllGenres();
        }
        public void GetAllGenres()
        {
            movielogic.GetGenres().ForEach(genre => GenreList.Add(new Genre(genre.Id, genre.Name)));
            this.DataContext = this;
        }
        private void btnMovieImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            try
            {
                image = System.Drawing.Image.FromFile(dialog.FileName);
            }
            catch {  }
        }
        private void btnMovieConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                movielogic.InsertMovie(tbMovieTitle.Text, cbMovieType.SelectedValue.ToString(), Convert.ToInt32(tbMovieLength.Text), Convert.ToInt32(tbMovieMinimumAge.Text), dpMovieReleaseDate.SelectedDate.Value, image, SelectedGenresID);
                this.Hide();
                MainWindow mainwindow = new MainWindow();
                mainwindow.Show();
            }
            catch
            {
                System.Windows.MessageBox.Show("Something went wrong!");
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var cb = sender as System.Windows.Controls.CheckBox;
            SelectedGenresID.Add(((Genre)cb.DataContext).Id);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var cb = sender as System.Windows.Controls.CheckBox;
            SelectedGenresID.Remove(((Genre)cb.DataContext).Id);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
        }
    }
}
