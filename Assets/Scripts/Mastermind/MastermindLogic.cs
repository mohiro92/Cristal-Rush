using UnityEngine;
using System.Collections;
using System.Linq;

namespace Assets.Scripts.Mastermind
{
    public enum Enemies { EasyEnemy, MediumEnemy, DifficultEnemy };
    
    public class MastermindLogic : MonoBehaviour
    {
        public Cipher Cipher;

        void Start()
        {
            Reset();
        }
        
        void Update()
        {

        }

        private void Reset()
        {
            // Get new cipher
        }
    }
}
