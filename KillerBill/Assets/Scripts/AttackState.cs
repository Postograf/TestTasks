using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttackState : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private WeaponSwitcher _weaponSwitcher;
    [SerializeField] private Transform _spine;
    [SerializeField] private float _attackRange;
    
    private static readonly int _attack = Animator.StringToHash("attack");
    
    private Transform _target;
    
    private void Update()
    {
        if (
            _target != null 
            && !_animator.GetBool(_attack)
        )
        {
            Destroy(_target.gameObject);
            
            _weaponSwitcher.ToGun();
            
            _target = null;
            enabled = false;
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;

        var lookPoint = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(lookPoint);

        var eulerRotation = _spine.eulerAngles;
        _spine.rotation = Quaternion.Euler(eulerRotation.x, transform.eulerAngles.y, eulerRotation.z);

        transform.position = _target.position - transform.forward * _attackRange;
        
        _animator.SetBool(_attack, true);
        
        _weaponSwitcher.ToKnife();
    }
}
