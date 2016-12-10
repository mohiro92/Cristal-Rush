using System;
using System.Collections.Generic;
using Assets.Scripts.Mastermind;
using UnityEngine;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Mastermind
{
    class Cipher
    {
        // Available cipher symbols GameObjects
        private GameObject[] availableSymbols;
        // Cipher representation in numbers (indices of availableSymbols)
        private int[] cipher;
        public int Length { get { return cipher.Length; }  }
        // Counted occurences of cipher symbols
        private int[] cipherOccurences;

        private System.Random randomGenerator = new System.Random();

        public Cipher(GameObject[] availableSymbols, int cipherLength)
        {
            this.availableSymbols = availableSymbols;
            RandomizeCipher(cipherLength);
        }

        private void RandomizeCipher(int cipherLength)
        {
            cipher = new int[cipherLength];
            for (int i = 0; i < cipherLength; i++)
            {
                cipher[i] = randomGenerator.Next(0, availableSymbols.Length);
            }
        }

        private void SetCipher(int[] cipher)
        {
            if (cipher != null)
            {
                cipherOccurences = new int[availableSymbols.Length];
                this.cipher = cipher;
                foreach(int symbol in cipher)
                {
                    cipherOccurences[symbol]++;
                }
            }
        }

        public Enemies[] CheckCipher(int[] checkedCipher)
        {
            Enemies[] enemies = new Enemies[cipher.Length];
            int[] cipherHits = cipherOccurences.ToArray();
            for (int i = 0; i < cipher.Length; i++)
            {
                int checkedSymbol = checkedCipher[i];

                Enemies enemy = Enemies.EasyEnemy;

                // Check if checked symbol is in our cipher
                if (cipherHits[checkedSymbol] > 0)
                {
                    // Symbol occurs in our cipher

                    if (checkedSymbol == cipher[i])
                    {
                        // Symbol occurs in the right spot
                        enemy = Enemies.DifficultEnemy;
                    }
                    else
                    {
                        // Symbol occurs on wrong spot
                        enemy = Enemies.MediumEnemy;
                    }
                    cipherHits[(int)checkedSymbol]--;
                }
                enemies[i] = enemy;
            }
            return enemies;
        }

        public GameObject GetSymbolGameObject(int index)
        {
            return availableSymbols[cipher[index]];
        }
    }
}
