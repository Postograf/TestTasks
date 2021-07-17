using UnityEngine;

public abstract class Gun : ObjectPoolUser<SpaceshipBullet>
{
    [Header("Sound")]
    [SerializeField] private AudioSource _shootSound;
    [Header("Shooting")]
    [SerializeField] protected Transform _shootPoint;
    [SerializeField] protected float _shootForce;
    [SerializeField] protected float _shootDelay;

    public float ShootForce => _shootForce;

    public virtual bool Shoot()
    {
        if (_shootSound != null)
        {
            _shootSound.Play();
        }

        return true;
    }
}
