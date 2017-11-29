using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageConverter
{
    public static class ImageBuilder
    {
        public static byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        public static ImageSource ByteToImageSource(byte[] imgBytes)
        {
            BitmapImage bmi = new BitmapImage();
            bmi.BeginInit();
            bmi.StreamSource = new MemoryStream(imgBytes);
            bmi.EndInit();
            return bmi as ImageSource;
        }
    }
}
