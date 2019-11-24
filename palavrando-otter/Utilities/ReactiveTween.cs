using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palavrando.Utilities
{
    public class ReactiveTween : Entity
    {
        public ReactiveTween(float x, float y) : base(x, y)
        {
            // Add a simple circle graphic.
            AddGraphic(Image.CreateCircle(30, Color.White));
            Graphic.CenterOrigin();
        }

        public override void Update()
        {
            base.Update();

            if (Input.KeyPressed(Key.Any))
            {
                // If a key is pressed do a cool tween.
                Tween(Graphic, new { ScaleX = 1, ScaleY = 1 }, 30)
                  .From(new { ScaleX = 2, ScaleY = 0.5f })
                  .Ease(Ease.ElasticOut);
            }
        }
    }
}
