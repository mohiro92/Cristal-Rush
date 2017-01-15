using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if(audio)
        {
            audio.Play();
        }
    }

	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))
		   Destroy(transform.gameObject);
	}
}
