using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Serialization;

public class PlayerStateMachine : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private MoveState _moveState;
    
    [Header("Stay")]
    [SerializeField] private IdleState _idle;
    
    [Header("Attack")]
    [SerializeField] private AttackState _attack;
    [SerializeField] private float _distanceToAttack;
    [SerializeField] private GameObject _attackMessage;
    
    private void Update()
    {
        var nearestEnemies = Physics
            .OverlapSphere(transform.position, _distanceToAttack)
            .Where(x => x.TryGetComponent(out Enemy enemy))
            .ToArray();
        
        if (nearestEnemies.Length > 0)
        {
            _attackMessage.SetActive(true);
            
            if (Input.GetButton("Attack"))
            {
                _attack.enabled = true;
                _moveState.enabled = false;
                _idle.enabled = false;

                _attack.SetTarget(nearestEnemies.First().transform);
            }
        }
        else
        {
            _attackMessage.SetActive(false);
        }

        if (_attack.enabled)
        {
            return;
        }
        
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            _attack.enabled = false;
            _moveState.enabled = false;
            _idle.enabled = true;
        }
        else
        {
            _attack.enabled = false;
            _moveState.enabled = true;
            _idle.enabled = false;
        }
    }
}
