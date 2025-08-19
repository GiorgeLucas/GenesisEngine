using GenesisEngine.InputManager;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;

namespace GenesisEngine
{
    public class GameEngine
    {
        protected IWindow? window;
        private IInputContext? _inputContext;

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
            window.Run();
        }

        public virtual void OnLoad()
        {
            _inputContext = window!.CreateInput();
            for (int i = 0; i < _inputContext.Keyboards.Count; i++)
            {
                _inputContext.Keyboards[i].KeyDown += Input.OnKeyDown;
                _inputContext.Keyboards[i].KeyUp += Input.OnKeyUp;
            }

        }

        public virtual void OnUpdate(double deltaTime)
        {

        }

        public virtual void OnRender(double deltaTime)
        {

        }
    }
}
