using System;
using Assets.Scripts.Common;
using Assets.Scripts.Enums;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jump = 1000f;

    public float maxForward = 45f;
    public float minBackward = 125f;

    private Rigidbody _rigidbody;
    private Animator _animator;
    private Camera _camera;


    private EntityState _state = EntityState.Idle;
    public EntityState State
    {
        get { return _state; }

        set
        {
            if (_state == value)
                return;

            if (_animator != null)
                _animator.SetTrigger(value.ParameterName());

            _state = value;
        }
    }


    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _camera = Camera.main;

        State = EntityState.Idle;
    }

    void Start()
    {
        if (_rigidbody == null)
            Debug.Log(string.Format("{0}: Missing Rigidbody", transform.name));
    }

    void FixedUpdate()
    {
        Vector3 forward = GetForward(_camera);
        Vector3 right = GetRight(_camera);

        UpdatePosition(forward, right);
        UpdateRotation(forward, right);

        UpdateJump();
    }

    private void UpdatePosition(Vector3 forward, Vector3 right)
    {
        float h = Input.GetAxis(Consts.Horizontal);
        float v = Input.GetAxis(Consts.Vertical);

        if (Math.Abs(v) < Consts.Tolerance && Math.Abs(h) < Consts.Tolerance)
        {
            State = EntityState.Idle;
            return;
        }

        Vector3 moveDirection = forward * v + right * h;
        SetStateMoving(moveDirection);


        Vector3 newPosition = _rigidbody.position + moveDirection * speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(newPosition);
    }

    private void SetStateMoving(Vector3 moveDirection)
    {
        Vector3 bodyForward = transform.forward;

        float angle = Vector3.Angle(bodyForward, moveDirection);

        if (angle <= maxForward)
        {
            State = EntityState.MovingForward;
        }
        else if (angle < minBackward)
        {
            Vector3 cross = Vector3.Cross(bodyForward, moveDirection);

            State = cross.y < 0 ? EntityState.MovingLeft : EntityState.MovingRight;
        }
        else
        {
            State = EntityState.MovingBackward;
        }
    }

    private void UpdateRotation(Vector3 forward, Vector3 right)
    {
        float h = Input.GetAxis(Consts.HorizontalRotation);
        float v = Input.GetAxis(Consts.VerticalRotation);

        if (Math.Abs(v) < Consts.Tolerance && Math.Abs(h) < Consts.Tolerance)
            return;

        Vector3 direction = forward * v + right * h;

        Quaternion newRotation = Quaternion.LookRotation(direction);
        _rigidbody.MoveRotation(newRotation);
    }

    private void UpdateJump()
    {
        if (Input.GetButton(Consts.Jump))
        {
            _rigidbody.AddForce(new Vector3(0f, jump * Time.fixedDeltaTime, 0f));
        }
    }

    private Vector3 GetForward(Camera cam)
    {
        Vector3 forward = cam.transform.forward;
        forward.y = 0f;

        return forward.normalized;
    }

    private Vector3 GetRight(Camera cam)
    {
        Vector3 right = cam.transform.right;
        right.y = 0f;

        return right.normalized;
    }
}
