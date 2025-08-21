using GenesisEngine;
using GenesisEngine.Components;
using GenesisEngine.InputManager;

namespace GameTest
{
    public class Game : GameEngine
    {
        Entity Player;

        public Game() : base("Just a simple game", (800, 600))
        {

        }

        public override void OnLoad()
        {
            base.OnLoad();
            Console.WriteLine("Game Loading...");
            // Crie a textura aqui, depois do base.OnLoad()
            var playerTexture = new Texture(_gl!, "silk.jpg");

            Player = EntityManager.CreateEntity();
            Player.AddComponent(new Transform());
            Player.AddComponent(new SpriteRenderer(playerTexture));

            Console.WriteLine("Player Texture: " + Player.GetComponent<SpriteRenderer>()?.Texture);
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
