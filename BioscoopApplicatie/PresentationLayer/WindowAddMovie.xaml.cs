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
using LogicLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WindowAddMovie : Window
    {
        private MovieLogic movielogic;
        private System.Drawing.Image image;
        public WindowAddMovie()
        {
            InitializeComponent();
            movielogic = new MovieLogic();
            movielogic.GetGenres().ForEach(genre => lbMovieGenres.Items.Add(genre));
        }

        private void btnMovieImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            image = System.Drawing.Image.FromFile(dialog.FileName);
        }
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var cb = sender as System.Windows.Controls.CheckBox;
            var item = cb.DataContext;
            lbMovieGenres.SelectedItem = item;
        }

        private void btnMovieConfirm_Click(object sender, RoutedEventArgs e)
        {
            //movielogic.InsertMovie(tbMovieTitle.Text,tbMovieType.Text,Convert.ToInt32(tbMovieLength.Text), Convert.ToInt32(tbMovieMinimumAge.Text),dpMovieReleaseDate.SelectedDate,image,)
        }
    }
}
