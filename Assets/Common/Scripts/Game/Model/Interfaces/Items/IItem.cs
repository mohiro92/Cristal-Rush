using Assets.Scripts.GameBase.Interfaces.Entities;

namespace Assets.Scripts.GameBase.Interfaces.Items
{
    public interface IItem
    {
        void Use(IEntity entity);
    }
}
