using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Precision = 0.1f;
    public float Speed = 0.5f;
    public float JumpForce = 1f;

    private bool _isJumping = true;
    private Vector3 _lastPosition;

    // Use this for initialization
    void Start()
    {
        _lastPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        var deltaTime = Time.deltaTime;

        CheckHorizontal(deltaTime);
        CheckVertical(deltaTime);
        CheckJump();
        CheckShoot();

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

    private void CheckHorizontal(float deltaTime)
    {
        var axisVal = Input.GetAxis("Horizontal");
        var sign = Mathf.Sign(axisVal);

        if (Mathf.Abs(axisVal) > Precision)
        {
            transform.position += new Vector3(Speed * sign * deltaTime, 0f, 0f);
        }
    }

    private void CheckVertical(float deltaTime)
    {
        var axisVal = Input.GetAxis("Vertical");
        var sign = Mathf.Sign(axisVal);

        if (Mathf.Abs(axisVal) > Precision)
        {
            transform.position += new Vector3(0f, 0f, Speed * sign * deltaTime);
        }
    }

    private void CheckJump()
    {
        if (Input.GetButton("Jump") && !_isJumping)
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

    private void CheckShoot()
    {
        if (Input.GetButton("Fire1"))
        {
            var entity = GetComponent<Entity>();
            if (entity == null)
                throw new NullReferenceException("GameObject needs Entity component");

            entity.Shoot(transform.position - _lastPosition);
        }
    }
}
