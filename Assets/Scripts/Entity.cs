using UnityEngine;

public class Entity : MonoBehaviour
{
    public Gun Gun;

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
        if (Gun == null)
        {
            Debug.Log("Entity don't have weapon");
            return;
        }

        Debug.Log(string.Format("Entity shoot. Direction: {0}", direction));
        Gun.Shoot(direction);
    }

    public void Hit(float val)
    {
        Debug.Log(string.Format("Entity.Hit({0})", val));
    }
}
