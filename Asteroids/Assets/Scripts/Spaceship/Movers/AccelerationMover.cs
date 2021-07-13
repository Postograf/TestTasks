using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AccelerationMover : Mover
{
    [Header("Moving")]
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _acceleration;

    private Rigidbody2D _rigidbody;
    private float _speed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void Move()
    {
        base.Move();

        if (_speed + _acceleration >= _maxSpeed)
        {
            _speed = _maxSpeed;
        }
        else
        {
            _speed += _acceleration;
        }

        _rigidbody.velocity = transform.up * _speed;
    }
}
