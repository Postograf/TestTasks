using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creator<T> : MonoBehaviour
{
    public abstract T Create(Transform parent);
}
