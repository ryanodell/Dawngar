using Dawngar.Systems;

namespace Dawngar.Loaders;

public interface IAnimationLoader
{
    BasicAnimation Load(string name);
    void LoadAllIntoMemory();
}

public class JsonAnimationLoader : IAnimationLoader
{
    public BasicAnimation Load(string name)
    {
        
        return new BasicAnimation();
    }

    public void LoadAllIntoMemory()
    {

    }
}