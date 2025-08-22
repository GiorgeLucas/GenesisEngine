using GenesisEngine.Graphics;
using System.Numerics;

namespace GenesisEngine
{
    public class SpriteBatcher
    {
        private readonly Renderer _renderer;
        private Shader? _currentShader;
        private Texture? _currentTexture;
        private Mesh? _currentMesh;
        public SpriteBatcher(Renderer renderer)
        {
            _renderer = renderer;
        }

        public void Begin(Shader shader, Mesh mesh)
        {
            _currentShader = shader;
            _currentMesh = mesh;
            _renderer.UseShader(shader);
            _renderer.BindMesh(mesh);
        }

        public void DrawSprite(Texture texture, Matrix4x4 transform)
        {
            // Só bind texture se mudou
            if (_currentTexture != texture)
            {
                _renderer.BindTexture(texture);
                _currentTexture = texture;
            }

            _renderer.SetTransform(transform);
            _renderer.DrawCurrent();
        }

        public void End()
        {
            _currentShader = null;
            _currentTexture = null;
            _currentMesh = null;
        }
    }
}
