using Silk.NET.Maths;
using System.Numerics;

namespace GenesisEngine.Components
{
    public class Transform : Component
    {
        public Vector3 Position { get; set; } = Vector3.Zero;
        public float Rotation { get; set; } = 0f;
        public Vector3 Scale { get; set; } = Vector3.One;
        public Transform()
        {
            Position = Vector3.Zero;
            Rotation = 0f;
            Scale = Vector3.One;
        }

        public Transform(Vector3 position)
        {
            Position = position;
            Rotation = 0f;
            Scale = Vector3.One;
        }

        public Transform(Vector3 position, float rotation)
        {
            Position = position;
            Rotation = rotation;
            Scale = Vector3.One;
        }

        public Transform(Vector3 position, float rotation, Vector3 scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }

        public Matrix4X4<float> GetTransformMatrix()
        {
            // 1️⃣ Escala
            Matrix4X4<float> scaleMatrix = Matrix4X4.CreateScale(Scale.X, Scale.Y, 1f);

            // 2️⃣ Rotação em Z
            Matrix4X4<float> rotationMatrix = Matrix4X4.CreateRotationZ(Rotation);

            // 3️⃣ Translação
            Matrix4X4<float> translationMatrix = Matrix4X4.CreateTranslation(Position.X, Position.Y, 0f);

            // 4️⃣ Multiplicar na ordem correta: Scale -> Rotate -> Translate
            return scaleMatrix * rotationMatrix * translationMatrix;
        }
    }
}
