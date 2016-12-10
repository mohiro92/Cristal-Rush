using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Utilities;
using UnityEngine;

public class PlayerAcivator : MonoBehaviour
{
    public PlayerController PlayerPrefab;
    public Vector3 StartPosition;

    private Dictionary<int, PlayerController> _players;

    // Use this for initialization
    void Start()
    {
        _players = new Dictionary<int, PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        var newIds = InputHelper.GetActiveInputIds().Select(k => k.Key).Where(i => !_players.ContainsKey(i) || !_players[i].gameObject.activeSelf);

        foreach (var id in newIds)
        {
            if (!_players.ContainsKey(id))
            {
                var player = Instantiate(PlayerPrefab);
                player.SetId(id);
                _players.Add(id, player);
            }

            _players[id].Respawn(StartPosition, Time.deltaTime);
        }
    }
}
