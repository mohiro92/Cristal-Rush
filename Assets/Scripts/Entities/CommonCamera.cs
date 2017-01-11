using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class CommonCamera : MonoBehaviour {
    private Vector3 centerVector = Vector3.zero;
    private Vector3 cameraOffset;

	// Use this for initialization 
	void Start () {
        cameraOffset = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] players = GameObject.FindGameObjectsWithTag(Consts.PlayerTag);
        if (players.Length > 0)
        {
            float minX = players[0].transform.position.x, minZ = players[0].transform.position.z;
            float maxX = minX, maxZ = minZ;

            foreach(GameObject player in players)
            {
                minX = Mathf.Min(minX, player.transform.position.x);
                minZ = Mathf.Min(minZ, player.transform.position.z);

                maxX = Mathf.Max(maxX, player.transform.position.x);
                maxZ = Mathf.Max(maxZ, player.transform.position.z);
            }
            centerVector.x = (minX + maxX) / 2;
            centerVector.z = (minZ + maxZ) / 2;
            transform.position = centerVector + cameraOffset;
        }
        
	}
}
