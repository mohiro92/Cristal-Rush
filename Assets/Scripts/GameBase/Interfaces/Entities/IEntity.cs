using Assets.Scripts.GameBase.Interfaces.Entities.Body;
using Assets.Scripts.GameBase.Interfaces.Items;

namespace Assets.Scripts.GameBase.Interfaces.Entities
{
    public interface IEntity
    {
        /// <summary>
        /// Current item in entity hand
        /// </summary>
        IItem CurrentItem { get; }

        /// <summary>
        /// Entity health points
        /// </summary>
        double Hp { get; }

        /// <summary>
        /// Represents entity body
        /// </summary>
        IBody Body { get; }

        /// <summary>
        /// Hit this entity by weapon
        /// </summary>
        /// <param name="weapon">Represents weapon with hit entity</param>
        void Hit(IWeapon weapon);

        /// <summary>
        /// Enity takes new item
        /// </summary>
        /// <param name="item">Item witch is taken</param>
        void Take(IItem item);

        /// <summary>
        /// Drops current item
        /// </summary>
        void DropCurrentItem();

        /// <summary>
        /// Use curent item
        /// </summary>
        void UseCurrentItem();
    }
}
