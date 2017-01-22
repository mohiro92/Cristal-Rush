using UnityEngine;
using Assets.Scripts.Utilities;
using Assets.Scripts.GameBase.Interfaces.Entities;
using Assets.Scripts.GameBase.Interfaces.Items;
using UnityEngine.UI;
using Assets.Scripts.GameBase.Interfaces.Entities.Body;
using System;
using Assets.Scripts;

public class Entity : MonoBehaviour, IEntity
{
    public EntityStats _stats;
    private EntityStats _currentStats;
    public bool _isAlive;

    public EntityBody _body;
    public Item _currentItem;
    
    #region Properties
    public IEntityStats Stats
    {
        get
        {
            return _stats;
        }
    }

    public IEntityStats CurrentStats
    {
        get
        {
            return _currentStats;
        }
    }

    public IEntityBody Body
    {
        get
        {
            return _body;
        }
    }

    public IItem CurrentItem
    {
        get
        {
            return _currentItem;
        }
    }

    public bool IsDead
    {
        get
        {
            _isAlive = _currentStats.Hp > 0 && transform.position.y > Consts.HellLevel;
            return _isAlive;
        }
    }
    #endregion

    #region MonoBehaviour
    private void Start()
    {
        GameObject currentStats = Instantiate(_stats.gameObject);
        currentStats.name = "Current Stats";
        currentStats.transform.SetParent(transform);
        _currentStats = currentStats.GetComponent<EntityStats>();
    }

    private void Update()
    {
        CheckDead();
    }
    #endregion

    #region IEntity
    public void Hit(IWeapon weapon)
    {
        _currentStats._hp -= weapon.Strength;
    }

    public void Take(IItem item)
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
        return IsDead;
    }

    public void Kill()
    {
        throw new NotImplementedException();
    }

    public void Move(Vector3 direction)
    {
        Body.Move(direction * CurrentStats.Speed);
    }

    public void Stop()
    {
        Body.Stop();
    }

    public void Jump()
    {
        Body.Jump(CurrentStats.JumpStrength);
    }

    public void Reset(Vector3 position)
    {
        _isAlive = true;
        Body.SetPosition(position);
    }

    public void SetPosition(Vector3 position)
    {
        Body.SetPosition(position);
    }
    #endregion
}
