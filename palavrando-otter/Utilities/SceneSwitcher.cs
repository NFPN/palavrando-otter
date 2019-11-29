using Otter;
using Palavrando.Interfaces;

namespace Palavrando.Utilities
{
    public class SceneSwitcher : Entity, ISwitchScene
    {
        private string SceneToKey { get; set; }
        public Entity Switcher { get; private set; }

        public SceneSwitcher() => Switcher = this;

        /// <summary>
        /// Generate a switcher entity with a default scene
        /// </summary>
        static public SceneSwitcher CreateWithDefault(string scene)
        {
            return new SceneSwitcher()
            {
                SceneToKey = scene,
            };
        }

        public void Switch()
        {
            Program.Manager.GameScenes.TryGetValue(SceneToKey, out Scene sceneTo);
            Game.Instance.SwitchScene(sceneTo);
        }

        public override void Update()
        {
            if (Input.KeyPressed(Key.Space) && Game.Instance != null)
            {
                Game.Instance.MouseVisible = false;
                Switch();
            }

            base.Update();
        }
    }
}