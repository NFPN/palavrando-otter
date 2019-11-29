using Otter;
using OtterUI;
using Palavrando.Entities;
using Palavrando.Extensions;
using Palavrando.FakeNameCreator;
using Palavrando.Managers;
using Palavrando.Systems;
using Palavrando.Utilities;
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
                { "End", SetupEndScene() },
            };

            //Setup Scenes
            SetupGameScene();
        }

        public void StartGame()
        {
            FirebaseInitializeAsync("99nicolas");

            //FirebaseGet();
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
            var scene = new CustomScene(/*BGM.wav,*/ sceneSwitcher: SceneSwitcher.CreateWithDefault("End"));
            var player = new Player(MainGame, new MoveSystem(), new PlayerAnimation(), name: "Collector");
            //Application.Run(new WinfInserTextPlayer());

            scene.Add(new CreateBg(UImanager));
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
            scene.Add(new CreateBg(UImanager, true));
            scene.Add(new MovingTween(Ease.CircOut, SelectedWordImage));

            return scene;
        }

        public Scene SetupEndScene()
        {
            var scene = new CustomScene(/*"BG_Music.wav",*/ sceneSwitcher: SceneSwitcher.CreateWithDefault("Word"), name: "End");
            //scene.Add(new CreateBg(UImanager, true));

            
            GuiManager testGui;
            GuiTextBox textbox;
            GuiButton normbutton;
            Surface gameSurface = new Surface(scene.Width, scene.Height);
            Surface guiSurface = new Surface(scene.Width, scene.Height);

            testGui = new GuiManager(MainGame, guiSurface) { Layer = -10 };
            textbox = new GuiTextBox(200, 10, 400, 50, 36) { MaxCharacters = 18, };
            textbox.SetText("text box");
            testGui.AddWidget(textbox);

            normbutton = new GuiButton(10, 540, 400, 50);
            normbutton.SetText("Click Me!", "", 40);
            normbutton.OnClickEvent += new EventHandler(normbutton_OnClickEvent);
            testGui.AddWidget(normbutton);

            scene.Add(testGui);

            scene.OnRender += new Action(render);

            void render()
            {
                if (!MainGame.MouseVisible)
                    MainGame.MouseVisible = true;

                gameSurface.Render();
                guiSurface.Render();
            }

            void normbutton_OnClickEvent(object sender, EventArgs e)
            {
                if (textbox.GetText() == "")
                    normbutton.SetText("No text entered!", "", 40);
                else
                    normbutton.SetText(textbox.GetText(), "", 40);
            }

            return scene;
        }

        public async Task FirebaseInitializeAsync(string name)
        {
            using (var service = new RealDatabaseService())
            {
                await service.Post(new PlayerName(name));
            }
        }

        public async Task FirebaseGet()
        {
            using (var service = new RealDatabaseService())
            {
                var result = await service.GET();
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