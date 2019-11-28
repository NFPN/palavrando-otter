using Otter;
using Palavrando.Entities;
using Palavrando.Extensions;
using Palavrando.FakeNameCreator;
using Palavrando.Managers;
using Palavrando.Systems;
using Palavrando.Utilities;
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
        private List<Image> WordImageList { get; set; }
        private PickupItemSpawnManager SpawnManager { get; set; }
        public Image SelectedWordImage { get; set; }

        public Game MainGame { get; private set; }
        public Dictionary<string, Scene> GameScenes { get; private set; }
        public UIManager UImanager { get; private set; }

        public GameManager()
        {
            MainGame = new Game("Palavrandro", MyGlobal.WINDOWWIDTH, MyGlobal.WINDOWHEIGHT);
            AwakeManager();
        }

        private void AwakeManager()
        {
            SelectedWordImage = GetRandomImageFromFolder(out string wordName);
            //TODO: make pikupitems from spawnmanager get a random image based on word folder
            WordImageList = GameExtensions.ImageListMaker(PathFolder.GetDirectory() + @"\Images\imgObjetoPalavra", out List<string> _, wordName);

            if (WordImageList.Count > 5)
                WordImageList.Remove(WordImageList[0]);

            UImanager = new UIManager();
            SpawnManager = new PickupItemSpawnManager();
            GameScenes = new Dictionary<string, Scene>()
            {
                { "Word", SetupWordScene() },
                { "Game", SetupGameScene() },
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
            FirebaseInitializeAsync(Guid.NewGuid(),"99nicolas",DateTime.Now);
            scene.Add(new CreateBg(UImanager,scene));
            //scene.AddGraphic(UImanager.GameScore);
            scene.Add(player);

            for (int i = 0; i < SpawnManager.PickupItems.Count; i++)
            {
                var item = SpawnManager.PickupItems[i];
                item.SetItem(WordImageList[i]);
                item.Graphic.ScaledHeight = 50;
                item.Graphic.ScaledWidth = 50;
                item.Name = Path.GetFileNameWithoutExtension(item.Graphic.Texture.Source);
                scene.Add(item);
                //var test = SpawnManager.PickupItems[i].Graphic.Texture.Source.Contains("Corret");
            }
            return scene;
        }

        public Scene SetupWordScene()
        {
            var scene = new CustomScene(/*"BG_Music.wav",*/ sceneSwitcher: SceneSwitcher.CreateWithDefault("Game"));
            scene.Add(new CreateBg(UImanager,scene));
            scene.Add(new MovingTween(Ease.CircOut, SelectedWordImage));
            return scene;
        }

        public async Task FirebaseInitializeAsync(Guid id, string name, DateTime date)
        {
            using (var service = new RealDatabaseService())
            {
                await service.Post(new PlayerName(id,name,date)
                {
                    //Id = id,
                    //Nome = name,
                    //DataNascimento = date
                    //Score = new PlayerInstance()
                    //{
                    //    IdPlayer = id,
                    //    Word = words,
                    //    PlayerWords = playerWords
                    //}
                });
            }
        }

        public Image GetRandomImageFromFolder(out string imageName)
        {
            var imgList = GameExtensions.ImageListMaker(PathFolder.GetDirectory() + @"\Images\imgPalavra", out List<string> names);
            var rand = new Random();
            var randNum = rand.Next(0, imgList.Count);
            imageName = Path.GetFileNameWithoutExtension(names[randNum]);
            return imgList[randNum];
        }
    }
}