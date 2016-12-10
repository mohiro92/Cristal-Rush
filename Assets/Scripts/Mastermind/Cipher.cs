using System;
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
        public Symbol SymbolPrefab;
        // Length of the cipher
        public int Length;

        // Cipher made with Symbols
        private Symbol[] cipherSymbols;

        // Counted occurences of cipher Symbols
        private int[] cipherOccurences;

        void Start()
        {
            RandomizeCipher();
        }

        private void RandomizeCipher()
        {
            cipherSymbols = new Symbol[Length];
            cipherOccurences = new int[SymbolPrefab.TypeCount()];
            for (int i = 0; i < Length; i++)
            {
                cipherSymbols[i] = Instantiate(SymbolPrefab).GetComponent<Symbol>();
                cipherSymbols[i].transform.SetParent(transform, false);
                cipherSymbols[i].transform.localPosition = new Vector3(i, 0);
                cipherOccurences[cipherSymbols[i].value]++;
            }
        }

        public Enemies[] CheckCipher(Cipher checkedCipher)
        {
            Enemies[] enemies = new Enemies[cipherSymbols.Length];
            int[] cipherHits = cipherOccurences.ToArray();
            for (int i = 0; i < cipherSymbols.Length; i++)
            {
                Symbol checkedSymbol = checkedCipher.GetSymbol(i);

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

        public Symbol GetSymbol(int index)
        {
            return cipherSymbols[index];
        }
    }
}
