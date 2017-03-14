using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

namespace Assets.Common.Scripts.Utilities
{
    public class StateMachine
    {
        private object lockObject = new object();
        private bool isChangingState = false;

        public State currentState { get; protected set; }

        public StateMachine()
        {

        }

        public bool ChangeState(State newState)
        {
            lock (lockObject)
            {
                if (currentState.AllowChangeState(newState))
                {
                    currentState.OnStateExit();
                    currentState = newState;
                    currentState.OnStateEnter();
                    return true;
                }        
                return false;
            }
        }
    }

    public abstract class State
    {
        protected HashSet<State> transitionStates = new HashSet<State>();

        public void AddTransition(State nextState)
        {
            transitionStates.Add(nextState);
        }

        public void RemoveTransition(State nextState)
        {
            transitionStates.Remove(nextState);
        }

        public abstract void OnStateEnter();

        public abstract void OnStateExit();

        public virtual bool AllowChangeState(State nextState)
        {
            return transitionStates.Contains(nextState);
        }
    }

    public class AnimationState : State
    {
        protected GameObject gameObject;

        protected Animator Animator;
        protected String AnimatorState;
        protected float AnimationStart = 0;
        protected float AnimationDuration = 0;
        
        public AnimationState(GameObject gameObject, String state, float duration)
        {
            this.gameObject = gameObject;
            Animator = gameObject.GetComponent<Animator>();
            AnimatorState = state;
            AnimationDuration = duration;
        }

        public override void OnStateEnter()
        {
            AnimationStart = Time.time;
            Animator.SetBool(AnimatorState, true);
            //FinishAfterTime();
        }

        public override void OnStateExit()
        {
            Animator.SetBool(AnimatorState, false);
        }
        
        public override bool AllowChangeState(State nextState)
        {
            return Time.time - AnimationStart > AnimationDuration && transitionStates.Contains(nextState);
        }
    }
}
