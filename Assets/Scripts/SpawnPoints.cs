using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Assets.Scripts.Randoms;
using Assets.Scripts;
using Assets.Scripts.Mastermind;
using UnityEngine;

public class SpawnPoints : MonoBehaviour {
    public GameObject EnemySpawnPrefab;
    public GameObject[] EnemyPrefabs;
    public GameObject ExplosionPrefab;

    private MastermindLogic MastermindLogic;
    private List<GameObject> Spawns = new List<GameObject>();


    public void SetLogic(MastermindLogic logic)
    {
        MastermindLogic = logic;
        for (int i = 0; i < MastermindLogic.originalCipher.Length + 1; i++)
        {
            GameObject spawnPoint = Instantiate(EnemySpawnPrefab);
            spawnPoint.transform.SetParent(transform);
            Spawns.Add(spawnPoint);
        }
    }

    public void SpawnEnemies(Enemies[] enemies)
    {
        if(GameObject.FindGameObjectsWithTag(Consts.EnemyTag).Length > 0)
        {
            return;
        }

        int i;
        for (i = 0; i < enemies.Length; i++)
        {
            print("SPawn " + i);
            SpawnEnemy(i, enemies[i]);
        }

        if(!enemies.Contains(Enemies.EasyEnemy) && !enemies.Contains(Enemies.MediumEnemy))
        {
            float bossType = Random.Range(0f, 1f);
            Debug.Log("Boss type + " + bossType);
            if (bossType < 0.5f)
            {
                SpawnEnemy(i, Enemies.GoodBoss);
            } else
            {
                SpawnEnemy(i, Enemies.EvilBoss);
            }
        }
    }

    private void SpawnEnemy(int spawn, Enemies type)
    {
        GameObject enemy = Instantiate(EnemyPrefabs[(int)type]);
        enemy.transform.parent = transform;
        enemy.transform.position = Spawns[spawn].transform.position;
        GameObject explosion = Instantiate(ExplosionPrefab);
        explosion.transform.position = enemy.transform.position;
        Destroy(explosion, 1.0f);
    }
}
