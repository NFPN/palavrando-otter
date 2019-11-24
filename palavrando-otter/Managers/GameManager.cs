using Otter;
using Palavrando.Entities;
using Palavrando.Extensions;
using Palavrando.Managers;
using Palavrando.Systems;
using Palavrando.Utilities;
using System.Collections.Generic;

namespace Palavrando
{
    public class GameManager
    {
        private int Score { get; set; }
        private Game MainGame { get; set; }

        public UIManager UImanager { get; private set; }
        public PickupItemSpawnManager SpawnManager { get; private set; }
        public Dictionary<string, Scene> GameScenes { get; private set; }
        public List<Image> GameObjectList { get; private set; }

        public GameManager()
        {
            MainGame = new Game("The Collector", MyGlobal.WINDOWWIDTH, MyGlobal.WINDOWHEIGHT);
            UImanager = new UIManager(MainGame);
            SpawnManager = new PickupItemSpawnManager();
            GameScenes = new Dictionary<string, Scene>()
            {
                { "Word", SetupWordScene() },
                { "Game", SetupGameScene() },
            };

            //TODO: make pikupitems from spawnmanager get a random image based on word folder
            GameObjectList = GameExtensions.ImageListMaker(@"D:\GitRepos\palavrando-otter\palavrando-otter\Images\");

            //Setup Scenes
            SetupGameScene();
        }

        public void StartGame()
        {
            GameScenes.TryGetValue("Game", out Scene scene);
            MainGame.Start(scene);
        }

        public void AddScore(int value)
        {
            Score += value;
            UImanager.ChangeScoreText(Score.ToString());
        }

        private Scene SetupGameScene()
        {
            var scene = new CustomScene(/*BGM.wav,*/ sceneSwitcher: SceneSwitcher.CreateWithDefault("Word"));
            var player = new Player(MainGame, new MoveSystem(), name: "Collector");

            //Add scene Graphics
            scene.AddGraphic(UImanager.GameScore);

            //Move the Text word to a player in Vertical
            scene.Add(new MovingTween(Ease.CircOut));

            // Add an Entity that tweens in response to a key press.
            scene.Add(new ReactiveTween(540, 400));

            //Add scene Entities
            scene.Add(player);
            foreach (var pickupItem in SpawnManager.PickupItems)
                scene.Add(pickupItem);

            return scene;
        }

        public Scene SetupWordScene()
        {
            var scene = new CustomScene(/*BGM.wav,*/ sceneSwitcher: SceneSwitcher.CreateWithDefault("Game"));
            scene.AddGraphic(Image.CreateRectangle(Game.Instance.Width, Game.Instance.Height, Color.Grey));
            return scene;
        }
    }
}