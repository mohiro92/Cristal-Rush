using System.Linq;
using Assets.Scripts.GameBase.Interfaces.Items;
using UnityEngine;
using Assets.Scripts.GameBase.Interfaces.Entities;
using System;

public class Item : MonoBehaviour, IItem
{
    #region IItem
    public void Use(IEntity entity)
    {
        throw new NotImplementedException();
    }
    #endregion
}
