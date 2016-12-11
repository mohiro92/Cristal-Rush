using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Utilities;
using UnityEngine;

public class PlayerAcivator : MonoBehaviour
{
    public PlayerWrapper PlayerPrefab;
    public Vector3 StartPosition;

    private Dictionary<int, PlayerWrapper> _players;

    // Use this for initialization
    void Start()
    {
        _players = new Dictionary<int, PlayerWrapper>();
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
                    var playerWrapper = Instantiate(PlayerPrefab);
                    playerWrapper.SetId(id);
                    _players.Add(id, playerWrapper);
                }

                _players[id].Respawn(StartPosition, Time.deltaTime);
                break;
            }
        }
    }
}
