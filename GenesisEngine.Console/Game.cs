using GenesisEngine;
using GenesisEngine.InputManager;

namespace GameTest
{
    public class Game : GameEngine
    {
        public Game(string windowTitle, (int, int) windowSize) : base(windowTitle, windowSize)
        {

        }

        public override void OnLoad()
        {
            base.OnLoad();
            Console.WriteLine("Game Loading...");

        }

        public override void OnUpdate(double deltaTime)
        {
            base.OnUpdate(deltaTime);

            if (Input.GetKeyPressed(KeyCode.D))
            {
                Console.WriteLine("Usuário pressionou D");
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Console.WriteLine("Usuário apertou A");
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                this.Close();
            }
        }

        public override void OnRender(double deltaTime)
        {
            base.OnRender(deltaTime);
        }

    }
}
