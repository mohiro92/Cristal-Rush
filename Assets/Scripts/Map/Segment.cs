using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour {
    public float SegmentSize;

    [Header("Palms")]
    public GameObject PalmPrefab;
    public float PalmDensity;

    [Header("Stones")]
    public GameObject StonePrefab;
    public float StoneDensity;

    [Header("Clumps")]
    public GameObject ClumpPrefab;
    public float ClumpDensity;

    // Use this for initialization
    void Start()
    {
        SpawnObjectRandomly(PalmPrefab, PalmDensity);
        SpawnObjectRandomly(StonePrefab, StoneDensity);
        //SpawnObjectRandomly(ClumpPrefab, ClumpDensity);
    }

    private void SpawnObjectRandomly(GameObject prefab, float spawnChance)
    {
        float spawnRandom = Random.Range(0, 1);
        if (spawnRandom <= spawnChance)
        {
            // Randomize location
            Vector3 spawnPosition = new Vector3(Random.Range(-SegmentSize/2, SegmentSize/2), 0, Random.Range(-SegmentSize / 2, SegmentSize / 2));
            GameObject spawnedObject = Instantiate(prefab);
            spawnedObject.transform.localPosition = spawnPosition;
            spawnedObject.transform.SetParent(transform, false);

            // Randomize rotation
            spawnedObject.transform.eulerAngles = new Vector3(spawnedObject.transform.eulerAngles.x, Random.Range(0, 360), spawnedObject.transform.eulerAngles.z);

            // Randomize scale
            spawnedObject.transform.localScale *= Random.Range(0.8f, 1.5f);
        }
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
