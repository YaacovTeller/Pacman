using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Library
{
    public interface IVisualPlayer :
        IHaveCoordinatesXandY,
        IHaveWidthAndHeight,
        IHaveStartAndEndAboutXAndY,
        ICrashedWithAnotherElement,
        IMoveableElement
    {
    }
    public interface IHaveWidthAndHeight
    {
        int Width { get; }
        int Height { get; }
    }
    public interface IHaveCoordinatesXandY
    {
        int X { get; }
        int Y { get; }
    }
    public interface IMoveableElement
    {
        void MoveLeft();
        void MoveUp();
        void MoveDown();
        void MoveRight();
    }
    public interface IHaveStartAndEndAboutXAndY
    {
        int XStart { get; }
        int XEnd { get; }


        int YStart { get; }
        int YEnd { get; }
    }
    public interface ICrashedWithAnotherElement
    {
        bool IsCrashed(IVisualPlayer player);
        bool IsCrashed(StaticItem item);
    }
}
