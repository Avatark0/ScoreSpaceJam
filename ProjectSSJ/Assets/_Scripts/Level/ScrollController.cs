using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : ScriptableObject
{
    private static float scrollSpeed = 4f;

    public static float GetScrollSpeed()
    {
        return scrollSpeed;
    }

    public static void SetScrollSpeed(float newSpeed)
    {
        scrollSpeed = newSpeed;
    }
}
