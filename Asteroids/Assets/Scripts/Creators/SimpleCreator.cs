using UnityEngine;

public abstract class SimpleCreator<T> : Creator<T> where T : MonoBehaviour
{
    [SerializeField] private T _prefab;

    public override T Create(Transform parent)
    {
        if (parent != null)
        {
            return Instantiate(_prefab, parent);
        }
        
        return Instantiate(_prefab);
    }
}
