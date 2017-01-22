using UnityEngine;
using Assets.Scripts.Utilities;
using Assets.Scripts.GameBase.Interfaces.Entities;
using Assets.Scripts.GameBase.Interfaces.Items;
using UnityEngine.UI;
using Assets.Scripts.GameBase.Interfaces.Entities.Body;
using System;

public class EntityStats : MonoBehaviour, IEntityStats
{
    public float _attack;
    public float _hp;
    public float _speed;
    public float _jumpStrength;

    #region Properties
    public float Attack
    {
        get
        {
            return _attack;
        }
    }

    public float Hp
    {
        get
        {
            return _hp;
        }
    }

    public float JumpStrength
    {
        get
        {
            return _jumpStrength;
        }
    }

    public float Speed
    {
        get
        {
            return _speed;
        }
    }
    #endregion
}
