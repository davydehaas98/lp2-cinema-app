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

using Models;
using Repository.Repositories;

namespace CinemaTool
{
    /// <summary>
    /// Interaction logic for WindowBooking.xaml
    /// </summary>
    public partial class WindowBooking : Window
    {
        private EventRepository eventrepo;
        //private Seat[] seats;
        public WindowBooking()
        {
            InitializeComponent();
            eventrepo = new EventRepository();
            //GenerateSeats();
        }
        //public void GenerateSeats()
        //{
        //    seats = eventrepo.GetAll().Single(eve => eve.Id == 1).Seats.ToArray();
        //    int x = 0;
        //    int y = 0;
        //    for (int i = 1; i < 101; i++)
        //    {
        //        Ellipse ell = new Ellipse();
        //        ell.Height = 30;
        //        ell.Width = 30;
        //        ell.Fill = Brushes.Black;
        //        ell.MouseLeftButtonDown += ellipse_MouseLeftButtonDown;
        //        ell.MouseEnter += ellipse_MouseEnter;
        //        ell.MouseLeave += ellipse_MouseLeave;
        //        Canvas.SetLeft(ell, x);
        //        Canvas.SetTop(ell, y);
        //        cnvsSeats.Children.Add(ell);
        //        x += 30;
        //        if (i % 10 == 0)
        //        {
        //            x = 0;
        //            y += 30;
        //        }
        //    }
        //}
        private void ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse el = (Ellipse)sender;
            if(el.Fill == Brushes.Black)
            {
                el.Fill = Brushes.Yellow;
            }
            else { el.Fill = Brushes.Black; }
        }
        private void ellipse_MouseEnter(object sender, MouseEventArgs e)
        {
            Ellipse el = (Ellipse)sender;
            el.Stroke = Brushes.Yellow;
        }
        private void ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            Ellipse el = (Ellipse)sender;
            el.Stroke = Brushes.Black;
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            List<int> seatsint = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                Ellipse ellipsechild = cnvsSeats.Children[i] as Ellipse;
                if (ellipsechild.Fill == Brushes.Yellow)
                {
                    seatsint.Add(i+1);
                }
            }
            MainWindow w = new MainWindow();
            w.Show();
        }
    }
}
