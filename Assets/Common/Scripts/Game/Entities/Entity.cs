using UnityEngine;
using Assets.Scripts.Utilities;
using UnityEngine.UI;
using Assets.Scripts.Enums;
using System;
using Assets.Scripts;

public class Entity : MonoBehaviour
{
    public EntityStats StatsPrefab;
    private EntityStats Stats;

    public EntityBody BodyPrefab;
    private EntityBody Body;

    public Item _currentItem;

    private EntityState _state = EntityState.Idle;
    public EntityState State
    {
        get { return _state; }

        set
        {
            // Check if we can change state

            // Change the state
            _state = value;
        }
    }

    private void Awake()
    {
        print("Awake");
    }

    #region MonoBehaviour
    private void Start()
    {
        print("Start");

        if (StatsPrefab != null)
        {
            GameObject statsGameObject = Instantiate(StatsPrefab.gameObject);
            statsGameObject.transform.SetParent(transform);
            Stats = statsGameObject.GetComponent<EntityStats>();

        }

        if (BodyPrefab != null)
        {
            GameObject bodyGameObject = Instantiate(BodyPrefab.gameObject);
            bodyGameObject.transform.SetParent(transform);
            Body = bodyGameObject.GetComponent<EntityBody>();
        }
    }

    private void Update()
    {
        CheckDead();
    }
    #endregion

    public void UpdateMovement(Vector3 movementVector)
    {
        Body.Move(movementVector);
    }

    public void Take(Item item)
    {
        throw new NotImplementedException();
    }

    public void DropCurrentItem()
    {
        _currentItem = null;
    }

    public void UseCurrentItem()
    {
        //_currentItem.Use(this);
    }

    private bool CheckDead()
    {
        if(Stats.Hp <= 0)
        {
            Kill();
        }

        return _state == EntityState.Dead;
    }

    public void Kill()
    {
        State = EntityState.Dead;
    }

    public void Move(Vector3 direction)
    {
        Body.Move(direction * Stats.Speed);
    }

    public void Stop()
    {
        Body.Stop();
    }

    public void Jump()
    {
        print("Jump");
        Body.Jump(Stats.JumpStrength);
    }

    public void Reset(Vector3 position)
    {
        State = EntityState.Idle;

        Body.SetPosition(position);
    }
}
