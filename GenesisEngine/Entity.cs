namespace GenesisEngine
{
    public class Entity
    {
        public int Id { get; }
        private Dictionary<Type, Component> _components = new();
        public Entity(int id) => Id = id;

        public T AddComponent<T>(T component) where T : Component
        {
            var type = typeof(T);
            _components[type] = component;
            component.Entity = this;
            component.Awake();
            return component;
        }

        public T? GetComponent<T>() where T : Component
        {
            var type = typeof(T);
            if (_components.TryGetValue(type, out var component))
                return (T)component;
            return default;
        }

        public bool TryGetComponent<T>(out T? component) where T : Component
        {
            if (_components.TryGetValue(typeof(T), out var stored))
            {
                component = (T)stored;
                return true;
            }
            component = default;
            return false;
        }

        public IEnumerable<Component> GetAllComponents()
        {
            return _components.Values;
        }

        public bool HasComponent<T>() where T : Component
        {
            return _components.ContainsKey(typeof(T));
        }

        public void RemoveComponent<T>() where T : Component
        {
            if (_components.TryGetValue(typeof(T), out var component))
            {
                component.Destroy();
                _components.Remove(typeof(T));
            }
        }
    }
}
