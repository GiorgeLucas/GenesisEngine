using Silk.NET.OpenGL;
using System.Numerics;

namespace GenesisEngine.Graphics
{
    public class Renderer
    {
        private readonly GL _gl;
        private Matrix4x4 _projection;

        private Shader? _currentShader;
        private Texture? _currentTexture;
        private Mesh? _currentMesh;
        public Renderer(GL gl)
        {
            _gl = gl;
            InitDefaultState();

        }

        private void InitDefaultState()
        {
            _gl.Enable(EnableCap.Blend);
            _gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            _gl.Enable(EnableCap.DepthTest);
            _gl.ClearDepth(1.0f);
        }

        public void Clear(float r, float g, float b, float a)
        {
            _gl.ClearColor(r, g, b, a);
            _gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        public void SetViewport(int width, int height)
        {
            _gl.Viewport(0, 0, (uint)width, (uint)height);
        }

        public Shader CreateShader(string vertexPath, string fragmentPath)
        {
            return new Shader(_gl, vertexPath, fragmentPath);
        }

        public Texture CreateTexture(string path)
        {
            return new Texture(_gl, path);
        }

        public Mesh CreateMesh(float[] vertex, uint[] index)
        {
            return new Mesh(_gl, vertex, index);
        }

        public void SetProjection(Matrix4x4 projection)
        {
            _projection = projection;
        }

        public unsafe void Draw(Mesh mesh, Shader shader, Texture texture, Matrix4x4 transform)
        {
            UseShader(shader);
            BindTexture(texture);
            BindMesh(mesh);
            SetTransform(transform);
            DrawCurrent();
        }

        public void UseShader(Shader shader)
        {
            if (_currentShader != shader)
            {
                shader.Use();
                shader.SetUniform("uProjection", _projection);
                shader.SetUniform("uTexture", 0);
                _currentShader = shader;
            }
        }
        public void BindTexture(Texture texture)
        {
            if (_currentTexture != texture)
            {
                texture.Bind();
                _currentTexture = texture;
            }
        }

        public void BindMesh(Mesh mesh)
        {
            if (_currentMesh != mesh)
            {
                mesh.Bind();
                _currentMesh = mesh;
            }
        }

        public void SetTransform(Matrix4x4 transform)
        {
            _currentShader?.SetUniform("uTransform", transform);
        }

        public unsafe void DrawCurrent()
        {
            if (_currentMesh != null)
            {
                _gl.DrawElements(PrimitiveType.Triangles, _currentMesh.IndexCount,
                           DrawElementsType.UnsignedInt, (void*)0);
            }
        }

    }
}
