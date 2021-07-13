using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreView : MonoBehaviour
{
    private TMP_Text _score;

    private void OnEnable()
    {
        Score.ScoreUpdated += UpdateScoreView;
    }

    private void Start()
    {
        _score = GetComponent<TMP_Text>();
        UpdateScoreView();
    }

    private void OnDisable()
    {
        Score.ScoreUpdated -= UpdateScoreView;
    }

    private void UpdateScoreView()
    {
        _score.text = $"Score: {Score.Value}";
    }
}
