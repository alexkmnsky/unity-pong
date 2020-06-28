using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameTimer
{
    static float gameDurationInSeconds = 120f;

    public static float GetTimeRemaining()
    {
        return gameDurationInSeconds - Time.timeSinceLevelLoad;
    }
}
