namespace DawngarCore.Entities;

public class EntityManager
{
    private Dictionary<int, Entity> _entities;
    private int _nextEntityId = 1;
    private ComponentManager _componentManager;
    public EntityManager(ComponentManager componentManager)
    {
        _entities = new Dictionary<int, Entity>();
        _componentManager = componentManager;
    }
    public IEnumerable<Entity> GetAll() => _entities.Values.AsEnumerable();
    public Entity GetEntity(Entity entity) => GetEntity(entity.Id);
    public Entity GetEntity(int id) => _entities[id];

    public Entity CreateEntity()
    {
        Entity entity =  new Entity(_nextEntityId, _componentManager);
        _entities.Add(_nextEntityId, entity);
        _componentManager.AddEntity(entity);
        _nextEntityId++;
        return entity;
    }

    public void Remove(Entity entity)
    {
        _entities.Remove(entity.Id);
    }

}