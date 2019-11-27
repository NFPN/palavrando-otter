namespace Palavrando
{
    public static class Program
    {
        public static GameManager Manager { get; set; }

        private static void Main(string[] args)
        {
            Manager = new GameManager();
            Manager.StartGame();
        }

        public static void ResetGame()
        {
            Manager.MainGame.Close();
            Manager = new GameManager();
            Manager.StartGame();
        }
    }
}