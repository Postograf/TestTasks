using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : ObjectPoolUser<Spaceship>
{
    [SerializeField] private SpaceshipSpawner _spaceshipSpawner;

    private int _value;

    public int Value => _value;

    public UnityAction<int> Initialized;
    public UnityAction HealthDecreased;
    public UnityAction PlayerDied;
 
    private void OnEnable()
    {
        _spaceshipSpawner.ShipSpawned += OnShipSpawn;
    }

    private void Start()
    {
        _value = pool.Count;
        Initialized?.Invoke(_value);
    }

    private void OnDisable()
    {
        _spaceshipSpawner.ShipSpawned -= OnShipSpawn;
    }

    private void OnShipSpawn(Spaceship spaceship)
    {
        spaceship.Died += (x, y) => OnShipDestoy();
    }

    private void OnShipDestoy()
    {
        _value--;

        HealthDecreased?.Invoke();

        if (_value == 0)
        {
            PlayerDied?.Invoke();
        }
    }
}
