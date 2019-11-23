using Otter;
using Palavrando.Entities;

namespace Palavrando.Extensions
{
    internal static class GameExtensions
    {
        public static PickupItem ChangePosition(this PickupItem item)
        {
            var randPosition = Rand.IntXY(
                item.Graphic.Width, MyGlobal.WINDOWWIDTH - (item.Graphic.Width / 2),
                item.Graphic.Height, MyGlobal.WINDOWHEIGHT - (item.Graphic.Height / 2));

            item.SetPosition(randPosition.X, randPosition.Y);
            return item;
        }
    }

    public enum Tag
    {
        Player,
        PickupItem,
        Enemy,
    }
}