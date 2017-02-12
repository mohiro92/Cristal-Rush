using System;
using System.Linq;
using Assets.Scripts;
using Assets.Scripts.Randoms;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject Target;
    public float NavigationTolerance = 0.5f;

    public float MinShootCooldown = 2f;
    public float MaxValueToAddShootCooldown = 2f;

    private float _minShootCooldownValue = -1f;
    private float _shootCooldownValue = 0f;

    private NavMeshAgent _nav;
    private Entity entity;

    // Use this for initialization
    void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        entity = GetComponent<Entity>();
        
        //to prevent shoot and start
        SetNewMinCooldownValue();
    }

    // Update is called once per frame
    void Update()
    {
        var deltaTime = Time.deltaTime;

        UpdateAgentDestination();
        CheckShoot(deltaTime);
    }

    private void UpdateAgentDestination()
    {
        var currentPos = transform.position;
        var nearestPlayer = GameObject.FindGameObjectsWithTag(Consts.PlayerTag).OrderBy(g => (g.transform.position - currentPos).magnitude).FirstOrDefault();

        if (Target != null)
        {
            if(!Target.activeSelf)
            {
                Target = nearestPlayer;
            }
            else
            {
                var distanceToTarget = (Target.transform.position - currentPos).magnitude;
                var distanceToNearestPlayer = nearestPlayer != null ? (nearestPlayer.transform.position - currentPos).magnitude : float.MaxValue;

                if (distanceToNearestPlayer - distanceToTarget < -NavigationTolerance)
                {
                    Target = nearestPlayer;
                }
            }
        }
        else
        {
            Target = nearestPlayer;
        }

        if (Target != null && _nav.destination != Target.transform.position)
        {
            _nav.SetDestination(Target.transform.position);
        }
    }

    private void Kill()
    {
        gameObject.SetActive(false);
    }

    private void CheckShoot(float deltaTime)
    {
        _shootCooldownValue += deltaTime;

        if (_shootCooldownValue > _minShootCooldownValue)
        {
            _shootCooldownValue = 0f;
            SetNewMinCooldownValue();

            Shoot();
        }
    }

    private void Shoot()
    {
        if (Target != null)
        {
            entity.UseCurrentItem();
        }
    }

    private void SetNewMinCooldownValue()
    {
        _minShootCooldownValue = MinShootCooldown + EnemyRandom.NextFloat(MaxValueToAddShootCooldown);
    }
}
