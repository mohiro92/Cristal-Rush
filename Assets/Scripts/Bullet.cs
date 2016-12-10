﻿using System.Linq;
using Assets.Scripts.Randoms;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float MinVal = 1f;
    public int Strength = 5;
    public float SelfDestructionDist = 50f;
    public float Speed = 1f;


    private Vector3 _startPosition;
    private Vector3 _direction;
    private bool _isDestroyed = false;

    public void Init(Vector3 direction, Vector3? position = null)
    {
        _direction = direction;
        _direction.Normalize();
        SetStartPosition(position ?? transform.position);

        this.gameObject.SetActive(true);
    }

    public void SetStartPosition(Vector3 position)
    {
        Debug.Log(position);
        _startPosition = position;
        transform.position = _startPosition;
    }
    
    // Update is called once per frame
    void Update()
    {
        if ((transform.position - _startPosition).magnitude > SelfDestructionDist)
        {
            SelfDestroy();
            return;
        }

        var move = _direction * Speed * Time.deltaTime;

        if (Physics.Raycast(transform.position, _direction, move.magnitude))
        {
            var firstHit = Physics.RaycastAll(transform.position, _direction, move.magnitude).First();
            var entity = firstHit.collider.GetComponent<Entity>();
            Hit(entity);
            return;
        }

        transform.position += move;
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);

            var entity = contact.otherCollider.GetComponent<Entity>();
            Hit(entity);
        }

    }

    private readonly object _hitLock = new object();
    private void Hit(Entity entity)
    {
        lock (_hitLock)
        {
            if (_isDestroyed)
                return;

            if (entity == null)
                return;
        }

        entity.Hit(MinVal + BulletRandom.NextFloat(Strength));
        SelfDestroy();
    }

    private void SelfDestroy()
    {
        _isDestroyed = true;
        // if needed place here OnDestroy method
        DestroyObject(this.gameObject);
    }
}