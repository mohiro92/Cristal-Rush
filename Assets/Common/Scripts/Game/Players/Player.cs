using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Entity EntityPrefab;
    private Entity Entity;

    public InputHandler InputHandlerPrefab;
    private InputHandler InputHandler;

    public string PlayerName { get { return gameObject.name; } private set { gameObject.name = value; } }

    private void Awake()
    {
        if(!Entity)
        {
            GameObject entityGameObject = Instantiate(EntityPrefab.gameObject);
            entityGameObject.transform.SetParent(transform);
            Entity = entityGameObject.GetComponent<Entity>();
        }

        if(!InputHandler)
        {
            GameObject inputHandlerGameObject = Instantiate(InputHandlerPrefab.gameObject);
            inputHandlerGameObject.transform.SetParent(transform);
            InputHandler = inputHandlerGameObject.GetComponent<InputHandler>();

            Entity.GetComponent<EntityController>().SetInputHandler(InputHandler);
        }
    }

    // Update is called once per frame
    void Update () {
        CheckDead();
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

    private void CheckDead()
    {
        if (!Entity.gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}
