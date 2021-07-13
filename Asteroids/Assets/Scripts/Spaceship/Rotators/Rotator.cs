using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rotator : MonoBehaviour
{
    public abstract void Rotate(float rotationDegrees);
    public abstract void RotateTo(Vector2 target);
}
