using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        var direction = new Vector3(
            Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")
        ).normalized;

        _animator.SetFloat("speed", direction.sqrMagnitude == 0 ? 0 : _speed);

        transform.LookAt(direction);
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
