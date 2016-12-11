using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Mastermind;
using UnityEngine;

public class SpawnPoints : MonoBehaviour {
    public GameObject EnemySpawnPrefab;
    public GameObject EnemyPrefab;
    public GameObject ExplosionPrefab;

    private MastermindLogic MastermindLogic;
    private List<GameObject> Spawns = new List<GameObject>();

    public void SetLogic(MastermindLogic logic)
    {
        MastermindLogic = logic;
        for (int i = 0; i < MastermindLogic.originalCipher.Length; i++)
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

        for (int i = 0; i < enemies.Length; i++)
        {
            print("SPawn " + i);
            GameObject enemy = Instantiate(EnemyPrefab);
            enemy.transform.parent = transform;
            enemy.transform.position = Spawns[i].transform.position;
            GameObject explosion = Instantiate(ExplosionPrefab);
            explosion.transform.position = enemy.transform.position;
            Destroy(explosion, 1.0f);
        }
    }
}
