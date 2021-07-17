using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rotator), typeof(Mover), typeof(Gun))]
public class Spaceship : MonoBehaviour
{
    public Gun Gun { get; private set; }

    public Mover Mover { get; private set; }

    public Rotator Rotator { get; private set; }

    public event UnityAction<Vector2, Quaternion> Died;

    private void Awake()
    {
        Gun = GetComponent<Gun>();
        Mover = GetComponent<Mover>();
        Rotator = GetComponent<Rotator>();
    }

    private void OnDestroy()
    {
        Died?.Invoke(transform.position, transform.rotation);
    }

    public void Move()
    {
        Mover.Move();
    }

    public void Rotate(float rotationDegrees)
    {
        Rotator.Rotate(rotationDegrees);
    }

    public void RotateTo(Vector2 target)
    {
        Rotator.RotateTo(target);
    }

    public bool Shoot()
    {
        return Gun.Shoot();
    }
}
