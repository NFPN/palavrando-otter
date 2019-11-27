﻿using Otter;
using Palavrando.Entities;
using Palavrando.Extensions;
using Palavrando.Managers;
using Palavrando.Systems;
using Palavrando.Utilities;
using palavrando_otter.Systems;
using PalavrandoSetup.Data;
using PalavrandoSetup.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

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
            //TODO: make pikupitems from spawnmanager get a random image based on word folder         
            GameObjectList = GameExtensions.ImagePalavraBota(PathFolder.getDirectory() + @"\Images\imgObjetoPalavra\BotasProcurar");

            MainGame = new Game("Palavrandro", MyGlobal.WINDOWWIDTH, MyGlobal.WINDOWHEIGHT);
            UImanager = new UIManager();
            SpawnManager = new PickupItemSpawnManager();
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
            GameScenes.TryGetValue("Word", out Scene scene);
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
            var player = new Player(MainGame, new MoveSystem(), new PlayerAnimation(), name: "Collector");
            //FirebaseInitializeAsync(1,"nicolas","lindo","ana");
            scene.Add(new CreateBg(UImanager));
         
            scene.AddGraphic(UImanager.GameScore);
            scene.Add(player);
                var rand = new Random();
            foreach (var pickupItem in SpawnManager.PickupItems)
            {
                var randNum = rand.Next(0, GameObjectList.Count);
                GameObjectList[randNum].Scale = 0.1f;
                pickupItem.SetItem(GameObjectList[randNum]);
                //GameObjectList.Remove(GameObjectList[randNum]);
                scene.Add(pickupItem);
            }

            return scene;
        }

        public Scene SetupWordScene()
        {
            var scene = new CustomScene("BG_Music.wav", sceneSwitcher: SceneSwitcher.CreateWithDefault("Game"));
            scene.Add(new CreateBg(UImanager));

            scene.Add(new MovingTween(Ease.CircOut));

            return scene;
        }

        public async Task FirebaseInitializeAsync(int id, string name, string words, string playerWords)
        {
            using (var service = new RealDatabaseService())
            {
                await service.Post(new PlayerData()
                {
                    Id = id,
                    Name = name,
                    Score = new PlayerInstance()
                    {
                        IdPlayer = id,
                        Word = words,
                        PlayerWords = playerWords
                    }
                });
            }
        }
    }
}