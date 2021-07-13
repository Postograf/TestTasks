using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rotator), typeof(Mover), typeof(Gun))]
public class Spaceship : MonoBehaviour
{
    private Gun _gun;
    private Mover _mover;
    private Rotator _rotator;

    public Gun Gun => _gun;
    public Mover Mover => _mover;
    public Rotator Rotator => _rotator;

    public event UnityAction<Vector2, Quaternion> Died;

    private void Awake()
    {
        _gun = GetComponent<Gun>();
        _mover = GetComponent<Mover>();
        _rotator = GetComponent<Rotator>();
    }

    private void OnDestroy()
    {
        Died?.Invoke(transform.position, transform.rotation);
    }

    public void Move()
    {
        _mover.Move();
    }

    public void Rotate(float rotationDegrees)
    {
        _rotator.Rotate(rotationDegrees);
    }

    public void RotateTo(Vector2 target)
    {
        _rotator.RotateTo(target);
    }

    public bool Shoot()
    {
        return _gun.Shoot();
    }
}
