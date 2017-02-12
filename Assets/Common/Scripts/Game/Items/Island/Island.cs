using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour {
    public GameObject MapSegmentPrefab;

    public float SegmentsSpacing;
    public int SegmentsSpawnsCount;

    private void Start()
    {
        for (int i = 0; i < SegmentsSpawnsCount; i++)
        {
            for (int j = 0; j < SegmentsSpawnsCount; j++)
            {
                // Calculate field
                Vector3 segmentPosition = new Vector3(-(SegmentsSpacing * (SegmentsSpawnsCount - 1) / 2) + SegmentsSpacing * j, 0, -(SegmentsSpacing * (SegmentsSpawnsCount - 1) / 2) + SegmentsSpacing * i);
                GameObject segment = Instantiate(MapSegmentPrefab, segmentPosition, MapSegmentPrefab.transform.rotation);
                segment.transform.SetParent(transform);
            }
        }
    }
    
	void Update () {
		
	}
}
