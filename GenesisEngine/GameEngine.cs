using GenesisEngine.Components;
using GenesisEngine.InputManager;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;
using System.Numerics;

namespace GenesisEngine
{
    public class GameEngine
    {
        protected IWindow? window;
        private Matrix4x4 _projectionMatrix;
        private IInputContext? _inputContext;
        protected GL? _gl;
        private uint _vao, _vbo, _ebo;
        private uint _program;
        protected EntityManager EntityManager = new();
        private Texture testTexture;


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

        public unsafe virtual void OnLoad()
        {
            _inputContext = window!.CreateInput();
            for (int i = 0; i < _inputContext.Keyboards.Count; i++)
            {
                _inputContext.Keyboards[i].KeyDown += Input.OnKeyDown;
                _inputContext.Keyboards[i].KeyUp += Input.OnKeyUp;
            }

            _gl = window.CreateOpenGL();

            _gl.ClearColor(System.Drawing.Color.CornflowerBlue);

            // Create the VAO.
            _vao = _gl.GenVertexArray();
            _gl.BindVertexArray(_vao);

            // The quad vertices data.
            // You may have noticed an addition - texture coordinates!
            // Texture coordinates are a value between 0-1 (see more later about this) which tell the GPU which part
            // of the texture to use for each vertex.
            float[] vertices =
            {
              // aPosition--------   aTexCoords
                 0.5f,  0.5f, 0.0f,  1.0f, 1.0f,
                 0.5f, -0.5f, 0.0f,  1.0f, 0.0f,
                -0.5f, -0.5f, 0.0f,  0.0f, 0.0f,
                -0.5f,  0.5f, 0.0f,  0.0f, 1.0f
            };

            // Create the VBO.
            _vbo = _gl.GenBuffer();
            _gl.BindBuffer(BufferTargetARB.ArrayBuffer, _vbo);

            // Upload the vertices data to the VBO.
            fixed (float* buf = vertices)
                _gl.BufferData(BufferTargetARB.ArrayBuffer, (nuint)(vertices.Length * sizeof(float)), buf, BufferUsageARB.StaticDraw);

            // The quad indices data.
            uint[] indices =
            {
                0u, 1u, 3u,
                1u, 2u, 3u
            };

            // Create the EBO.
            _ebo = _gl.GenBuffer();
            _gl.BindBuffer(BufferTargetARB.ElementArrayBuffer, _ebo);

            // Upload the indices data to the EBO.
            fixed (uint* buf = indices)
                _gl.BufferData(BufferTargetARB.ElementArrayBuffer, (nuint)(indices.Length * sizeof(uint)), buf, BufferUsageARB.StaticDraw);

            // The vertex shader code.
            const string vertexCode = @"
        #version 330 core
        
        layout (location = 0) in vec3 aPosition;

        // On top of our aPosition attribute, we now create an aTexCoords attribute for our texture coordinates.
        layout (location = 1) in vec2 aTexCoords;

        uniform mat4 uProjection;
        uniform mat4 uTransform;

        // Likewise, we also assign an out attribute to go into the fragment shader.
        out vec2 frag_texCoords;
        
        void main()
        {
            gl_Position = uProjection * uTransform * vec4(aPosition, 1.0);

            // This basic vertex shader does no additional processing of texture coordinates, so we can pass them
            // straight to the fragment shader.
            frag_texCoords = aTexCoords;
        }";

            // The fragment shader code.
            const string fragmentCode = @"
        #version 330 core

        // This in attribute corresponds to the out attribute we defined in the vertex shader.
        in vec2 frag_texCoords;
        
        out vec4 out_color;

        // Now we define a uniform value!
        // A uniform in OpenGL is a value that can be changed outside of the shader by modifying its value.
        // A sampler2D contains both a texture and information on how to sample it.
        // Sampling a texture is basically calculating the color of a pixel on a texture at any given point.
        uniform sampler2D uTexture;
        
        void main()
        {
            // We use GLSL's texture function to sample from the texture at the given input texture coordinates.
            out_color = texture(uTexture, frag_texCoords);
        }";

            // Create our vertex shader, and give it our vertex shader source code.
            uint vertexShader = _gl.CreateShader(ShaderType.VertexShader);
            _gl.ShaderSource(vertexShader, vertexCode);

            // Attempt to compile the shader.
            _gl.CompileShader(vertexShader);

            // Check to make sure that the shader has successfully compiled.
            _gl.GetShader(vertexShader, ShaderParameterName.CompileStatus, out int vStatus);
            if (vStatus != (int)GLEnum.True)
                throw new Exception("Vertex shader failed to compile: " + _gl.GetShaderInfoLog(vertexShader));

            // Repeat this process for the fragment shader.
            uint fragmentShader = _gl.CreateShader(ShaderType.FragmentShader);
            _gl.ShaderSource(fragmentShader, fragmentCode);

            _gl.CompileShader(fragmentShader);

            _gl.GetShader(fragmentShader, ShaderParameterName.CompileStatus, out int fStatus);
            if (fStatus != (int)GLEnum.True)
                throw new Exception("Fragment shader failed to compile: " + _gl.GetShaderInfoLog(fragmentShader));

            // Create our shader program, and attach the vertex & fragment shaders.
            _program = _gl.CreateProgram();

            _gl.AttachShader(_program, vertexShader);
            _gl.AttachShader(_program, fragmentShader);

            // Attempt to "link" the program together.
            _gl.LinkProgram(_program);

            // Similar to shader compilation, check to make sure that the shader program has linked properly.
            _gl.GetProgram(_program, ProgramPropertyARB.LinkStatus, out int lStatus);
            if (lStatus != (int)GLEnum.True)
                throw new Exception("Program failed to link: " + _gl.GetProgramInfoLog(_program));

            // Detach and delete our shaders. Once a program is linked, we no longer need the individual shader objects.
            _gl.DetachShader(_program, vertexShader);
            _gl.DetachShader(_program, fragmentShader);
            _gl.DeleteShader(vertexShader);
            _gl.DeleteShader(fragmentShader);

            // Set up our vertex attributes! These tell the vertex array (VAO) how to process the vertex data we defined
            // earlier. Each vertex array contains attributes. 

            // Our stride constant. The stride must be in bytes, so we take the first attribute (a vec3), multiply it
            // by the size in bytes of a float, and then take our second attribute (a vec2), and do the same.
            const uint stride = (3 * sizeof(float)) + (2 * sizeof(float));

            // Enable the "aPosition" attribute in our vertex array, providing its size and stride too.
            const uint positionLoc = 0;
            _gl.EnableVertexAttribArray(positionLoc);
            _gl.VertexAttribPointer(positionLoc, 3, VertexAttribPointerType.Float, false, stride, (void*)0);

            // Now we need to enable our texture coordinates! We've defined that as location 1 so that's what we'll use
            // here. The code is very similar to above, but you must make sure you set its offset to the **size in bytes**
            // of the attribute before.
            const uint textureLoc = 1;
            _gl.EnableVertexAttribArray(textureLoc);
            _gl.VertexAttribPointer(textureLoc, 2, VertexAttribPointerType.Float, false, stride, (void*)(3 * sizeof(float)));

            // Unbind everything as we don't need it.
            _gl.BindVertexArray(0);
            _gl.BindBuffer(BufferTargetARB.ArrayBuffer, 0);
            _gl.BindBuffer(BufferTargetARB.ElementArrayBuffer, 0);

            SetupProjection();

            // Unbind the texture as we no longer need to update it any further.
            _gl.BindTexture(TextureTarget.Texture2D, 0);

            // Get our texture uniform, and set it to 0.
            // We can easily do this by using glGetUniformLocation and giving it a name.
            // Setting it to 0 tells it that you want it to use the 0th texture unit.
            // Generally, OpenGL should automatically initialize all uniform values to their default value (which is
            // almost always 0), however you should get into the practice of initializing all uniform values to a known
            // value, before you use them in your shader.
            int location = _gl.GetUniformLocation(_program, "uTexture");
            _gl.Uniform1(location, 0);

            // Finally a bit of blending!
            // If you disable blending, you'll notice a black border around the texture.
            // The texture is partially transparent, however OpenGL doesn't know how to handle this by default.
            // By enabling blending, and giving it a blend function, you can tell OpenGL how to handle transparency.
            // In this case, it removes the black background and just leaves the texture on its own.
            // The blend function is out of scope for this tutorial, so don't worry if you don't understand it too much.
            // The program will function just fine without blending!
            _gl.Enable(EnableCap.Blend);
            _gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);



        }

        public virtual void OnUpdate(double deltaTime)
        {
            EntityManager.UpdateAll(deltaTime);
        }

        public virtual unsafe void OnRender(double deltaTime)
        {
            _gl!.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            _gl.BindVertexArray(_vao);
            _gl!.UseProgram(_program);

            // renderização aqui
            var entities = EntityManager.GetEntitiesWith<SpriteRenderer>()
                   .Where(e => e.HasComponent<Transform>());

            entities = entities.OrderBy(e => e.GetComponent<SpriteRenderer>()!.Layer);
            foreach (var entity in entities)
            {
                var sr = entity.GetComponent<SpriteRenderer>()!;
                var tr = entity.GetComponent<Transform>()!;

                if (!sr.Enabled) continue;


                Matrix4X4<float> model = tr.GetTransformMatrix(); // posição, rotação, escala
                float[] TransformArray = {
                    model.M11, model.M12, model.M13, model.M14,
                    model.M21, model.M22, model.M23, model.M24,
                    model.M31, model.M32, model.M33, model.M34,
                    model.M41, model.M42, model.M43, model.M44
                };



                int matrixLocation = _gl.GetUniformLocation(_program, "uTransform");
                _gl.UniformMatrix4(matrixLocation, 1, false, TransformArray);

                sr.Texture.Bind();

                _gl.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, (void*)0);

            }
        }
        private void SetupProjection()
        {
            Console.WriteLine("Width: " + window!.Size.X + ", Height: " + window.Size.Y);
            _projectionMatrix = Matrix4x4.CreateOrthographicOffCenter(
               0f, window!.Size.X,     // 0 a 800
               0f, window.Size.Y,     // 600 a 0 (Y invertido)
               -1f, 1f);

            _gl!.UseProgram(_program);
            int projLocation = _gl!.GetUniformLocation(_program, "uProjection");

            float[] projectionArray = {
                _projectionMatrix.M11, _projectionMatrix.M12, _projectionMatrix.M13, _projectionMatrix.M14,
                _projectionMatrix.M21, _projectionMatrix.M22, _projectionMatrix.M23, _projectionMatrix.M24,
                _projectionMatrix.M31, _projectionMatrix.M32, _projectionMatrix.M33, _projectionMatrix.M34,
                _projectionMatrix.M41, _projectionMatrix.M42, _projectionMatrix.M43, _projectionMatrix.M44
            };
            _gl.UniformMatrix4(projLocation, false, projectionArray);
        }

        private void OnFramebufferResize(Vector2D<int> newSize)
        {
            _gl!.Viewport(newSize);
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
