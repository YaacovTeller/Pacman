using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pac_Library
{
    public class Food: StaticItem
    {
        public static short foodCounter = 0;
        public Food()
        {
            this.FoodImage = new PictureBox();
            if (foodCounter == 6) { foodCounter = 1; }
            else foodCounter++;
            switch (foodCounter)
            {
                case 1:
                    this.FoodImage.ImageLocation = "../../assets/cherr.png";
                    break;
                case 2:
                    this.FoodImage.ImageLocation = "../../assets/app.png";
                    break;
                case 3:
                    this.FoodImage.ImageLocation = "../../assets/oran.png";
                    break;
                case 4:
                    this.FoodImage.ImageLocation = "../../assets/strawb.png";
                    break;
                case 5:
                    this.FoodImage.ImageLocation = "../../assets/nade.png";
                    break;
                case 6:
                    this.FoodImage.ImageLocation = "../../assets/oran.png";
                    break;
            }
            //        this.FoodImage.ImageLocation = "../../assets/cherry.png";
           
            this.FoodImage.Location = Randomizer.setRandLoc();
    //        this.FoodImage.Location = new Point(100, 100);
            this.FoodImage.Size = new Size(50, 50);
            FoodImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public PictureBox FoodImage { get; set; }

        public override int X => this.FoodImage.Left;

        public override int Y => this.FoodImage.Top;

        public override int Width => this.FoodImage.Width;

        public override int Height => this.FoodImage.Height;


    }
}
