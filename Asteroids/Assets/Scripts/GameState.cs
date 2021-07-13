using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    JustTurnOn,
    AlreadyPlaying
}

public static class Game
{
    public static GameState state;
}