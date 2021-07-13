using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Asteroid : ObjectPoolUser<Asteroid>, IScorable
{

    public static readonly int fragmentsCount = 2;

    private Rigidbody2D _rigidbody;
    private AudioSource _audioSource;

    public event UnityAction<Asteroid> Destroyed;
    public event UnityAction<ObjectPool<Asteroid>, Vector3, Vector2> Splited;
    public event UnityAction Scored;

    public Rigidbody2D Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        TryGetComponent(out _audioSource);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Spaceship spaceship))
        {
            Destroy(spaceship.gameObject);
            Destroy();
        }
    }

    public void Split()
    {
        if (pool != null)
        {
            Splited?.Invoke(pool, transform.position, _rigidbody.velocity);
        }

        Scored?.Invoke();
        Destroy();
    }

    private void Destroy()
    {
        if (_audioSource != null)
        {
            DeathRattle();
        }

        gameObject.SetActive(false);

        Destroyed?.Invoke(this);
    }

    private void DeathRattle()
    {
        var obj = new GameObject();
        obj.transform.position = transform.position;
        var source = obj.AddComponent<AudioSource>();
        source.clip = _audioSource.clip;
        source.Play();
        Destroy(obj, source.clip.length);
    }
}
