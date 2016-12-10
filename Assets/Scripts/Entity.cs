using UnityEngine;

public class Entity : MonoBehaviour
{
    public Gun Gun;
    public float MaxHp  = 100f;
    public float _currentHp;
    public bool IsDead { get { return _currentHp <= 0; } }

    // Use this for initialization
    void Start()
    {
        _currentHp = MaxHp;
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

        Gun.Shoot(direction);
    }

    public void Hit(float val)
    {
        Debug.Log(string.Format("Entity.Hit({0})", val));

        _currentHp -= val;
    }
}
