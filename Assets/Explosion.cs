using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    private AudioSource ExplosionAuto;

    // Use this for initialization
    void Start () {
        ExplosionAuto = GetComponent<AudioSource>();
        if (ExplosionAuto)
        {
            ExplosionAuto.Play();
        }
        Destroy(gameObject, 1.5f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
