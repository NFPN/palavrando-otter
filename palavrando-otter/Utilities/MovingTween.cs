using Otter;
using System;

namespace Palavrando.Utilities
{
    public class MovingTween : Entity
    {
        private static float nextY;
        private static float spacing = 10;
        private static float nextHue = 40;

        public MovingTween(Func<float, float> easeType)
        {
            var image = new Image(@"C:\Users\nicolas.ssoares\Documents\GitPortable\GitHubDesktopPortable\Data\GitHub\palavrando-otter\palavrando-otter\Images\imgPalavra\Gato\Gato.png");
            image.Scale = .45f;
            image.SetPosition(new Vector2(MyGlobal.WINDOWWIDTH / 4, 0));
            AddGraphic(image);

            // Adjust the nextY and nextHue for the future MovingTweens.
            nextY += spacing;
            nextHue += 0.05f;

            // Set the position here.
            X = 40;
            Y = nextY;

            // Tween the Entity across the screen and back for 180 frames.
            Tween(this, new { Y = Game.Instance.HalfWidth - 120 }, 300)
              .Ease(easeType)
              .RepeatDelay(30);
        }
    }
}