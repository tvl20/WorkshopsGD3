using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float deadzone = 50;
    public float doubleTapTimeframe = 0.5f;

    private Vector2 tapOrigin = Vector2.zero;
    private bool doubleTap = false;
    private float doubleTapCounter = 0;

    // todo: pretty this up
    public Tap GetInput()
    {
        if (Input.touchCount == 0)
        {
            return null;
        }

        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            tapOrigin = touch.position;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            return new Tap(tapOrigin, touch.position, getTapType(tapOrigin, touch.position, deadzone));
        }

        return null;
    }

    private void Update()
    {
        if (doubleTap)
        {
            if (doubleTapCounter < doubleTapTimeframe)
            {
                doubleTapCounter += Time.deltaTime;
            }
            else
            {
                doubleTapCounter = 0;
                doubleTap = false;
            }
        }
    }
    private TapInputGesture getTapType(Vector2 origin, Vector2 destination, float deadzone)
    {
        float deltaX = destination.x - origin.x;
        float deltaY = destination.y - origin.y;

        if (Math.Abs(deltaX) < deadzone && Math.Abs(deltaY) < deadzone)
        {
            // The taps were within the deadzone, thus it is a tap or double tap
            if (doubleTap)
            {
                if (doubleTapCounter < doubleTapTimeframe)
                {
                    doubleTapCounter = 0;
                    doubleTap = false;
                    return TapInputGesture.DoubleTap;
                }
            }

            doubleTap = true;
            return TapInputGesture.Tap;
        }

        if (Math.Abs(deltaX) > Math.Abs(deltaY))
        {
            // we are moving horizontally
            if (deltaX < 0)
            {
                return TapInputGesture.SwipeLeft;
            }
            else if (deltaX > 0)
            {
                return TapInputGesture.SwipeRight;
            }
        }
        else
        {
            // we are moving vertically
            if (deltaY < 0)
            {
                return TapInputGesture.SwipeDown;
            }
            else if (deltaY > 0)
            {
                return TapInputGesture.SwipeUp;
            }
        }

        // Code shouldnt reach this, but this is needed for the compiler
        return TapInputGesture.Tap;
    }
}
