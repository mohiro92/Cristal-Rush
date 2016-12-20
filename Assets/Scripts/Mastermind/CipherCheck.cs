using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Mastermind
{
    public class CipherCheck : MonoBehaviour
    {
        public MastermindLogic MastermindLogic;

        private Vector3 rotationVector = new Vector3(0, 180, 0);
        
        public void Check()
        {
            if (GameObject.FindGameObjectsWithTag(Consts.EnemyTag).Length > 0)
            {
                return;
            }

            MastermindLogic.CheckCipher();
            transform.Rotate(rotationVector);
        }
    }
}
