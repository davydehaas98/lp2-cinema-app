using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Repository.Interfaces;
using Repository.Repositories;
using Models;
using System.ComponentModel;

namespace CinemaTool
{
    public partial class WindowMovieAdd : Window
    {
        private IMovieRepository movierepo;
        public ObservableCollection<Genre> GenreList { get; set; }
        private List<int> SelectedGenresID;
        private string image;
        public WindowMovieAdd() : this(new MovieRepository()) { }
        public WindowMovieAdd(IMovieRepository movierepo)
        {
            InitializeComponent();
            this.movierepo = movierepo;
            GenreList = new ObservableCollection<Genre>();
            SelectedGenresID = new List<int>();
            new int[5] { 0, 6, 9, 12, 16 }.ToList().ForEach(age => cbMovieMinimumAge.Items.Add(age));
            movierepo.GetGenres().ToList().ForEach(genre => GenreList.Add(new Genre(genre.Id, genre.Name)));
            DataContext = this;
        }
        private void btnMovieImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            try
            {
                image = ImageConverter.ImageBuilder.UploadImage(System.Drawing.Image.FromFile(dialog.FileName));
                if (image != null) btnMovieConfirm.IsEnabled = true;
            }
            catch { }
        }
        private void btnMovieConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                movierepo.InsertMovie(tbMovieTitle.Text, (bool)chkb3D.IsChecked, Convert.ToInt32(tbMovieLength.Text), Convert.ToInt32(cbMovieMinimumAge.SelectedValue), dpMovieReleaseDate.SelectedDate.Value, image , SelectedGenresID);
                this.Close();
            }
            catch
            {
                System.Windows.MessageBox.Show("Not all fields are filled in correctly!");
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

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
        }
    }
}
