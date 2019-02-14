using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Library
{
    public class GameHelper
    {
        public static void MoveUp(IVisualPlayer player)
        {
            player.MoveUp();
        }
        public static void MoveDown(IVisualPlayer player)
        {
            player.MoveDown();
        }
        public static void MoveLeft(IVisualPlayer player)
        {
            player.MoveLeft();
        }
        public static void MoveRight(IVisualPlayer player)
        {
            player.MoveRight();
        }
        public static bool IsCrashedTwoElement(IVisualPlayer player1, IVisualPlayer player2)
        {
            return player1.IsCrashed(player2);
        }
        public static bool IsCrashedTwoElement(IVisualPlayer player1, StaticItem item)
        {
            return player1.IsCrashed(item);
        }
    }
}
