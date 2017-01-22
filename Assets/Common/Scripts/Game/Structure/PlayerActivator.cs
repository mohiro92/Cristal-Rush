using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Utilities;
using UnityEngine;

public class PlayerActivator : MonoBehaviour
{
    public Player PlayerPrefab;
    public Vector3 StartPosition;

    private Dictionary<int, Player> _players;

    // Use this for initialization
    void Start()
    {
        _players = new Dictionary<int, Player>();
    }


    private object lockObj = new object();  
    // Update is called once per frame
    void Update()
    {
        lock (lockObj)
        {
            var newIds = InputHelper.GetActiveInputIds().Select(k => k.Key).Where(i => !_players.ContainsKey(i) || !_players[i].gameObject.activeSelf).Distinct();

            foreach (var id in newIds)
            {
                if (!_players.ContainsKey(id))
                {
                    var player = Instantiate(PlayerPrefab);
                    player.SetId(id);
                    player.transform.SetParent(transform);
                    _players.Add(id, player);
                }

                _players[id].Respawn();
                break;
            }
        }
    }
}
