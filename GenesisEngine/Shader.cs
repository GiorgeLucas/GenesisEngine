using Silk.NET.OpenGL;
using System.Numerics;

namespace GenesisEngine.Graphics
{
    public class Shader
    {
        private readonly GL _gl;
        private readonly uint _program;
        public Shader(GL gl, string vertexPath, string fragmentPath)
        {
            _gl = gl;

            uint vertex = CompileShader(ShaderType.VertexShader, File.ReadAllText(vertexPath));
            uint fragment = CompileShader(ShaderType.FragmentShader, File.ReadAllText(fragmentPath));

            _program = _gl.CreateProgram();

            _gl.AttachShader(_program, vertex);
            _gl.AttachShader(_program, fragment);

            _gl.LinkProgram(_program);

            _gl.GetProgram(_program, ProgramPropertyARB.LinkStatus, out int lStatus);
            if (lStatus != (int)GLEnum.True)
                throw new Exception("Program failed to link: " + _gl.GetProgramInfoLog(_program));

            _gl.DetachShader(_program, vertex);
            _gl.DetachShader(_program, fragment);
            _gl.DeleteShader(vertex);
            _gl.DeleteShader(fragment);
        }

        private uint CompileShader(ShaderType type, string source)
        {
            uint shader = _gl.CreateShader(type);
            _gl.ShaderSource(shader, source);
            _gl.CompileShader(shader);

            _gl.GetShader(shader, ShaderParameterName.CompileStatus, out int status);
            if (status == 0)
                throw new Exception($"Erro ao compilar {type}: {_gl.GetShaderInfoLog(shader)}");

            return shader;
        }

        public void Use()
        {
            _gl.UseProgram(_program);
        }

        public void SetUniform(string name, int value)
        {
            int loc = _gl.GetUniformLocation(_program, name);
            if (loc != -1) _gl.Uniform1(loc, value);
        }

        public void SetUniform(string name, float value)
        {
            int loc = _gl.GetUniformLocation(_program, name);
            if (loc != -1) _gl.Uniform1(loc, value);
        }

        public void SetUniform(string name, Vector3 vec)
        {
            int loc = _gl.GetUniformLocation(_program, name);
            if (loc != -1) _gl.Uniform3(loc, vec.X, vec.Y, vec.Z);
        }

        public void SetUniform(string name, Matrix4x4 mat)
        {
            int loc = _gl.GetUniformLocation(_program, name);
            if (loc != -1)
            {
                unsafe
                {
                    _gl.UniformMatrix4(loc, 1, false, (float*)&mat);
                }
            }
        }

    }
}
