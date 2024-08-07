using System;
using System.Drawing;
using System.IO;

namespace morebitmaps
{
    class MainClass
    {
        public static void Main(string[] args)
       {
            var currentPath = Directory.GetCurrentDirectory();
            string folderName = "Img";
            string fileName = "Green.png";
            string pathString = Path.Combine(currentPath, folderName);
            Directory.CreateDirectory(pathString);

            using (Bitmap bitmap = new Bitmap(500, 500))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    Image pastedImage = Image.FromFile("qingque.png");
                    Point ulCorner = new Point(0, 0);
                    Point urCorner = new Point(250, 0);
                    Point llCorner = new Point(0, 250);
                    Point [] imageLocation = {ulCorner, urCorner, llCorner };

                    graphics.Clear(Color.Green);
                    graphics.DrawImage(pastedImage, imageLocation);
                }
                bitmap.Save($"{pathString}/{fileName}");
            }

        }
    }
}

