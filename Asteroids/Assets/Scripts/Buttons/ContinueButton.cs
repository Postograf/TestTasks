using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private MenuStatsSwitcher _switcher;

    private void Start()
    {
        GetComponent<Button>().interactable = Game.state == GameState.AlreadyPlaying;
    }

    public void Continue()
    {
        _switcher.ToStats();
    }
}