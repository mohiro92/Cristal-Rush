using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotator : MonoBehaviour {

    public Camera m_Camera;
    public Transform PlayerTransform;

    private Vector3 offset;

    void Awake()
    {
        if (m_Camera == null)
            m_Camera = Camera.main;

        offset = transform.localPosition;
    }

    void Update()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
        transform.position = PlayerTransform.position + offset;
    }
}
