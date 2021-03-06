﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Pac_Library
{
    public class Pacman : AbstractPlayer
    {
        public Pacman()
        {
            this.pacmanImage = new PictureBox();
            this.pacmanImage.ImageLocation = "../../assets/pacman_gifs/pac_E.gif";
            this.pacmanImage.Location = new Point(100, 300);
            this.pacmanImage.Size = new Size(50, 50);
            //          this.pacmanImage.BackgroundImage = new Bitmap("../../assets/Transparent.png");
            pacmanImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public int speed;
        
        public PictureBox pacmanImage { get; set; }

        public override int X => this.pacmanImage.Left;

        public override int Y => this.pacmanImage.Top;

        public override int Width => this.pacmanImage.Width;

        public override int Height => this.pacmanImage.Height;

        public void die()
        {

        }

        public override void MoveDown()
        {
            this.pacmanImage.Top += speed;
        }

        public override void MoveLeft()
        {
            this.pacmanImage.Left -= speed;
        }

        public override void MoveRight()
        {
            this.pacmanImage.Left += speed;
        }

        public override void MoveUp()
        {
            this.pacmanImage.Top -= speed;
        }
    }
}
