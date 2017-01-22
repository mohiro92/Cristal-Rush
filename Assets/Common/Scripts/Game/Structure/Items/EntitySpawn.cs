using System.Linq;
using Assets.Scripts.GameBase.Interfaces.Items;
using UnityEngine;
using System;
using Assets.Scripts.GameBase.Interfaces;
using Assets.Scripts.GameBase.Interfaces.Entities;

public class EntitySpawn : MonoBehaviour, IEntitySpawn
{
    public void Spawn(IEntity entity)
    {
        entity.Reset(transform.position);
    }
}
