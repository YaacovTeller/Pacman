using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PacLibrary_WinForm
{
    [Serializable]
    public class Ghost : AbstractPlayer
    {
        public string name;
        public static int ghostIndex = 1;
        public int speed;
        public Ghost()
        {
            switch (ghostIndex)
            {
                case 1:
                    name = "inky";
                    speed = 1;
                    break;
                case 2:
                    name = "clyde";
                    speed = 2;
                    break;
                case 3:
                    name = "pinky";
                    speed = 3;
                    break;
                case 4:
                    name = "blinky";
                    speed = 4;
                    break;
            }

            this.ghostImage = new PictureBox();
            this.ghostImage.ImageLocation = "../../assets/ghost_" + Ghost.ghostIndex + ".png";
            if (Ghost.ghostIndex == 4) { Ghost.ghostIndex = 1; }
            else Ghost.ghostIndex++;
            this.ghostImage.Location = new Point (100,100);
            this.ghostImage.Size = new Size(50,50);
            ghostImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public PictureBox ghostImage { get; set; }

        public override int X => this.ghostImage.Left;

        public override int Y => this.ghostImage.Top;

        public override int Width => this.ghostImage.Width;

        public override int Height => this.ghostImage.Height;

        public override void MoveDown()
        {
            this.ghostImage.Top += speed;
        }

        public override void MoveLeft()
        {
            this.ghostImage.Left -= speed;
        }

        public override void MoveRight()
        {
            this.ghostImage.Left += speed;
        }

        public override void MoveUp()
        {
            this.ghostImage.Top -= speed;
        }

        public static Random rand = new Random();
        public static int randomX;
        public static int randomY;
        public static void randLoc()
        {
            var hgt = 770;
            var wdth = 1400;
            randomX = rand.Next(1, wdth);
            randomY = rand.Next(1, hgt);
        }
        public void setRandLoc(int rX, int rY)
        {
            this.ghostImage.Top =  rY;
            this.ghostImage.Left = rX;
        }
    }
}
