using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLowerDevice : MonoBehaviour
{
    private float _angle;
    private bool _open;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _angle = 90f;
        _open = false;

    }

    private void Activate()
    {
        if (!_open)
        {
            rb.MoveRotation(rb.rotation + _angle);
            _open = !_open;
        }
    }

    private void Deactivate()
    {
        if (_open)
        {
            rb.MoveRotation(rb.rotation - _angle);
            _open = !_open;
        }
    }
}
