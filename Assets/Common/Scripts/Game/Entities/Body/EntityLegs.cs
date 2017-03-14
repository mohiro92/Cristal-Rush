using UnityEngine;
using Assets.Common.Scripts.Utilities;

public class EntityLegs : MonoBehaviour
{
    protected Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Run()
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName(State.Running))
        {
            animator.SetTrigger(State.Running);
        }
    }

    public void Idle()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(State.Idle))
        {
            animator.SetTrigger(State.Idle);
        }
    }
    
    protected class State
    {
        public static string Running = "Running";
        public static string Idle = "Idle";
    }
}
