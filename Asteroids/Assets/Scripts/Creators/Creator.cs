using UnityEngine;

public abstract class Creator<T> : MonoBehaviour
{
    public abstract T Create(Transform parent);
}
