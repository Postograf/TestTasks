using UnityEngine;

public class ObjectPoolUser<T> : MonoBehaviour where T : MonoBehaviour
{
    public ObjectPool<T> pool;
}
