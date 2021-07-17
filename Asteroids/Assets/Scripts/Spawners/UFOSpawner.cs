using UnityEngine;
using UnityEngine.Events;

public class UFOSpawner : ObjectPoolUser<UFO>
{
    [SerializeField] private Vector2 _spawnDelayRange;
    [Range(0, 100)]
    [SerializeField] private float _edgesOffsetProcent;
    [SerializeField] private float _ufoScreenTime;

    private Camera _camera;

    private float _leftX;
    private float _rightX;
    private Vector2 _yRange;
    private float _speed;

    public event UnityAction<UFO> UFOSpawned;

    private void Awake()
    {
        _camera = Camera.main;

        var leftTop = _camera.ViewportToWorldPoint(new Vector2(0, 1));
        var leftBottom = _camera.ViewportToWorldPoint(new Vector2(0, 0));
        var rightTop = _camera.ViewportToWorldPoint(new Vector2(1, 1));
        var rightBottom = _camera.ViewportToWorldPoint(new Vector2(1, 0));

        _leftX = leftTop.x;
        _rightX = rightTop.x;

        var edgesOffset = (leftTop.y - leftBottom.y) * _edgesOffsetProcent / 100 / 2;

        _yRange = new Vector2(leftBottom.y + edgesOffset, leftTop.y - edgesOffset);

        _speed = _camera.PixelToUnit(_camera.pixelWidth) / _ufoScreenTime;
    }

    private void Start()
    {
        SpawnWithDelay();
    }

    private void Spawn()
    {
        if (pool.TryGetObject(out var ufo))
        {
            var position = Vector2.zero;
            var direction = Vector2.zero;

            switch (Random.Range(0, 2))
            {
                case 0:
                    direction = Vector2.right;
                    position.x = _leftX;
                    break;
                case 1:
                    direction = Vector2.left;
                    position.x = _rightX;
                    break;
            }

            position.y = Random.Range(_yRange.x, _yRange.y);

            ufo.transform.position = position;
            ufo.gameObject.SetActive(true);

            ufo.Rigidbody.velocity = direction.normalized * _speed;

            ufo.Destroyed += SpawnWithDelay;

            UFOSpawned?.Invoke(ufo);
        }
    }

    private void SpawnWithDelay(UFO ufo = null)
    {
        Invoke(nameof(Spawn), Random.Range(_spawnDelayRange.x, _spawnDelayRange.y));
    }
}
