using UnityEngine;

public class RotatorBySpeed : Rotator
{
    [SerializeField] private float _speed;

    private Quaternion _from;
    private Quaternion _to;
    private float _delta = 1f;

    private void Update()
    {
        if (transform.rotation != _to)
        {
            _delta += _speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(_from, _to, _delta);
        }
    }

    public override void Rotate(float rotationDegrees)
    {
        _from = transform.rotation;

        var nextRotationInDegrees = rotationDegrees - transform.rotation.eulerAngles.z;
        _to = Quaternion.AngleAxis(nextRotationInDegrees, Vector3.back);

        _delta = 0;
    }

    public override void RotateTo(Vector2 target)
    {
        _from = transform.rotation;

        var directionToTarget = target - (Vector2)transform.position;
        _to = Quaternion.LookRotation(Vector3.forward, directionToTarget);

        _delta = 0;
    }
}
