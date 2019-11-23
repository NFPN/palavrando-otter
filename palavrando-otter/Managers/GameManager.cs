using Otter;
using Palavrando.Entities;
using Palavrando.Managers;
using Palavrando.Systems;
using Palavrando.Utils;
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

        public GameManager()
        {
            MainGame = new Game("The Collector", MyGlobal.WINDOWWIDTH, MyGlobal.WINDOWHEIGHT);
            UImanager = new UIManager(MainGame);
            SpawnManager = new PickupItemSpawnManager(MainGame);
            GameScenes = new Dictionary<string, Scene>()
            {
                { "Game", SetupGameScene() },
                { "Word", SetupWordScene() },
            };

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
            var scene = new CustomScene(/*BGM.wav*/);
            var player = new Player(MainGame, new MoveSystem(), name: "Collector");

            //Add scene Graphics
            scene.AddGraphic(UImanager.GameScore);

            //Add scene Entities
            scene.Add(player);
            foreach (var pickupItem in SpawnManager.PickupItems)
                scene.Add(pickupItem);

            return scene;
        }

        public Scene SetupWordScene()
        {
            var scene = new CustomScene(/*BGM.wav*/);
            scene.AddGraphic(Image.CreateRectangle(Game.Instance.Width, Game.Instance.Height, Color.Blue));
            return scene;
        }
    }
}