using UnityEngine;
using Assets.Scripts;
using System.Collections;
using System.Linq;

namespace Assets.Scripts.Mastermind
{
    public enum Enemies { EasyEnemy, MediumEnemy, DifficultEnemy };
    
    public class MastermindLogic : MonoBehaviour
    {
        public Cipher CipherPrefab;
        public CipherCheck CipherCheck;
        public SpawnPoints SpawnPoints;

        public Cipher originalCipher { get; private set; }
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

            SpawnPoints.SetLogic(this);
        }

        public void CheckCipher()
        {
                SpawnPoints.SpawnEnemies(originalCipher.CheckCipher(checkedCipher));
        }
    }
}
