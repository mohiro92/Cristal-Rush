using System;
using Assets.Scripts;
using Assets.Scripts.Utilities;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float Precision = 0.1f;
    public float JumpForce = 1f;
    public GameObject GunPivot;

    private bool _isJumping = true;
    private float _lastSign = 1f;

    private Vector3 _bodyForward = Vector3.forward;
    private Vector3 _shootDir = Vector3.forward;

    private int _id = -1;

    // Update is called once per frame
    void Update()
    {
        var deltaTime = Time.deltaTime;

        CheckDead();

        UpdateBody(deltaTime);
        UpdateShoot(deltaTime);
    }

    private void UpdateBody(float deltaTime)
    {
        CheckDead();

        var dir = Vector3.zero;

        dir += GetHorizontalDirection(Consts.HorizontalPrefixStr, deltaTime);
        dir += GetVerticalDirection(Consts.VerticalPrefixStr, deltaTime);
        dir.Normalize();
        
        var entity = GetComponentInChildren<Entity>();
        if (entity == null)
            throw new NullReferenceException("GameObject needs Entity component");


        entity.Move(dir);

        _bodyForward = CheckRotate(entity.transform, dir);
        CheckJump();
    }

    private void UpdateShoot(float deltaTime)
    {
        var dir = Vector3.zero;

        dir += GetHorizontalDirection(Consts.HorizontalRightPrefixStr, deltaTime);
        dir += GetVerticalDirection(Consts.VerticalRightPrefixStr, deltaTime);

        var entity = GetComponentInChildren<Entity>();
        if (entity == null)
            throw new NullReferenceException("GameObject needs Entity component");
        
        if(!dir.IsZero())
            _shootDir = CheckRotate(GunPivot.transform, dir);

        CheckShoot(_shootDir);
    }

    // on colision enter sets _isJumpiong to false
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);

            if (contact.point.y < transform.position.y)
                _isJumping = false;
        }
    }

    private void CheckDead()
    {
        var entity = GetComponentInChildren<Entity>();
        if (entity == null)
            throw new NullReferenceException("GameObject needs Entity component");

        if (entity.IsDead || entity.transform.position.y < Consts.HellLevel)
            Kill();
    }

    private void Kill()
    {
        gameObject.SetActive(false);
    }

    private Vector3 CheckRotate(Transform trans, Vector3 dir)
    {
        var result = _bodyForward;

        if (Math.Abs(dir.x) > Consts.Eps)
        {
            _lastSign = Mathf.Sign(dir.x);
        }

        if (Math.Abs(dir.x) > Consts.Eps || Math.Abs(dir.y) > Consts.Eps || Math.Abs(dir.z) > Consts.Eps)
        {
            result = Vector3.Normalize(dir);
        }

        var angle = Vector3.Angle(Vector3.forward, result) * _lastSign;

        trans.rotation = Quaternion.Euler(0f, angle, 0f);

        return result;
    }

    private Vector3 GetHorizontalDirection(string prefix, float deltaTime)
    {
        var axisVal = Input.GetAxis(InputHelper.GetAxisName(prefix, _id));
        var sign = Mathf.Sign(axisVal);

        var result = Vector3.zero;
        if (Mathf.Abs(axisVal) > Precision)
        {
            var direction = Vector3.right * sign;

            result += direction;
        }

        return result;
    }

    private Vector3 GetVerticalDirection(string prefix, float deltaTime)
    {
        var axisVal = Input.GetAxis(InputHelper.GetAxisName(prefix, _id));
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
        if(_isJumping)
            return;

        var axisName = InputHelper.GetAxisName(Consts.JumpPrefixStr, _id);

        if (_id == Consts.KeyBoardId && Input.GetButton(axisName))
        {
            Jump();
        }
        else if (_id != Consts.KeyBoardId && Input.GetAxis(axisName) > Consts.Eps)
        {
            Jump();
        }
    }

    private void Jump()
    {
        _isJumping = true;

        var body = GetComponent<Rigidbody>();
        if (body == null)
            throw new NullReferenceException("GameObject needs Rigidbody component");

        body.AddForce(Vector3.up * JumpForce);
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
        var entity = GetComponentInChildren<Entity>();
        if (entity == null)
            throw new NullReferenceException("GameObject needs Entity component");

        _shootDir = dir;
        entity.Shoot(dir);
    }

    public void Respawn(Vector3 startPosition, float deltaTime)
    {
        //TODO: delta for control respawnCooldown; -- delta is wrong! should be actual time in ms

        transform.position = startPosition;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        var entity = GetComponentInChildren<Entity>();
        if (entity == null)
            throw new NullReferenceException("GameObject needs Entity component");

        entity.Respawn();

        gameObject.SetActive(true);
    }

    public void SetId(int id)
    {
        _id = id;
        gameObject.name = string.Format("Player {0}", _id);
    }
}
