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
using Models;
using System.ComponentModel;

namespace PresentationLayer
{
    public partial class WindowMovieAdd : Window
    {
        private MovieLogic movielogic;
        public ObservableCollection<Genre> GenreList { get; set; }
        private List<int> SelectedGenresID;
        private System.Drawing.Image image;
        public WindowMovieAdd()
        {
            InitializeComponent();
            movielogic = new MovieLogic();
            GenreList = new ObservableCollection<Genre>();
            SelectedGenresID = new List<int>();
            new int[5] { 0, 6, 9, 12, 16 }.ToList().ForEach(age => cbMovieMinimumAge.Items.Add(age));
            movielogic.GetGenres().ForEach(genre => GenreList.Add(new Genre(genre.Id, genre.Name)));
            DataContext = this;
        }
        private bool CheckFields()
        {
            return movielogic.CheckFields(tbMovieTitle.Text, tbMovieLength.Text, dpMovieReleaseDate.SelectedDate.Value, image, SelectedGenresID);
        }
        private void btnMovieImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            try
            {
                image = System.Drawing.Image.FromFile(dialog.FileName);
                if (image != null)
                    btnMovieConfirm.IsEnabled = true;
            }
            catch { }
        }
        private void btnMovieConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFields())
            {
                movielogic.InsertMovie(tbMovieTitle.Text, (bool)chkb3D.IsChecked, Convert.ToInt32(tbMovieLength.Text), Convert.ToInt32(cbMovieMinimumAge.SelectedValue), dpMovieReleaseDate.SelectedDate.Value, image, SelectedGenresID);
                this.Close();
            }
            else
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
