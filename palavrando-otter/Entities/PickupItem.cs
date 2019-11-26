using Otter;
using Palavrando.Extensions;

namespace Palavrando.Entities
{
    public class PickupItem : Entity
    {
        public int ItemRadius { get; private set; } = 5;

        public PickupItem(float x = 0, float y = 0,Image image = null ,Graphic graphic = null, Collider collider = null, string name = "")
            : base(x, y, graphic, collider, name)
        {
            
        }

        public void SetItem(Graphic graphic = null)
        {
            Graphic = graphic ?? Image.CreateCircle(ItemRadius, Color.Green);
            Collider = new CircleCollider(ItemRadius, Tag.PickupItem);
            Collider.CenterOrigin();
            graphic.CenterOrigin();
        }
    }
}