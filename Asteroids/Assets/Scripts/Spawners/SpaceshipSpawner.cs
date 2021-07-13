using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpaceshipSpawner : ObjectPoolUser<Spaceship>
{
    [SerializeField] private SpaceshipControls[] _controlMaps;
    [SerializeField] private Vector2 _startPoint;
    [SerializeField] private Vector3 _startRotation;

    private Spaceship _spaceship;

    public Spaceship Spaceship => _spaceship;

    public event UnityAction<Spaceship> ShipSpawned;

    private void Start()
    {
        SpawnShip(_startPoint, Quaternion.Euler(_startRotation));
    }

    private void OnEnable()
    {
        if (_spaceship != null)
        {
            _spaceship.Died += OnShipDeath;
        }
    }

    private void OnDisable()
    {
        _spaceship.Died -= OnShipDeath;
    }

    private void OnShipDeath(Vector2 deadPoint, Quaternion deadRotation)
    {
        foreach (var controls in _controlMaps)
        {
            controls.ship = null;
        }

        StartCoroutine(SpawnWithDelay(deadPoint, deadRotation));
    }

    private void SpawnShip(Vector2 spawnPoint, Quaternion rotation)
    {
        if (pool.TryGetObject(out var obj)) 
        {
            _spaceship = obj.GetComponent<Spaceship>();

            _spaceship.transform.SetPositionAndRotation(spawnPoint, rotation);

            foreach (var controls in _controlMaps)
            {
                controls.ship = _spaceship;
            }

            _spaceship.Died += OnShipDeath;

            _spaceship.gameObject.SetActive(true);

            ShipSpawned?.Invoke(_spaceship);
        }
    }

    private IEnumerator SpawnWithDelay(Vector2 spawnPoint, Quaternion rotation)
    {
        yield return new WaitForEndOfFrame();

        SpawnShip(spawnPoint, rotation);
    }
}
