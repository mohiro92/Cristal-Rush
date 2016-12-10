using UnityEngine;
using System.Collections;
using System.Linq;

namespace Assets.Scripts.Mastermind
{
    public enum Enemies { EasyEnemy, MediumEnemy, DifficultEnemy };
    
    public class MastermindLogic : MonoBehaviour
    {
        public Cipher CipherPrefab;
        public CipherCheck CipherCheck;

        private Cipher originalCipher;
        private Cipher checkedCipher;

        void Start()
        {
            Reset();
        }
        
        void Update()
        {

        }

        private void Reset()
        {
            originalCipher = Instantiate(CipherPrefab);
            originalCipher.transform.SetParent(transform, false);
            originalCipher.gameObject.SetActive(false);

            checkedCipher = Instantiate(CipherPrefab);
            checkedCipher.transform.SetParent(transform, false);

            CipherCheck.transform.SetParent(transform, false);
            CipherCheck.transform.localPosition = new Vector3(- CipherPrefab.Length / 2 - 1, 0);
        }

        public void CheckCipher()
        {
            print("Check cipher");
        }
    }
}
