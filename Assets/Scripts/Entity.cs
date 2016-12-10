using UnityEngine;
using Assets.Scripts;

public class Entity : MonoBehaviour
{
    public Gun Gun;
    public float MaxHp  = 100f;
    public float _currentHp;
    public bool IsDead { get { return _currentHp <= 0; } }

    public Animator animator;

    // Use this for initialization
    void Start()
    {
        _currentHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();
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

    private void UpdateAnimation()
    {
        if (animator)
        {
            if (transform.rotation.eulerAngles.y == 90)
            {
                animator.SetInteger(Consts.EntityAnimationDirection, 1);
                print("1");
            }
            else if (transform.rotation.eulerAngles.y == 270)
            {
                animator.SetInteger(Consts.EntityAnimationDirection, 3);
                print("3");
            }

            if (transform.rotation.eulerAngles.y == 0)
            {
                animator.SetInteger(Consts.EntityAnimationDirection, 0);
                print("2");
            }
            else if (transform.rotation.eulerAngles.y == 180)
            {
                animator.SetInteger(Consts.EntityAnimationDirection, 2);
                print("0");
            }
        }
    }

    public void Respawn()
    {
        _currentHp = MaxHp;
    }
}
