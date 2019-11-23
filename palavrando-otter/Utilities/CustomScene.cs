using Otter;

namespace Palavrando.Utils
{
    public class CustomScene : Scene
    {
        public Music SceneBGM { get; private set; }
        public Game SceneGame { get; private set; }

        public CustomScene(string bgmFilePath = null,Game game = null, int width = MyGlobal.WINDOWWIDTH, int height = MyGlobal.WINDOWHEIGHT)
            : base(width, height)
        {
            SceneGame = game;
            if (!string.IsNullOrWhiteSpace(bgmFilePath))
            {
                SceneBGM = new Music(bgmFilePath);
                SceneBGM.Play();
            }
        }
    }
}