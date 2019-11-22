using Palavrando;

namespace Palavrando
{
    public static class Program
    {
        static public GameManager Manager { get; set; }
        private static void Main(string[] args)
        {
            Manager = new GameManager();
            Manager.StartGame();
        }
    }
}