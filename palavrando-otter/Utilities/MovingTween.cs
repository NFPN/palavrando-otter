using Otter;
using Palavrando.Extensions;
using Palavrando.Systems;
using System;
using System.Collections.Generic;

namespace Palavrando.Utilities
{
    public class MovingTween : Entity
    {
        public List<Image> GameObjectList { get; private set; }
        private static float nextY;
        private static float spacing = 10;
        private static float nextHue = 40;

        public MovingTween(Func<float, float> easeType)
        {
            GameObjectList = GameExtensions.ImageListMaker(PathFolder.GetDirectory() + @"\Images\imgPalavra");

            var rand = new Random();
            var randNum = rand.Next(0, GameObjectList.Count);
            var randImg = GameObjectList[randNum];
            randImg.CenterOrigin();
            randImg.Scale = 0.45f;
            randImg.Scale = .45f;
            randImg.SetPosition(new Vector2(MyGlobal.WINDOWWIDTH / 2, 0));
            AddGraphic(randImg);

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