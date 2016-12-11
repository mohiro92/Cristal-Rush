using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Mastermind;
using UnityEngine;
using Assets.Scripts;

public class Spawn : MonoBehaviour {
    public float SpawnSpeed;

    private static readonly int seedMultiplier = 1000;

    // Use this for initialization
    void Start()
    {
        transform.Translate(new Vector3(Random.Range(-Consts.ArenaWidth, Consts.ArenaWidth), 0, Random.Range(-Consts.ArenaDepth, Consts.ArenaDepth)));
        RotateRandom();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * SpawnSpeed * Time.deltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        RotateRandom();

    }

    private void OnCollisionEnter(Collision collision)
    {
        RotateRandom();
    }

    private void RotateRandom()
    {
        print("ROtate random");
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360));
        //transform.eulerAngles = Vector3.Reflect(transform.eulerAngles, transform.forward);
    }

}
