using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private AudioSource _moveSound;

    public virtual void Move()
    {
        if (_moveSound != null && !_moveSound.isPlaying)
        {
            _moveSound.Play();
        }
    }
}
