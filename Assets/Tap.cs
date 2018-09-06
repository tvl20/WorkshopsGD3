using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap
{
    public Vector2 originPosition;
    public Vector2 endPosition;
    public TapInputGesture Gesture;

    public Tap(Vector2 originPosition, Vector2 endPosition, TapInputGesture gesture)
    {
        this.originPosition = originPosition;
        this.endPosition = endPosition;
        Gesture = gesture;
    }
}
