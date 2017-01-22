using UnityEngine;

namespace Assets.Scripts.GameBase.Interfaces.Entities
{
    public interface IMoveable
    {
        /// <summary>
        /// Invoke when move
        /// </summary>
        /// <param name="direction">Represents normalized move direction</param>
        void Move(Vector3 direction);

        /// <summary>
        /// Invoke when stop
        /// </summary>
        void Stop();

        void SetPosition(Vector3 position);
    }
}
