using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenActivator : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private GameObject[] _objectsToDiactivate;
    [SerializeField] private GameObject _deathScreen;

    private void OnEnable()
    {
        _health.PlayerDied += OnPlayersDeath;
    }

    private void Start()
    {
        _deathScreen.SetActive(false);
    }

    private void OnDisable()
    {
        _health.PlayerDied -= OnPlayersDeath;
    }

    private void OnPlayersDeath()
    {
        Time.timeScale = 0f;

        foreach(var deactivation in _objectsToDiactivate)
        {
            deactivation.SetActive(false);
        }

        _deathScreen.SetActive(true);
    }
}
