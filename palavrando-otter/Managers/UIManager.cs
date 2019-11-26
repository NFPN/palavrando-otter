using Otter;
using System.Collections.Generic;

namespace Palavrando.Managers
{
    public class UIManager 
    {
        public List<Text> DebugTexts { get; private set; }
        public RichText GameScore { get; private set; }

        public UIManager()
        {
            GameScore = ScoreSetup( "Score: 0");
          
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

        public void ChangeScoreText(string score)
        {
            GameScore.String = $"Score: {score}";
        }
    }
}