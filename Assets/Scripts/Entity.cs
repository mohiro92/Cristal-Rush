using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    public Gun Gun;
    public Transform GunPivot;
    public float MaxHp  = 100f;
    public float _currentHp;
    public bool IsDead { get { return _currentHp <= 0; } }

    public Image HealthBar;
    public Text HealthText;


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
        UpdateUI();

    }

    private void UpdateUI()
    {
        if (HealthBar != null)
        {
            HealthBar.fillAmount = (float)_currentHp / MaxHp;
        }

        if (HealthText != null)
        {
            HealthText.text = string.Format("{0:#.00}/{1:#.00}", _currentHp, MaxHp);
        }
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
            if (GunPivot.eulerAngles.y <= 45 || GunPivot.eulerAngles.y > 315)
            {
                animator.SetInteger(Consts.EntityAnimationDirection, 0);
            }
            else if (GunPivot.eulerAngles.y > 45 && GunPivot.eulerAngles.y <= 135)
            {
                animator.SetInteger(Consts.EntityAnimationDirection, 1);
            }
            else if (GunPivot.eulerAngles.y > 135 && GunPivot.eulerAngles.y <= 225)
            {
                animator.SetInteger(Consts.EntityAnimationDirection, 2);
            }
            else if (GunPivot.eulerAngles.y > 225 && GunPivot.eulerAngles.y <= 315)
            {
                animator.SetInteger(Consts.EntityAnimationDirection, 3);
            }
        }
    }

    public void Respawn()
    {
        _currentHp = MaxHp;
    }
}
