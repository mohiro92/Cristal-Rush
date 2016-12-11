using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Mastermind
{
    public class CipherCheck : MonoBehaviour
    {
        public MastermindLogic MastermindLogic;
        
        public void Check()
        {
            MastermindLogic.CheckCipher();
        }
    }
}
