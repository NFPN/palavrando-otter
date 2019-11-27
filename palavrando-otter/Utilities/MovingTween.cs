using Otter;
using System;

namespace Palavrando.Utilities
{
    public class MovingTween : Entity
    {
        private float NextY { get; set; }
        private float Spacing { get; set; } = 10;
        private float NextHue { get; set; } = 40;

        public MovingTween(Func<float, float> easeType, Image chosenWord)
        {
            chosenWord.CenterOrigin();
            chosenWord.Scale = 0.45f;
            chosenWord.Scale = .45f;
            chosenWord.SetPosition(new Vector2(MyGlobal.WINDOWWIDTH / 2, 0));
            AddGraphic(chosenWord);

            // Adjust the nextY and nextHue for the future MovingTweens.
            NextY += Spacing;
            NextHue += 0.05f;

            // Set the position here.
            X = 40;
            Y = NextY;

            // Tween the Entity across the screen and back for 180 frames.
            Tween(this, new { Y = Game.Instance.HalfWidth - 120 }, 300)
              .Ease(easeType)
              .RepeatDelay(30);
        }
    }
}