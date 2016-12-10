using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Mastermind
{
    public class CipherCheck : MonoBehaviour
    {
        public MastermindLogic MastermindLogic;

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag.Equals(Consts.BulletTag))
            {
                MastermindLogic.CheckCipher();
            } else
            {
                print(col.gameObject.tag);
            }
        }
    }
}
