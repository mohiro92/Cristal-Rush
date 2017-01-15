using UnityEngine;
using Assets.Scripts;

using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Mastermind
{
    public class Crystal : MonoBehaviour
    { 
        // Randomization component
        private static System.Random randomGenerator = new System.Random();
        // Available cipher colors
        [ColorUsageAttribute(true, true, 0f, 8f, 0.125f, 3f)]
        public List<Color> availableColors;
        // Actual value of symbol
        public int value;
        // Crystal explosion prefab
        public GameObject ExplosionPrefab;

        public GameObject CrystalModel;
        public Light Light;

        // Use this for initialization
        void Start()
        {
            CrystalModel.GetComponent<Renderer>().material.EnableKeyword("_EmissionColor");
            Activate(value);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void RandomizeValue()
        {
            value = randomGenerator.Next(0, availableColors.Count);
        }

        public static bool operator ==(Crystal emp1, Crystal emp2)
        {
            return emp1.value == emp2.value;
        }

        public static bool operator !=(Crystal emp1, Crystal emp2)
        {
            return emp1.value != emp2.value;
        }

        public int TypeCount()
        {
            return availableColors.Count;
        }

        private void Next()
        {
            int newValue = (value + 1) % availableColors.Count;
            Activate(newValue);
        }

        private void Previous()
        {
            int newValue = value-1;
            if(newValue < 0)
            {
                newValue = availableColors.Count - 1;
            }
            Activate(newValue);
        }
        
        private void Activate(int index)
        {
            value = index;
            CrystalModel.GetComponent<Renderer>().material.SetColor("_EmissionColor", availableColors[value]);
            Light.color = availableColors[value];
        }

        public void BulletHit(Transform bulletTransform)
        {
            if(GameObject.FindGameObjectsWithTag(Consts.EnemyTag).Length > 0)
            {
                return;
            }

            if (bulletTransform.gameObject.tag.Equals(Consts.BulletTag))
            {
                print(bulletTransform.position.z + " " + transform.position.z);
                if (bulletTransform.position.z > transform.position.z)
                {
                    Next();
                }
                else
                {
                    Previous();
                }
                GameObject explosionObject = Instantiate(ExplosionPrefab);
                explosionObject.transform.Translate(transform.position);
            }
        }
    }
}
