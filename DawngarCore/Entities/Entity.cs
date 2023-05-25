using DawngarCore.Collections;

namespace DawngarCore.Entities;

public class Entity : IEquatable<Entity>
{
    public int Id { get; }
    private ComponentManager _componentManager;
    public Entity(int id, ComponentManager componentManager) 
    {
        Id = id;
        _componentManager = componentManager;
    }

    public void AddComponent<T>() 
    {
        AddComponent<T>(default(T));
    }
    public void Remove<T>(T? component)
    {
        _componentManager.Remove<T>(this);
    }
    public bool Has<T>()
    {
        return _componentManager.Has<T>(this);
    }

    public T? GetComponent<T>() 
    {
        return _componentManager.GetComponent<T>(this);
    }
    public void AddComponent<T>(T? component)
    {
        _componentManager.AddComponent<T>(this, component ?? default(T));
    }

    public bool Equals(Entity? other)
    {
        if(other != null) 
        {
            if(this.Id == other.Id) 
            {
                return true;
            }
        }
        return false;
    }
}