using UnityEngine;
using Assets.Scripts.Utilities;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    public Gun Gun;
    public Transform GunPivot;
    public float MaxHp  = 100f;
    public float _currentHp;
    public float Speed = 0.5f;
    public bool IsDead { get { return _currentHp <= 0; } }  

    public Image HealthBar;
    public Text HealthText;

    private Animator Animator;

    // Use this for initialization
    void Start()
    {
        _currentHp = MaxHp;
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
        
        if(Gun.CanShoot())
        {
            Animator.SetTrigger("Throw");
            Gun.Shoot();
        }
    }

    public void Move(Vector3 direction)
    {
        Animator.SetBool("IsRunning", !direction.IsZero());
        transform.position += direction * Speed * Time.deltaTime;
    }

    public void Hit(float val)
    {
        Debug.Log(string.Format("Entity.Hit({0})", val));

        _currentHp -= val;
    }

    public void Respawn()
    {
        _currentHp = MaxHp;
    }
}
