using System.Linq;
using UnityEngine;
using System;

public class EntitySpawn : MonoBehaviour
{
    public void Spawn(Entity entity)
    {
        entity.Reset(transform.position);
    }
}
