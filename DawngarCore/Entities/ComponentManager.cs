using DawngarCore.Entities.Systems;

namespace  DawngarCore.Entities;

public class ComponentManager : UpdateSystem
{
    private Dictionary<Entity, List<object?>> _components;
    public ComponentManager()
    {
        _components = new Dictionary<Entity, List<object?>>();
    }

    public void AddEntity(Entity entity)
    {
        _components.Add(entity, new List<object?>());
    }

    public void AddComponent<T>(Entity entity, object? data) 
    {
        _components[entity].Add(data ?? default(T));
    }

    public T? GetComponent<T>(Entity entity) 
    {
        var components = _components[entity];
        foreach(var component in components) 
        {
            if(component is T typedComponent) 
            {
                return typedComponent;
            }
        }
        return default(T);
    }
    public void Remove<T>(Entity entity)
    {
        if(Has<T>(entity))
        {
            _components[entity].Remove(GetComponent<T>(entity));
        }
    }
    public bool Has<T>(Entity entity) 
    {
        var components = _components[entity];
        foreach(var component in components) 
        {
            if(component is T) 
            {
                return true;
            }
        }
        return false;
    }
}