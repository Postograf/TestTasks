using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    private CharacterController _controller;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var direction = new Vector3(
            Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")
        ).normalized;

        _animator.SetFloat("speed", direction.sqrMagnitude == 0 ? 0 : _speed);
        
        transform.LookAt(transform.position + direction);
        _controller.Move(direction * (_speed * Time.deltaTime));
    }
}
