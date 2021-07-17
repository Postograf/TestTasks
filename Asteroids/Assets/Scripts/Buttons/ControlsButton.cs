using TMPro;

using UnityEngine;

public class ControlsButton : MonoBehaviour
{
    [SerializeField] private ControlsSwitcher _controlsSwitcher;
    [SerializeField] private TMP_Text _buttonName;

    private int _pressCount;

    private void Start()
    {
        if (_controlsSwitcher.CurrentControls != null)
        {
            SetName(_controlsSwitcher.CurrentControls.Name);
        }
        else
        {
            SetName("");
        }
    }

    public void SwitchControls()
    {
        if (_pressCount == 0)
        {
            SetName(_controlsSwitcher.Switch());
            _pressCount++;
        }
        else
        {
            _pressCount = 0;
        }
    }

    private void SetName(string name)
    {
        _buttonName.text = $"Управление: {name}";
    }
}
