using UnityEngine;
using UnityEngine.Events;

public class AsteroidsSpawner : ObjectPoolUser<Asteroid>
{
    [SerializeField] private float _splitDeviationAngle = 45;
    [SerializeField] private Vector2 _speedRange;

    private Camera _camera;

    private Vector2 _leftTop;
    private Vector2 _leftBottom;
    private Vector2 _rightTop;
    private Vector2 _rightBottom;

    public event UnityAction<Asteroid> AsteroidSpawned;

    private void Awake()
    {
        _camera = Camera.main;

        _leftTop = _camera.ViewportToWorldPoint(new Vector2(0, 1));
        _leftBottom = _camera.ViewportToWorldPoint(new Vector2(0, 0));
        _rightTop = _camera.ViewportToWorldPoint(new Vector2(1, 1));
        _rightBottom = _camera.ViewportToWorldPoint(new Vector2(1, 0));
    }

    public void SpawnWave()
    {
        while (pool.TryGetObject(out var asteroid))
        {
            var position = Vector2.zero;
            var direction = Vector2.zero;

            var deviationAngle = Random.Range(-45f, 45f);

            switch (Random.Range(0, 4))
            {
                case 0:
                    direction = Vector2.right;
                    position.x = _leftTop.x;
                    position.y = Random.Range(_leftBottom.y, _leftTop.y);
                    break;
                case 1:
                    direction = Vector2.left;
                    position.x = _rightTop.x;
                    position.y = Random.Range(_rightBottom.y, _rightTop.y);
                    break;
                case 2:
                    direction = Vector2.down;
                    position.y = _leftTop.y;
                    position.x = Random.Range(_leftTop.x, _rightTop.x);
                    break;
                case 3:
                    direction = Vector2.up;
                    position.y = _leftBottom.y;
                    position.x = Random.Range(_leftBottom.x, _rightBottom.x);
                    break;
            }

            Spawn(pool, position, direction.RotateByAngle(deviationAngle));
        }
    }

    public void Spawn(
        ObjectPool<Asteroid> asteroidsPool, 
        Vector3 position, 
        Vector2 direction, 
        float? speed = null
    )
    {
        if (asteroidsPool.TryGetObject(out var asteroid))
        {
            asteroid.transform.position = position;
            asteroid.gameObject.SetActive(true);

            var normalSpeed = speed == null
                ? Random.Range(_speedRange.x, _speedRange.y)
                : speed.Value;

            asteroid.Rigidbody.velocity = direction.normalized * normalSpeed;

            asteroid.Splited += OnAsteroidSplit;

            AsteroidSpawned?.Invoke(asteroid);
        }
    }

    private void OnAsteroidSplit(
        ObjectPool<Asteroid> asteroidsPool,
        Vector3 position,
        Vector2 direction
    )
    {
        var speed = Random.Range(_speedRange.x, _speedRange.y);

        for (var i = 0; i < Asteroid.fragmentsCount; i++)
        {
            var sign = i % 2 == 0 ? 1 + i / 2 : -1 - i / 2;
            
            var fragmentDirection = direction.RotateByAngle(sign * _splitDeviationAngle);

            Spawn(asteroidsPool, position, fragmentDirection, speed);
        }
    }
}
