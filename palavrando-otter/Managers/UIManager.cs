using Otter;
using System.Collections.Generic;

namespace Palavrando.Managers
{
    public class UIManager
    {
        public RichText DebugTexts { get; private set; }
        public RichText GameScore { get; private set; }
        public RichText Message { get; private set; }


        public UIManager()
        {
            GameScore = ScoreSetup("Score: 0");
            Message = MessageToPlayer("Aperte Qualquer Tecla");
            DebugTexts = Debug("Insira a sua História com as palavras \n conhecidas Hoje");
        }

        //Text Configuration
        private RichText ScoreSetup(string scoreText)
        {
            var scoreConfig = new RichTextConfig()
            {
                CharColor0 = Color.Cyan,
                CharColor1 = Color.White,
                FontSize = 24,
            };

            return new RichText(scoreText, scoreConfig)
            {
                X = Game.Instance.HalfWidth - (scoreText.Length * 5),
                Y = 10,
                TextAlign = TextAlign.Center,
            };
        }

        private RichText MessageToPlayer(string scoreText)
        {
            var scoreConfig = new RichTextConfig()
            {
                CharColor0 = Color.Cyan,
                CharColor1 = Color.White,
                FontSize = 32,
            };

            return new RichText(scoreText, scoreConfig)
            {
                X = Game.Instance.HalfWidth - (scoreText.Length * 7),
                Y = Game.Instance.WindowHeight - (scoreText.Length * 5),
                TextAlign = TextAlign.Center,
            };
        }

        private RichText Debug(string scoreText)
        {
            var scoreConfig = new RichTextConfig()
            {
                CharColor0 = Color.Cyan,
                CharColor1 = Color.White,
                FontSize = 32,
            };

            return new RichText(scoreText, scoreConfig)
            {
                X = 10,
                Y = 50,
                TextAlign = TextAlign.Center,
                TextWidth = Game.Instance.WindowWidth,
            };
        }


        public void ChangeScoreText(string score)
        {
            GameScore.String = $"Score: {score}";
        }
    }
}