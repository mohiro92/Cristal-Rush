using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalAnimator : MonoBehaviour
{
    public float AnimationHeight = 0.5f;
    public float Speed = 1.5f;

    private Vector3 animationVector;
    private Vector3 originalPosition;
    private float animationSeed;

	// Use this for initialization
	void Start () {
        animationVector = new Vector3(0, AnimationHeight);
        originalPosition = transform.localPosition;
        animationSeed = Random.Range(0, 2 * 3.1415f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = originalPosition + animationVector * Mathf.Sin(animationSeed + Speed * Time.time);
	}
}
