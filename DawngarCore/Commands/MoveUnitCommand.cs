using DawngarCore.Entities;

namespace DawngarCore.Commands;

public class MoveUnitCommand : ICommand
{
    private Entity _entity;
    public MoveUnitCommand(Entity entity)
    {
        
    }
    public void Execute()
    {
        
        throw new NotImplementedException();
    }

    public void Undo()
    {
        throw new NotImplementedException();
    }
}