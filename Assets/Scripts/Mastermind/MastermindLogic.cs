using UnityEngine;
using System.Collections;
using System.Linq;

namespace Assets.Scripts.Mastermind
{
    public enum Enemies { EasyEnemy, MediumEnemy, DifficultEnemy };
    
    public class MastermindLogic : MonoBehaviour
    {
        public int CipherLength;
        public GameObject[] Symbols;

        private Cipher cipher;

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
            cipher = new Cipher(Symbols, CipherLength);

            // Destroy all children
            foreach (Transform child in transform)
            {
                Destroy(child);
            }

            // Add new children
            for (int i = 0; i < cipher.Length; i++)
            {
                GameObject cipherSymbol = Instantiate(cipher.GetSymbolGameObject(i));
                cipherSymbol.transform.SetParent(transform, false);
                cipherSymbol.transform.localPosition = new Vector3(i, 0);
            }
        }
    }
}
