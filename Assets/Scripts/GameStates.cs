using System;
using UnityEngine;

public static class GameStates
{
    public static string CurrentLevel = "WaterLevel1";
    public static bool IsWonCurrentLevel = false;
    public static bool IsPaused = false;
}

public enum Level
{
    LevelWater,
    LevelDarkness,
    LevelSpiders
}