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
            var transform = Player.GetComponent<Transform>();
            transform.Position = new System.Numerics.Vector3(1.5f, 1.0f, 0);

            Player.AddComponent(new SpriteRenderer(playerTexture));

            Console.WriteLine("Player Texture: " + Player.GetComponent<SpriteRenderer>()?.Texture);
        }

        public override void OnUpdate(double deltaTime)
        {
            base.OnUpdate(deltaTime);

            var transform = Player.GetComponent<Transform>();
            transform.Scale = new System.Numerics.Vector3(64f, 64f, 1f);

            if (Input.GetKeyPressed(KeyCode.T))
            {
                transform.Scale = new System.Numerics.Vector3(transform.Scale.X + 20f, transform.Scale.Y + 20f, 1f);
            }

            if (Input.GetKeyPressed(KeyCode.G))
            {
                transform.Scale = new System.Numerics.Vector3(transform.Scale.X - 20f, transform.Scale.Y - 20f, 1f);
            }

            // Reset para posição visível primeiro
            if (Input.GetKeyDown(KeyCode.R))
            {
                transform.Position = new System.Numerics.Vector3(100f, 100f, 0f);
                Console.WriteLine($"Reset para: {transform.Position}");
            }

            if (Input.GetKeyPressed(KeyCode.D)) // Use GetKeyDown
            {
                transform.Position = new System.Numerics.Vector3(transform.Position.X + 0.2f, transform.Position.Y, 0f);
                Console.WriteLine($"Movendo para: {transform.Position}");
            }

            if (Input.GetKeyPressed(KeyCode.W))
            {
                transform.Position = new System.Numerics.Vector3(transform.Position.X, transform.Position.Y + 0.2f, 0f);
                Console.WriteLine($"Movendo para: {transform.Position}");
            }

            if (Input.GetKeyPressed(KeyCode.S))
            {
                transform.Position = new System.Numerics.Vector3(transform.Position.X, transform.Position.Y - 0.2f, 0f);
                Console.WriteLine($"Movendo para: {transform.Position}");
            }

            if (Input.GetKeyPressed(KeyCode.A))
            {
                transform.Position = new System.Numerics.Vector3(transform.Position.X - 0.2f, transform.Position.Y, 0f);
                Console.WriteLine($"Movendo para: {transform.Position}");
            }
        }

        public override void OnRender(double deltaTime)
        {
            base.OnRender(deltaTime);
        }

    }
}
