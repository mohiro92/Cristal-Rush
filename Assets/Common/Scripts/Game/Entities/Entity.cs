using UnityEngine;
using Assets.Scripts.Utilities;
using UnityEngine.UI;
using Assets.Scripts.Enums;
using System;
using Assets.Scripts;

public class Entity : BaseBehaviour
{
    public EntityStats StatsPrefab;
    private EntityStats Stats;

    public EntityBody BodyPrefab;
    private EntityBody Body;

    public GameObject ItemPrefab;
    private GameObject CurrentItem;

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

    #region MonoBehaviour
    private void Awake()
    {
        print("Awake");
    }

    private void Start()
    {
        print("Start");

        if (StatsPrefab != null)
        {
            Stats = SpawnPrefab(StatsPrefab);
        }

        if (BodyPrefab != null)
        {
            Body = SpawnPrefab(BodyPrefab);
        }
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
        CurrentItem = null;
    }

    public void UseCurrentItem()
    {
        //_currentItem.Use(this);
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

    public void Punch()
    {
        Body.Punch();
    }

    public void Reset(Vector3 position)
    {
        State = EntityState.Idle;

        Body.SetPosition(position);
    }
}
