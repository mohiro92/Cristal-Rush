using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Vector3 BulletSpawnOffset = Vector3.zero;
    public Bullet Bullet;
    public int ShootCooldown = 30;

    private DateTime? _lastShootDateTime;

    // Use this for initialization
    void Start()
    {
        if(Bullet == null)
            throw new NullReferenceException("Bullet should be not null");
    }

    public bool CanShoot()
    {
        int lastTime = (DateTime.Now - (_lastShootDateTime ?? DateTime.Now)).Milliseconds;

        return _lastShootDateTime == null || lastTime > ShootCooldown;
    }

    public void Shoot()
    {
        if (CanShoot())
        {
            _lastShootDateTime = DateTime.Now;
            Invoke("Throw", 0.4f);
        }
    }

    private void Throw()
    {
        var spawnPosition = transform.position + BulletSpawnOffset;
        var bullet = Instantiate(Bullet, spawnPosition, transform.rotation);
    }
}
