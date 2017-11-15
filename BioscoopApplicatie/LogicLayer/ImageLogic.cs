using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;


namespace LogicLayer
{
    public class ImageLogic
    {
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        public ImageSource ByteToImageSource(byte[] imgBytes)
        {
            BitmapImage bmi = new BitmapImage();
            bmi.BeginInit();
            bmi.StreamSource = new MemoryStream(imgBytes);
            bmi.EndInit();
            return bmi as ImageSource;
        }
    }
}
