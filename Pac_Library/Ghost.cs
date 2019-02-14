using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Pac_Library
{
    [Serializable]
    public class Ghost : AbstractPlayer
    {
        public string name;
        public static int ghostIndex = 1;
        public int speed;
        public int damage;
        public string compass = "E";
        public Ghost()
        {
            switch (ghostIndex)
            {
                case 1:
                    name = "inky";
                    speed = 1;
                    damage = 10;
                    break;
                case 2:
                    name = "clyde";
                    speed = 2;
                    damage = 7;
                    break;
                case 3:
                    name = "pinky";
                    speed = 3;
                    damage = 5;
                    break;
                case 4:
                    name = "blinky";
                    speed = 4;
                    damage = 3;
                    break;
            }

            this.ghostImage = new PictureBox();
            this.ghostImage.ImageLocation = "../../assets/ghosts/" + Ghost.ghostIndex+ "_" + compass + ".gif";
            if (Ghost.ghostIndex == 4) { Ghost.ghostIndex = 1; }
            else Ghost.ghostIndex++;
            this.ghostImage.Location = new Point (100,100);
            this.ghostImage.Size = new Size(50,50);
            this.ghostImage.BackColor = Color.Transparent;
            ghostImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        [NonSerialized]
        public PictureBox ghostImage;

        public override int X => this.ghostImage.Left;

        public override int Y => this.ghostImage.Top;

        public override int Width => this.ghostImage.Width;

        public override int Height => this.ghostImage.Height;

        public void setGhostDirectionImage(string comp)
        {
            this.compass = comp;
            this.ghostImage.ImageLocation = "../../assets/ghosts/" + speed + "_" + compass + ".gif";
        }

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
    }
}
