using Assets.Scripts.Common;
using UnityEngine;

public class Detachable : MonoBehaviour
{

    public KeyCode keyCode = KeyCode.Q;
    private Rigidbody _rigidbody;

    // Use this for initialization
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyCode))
        {
            Detach();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Detach();

        Debug.Log("Collision :)");
    }

    private void Detach()
    {
        transform.parent = null;

        if(_rigidbody != null)
            _rigidbody.isKinematic = false;

        
        //gameObject.layer = (int) Layers.Item;
    }
}
