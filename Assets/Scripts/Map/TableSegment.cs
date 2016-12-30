using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSegment : MonoBehaviour {
    public float SegmentSize;

    [Header("Table")]
    public GameObject TablePrefab;
    public float TableDensity;

    [Header("Chair")]
    public GameObject ChairPrefab;
    public float ChairDensity;
    
    // Use this for initialization
    void Start()
    {
        SpawnObjectRandomly(TablePrefab, TableDensity);
        SpawnObjectRandomly(ChairPrefab, ChairDensity);
        //SpawnObjectRandomly(ClumpPrefab, ClumpDensity);
    }

    private void SpawnObjectRandomly(GameObject prefab, float spawnChance)
    {
        float spawnRandom = Random.Range(0, 1);
        if (spawnRandom <= spawnChance)
        {
            // Randomize location
            Vector3 spawnPosition = new Vector3(Random.Range(-SegmentSize / 2, SegmentSize / 2), 0, Random.Range(-SegmentSize / 2, SegmentSize / 2));
            GameObject spawnedObject = Instantiate(prefab);
            spawnedObject.transform.localPosition = spawnPosition;
            spawnedObject.transform.SetParent(transform, false);

            // Randomize rotation
            spawnedObject.transform.eulerAngles = new Vector3(spawnedObject.transform.eulerAngles.x, Random.Range(0, 360), spawnedObject.transform.eulerAngles.z);

            // Randomize scale
            spawnedObject.transform.localScale *= Random.Range(1f, 1f);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
