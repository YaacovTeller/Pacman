using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Library
{
    public static class Randomizer
    {
        public static Random rand = new Random();
        public static int randomX;
        public static int randomY;
        public static int hgt = 730;
        public static int wdth = 1300;

        static public Point setRandLoc()
        {
            randomX = rand.Next(1, wdth);
            randomY = rand.Next(1, hgt);
            return new Point(randomX, randomY);
        }
    }
}
