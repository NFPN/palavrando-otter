using Otter;
using Palavrando.Entities;
using Palavrando.Managers;
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
            MainGame = new Game("The Collector", Global.WINDOWWIDTH, Global.WINDOWHEIGHT);
            UImanager = new UIManager(MainGame);
            SpawnManager = new PickupItemSpawnManager(MainGame);
            GameScenes = new Dictionary<string, Scene>()
            {
                { "Game",new CustomScene("BGM.wav") },
            };

            foreach (var sceneItem in GameScenes)
                MainGame.AddScene(sceneItem.Value);

            //Setup Scenes
            SetupGameScene();
        }

        public void StartGame() => MainGame.Start();

        public void AddScore(int value)
        {
            Score += value;
            UImanager.ChangeScoreText(Score.ToString());
        }

        private void SetupGameScene()
        {
            GameScenes.TryGetValue("Game", out Scene scene);
            var player = new Player(MainGame, name: "Collector");

            //Add scene Graphics
            scene.AddGraphic(UImanager.GameScore);

            //Add scene Entities
            scene.Add(player);
            foreach (var pickupItem in SpawnManager.PickupItems)
                scene.Add(pickupItem);
        }
    }
}