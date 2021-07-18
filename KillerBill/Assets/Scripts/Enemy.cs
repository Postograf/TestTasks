using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _regDoll;
    
    private void OnDisable()
    {
        Instantiate(_regDoll, transform.position, transform.rotation);
    }
}
