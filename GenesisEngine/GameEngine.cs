using GenesisEngine.Components;
using GenesisEngine.Graphics;
using GenesisEngine.InputManager;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;
using System.Numerics;
using Shader = GenesisEngine.Graphics.Shader;

namespace GenesisEngine
{
    public class GameEngine
    {
        protected IWindow? window;
        protected Renderer Renderer;
        protected EntityManager EntityManager;

        private Mesh _quadMesh;
        private Shader _shader;
        private SpriteBatcher _spriteBatcher;

        private IInputContext? _inputContext;

        private static uint _texture;

        public GameEngine(string windowTitle, (int, int) windowSize)
        {
            WindowOptions windowOptions = WindowOptions.Default with
            {
                Size = new Vector2D<int>(windowSize.Item1, windowSize.Item2),
                Title = windowTitle,
            };

            // Cria a janela
            window = Window.Create(windowOptions);

            window.Load += OnLoad;
            window.Update += OnUpdate;
            window.Render += OnRender;
            window.FramebufferResize += OnFramebufferResize;
        }

        public void Run()
        {
            window!.Run();
        }

        private void LoadResources()
        {
            _shader = Renderer.CreateShader("Shaders/vertex.vert", "Shaders/fragment.frag");

            float[] vertex =
            {
              // aPosition--------   aTexCoords
                 0.5f,  0.5f, 0.0f,  1.0f, 1.0f,
                 0.5f, -0.5f, 0.0f,  1.0f, 0.0f,
                -0.5f, -0.5f, 0.0f,  0.0f, 0.0f,
                -0.5f,  0.5f, 0.0f,  0.0f, 1.0f
            };

            uint[] index =
            {
                0u, 1u, 3u,
                1u, 2u, 3u
            };

            _quadMesh = Renderer.CreateMesh(vertex, index);
        }

        public unsafe virtual void OnLoad()
        {
            _inputContext = window!.CreateInput();
            for (int i = 0; i < _inputContext.Keyboards.Count; i++)
            {
                _inputContext.Keyboards[i].KeyDown += Input.OnKeyDown;
                _inputContext.Keyboards[i].KeyUp += Input.OnKeyUp;
            }

            GL gl = window.CreateOpenGL();
            Renderer = new Renderer(gl);

            EntityManager = new();

            SetupProjection();

            LoadResources();

            _spriteBatcher = new SpriteBatcher(Renderer);
        }

        public virtual void OnUpdate(double deltaTime)
        {
            EntityManager.UpdateAll(deltaTime);
        }

        public virtual unsafe void OnRender(double deltaTime)
        {
            Renderer.Clear(1f, 1f, 1f, 1f);

            var entities = EntityManager.GetEntitiesWith<SpriteRenderer>()
               .Where(e => e.HasComponent<Transform>() && e.GetComponent<SpriteRenderer>()!.Enabled)
               .OrderBy(e => e.GetComponent<SpriteRenderer>()!.Layer)
               .ThenBy(e => e.GetComponent<SpriteRenderer>()!.Texture.handle);

            _spriteBatcher.Begin(_shader, _quadMesh);

            foreach (var entity in entities)
            {
                var sr = entity.GetComponent<SpriteRenderer>()!;
                var tr = entity.GetComponent<Transform>()!;

                _spriteBatcher.DrawSprite(sr.Texture, tr.GetTransformMatrix());
            }

            _spriteBatcher.End();
        }
        private void SetupProjection()
        {
            var projectionMatrix = Matrix4x4.CreateOrthographicOffCenter(
               0f, window!.Size.X,     // 0 a 800
               window.Size.Y, 0f,     // 600 a 0 (Y invertido)
               -1f, 1f);

            Renderer.SetProjection(projectionMatrix);
        }

        private void OnFramebufferResize(Vector2D<int> newSize)
        {
            Renderer.SetViewport(newSize.X, newSize.Y);
            SetupProjection();
        }

        public void Close()
        {
            if (window != null)
            {
                this.window!.Close();
            }
        }
    }
}
