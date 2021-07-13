using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IScorable))]
public class ScoreTarget : MonoBehaviour
{
    [SerializeField] private int _scoreForDestruction;

    private IScorable _scorable;

    private void Awake()
    {
        _scorable = GetComponent<IScorable>();
        _scorable.Scored += AddScore;
    }

    private void AddScore()
    {
        Score.Add(_scoreForDestruction);
    }
}
