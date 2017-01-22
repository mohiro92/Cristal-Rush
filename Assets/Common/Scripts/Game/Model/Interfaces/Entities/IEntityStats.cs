using Assets.Scripts.GameBase.Interfaces.Entities.Body;
using Assets.Scripts.GameBase.Interfaces.Items;

namespace Assets.Scripts.GameBase.Interfaces.Entities
{
    public interface IEntityStats
    {
        /// <summary>
        /// Entity health points
        /// </summary>
        float Hp { get; }

        /// <summary>
        /// Entity attack points
        /// </summary>
        float Attack { get; }

        /// <summary>
        /// Entity speed
        /// </summary>
        float Speed { get; }

        /// <summary>
        /// Jump strenth
        /// </summary>
        float JumpStrength { get; }
    }
}
