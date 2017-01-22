using Assets.Scripts.GameBase.Interfaces.Entities.Body;
using Assets.Scripts.GameBase.Interfaces.Items;
using UnityEngine;

namespace Assets.Scripts.GameBase.Interfaces.Entities
{
    public interface IEntity : IMoveable
    {
        /// <summary>
        /// Entity statistics (hp, attack, speed, etc.)
        /// </summary>
        IEntityStats Stats { get; }

        /// <summary>
        /// Current entity statistics (hp, attack, speed, etc.)
        /// </summary>
        IEntityStats CurrentStats { get; }

        /// <summary>
        /// True if entity is dead
        /// </summary>
        bool IsDead { get; }

        /// <summary>
        /// Represents entity body
        /// </summary>
        IEntityBody Body { get; }

        /// <summary>
        /// Current item in entity hand
        /// </summary>
        IItem CurrentItem { get; }

        /// <summary>
        /// Kills the entity
        /// </summary>
        void Kill();

        /// <summary>
        /// Entity jumps
        /// </summary>
        void Jump();

        /// <summary>
        /// Resets entity to default values
        /// </summary>
        void Reset(Vector3 position);

        /// <summary>
        /// Hit this entity by weapon
        /// </summary>
        /// <param name="weapon">Represents weapon which hit entity</param>
        void Hit(IWeapon weapon);

        /// <summary>
        /// Enity takes new item
        /// </summary>
        /// <param name="item">Item which is taken</param>
        void Take(IItem item);

        /// <summary>
        /// Drops current item
        /// </summary>
        void DropCurrentItem();

        /// <summary>
        /// Use current item
        /// </summary>
        void UseCurrentItem();
    }
}
