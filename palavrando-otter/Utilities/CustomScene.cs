using Otter;
using Palavrando.Interfaces;

namespace Palavrando.Utilities
{
    public class CustomScene : Scene
    {
        public Music SceneBGM { get; private set; }
        public string Name { get; private set; }

        public CustomScene(string bgmFilePath = null, ISwitchScene sceneSwitcher = null, int width = MyGlobal.WINDOWWIDTH, int height = MyGlobal.WINDOWHEIGHT , string name = "")
            : base(width, height)
        {
            if (!string.IsNullOrWhiteSpace(bgmFilePath))
            {
                SceneBGM = new Music(bgmFilePath);
                SceneBGM.Play();
            }

            //Add interfaced SceneSwitcher Entity
            Add(sceneSwitcher.Switcher);
        }
    }
}