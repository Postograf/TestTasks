using UnityEngine;

public abstract class DependentPool<TPool, TMain> : ObjectPool<TPool> 
    where TPool : MonoBehaviour
    where TMain : MonoBehaviour
{
    [SerializeField] private MainPool<TMain> _mainPool;

    private void OnEnable()
    {
        _mainPool.ObjectsAdded += OnObjectsAdded;
    }

    private void OnDisable()
    {
        _mainPool.ObjectsAdded -= OnObjectsAdded;
    }

    protected abstract void OnObjectsAdded(int count);
}
