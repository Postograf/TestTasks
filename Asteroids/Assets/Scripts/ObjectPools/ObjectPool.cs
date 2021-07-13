using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Creator<T> _creator;

    private List<T> _pool = new List<T>();

    public int Count => _pool.Count;

    public event UnityAction<int> ObjectsAdded;

    public bool TryGetObject(out T result)
    {
        result = _pool.FirstOrDefault(x => x != null && !x.gameObject.activeSelf);

        return result != null;
    }

    public void ResetPool()
    {
        foreach (var poolObject in _pool)
        {
            poolObject.gameObject.SetActive(false);
        }
    }

    protected void Add(int count = 1)
    {
        for (int i = 0; i < count; i++)
{
            var poolObject = _creator.Create(_container);

            poolObject.gameObject.SetActive(false);

            _pool.Add(poolObject);
        }

        ObjectsAdded?.Invoke(count);
    }
}
