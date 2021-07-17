using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SpaceshipSpawner : ObjectPoolUser<Spaceship>
{
    [SerializeField] private SpaceshipControls[] _controlMaps;
    [SerializeField] private Vector2 _startPoint;
    [SerializeField] private Vector3 _startRotation;

    public Spaceship Spaceship { get; private set; }

    public event UnityAction<Spaceship> ShipSpawned;

    private void Start()
    {
        SpawnShip(_startPoint, Quaternion.Euler(_startRotation));
    }

    private void OnEnable()
    {
        if (Spaceship != null)
        {
            Spaceship.Died += OnShipDeath;
        }
    }

    private void OnDisable()
    {
        Spaceship.Died -= OnShipDeath;
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
            Spaceship = obj;

            Spaceship.transform.SetPositionAndRotation(spawnPoint, rotation);

            foreach (var controls in _controlMaps)
            {
                controls.ship = Spaceship;
            }

            Spaceship.Died += OnShipDeath;

            Spaceship.gameObject.SetActive(true);

            ShipSpawned?.Invoke(Spaceship);
        }
    }

    private IEnumerator SpawnWithDelay(Vector2 spawnPoint, Quaternion rotation)
    {
        yield return new WaitForEndOfFrame();

        SpawnShip(spawnPoint, rotation);
    }
}
