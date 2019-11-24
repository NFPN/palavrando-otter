using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palavrando.Utilities
{
    public class ScalingTween : Entity
    {
        public ScalingTween(float x, float y, Func<float, float> easeType) : base(x, y)
        {
            // Add a simple circle graphic.
            AddGraphic(Image.CreateCircle(20, Color.White));
            Graphic.CenterOrigin();

            // Tween the scale of the graphic with the easetype for 120 frames.
            // Also reflect and repeat the tween forever!
            Tween(Graphic, new { ScaleX = 2, ScaleY = 2 }, 120)
              .Ease(easeType)
              .Reflect()
              .Repeat();
        }
    }
}