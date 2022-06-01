namespace Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            using var core = new Core(name: "Engine", width: 600, height: 600);

            core.Run();
        }
    }
}
