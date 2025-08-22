using Silk.NET.OpenGL;

namespace GenesisEngine.Graphics
{
    public class Mesh
    {
        private readonly GL _gl;
        private readonly uint _vao;
        private readonly uint _vbo;
        private readonly uint _ebo;

        public uint IndexCount { get; private set; }

        public unsafe Mesh(GL gl, float[] vertex, uint[] index)
        {
            _gl = gl;
            IndexCount = (uint)index.Length;

            _vao = _gl.GenVertexArray();
            _vbo = _gl.GenBuffer();
            _ebo = _gl.GenBuffer();

            _gl.BindVertexArray(_vao);

            _gl.BindBuffer(BufferTargetARB.ArrayBuffer, _vbo);
            fixed (float* buf = vertex)
                _gl.BufferData(BufferTargetARB.ArrayBuffer, (nuint)(vertex.Length * sizeof(float)), buf, BufferUsageARB.StaticDraw);

            _gl.BindBuffer(BufferTargetARB.ElementArrayBuffer, _ebo);
            fixed (uint* buf = index)
                _gl.BufferData(BufferTargetARB.ElementArrayBuffer, (nuint)(index.Length * sizeof(uint)), buf, BufferUsageARB.StaticDraw);

            const uint stride = (3 * sizeof(float)) + (2 * sizeof(float));

            const uint positionLoc = 0;

            _gl.EnableVertexAttribArray(positionLoc);
            _gl.VertexAttribPointer(positionLoc, 3, VertexAttribPointerType.Float, false, stride, (void*)0);

            const uint textureLoc = 1;
            _gl.EnableVertexAttribArray(textureLoc);
            _gl.VertexAttribPointer(textureLoc, 2, VertexAttribPointerType.Float, false, stride, (void*)(3 * sizeof(float)));

            _gl.BindVertexArray(0);
            _gl.BindBuffer(BufferTargetARB.ArrayBuffer, 0);
            _gl.BindBuffer(BufferTargetARB.ElementArrayBuffer, 0);
        }
        public void Bind()
        {
            _gl.BindVertexArray(_vao);
        }
    }
}
