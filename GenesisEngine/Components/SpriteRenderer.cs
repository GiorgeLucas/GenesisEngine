namespace GenesisEngine.Components
{
    public struct Color
    {
        public float R, G, B, A;

        public Color(float r, float g, float b, float a = 1f)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
    public class SpriteRenderer : Component
    {
        public Texture Texture { get; set; }
        //public Color Color { get; set; } = new Color(1f, 1f, 1f, 1f);
        public int Layer { get; set; } = 0;
        public SpriteRenderer(Texture texture)
        {
            Texture = texture;
        }
    }
}
