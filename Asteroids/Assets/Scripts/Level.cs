using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private AsteroidsSpawner _asteroidsSpawner;
    [SerializeField] private MainPool<Asteroid> _asteroidsPool;
    [SerializeField] private int _increaseCountPerWave = 1;
    [SerializeField] private float _timeBetweenWaves = 2;

    private int _currentAsteroidsCount;

    private void Start()
    {
        Invoke(nameof(SpawnWave), _timeBetweenWaves);
    }

    private void OnEnable()
    {
        _asteroidsSpawner.AsteroidSpawned += OnAsteroidSpawned;
    }

    private void OnDisable()
    {
        _asteroidsSpawner.AsteroidSpawned -= OnAsteroidSpawned;
    }

    public void SpawnWave()
    {
        _asteroidsSpawner.SpawnWave();
    }

    private void OnAsteroidSpawned(Asteroid asteroid)
    {
        _currentAsteroidsCount++;
        asteroid.Destroyed += OnAsteroidDestroying;
    }

    private void OnAsteroidDestroying(Asteroid asteroid)
    {
        asteroid.Destroyed -= OnAsteroidDestroying;

        _currentAsteroidsCount--;

        if (_currentAsteroidsCount == 0)
        {
            IncreaseDifficultyLevel();
            Invoke(nameof(SpawnWave), _timeBetweenWaves);
        }
    }

    private void IncreaseDifficultyLevel()
    {
        _asteroidsPool.Add(_increaseCountPerWave);
    }
}
