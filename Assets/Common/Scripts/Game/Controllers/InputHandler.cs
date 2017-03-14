using System;
using Assets.Scripts.Common;
using Assets.Scripts.Enums;
using UnityEngine;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour
{
    public static class Consts
    {
        public const float Tolerance = 0.0001f;
        
        public const string Horizontal = "Horizontal";
        public const string Vertical = "Vertical";
        public const string HorizontalRotation = "HorizontalRotation";
        public const string VerticalRotation = "VerticalRotation";
    }
    
    private Dictionary<KeyCode, List<Action>> keyCallbacks = new Dictionary<KeyCode, List<Action>>();
    private List<Action<float, float>> axisCallbacks = new List<Action<float, float>>();

    private void FixedUpdate()
    {
        CheckKeys();
        CheckAxes();
    }

    private void CheckAxes()
    {
        foreach(Action<float, float> action in axisCallbacks)
        {
            action(Input.GetAxis(Consts.Horizontal), Input.GetAxis(Consts.Vertical));
        }
    }

    private void CheckKeys()
    {
        foreach (KeyCode key in keyCallbacks.Keys)
        {
            if (Input.GetKey(key))
            {
                foreach (Action callback in keyCallbacks[key])
                {
                    callback();
                }
            }
        }
    }

    public void RegisterAxisCallback(Action<float, float> callback)
    {
        axisCallbacks.Add(callback);
    }

    public void UnregisterAxisCallback(Action<float, float> action)
    {
        axisCallbacks.Remove(action);
    }

    public void RegisterKeyCallback(KeyCode key, Action callback)
    {
        if(!keyCallbacks.ContainsKey(key))
        {
            keyCallbacks.Add(key, new List<Action>());
        }
        keyCallbacks[key].Add(callback);
    }

    public void UnregisterKeyCallback(KeyCode key, Action callback)
    {
        if(!keyCallbacks.ContainsKey(key))
        {
            return;
        }
        keyCallbacks[key].Remove(callback);
    }
}
