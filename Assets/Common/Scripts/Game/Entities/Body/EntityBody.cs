using UnityEngine;
using Assets.Scripts.Utilities;
using UnityEngine.UI;
using Assets.Scripts;
using System;

public class EntityBody : BaseBehaviour
{
    public EntityTorso TorsoPrefab;
    private EntityTorso entityTorso;

    public EntityLegs LegsPrefab;
    private EntityLegs entityLegs;

    private bool _isJumping;
    private Rigidbody rigidBody;

    public bool IsJumping
    {
        get
        {
            return _isJumping;
        }

        private set
        {
            _isJumping = value;
        }
    }

    #region MonoBehaviour
    private void Awake()
    {
        if(!entityTorso)
        {
            entityTorso = SpawnPrefab(TorsoPrefab);
        }

        if(!entityLegs)
        {
            entityLegs = SpawnPrefab(LegsPrefab);
        }

        if (!rigidBody)
        {
            rigidBody = GetComponent<Rigidbody>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Dot(contact.normal, Vector3.up) > Consts.Eps)
            {
                IsJumping = false;
                break;
            }
        }
    }
    #endregion
    
    public void Move(Vector3 direction)
    {           
        ResetHorizontalVelocity();

        if (direction.IsZero())
        {
            print("Idle");
            entityTorso.Idle();
            entityLegs.Idle();
        } else
        {
            print("Running");
            // Rotate towards direction
            Quaternion newRotation = Quaternion.LookRotation(-direction);
            rigidBody.MoveRotation(newRotation);

            // "Push" body to direction
            rigidBody.velocity = new Vector3(direction.x, rigidBody.velocity.y, direction.z);
            
            entityTorso.Run();
            entityLegs.Run();
        }
    }

    public void Stop()
    {
        ResetHorizontalVelocity();
    }

    public void Jump(float strength)
    {
        if (_isJumping)
            return;

        IsJumping = true;
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, strength, rigidBody.velocity.z);
    }

    public void Punch()
    {
        entityTorso.Punch();
    }

    public void SetPosition(Vector3 position)
    {
        GetComponent<Rigidbody>().position = position;
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void Reset(Vector3 position)
    {
        _isJumping = false;
        SetPosition(position);
    }

    private void ResetHorizontalVelocity()
    {
        rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, 0);
        rigidBody.angularVelocity = Vector3.zero;
    }
}
