using UnityEngine;

public abstract class ObjectPoolUserCreator<TItem, TPool> : Creator<TItem> 
    where TItem : ObjectPoolUser<TPool>
    where TPool : MonoBehaviour
{
    [SerializeField] private TItem _prefab;
    [SerializeField] private ObjectPool<TPool> _objectPoolToUse;

    public override TItem Create(Transform parent)
    {
        TItem poolUser;

        if (parent != null)
        {
            poolUser = Instantiate(_prefab, parent);
        }
        else
        {
            poolUser = Instantiate(_prefab);
        }

        poolUser.pool = _objectPoolToUse;

        return poolUser;
    }
}
