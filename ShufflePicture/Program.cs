using System;
using System.Drawing;
using System.IO;

namespace ShufflePicture
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var currentPath = Directory.GetCurrentDirectory();
            string folderName = "Img";
            string fileName = "deshuffelled.png";
            string pathString = Path.Combine(currentPath, folderName);

            Console.WriteLine(pathString);

            Directory.CreateDirectory(pathString);

            using (Bitmap OriginalBitmap = new Bitmap("shuffelled.png"))
            {
                int gridSize = 2;
                int ImageWidth = OriginalBitmap.Width / gridSize;
                int ImageHeight = OriginalBitmap.Height / gridSize;

                // Builds the original Grid
                Bitmap[,] Grid = new Bitmap[gridSize, gridSize];
                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        Rectangle pieceRect = new Rectangle(i * ImageWidth, j * ImageHeight, ImageWidth, ImageHeight);
                        Grid[i, j] = OriginalBitmap.Clone(pieceRect, OriginalBitmap.PixelFormat);
                    }
                }

                // Builds a rearranged Grid
                Bitmap[,] RearrangedGrid = new Bitmap[gridSize, gridSize];
                for (int y = 0; y < gridSize; y++)
                {
                    for (int x = 0; x < gridSize; x++)
                    {
                        RearrangedGrid[x, y] = Grid[gridSize - 1 - x, gridSize - 1 - y];
                    }
                }

                using (Bitmap RearrangedBitmap = new Bitmap(OriginalBitmap.Width, OriginalBitmap.Height))
                {

                    using (Graphics graphics = Graphics.FromImage(RearrangedBitmap))
                    {
                        for (int y = 0; y < gridSize; y++)
                        {
                            for (int x = 0; x < gridSize; x++)
                            {
                                graphics.DrawImage(RearrangedGrid[x, y], x * ImageWidth, y * ImageHeight, ImageWidth, ImageHeight);
                            }
                        }
                    }
                    RearrangedBitmap.Save($"{pathString}/{fileName}");
                }
            }
        }
    }
}


