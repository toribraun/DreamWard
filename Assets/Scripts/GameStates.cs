using System;
using UnityEngine;

public static class GameStates
{
    public static string CurrentLevel = "Level1";
    public static bool IsWonCurrentLevel = false;
}

public enum Level
{
    LevelWater,
    LevelDarkness,
    LevelSpiders
}