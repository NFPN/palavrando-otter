using Otter;
using Palavrando.Extensions;
using palavrando_otter.Systems;
using System;
using System.Collections.Generic;
using System.IO;

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
            GameObjectList = GameExtensions.ImageListMaker(PathFolder.getDirectory() + @"\Images\imgPalavra");
            Image image = null;

            var rand = new Random();
            foreach (var item in GameObjectList)
            {
                var randNum = rand.Next(0, GameObjectList.Count);
                GameObjectList[randNum].Scale = 0.45f;
                //image = new Image(GameObjectList);
            }

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