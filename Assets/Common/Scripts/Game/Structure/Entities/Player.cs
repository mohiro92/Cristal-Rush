using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Entity Entity;
    public string PlayerName { get { return gameObject.name; } private set { gameObject.name = value; } }
    
    #region MonoBehaviour

	// Update is called once per frame
	void Update () {
        CheckDead();
	}
    #endregion

    internal void SetId(int id)
    {
        GetComponent<__PlayerController>().SetId(id);
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
