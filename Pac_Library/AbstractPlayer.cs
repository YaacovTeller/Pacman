using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacLibrary_WinForm
{
    [Serializable]
    public abstract class AbstractPlayer : IVisualPlayer
    {
        public abstract int X { get; }

        public abstract int Y { get; }

        public abstract int Width { get; }

        public abstract int Height { get; }


        public abstract void MoveDown();

        public abstract void MoveLeft();

        public abstract void MoveRight();

        public abstract void MoveUp();


        //מכאן חלקים ממומשים
        public int XStart => X;

        public int XEnd => X + Width;

        public int YStart => Y;

        public int YEnd => Y + Height;

        public bool IsCrashed(IVisualPlayer player)
        {

            bool overlapXCoordinate = CrashElementsHelper.IsTwoNumberBetweenRangeOfTowNumbers
                (this.X, this.XEnd, player.X, player.XEnd);


            bool overlapYCoordinate = CrashElementsHelper.IsTwoNumberBetweenRangeOfTowNumbers
                (this.Y, this.YEnd, player.Y, player.YEnd);

            bool crashed = overlapXCoordinate && overlapYCoordinate;

            return crashed;

        }
    }
}
