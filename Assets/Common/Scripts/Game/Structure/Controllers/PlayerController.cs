using System;
using Assets.Scripts;
using Assets.Scripts.Utilities;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player Player;

    public float Precision = 0.1f;
    
    private Vector3 _shootDir = Vector3.forward;

    private int _id = -1;

    // Update is called once per frame
    void Update()
    {
        var deltaTime = 1;
        
        UpdateBody(deltaTime);
        CheckShoot(_shootDir);
    }

    private void UpdateBody(float deltaTime)
    {
        var dir = Vector3.zero;

        dir += GetHorizontalDirection();
        dir += GetVerticalDirection();
        dir.Normalize();

        if(!dir.IsZero())
        {
            Player.Entity.Move(dir);
        } else
        {
            Player.Entity.Stop();
        }
        
        CheckJump();
    }
    
    private Vector3 GetHorizontalDirection()
    {
        var axisVal = Input.GetAxis(InputHelper.GetAxisName(Consts.HorizontalPrefixStr, _id));
        var sign = Mathf.Sign(axisVal);

        var result = Vector3.zero;
        if (Mathf.Abs(axisVal) > Precision)
        {
            var direction = Vector3.right * sign;

            result += direction;
        }

        return result;
    }

    private Vector3 GetVerticalDirection()
    {
        var axisVal = Input.GetAxis(InputHelper.GetAxisName(Consts.VerticalPrefixStr, _id));
        var sign = Mathf.Sign(axisVal);

        var result = Vector3.zero;
        if (Mathf.Abs(axisVal) > Precision)
        {
            var direction = Vector3.forward * sign;

            result += direction;
        }

        return result;
    }

    private void CheckJump()
    {
        var axisName = InputHelper.GetAxisName(Consts.JumpPrefixStr, _id);

        if (_id == Consts.KeyBoardId && Input.GetButton(axisName))
        {
            Player.Entity.Jump();
        }
        else if (_id != Consts.KeyBoardId && Input.GetAxis(axisName) > Consts.Eps)
        {
            Player.Entity.Jump();
        }
    }

    private void CheckShoot(Vector3 dir)
    {
        var name = InputHelper.GetAxisName(Consts.FirePrefixStr, _id);

        if (_id == Consts.KeyBoardId && (Input.GetButton(name) || Input.GetAxis(name) < -Consts.Eps))
        {
            Shoot(dir);
        }
    }

    private void Shoot(Vector3 dir)
    {
        _shootDir = dir;
        Player.Entity.UseCurrentItem();
    }

    public void Respawn()
    {
        Player.Respawn();
    }

    public void SetId(int id)
    {
        _id = id;
        gameObject.name = string.Format("Player {0}", _id);
    }
}
