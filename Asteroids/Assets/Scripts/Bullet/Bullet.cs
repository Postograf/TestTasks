using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    protected Camera _camera;
    protected float _traveledDistance;
    protected float _maxDistance;

    public Rigidbody2D Rigidbody => _rigidbody;

    protected virtual void Awake()
    {
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody2D>();

        _maxDistance = _camera.PixelToUnit(_camera.pixelWidth);
    }

    protected virtual void FixedUpdate()
    {
        _traveledDistance += _rigidbody.velocity.magnitude * Time.fixedDeltaTime;

        if (_traveledDistance >= _maxDistance)
        {
            Destroy();
        }
    }

    protected virtual void OnDisable()
    {
        _traveledDistance = 0;
    }

    protected virtual void Destroy()
    {
        gameObject.SetActive(false);
    }
}
