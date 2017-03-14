using UnityEngine;
using Assets.Scripts.Utilities;
using Assets.Scripts;
using System;
using System.Collections;
using Assets.Common.Scripts.Utilities;

public class EntityTorso : MonoBehaviour
{
    public GameObject Weapon;
    
    private TorsoStateMachine stateMachine;
    
    private void Awake()
    {
        stateMachine = new TorsoStateMachine(gameObject);
    }

    public void Run()
    {
        stateMachine.ChangeState(stateMachine.RunningState);
    }

    public void Idle()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    public void Punch()
    {
        stateMachine.ChangeState(stateMachine.AttackState);
    }
    
    private class TorsoStateMachine : StateMachine
    {
        private String Running = "Running";
        private String Idle = "Idle";
        private String Attack = "Attack";

        public State RunningState;
        public State IdleState;
        public State AttackState;
        
        public TorsoStateMachine(GameObject gameObject)
        {
            RunningState = new Assets.Common.Scripts.Utilities.AnimationState(gameObject, Running, 0);
            IdleState = new Assets.Common.Scripts.Utilities.AnimationState(gameObject, Idle, 0);
            AttackState = new Assets.Common.Scripts.Utilities.AnimationState(gameObject, Attack, 0);

            RunningState.AddTransition(IdleState);
            RunningState.AddTransition(AttackState);
            IdleState.AddTransition(RunningState);
            IdleState.AddTransition(AttackState);
            AttackState.AddTransition(IdleState);
            AttackState.AddTransition(RunningState);

            currentState = IdleState;
        }
    }
}
