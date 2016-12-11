using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Mastermind
{
    public class CipherCheck : MonoBehaviour
    {
        public MastermindLogic MastermindLogic;
        
        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.CompareTag(Consts.BulletTag))
            {
                print("OnCollisionEnter");
                MastermindLogic.CheckCipher();
            } else
            {
                print(col.gameObject.tag);
            }
        }
    }
}
