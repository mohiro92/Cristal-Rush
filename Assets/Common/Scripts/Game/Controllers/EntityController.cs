using System;
using Assets.Scripts.Common;
using Assets.Scripts.Enums;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    private Entity entity;
    private InputHandler inputHandler;
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
        entity = GetComponent<Entity>();

        if (!entity)
        {
            print("Warning! Entity is null!");
        }

        if (!inputHandler)
        {
            print("Warning! Input handler is null!");
        }
    }

    private void OnDestroy()
    {
        if(inputHandler)
        {
            inputHandler.UnregisterAxisCallback(UpdateDirection);
            inputHandler.UnregisterKeyCallback(KeyCode.Space, Jump);
            inputHandler.UnregisterKeyCallback(KeyCode.LeftControl, Punch);
        }
    }

    public void SetInputHandler(InputHandler inputHandler)
    {
        if(!this.inputHandler)
        {
            this.inputHandler = inputHandler;

            inputHandler.RegisterAxisCallback(UpdateDirection);
            inputHandler.RegisterKeyCallback(KeyCode.Space, Jump);
            inputHandler.RegisterKeyCallback(KeyCode.LeftControl, Punch);
        }
    }
        

    private void UpdateDirection(float horizontalAxis, float verticalAxis)
    {
        Vector3 direction = GetForward() * verticalAxis + GetRight() * horizontalAxis;

        entity.Move(direction.normalized);
    }
    
    private void Jump()
    {
        entity.Jump();
    }

    private void Punch()
    {
        entity.Punch();
    }

    private Vector3 GetForward()
    {
        Vector3 forward = camera.transform.forward;
        forward.y = 0f;

        return forward;
    }

    private Vector3 GetRight()
    {
        Vector3 right = camera.transform.right;
        right.y = 0f;

        return right;
    }
}
