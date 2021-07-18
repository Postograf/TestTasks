using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MoveState : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _spine;

    private CharacterController _controller;
    
    private static readonly int _animationSpeed = Animator.StringToHash("speed");
    private static readonly int _forward = Animator.StringToHash("forward");
    private static readonly int _back = Animator.StringToHash("back");

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var moveDirection = new Vector3(
            Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")
        ).normalized;

        var lookDirection = moveDirection;

        if (moveDirection.sqrMagnitude != 0)
        {
            var spineDirection = _spine.up;
            spineDirection.y = 0;
            spineDirection.Normalize();
            
            if (Vector3.Angle(spineDirection, moveDirection) <= 90)
            {
                _animator.SetTrigger(_forward);
            }
            else
            {
                _animator.SetTrigger(_back);
                lookDirection = -lookDirection;
            }
            
            _animator.SetFloat(_animationSpeed, _speed);
            
            transform.LookAt(transform.position + lookDirection);
            _controller.Move(moveDirection * (_speed * Time.deltaTime));
        }
        else
        {
            _animator.SetFloat(_animationSpeed, 0);
        }
    }

    private void OnDisable()
    {
        _animator.SetFloat(_animationSpeed, 0);
    }
}
