using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseBehaviour {
    public Entity EntityPrefab;
    private Entity Entity;

    public InputHandler InputHandlerPrefab;
    private InputHandler InputHandler;

    public string PlayerName { get { return gameObject.name; } private set { gameObject.name = value; } }

    private void Awake()
    {
        if(!Entity)
        {
            Entity = SpawnPrefab(EntityPrefab);
        }

        if(!InputHandler)
        {
            InputHandler = SpawnPrefab(InputHandlerPrefab);

            Entity.GetComponent<EntityController>().SetInputHandler(InputHandler);
        }
    }

    internal void SetId(int id)
    {
        PlayerName = string.Format("Player {0}", id);
    }

    internal void Respawn()
    {
        EntitySpawn spawn = GameObject.FindObjectOfType(typeof(EntitySpawn)) as EntitySpawn;
        spawn.Spawn(Entity);
    }
}
