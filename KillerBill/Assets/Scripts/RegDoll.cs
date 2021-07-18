using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class RegDoll : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _spawnDelay;

    private void Start()
    {
        StartCoroutine(SpawnWithDelay());
    }

    private IEnumerator SpawnWithDelay()
    {
        yield return new WaitForSeconds(_spawnDelay);

        Instantiate(
            _enemy, 
            new Vector3(Random.Range(0f, 10f), 0, Random.Range(0f, 10f)), 
            Quaternion.identity
        );
        
        Destroy(gameObject);
    }
}
