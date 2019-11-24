using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace palavrando_otter.Utilities
{
    public class ColorTween : Entity
    {
        // Tween this value to determine the color later.
        float hue;

        public ColorTween(float x, float y) : base(x, y)
        {
            // Add a simple circle graphic.
            AddGraphic(Image.CreateCircle(30, Color.White));
            Graphic.CenterOrigin();

            // Tween the hue from 0 to 1 and repeat it forever over 360 frames.
            Tween(this, new { hue = 1 }, 360)
              .Repeat();
        }

        public override void Update()
        {
            base.Update();
            // Update the Color every update by using the tweened hue value.
            Graphic.Color = Color.FromHSV(hue, 1, 1, 1);
        }
    }
}
