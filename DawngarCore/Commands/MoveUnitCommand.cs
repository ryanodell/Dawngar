using DawngarCore.Entities;

namespace DawngarCore.Commands;

public class MoveUnitCommand : ICommand
{
    private Entity _entity;
    public MoveUnitCommand(Entity entity)
    {
        _entity =  entity;
    }
    public void Execute()
    {
        
    }

    public void Undo()
    {
        throw new NotImplementedException();
    }
}