using Otter;
using System;

namespace Palavrando.Utilities
{
    public class MovingTween : Entity
    {
        // The next Y position to place the Entity at.
        private static float nextY;

        // How far each MovingTween Entity should be spaced from each other vertically.
        private static float spacing = 10;

        // The next hue value to color the Graphic with.
        private static float nextHue = 40;

        public MovingTween(Func<float, float> easeType)
        {
            // Create a Color using the nextHue value.
            var color = Color.White;
            // Make a circle using that color.
            //var image = Image.CreateCircle(8, color);
            var image = new Image(@"C:\Vs\Natanael\REPOS\palavrando-otter\palavrando-otter\Images\imgPalavra\Adaga.png");
            // Make it fancy.
            //image.OutlineColor = Color.Black;
            image.Scale = .3f;
            image.OutlineThickness = 1;
            //image.CenterOrigin();
            image.SetPosition(new Vector2(400, 0));
            AddGraphic(image);

            // Adjust the nextY and nextHue for the future MovingTweens.
            nextY += spacing;
            nextHue += 0.05f;

            // Set the position here.
            X = 40;
            Y = nextY;

            // Tween the Entity across the screen and back for 180 frames.
            Tween(this, new { Y = Game.Instance.HalfWidth - 40 }, 180)
              .Ease(easeType)
              .RepeatDelay(30);
        }
    }
}