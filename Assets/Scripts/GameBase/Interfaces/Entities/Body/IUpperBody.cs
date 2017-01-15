using Assets.Scripts.GameBase.Interfaces.Items;

namespace Assets.Scripts.GameBase.Interfaces.Entities.Body
{
    public interface IUpperBody : IMoveable
    {
        /// <summary>
        /// Current item in body hand
        /// </summary>
        IItem CurrentItem { get; }

        /// <summary>
        /// Use current item in hand
        /// </summary>
        void UseCurrentItem();

        /// <summary>
        /// Drops current item form hand
        /// </summary>
        void DropCurrentItem();
    }
}
