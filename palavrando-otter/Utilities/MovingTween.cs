using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palavrando.Utilities
{
    public class MovingTween : Entity
    {
        // The next Y position to place the Entity at.
        static float nextY;
        // How far each MovingTween Entity should be spaced from each other vertically.
        static float spacing = 10;
        // The next hue value to color the Graphic with.
        static float nextHue = 40;

        public MovingTween(Func<float, float> easeType)
        {
            // Create a Color using the nextHue value.
            var color = Color.White;
            // Make a circle using that color.
            var image = Image.CreateCircle(8, color);
            // Make it fancy.
            image.OutlineColor = Color.Black;
            image.OutlineThickness = 1;
            image.CenterOrigin();
            AddGraphic(image);

            // Adjust the nextY and nextHue for the future MovingTweens.
            nextY += spacing;
            nextHue += 0.05f;

            // Set the position here.
            X = 40;
            Y = nextY;

            // Tween the Entity across the screen and back for 180 frames.
            Tween(this, new { Y = Game.Instance.Height - 40 }, 180)
              .Ease(easeType)
              .Reflect()
              .RepeatDelay(30)
              .Repeat();
        }
    }
}

