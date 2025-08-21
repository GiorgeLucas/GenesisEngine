namespace GenesisEngine
{
    public abstract class Component
    {
        public Entity? Entity { get; internal set; }
        public bool Enabled { get; set; } = true;

        public virtual void Awake() { }
        public virtual void Update(double deltaTime) { }
        public virtual void Destroy() { }

    }
}
