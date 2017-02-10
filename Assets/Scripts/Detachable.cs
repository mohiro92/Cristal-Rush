using Assets.Scripts.Common;
using UnityEngine;

public class Detachable : MonoBehaviour
{

    public KeyCode keyCode;
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
            transform.parent = null;
            _rigidbody.isKinematic = false;
            gameObject.layer = (int) Layers.Item;
        }

    }
}
