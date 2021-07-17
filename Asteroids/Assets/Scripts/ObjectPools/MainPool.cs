using UnityEngine;

public abstract class MainPool<T> : ObjectPool<T> where T : MonoBehaviour
{
    [SerializeField] private int _startCount;

    protected void Awake()
    {
        if (Count == 0)
        {
            Add(_startCount);
        }
    }

    public new void Add(int count)
    {
        base.Add(count);
    }
}
