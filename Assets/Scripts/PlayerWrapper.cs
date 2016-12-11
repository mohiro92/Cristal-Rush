using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWrapper : MonoBehaviour {
    public PlayerController Controller;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!Controller.gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
	}

    internal void SetId(int id)
    {
        Controller.SetId(id);
        gameObject.name = string.Format("Player {0}", id);
    }

    internal void Respawn(Vector3 startPosition, float deltaTime)
    {
        Controller.Respawn(startPosition, deltaTime);
        gameObject.SetActive(true);
    }
}
