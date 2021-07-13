using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpaceshipControls : MonoBehaviour
{
    [HideInInspector] public Spaceship ship;
    [SerializeField] private string _name;

    public string Name => _name;
}
