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
            Matrix4X4<float> scaleMatrix = Matrix4X4.CreateScale(Scale.X, Scale.Y, 1f);
            Matrix4X4<float> rotationMatrix = Matrix4X4.CreateRotationZ(Rotation);
            Matrix4X4<float> translationMatrix = Matrix4X4.CreateTranslation(Position.X, Position.Y, 0f);

            // Ordem correta: TRS (Translation * Rotation * Scale)
            return translationMatrix * rotationMatrix * scaleMatrix;
        }
    }
}
