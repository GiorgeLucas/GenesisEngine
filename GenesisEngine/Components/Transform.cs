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

        public Matrix4x4 GetTransformMatrix()
        {
            Matrix4x4 scaleMatrix = Matrix4x4.CreateScale(Scale.X, Scale.Y, 1f);
            Matrix4x4 rotationMatrix = Matrix4x4.CreateRotationZ(Rotation);
            Matrix4x4 translationMatrix = Matrix4x4.CreateTranslation(Position.X, Position.Y, 0f);

            // Ordem correta: TRS (Translation * Rotation * Scale)
            return translationMatrix * rotationMatrix * scaleMatrix;
        }
    }
}
