using System;
using System.Linq;
using System.Collections.Generic;
using Assets.Scripts.Mastermind;
using UnityEngine;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Mastermind
{
    public class Cipher : MonoBehaviour
    {
        // Cipher Symbol prefab
        public Crystal CrystalPrefab;
        // Length of the cipher
        public int Length;

        // Cipher made with Symbols
        private Crystal[] cipherSymbols;
        private float cipherSpacing = 4;

        // Counted occurences of cipher Symbols
        private int[] cipherOccurences;

        void Awake()
        {
            RandomizeCipher();
        }

        private void RandomizeCipher()
        {
            cipherSymbols = new Crystal[Length];
            cipherOccurences = new int[CrystalPrefab.TypeCount()];
            float cipherOffsetX = -(Length - 1) / 2 * cipherSpacing;
            for (int i = 0; i < Length; i++)
            {
                cipherSymbols[i] = Instantiate(CrystalPrefab).GetComponent<Crystal>();
                cipherSymbols[i].transform.SetParent(transform, false);
                cipherSymbols[i].transform.position = new Vector3(cipherOffsetX + i * cipherSpacing, 0);
                cipherSymbols[i].RandomizeValue();
                cipherOccurences[cipherSymbols[i].value]++;
            }
        }

        public Enemies[] CheckCipher(Cipher checkedCipher)
        {
            Enemies[] enemies = new Enemies[cipherSymbols.Length];
            int[] cipherHits = cipherOccurences.ToArray();
            for (int i = 0; i < cipherSymbols.Length; i++)
            {
                Crystal checkedSymbol = checkedCipher.GetSymbol(i);

                Enemies enemy = Enemies.EasyEnemy;

                // Check if checked symbol is in our cipher
                if (cipherHits[checkedSymbol.value] > 0)
                {
                    // Symbol occurs in our cipher

                    if (checkedSymbol == cipherSymbols[i])
                    {
                        // Symbol occurs in the right spot
                        enemy = Enemies.DifficultEnemy;
                    }
                    else
                    {
                        // Symbol occurs on wrong spot
                        enemy = Enemies.MediumEnemy;
                    }
                    cipherHits[checkedSymbol.value]--;
                }
                enemies[i] = enemy;
            }
            return enemies;
        }

        public Crystal GetSymbol(int index)
        {
            return cipherSymbols[index];
        }

        public override string ToString()
        {
            return string.Join(" - ", cipherSymbols.Select(s => s.value.ToString()).ToArray());
        }
    }
}
