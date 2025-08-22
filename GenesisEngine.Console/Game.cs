using GenesisEngine;
using GenesisEngine.Components;

namespace GameTest
{
    public class Game : GameEngine
    {
        Entity Player;
        Entity Player2;

        public Game() : base("Just a simple game", (800, 600))
        {

        }

        public override void OnLoad()
        {
            base.OnLoad();
            Console.WriteLine("Game Loading...");

            var playerTexture = Renderer.CreateTexture("silk.png");

            Player = EntityManager.CreateEntity();
            Player.AddComponent(new Transform());
            var transform1 = Player.GetComponent<Transform>();
            transform1!.Position = new System.Numerics.Vector3(1.5f, 1.0f, 0);
            transform1!.Scale = new System.Numerics.Vector3(64f, 64f, 1f);
            Player.AddComponent(new SpriteRenderer(playerTexture));

            Player2 = EntityManager.CreateEntity();
            Player2.AddComponent(new Transform());
            Player2.AddComponent(new SpriteRenderer(playerTexture));
            var transform2 = Player2.GetComponent<Transform>();
            transform2!.Position = new System.Numerics.Vector3(5.5f, 5.0f, 0);
            transform2!.Scale = new System.Numerics.Vector3(64f, 64f, 1f);
        }

        public override void OnUpdate(double deltaTime)
        {
            base.OnUpdate(deltaTime);

        }

        public override void OnRender(double deltaTime)
        {
            base.OnRender(deltaTime);
        }

    }
}
