using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageConverter
{
    public static class ImageBuilder
    {
        public static ImageSource LoadImage(string imageuri)
        {
            BitmapImage bmi = new BitmapImage();
            bmi.BeginInit();
            bmi.UriSource = new Uri(imageuri, UriKind.Absolute);
            bmi.EndInit();
            return bmi as ImageSource;
        }
        public static byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        public static string UploadImage(Image image)
        {
            using (WebClient w = new WebClient())
            {
                w.Headers.Add("Authorization", "Client-ID 9ca013a9abb99d0");
                var values = new NameValueCollection { { "image", Convert.ToBase64String(ImageToByteArray(image)) } };
                byte[] response = w.UploadValues("https://api.imgur.com/3/upload.xml", values);

                var sr = new StreamReader(new MemoryStream(response));

                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine();
                    if (line != null && line.Contains("link"))
                    {
                        sr.Dispose();
                        //Get Substring starting at https
                        line = line.Substring(line.IndexOf(":", StringComparison.Ordinal) - 5, line.Length - line.IndexOf(":", StringComparison.Ordinal));
                        //Split string starting at </link
                        return line.Substring(0, line.IndexOf("<", StringComparison.Ordinal));
                    }
                }
            }
            return null;
        }
    }
}
