namespace GenesisEngine
{
    public class EntityManager
    {
        private Dictionary<int, Entity> _entities = new();
        private int _nextID = 0;

        public Entity CreateEntity()
        {
            var entity = new Entity(_nextID++);
            _entities.Add(entity.Id, entity);
            return entity;
        }

        public void DestroyEntity(Entity entity)
        {
            foreach (var component in entity.GetAllComponents())
                component.Destroy();
            _entities.Remove(entity.Id);
        }

        public Entity? GetEntity(int id)
        {
            _entities.TryGetValue(id, out var entity);
            return entity;
        }

        public IEnumerable<Entity> GetEntities() => _entities.Values;

        public IEnumerable<Entity> GetEntitiesWith<T>() where T : Component
        {
            return _entities.Values.Where(e => e.HasComponent<T>());
        }

        public void UpdateAll(double deltaTime)
        {
            foreach (var entity in _entities.Values)
            {
                foreach (var component in entity.GetAllComponents())
                {
                    if (component.Enabled)
                    {
                        component.Update(deltaTime);
                    }
                }
            }
        }
    }
}
