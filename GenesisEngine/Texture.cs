using Silk.NET.OpenGL;
using StbImageSharp;

namespace GenesisEngine
{
    public class Texture
    {
        private readonly GL _gl;
        public readonly uint handle;
        public Texture(GL gl, string imagePath, TextureWrapMode wrapS = TextureWrapMode.Repeat,
                  TextureWrapMode wrapT = TextureWrapMode.Repeat,
                  TextureMinFilter minFilter = TextureMinFilter.LinearMipmapLinear,
                  TextureMagFilter magFilter = TextureMagFilter.Linear)
        {
            _gl = gl;
            handle = _gl.GenTexture();

            LoadFromFile(imagePath);
            SetupParameters(wrapS, wrapT, minFilter, magFilter);

        }

        private void LoadFromFile(string path)
        {
            // Load image data from file (using an image loading library like StbImageSharp or similar)
            // Bind the texture and upload the image data to the GPU
            // Set texture parameters (wrapping, filtering, etc.)

            var result = ImageResult.FromMemory(File.ReadAllBytes(path), ColorComponents.RedGreenBlueAlpha);

            _gl.BindTexture(TextureTarget.Texture2D, handle);

            unsafe
            {
                fixed (byte* dataPtr = result.Data)
                {
                    _gl.TexImage2D(TextureTarget.Texture2D, 0, InternalFormat.Rgba, (uint)result.Width, (uint)result.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, dataPtr);
                }
            }
        }

        private void SetupParameters(TextureWrapMode wrapS, TextureWrapMode wrapT,
                               TextureMinFilter minFilter, TextureMagFilter magFilter)
        {
            _gl.TextureParameter(handle, TextureParameterName.TextureWrapS, (int)wrapS);
            _gl.TextureParameter(handle, TextureParameterName.TextureWrapT, (int)wrapT);
            _gl.TextureParameter(handle, TextureParameterName.TextureMinFilter, (int)minFilter);
            _gl.TextureParameter(handle, TextureParameterName.TextureMagFilter, (int)magFilter);

            _gl.GenerateMipmap(TextureTarget.Texture2D);
        }

        public void Bind(uint unit = 0)
        {
            _gl.ActiveTexture(TextureUnit.Texture0 + (int)unit);
            _gl.BindTexture(TextureTarget.Texture2D, handle);
        }


    }
}
