using DawngarCore.Entities.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DawngarCore.Entities;

public class World : IDisposable
{
    private List<IDrawSystem> _drawSystems;
    private List<IUpdateSystem> _updateSystems;
    private EntityManager _entityManager;
    private ComponentManager _componentManager;
    public World() 
    {
        _drawSystems = new List<IDrawSystem>();
        _updateSystems = new List<IUpdateSystem>();
        _componentManager = new ComponentManager();
        _entityManager = new EntityManager(_componentManager);
    }

    public void RegisterSystem(ISystem system) 
    {
        if(system is IDrawSystem drawSystem) 
        {
            _drawSystems.Add(drawSystem);
        }

        if(system is IUpdateSystem updateSystem) 
        {
            _updateSystems.Add(updateSystem);
        }
    }

    public Entity CreateEntity() => _entityManager.CreateEntity();

    public Entity GetEntity(int id) => _entityManager.GetEntity(id);

    public void Update(GameTime gameTime) 
    {
        foreach(var updateSystem in  _updateSystems) 
        {
            updateSystem.Update(gameTime);
        }
    }

    public void Draw(SpriteBatch spriteBatch, GameTime gameTime) 
    {
        foreach(var drawSystem in _drawSystems) 
        {
            drawSystem.Draw(spriteBatch, gameTime);
        }
    }

    public void Dispose()
    {
        foreach(var drawSystem in  _drawSystems) { drawSystem.Dispose(); }
        foreach(var updateSystem in  _updateSystems) { updateSystem.Dispose(); }
        _drawSystems.Clear();
        _updateSystems.Clear();
    }
}