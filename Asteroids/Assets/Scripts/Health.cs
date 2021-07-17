using UnityEngine;
using UnityEngine.Events;

public class Health : ObjectPoolUser<Spaceship>
{
    [SerializeField] private SpaceshipSpawner _spaceshipSpawner;

    public int Value { get; private set; }

    public UnityAction<int> Initialized;
    public UnityAction HealthDecreased;
    public UnityAction PlayerDied;
 
    private void OnEnable()
    {
        _spaceshipSpawner.ShipSpawned += OnShipSpawn;
    }

    private void Start()
    {
        Value = pool.Count;
        Initialized?.Invoke(Value);
    }

    private void OnDisable()
    {
        _spaceshipSpawner.ShipSpawned -= OnShipSpawn;
    }

    private void OnShipSpawn(Spaceship spaceship)
    {
        spaceship.Died += (x, y) => OnShipDestroy();
    }

    private void OnShipDestroy()
    {
        Value--;

        HealthDecreased?.Invoke();

        if (Value == 0)
        {
            PlayerDied?.Invoke();
        }
    }
}
