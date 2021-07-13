using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStatsSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _gameStats;
    [SerializeField] private GameObject _menu;

    private void Awake()
    {
        if (Game.state == GameState.JustTurnOn)
        {
            Time.timeScale = 0f;
            ToMenu();
        }
        else
        {
            ToStats();
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!_menu.activeSelf)
            {
                ToMenu();
            }
            else
            {
                ToStats();
            }
        }
    }

    public void ToStats()
    {
        Time.timeScale = 1f;
        _gameStats.SetActive(true);
        _menu.SetActive(false);
    }

    public void ToMenu()
    {
        Time.timeScale = 0f;
        _gameStats.SetActive(false);
        _menu.SetActive(true);
    }
}
