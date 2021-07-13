using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsSwitcher : MonoBehaviour
{
    [SerializeField] private SpaceshipControls[] _controlMaps;

    private int _indexOfEnabled = 0;

    public SpaceshipControls CurrentControls => _controlMaps[_indexOfEnabled];

    private void Awake()
    {
        DisableAll();

        if (_indexOfEnabled >= _controlMaps.Length)
        {
            return;
        }

        _controlMaps[_indexOfEnabled].enabled = true;
    }

    private void Start()
    {
    }

    public string Switch()
    {
        if (_indexOfEnabled >= _controlMaps.Length)
        {
            return "";
        }
        
        _controlMaps[_indexOfEnabled].enabled = false;

        if (_indexOfEnabled + 1 == _controlMaps.Length)
        {
            _indexOfEnabled = 0;
        }
        else
        {
            _indexOfEnabled++;
        }

        _controlMaps[_indexOfEnabled].enabled = true;

        return _controlMaps[_indexOfEnabled].Name;
    }

    public void DisableAll()
    {
        foreach (var control in _controlMaps)
        {
            control.enabled = false;
        }
    }
}
