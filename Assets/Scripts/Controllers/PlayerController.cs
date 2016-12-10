using System;
using Assets.Scripts;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float Precision = 0.1f;
    public float Speed = 0.5f;
    public float JumpForce = 1f;
    public float RottationTime = 100f;
    private float _ratationTimeSum = 0f;


    private bool _isJumping = true;
    private Vector3 _lastPosition;
    private float _lastSign = 1f;

    private Vector3 _targetDirection = Vector3.forward;

    // Use this for initialization
    void Start()
    {
        _lastPosition = transform.localPosition;
        _ratationTimeSum = RottationTime;
    }

    // Update is called once per frame
    void Update()
    {
        var deltaTime = Time.deltaTime;

        CheckDead();

        var dir = Vector3.zero;

        dir += CheckHorizontal(deltaTime);
        dir += CheckVertical(deltaTime);

        CheckJump();
        _targetDirection = CheckRotate(deltaTime, dir);
        CheckShoot(_targetDirection);

        _lastPosition = transform.position;
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

        if (entity.IsDead)
            Kill();
    }

    private void Kill()
    {
        gameObject.SetActive(false);
    }

    private Vector3 CheckRotate(float deltaTime, Vector3 dir)
    {
        var result = _targetDirection;

        if(Math.Abs(dir.x) > Consts.Eps)
        {
            _lastSign = Mathf.Sign(dir.x);
        }

        if (Math.Abs(dir.x) > Consts.Eps || Math.Abs(dir.y) > Consts.Eps || Math.Abs(dir.z) > Consts.Eps)
        {
            result = Vector3.Normalize(dir);
            _ratationTimeSum = 0f;
        }

        //var maxDeg = 180f;
        //_ratationTimeSum += deltaTime;
        //var sinArg = Mathf.PI / .2f * Mathf.Clamp(_ratationTimeSum, 0f, RottationTime) / RottationTime;
        //var rotation = _targetDirection * maxDeg * Mathf.Sin(sinArg);

        var angle = Vector3.Angle(Vector3.forward, result) * _lastSign;

        transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
        return result;
    }

    private Vector3 CheckHorizontal(float deltaTime)
    {
        var axisVal = Input.GetAxis(Consts.HorizontalStr);
        var sign = Mathf.Sign(axisVal);

        var result = Vector3.zero;
        if (Mathf.Abs(axisVal) > Precision)
        {
            var direction = Vector3.right * sign;

            transform.position += direction * Speed * deltaTime;
            result += direction;
        }

        return result;
    }

    private Vector3 CheckVertical(float deltaTime)
    {
        var axisVal = Input.GetAxis(Consts.VerticalStr);
        var sign = Mathf.Sign(axisVal);

        var result = Vector3.zero;
        if (Mathf.Abs(axisVal) > Precision)
        {
            var direction = Vector3.forward*sign;

            transform.position += direction*Speed*deltaTime;
            result += direction;
        }

        return result;
    }

    private void CheckJump()
    {
        if (Input.GetButton(Consts.JumpStr) && !_isJumping)
        {
            Jump();
        }
    }

    private void Jump()
    {
        _isJumping = true;

        var body = GetComponent<Rigidbody>();
        if(body == null)
            throw new NullReferenceException("GameObject needs Rigidbody component");

        body.AddForce(Vector3.up * JumpForce);
    }

    private void CheckShoot(Vector3 dir)
    {
        if (Input.GetButton(Consts.FireStr))
        {
            var entity = GetComponentInChildren<Entity>();
            if (entity == null)
                throw new NullReferenceException("GameObject needs Entity component");

            entity.Shoot(_targetDirection);
        }
    }
}
