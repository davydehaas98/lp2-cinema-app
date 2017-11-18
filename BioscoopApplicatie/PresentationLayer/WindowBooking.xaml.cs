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
using LogicLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for WindowBooking.xaml
    /// </summary>
    public partial class WindowBooking : Window
    {
        private EventLogic eventlogic;
        private Seat[] seats;
        public WindowBooking()
        {
            InitializeComponent();
            eventlogic = new EventLogic();
            GenerateSeats();
        }
        public void GenerateSeats()
        {
            seats = eventlogic.GetEvents().Single(eve => eve.Id == 5).Seats.ToArray();
            int x = 0;
            int y = 0;
            foreach(Seat seat in seats)
            {
                Ellipse ell = new Ellipse();
                ell.Height = 30;
                ell.Width = 30;
                if (seat.Booked == false)
                {
                    ell.Fill = Brushes.Black;
                    ell.MouseLeftButtonDown += ellipse_MouseLeftButtonDown;
                }
                else
                {
                    ell.Fill = Brushes.Gray;
                }
                Canvas.SetLeft(ell, x);
                Canvas.SetTop(ell, y);
                cnvsSeats.Children.Add(ell);
                x += 30;
                if(seat.Number % 10 == 0)
                {
                    x = 0;
                    y += 30;
                }
            }
        }
        private void ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse el = (Ellipse)sender;
            if(el.Fill == Brushes.Black)
            {
                el.Fill = Brushes.Yellow;
            }
            else { el.Fill = Brushes.Black; }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            List<int> seatsint = new List<int>();
            for (int i = 0; i < 50; i++)
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
