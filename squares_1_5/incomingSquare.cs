using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace squares_1_5
{
    class incomingSquare
    {
        public Point[] loctions;
        public Color col;
        public int pointsNums;
        public static int colorsNums = 5;
        public static int shapsNums = 10;
        static Color[] theColors = new Color[5] { Color.DarkBlue, Color.OrangeRed, Color.Yellow, Color.Red, Color.Green };
        //static Point[,] theShapes = new Point[
        public incomingSquare()
        {
            Random choseShape = new Random();
            int ch = (int)choseShape.Next(0, incomingSquare.shapsNums);
            System.IO.StreamReader file = new System.IO.StreamReader("shape" + ch.ToString() + ".txt");

            loctions = new Point[4];
            int i = 0;
            while (!file.EndOfStream)
            {

                string point = file.ReadLine();

                int x = point[0] - 48;
                int y = point[1] - 48 - 3;

                loctions[i] = new Point(x, y);
                i++;
            }
            pointsNums = i;

            file.Close();
            Random choseColor = new Random();
            ch = (int)(choseColor.Next(0, incomingSquare.colorsNums - 1));
            col = theColors[ch];
        }

        public void increaseY()
        {
            for (int i = 0; i < pointsNums; i++)
                loctions[i].Y++;
        }

        public void increaseX()
        {
            for (int i = 0; i < pointsNums; i++)
                loctions[i].X++;
        }

        public void decreaseX()
        {
            for (int i = 0; i < pointsNums; i++)
                loctions[i].X--;
        }
    }
}
