using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class UFO : ObjectPoolUser<UFOBullet>, IScorable
{
    [SerializeField] public SpaceshipSpawner spaceshipSpawner;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Vector2 _shootDelayRange;

    private Spaceship _target;
    private Vector2 _lastTargetPosition;
    private float _lastTargetShootForce;

    public Rigidbody2D Rigidbody { get; private set; }

    public event UnityAction<UFO> Destroyed;
    public event UnityAction Scored;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(ShootWithDelay());
    }

    public void Destroy()
    {
        Scored?.Invoke();
        Destroyed?.Invoke(this);

        gameObject.SetActive(false);
    }

    private IEnumerator ShootWithDelay()
    {
        yield return new WaitForSeconds(Random.Range(_shootDelayRange.x, _shootDelayRange.y));
        Shoot();
    }

    private void Shoot()
    {
        if (pool.TryGetObject(out var bullet))
        {
            bullet.transform.position = _shootPoint.position;

            if(spaceshipSpawner.Spaceship != null)
            {
                _lastTargetPosition = spaceshipSpawner.Spaceship.transform.position;
                _lastTargetShootForce = spaceshipSpawner.Spaceship.Gun.ShootForce;
            }

            var directionToTarget = _lastTargetPosition - (Vector2)transform.position;
            bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, directionToTarget);

            bullet.gameObject.SetActive(true);

            bullet.Rigidbody.velocity = bullet.transform.up * _lastTargetShootForce;

            StartCoroutine(ShootWithDelay());
        }
    }
}
