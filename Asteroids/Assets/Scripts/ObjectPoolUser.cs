using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolUser<T> : MonoBehaviour where T : MonoBehaviour
{
    public ObjectPool<T> pool;
}
