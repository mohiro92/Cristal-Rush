using UnityEngine;

public class Entity : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot(Vector3 direction)
    {
        Debug.Log(string.Format("Entity shoot. Direction: {0}", direction));
    }

    public void Hit(float val)
    {
        Debug.Log(string.Format("Entity.Hit({0})", val));
    }
}
