using Dawngar.Systems;
using DefaultEcs;
using DefaultEcs.Resource;

namespace Dawngar;

public class AnimationResourceManager : AResourceManager<(string name, string idx), BasicAnimation>
{
    protected override BasicAnimation Load((string, string) info)
    {
        throw new System.NotImplementedException();
    }

    protected override void OnResourceLoaded(in Entity entity, (string, string) info, BasicAnimation resource)
    {
        throw new System.NotImplementedException();
    }
}