using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Library
{
    public abstract class StaticItem : 
        IHaveCoordinatesXandY,
        IHaveWidthAndHeight,
        IHaveStartAndEndAboutXAndY,
        ICrashedWithAnotherElement
    {
        public abstract int X { get; }

        public abstract int Y { get; }

        public abstract int Width { get; }

        public abstract int Height { get; }

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
        public bool IsCrashed(StaticItem item)
        {
            bool overlapXCoordinate = CrashElementsHelper.IsTwoNumberBetweenRangeOfTowNumbers
                (this.X, this.XEnd, item.X, item.XEnd);

            bool overlapYCoordinate = CrashElementsHelper.IsTwoNumberBetweenRangeOfTowNumbers
                (this.Y, this.YEnd, item.Y, item.YEnd);

            bool crashed = overlapXCoordinate && overlapYCoordinate;

            return crashed;
        }
    }
}
