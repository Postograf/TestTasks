using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _gun;
    [SerializeField] private GameObject _knife;

    public void ToKnife()
    {
        _gun.SetActive(false);
        _knife.SetActive(true);
    }
    
    public void ToGun()
    {
        _gun.SetActive(true);
        _knife.SetActive(false);
    }
}
