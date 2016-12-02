using UnityEngine;
using System.Collections;

public class TouchUnit {

    private Touch currentTouch;

    private int touchId;

    private Vector2 beginPosition;

    public TouchUnit(Touch beginTouch) {
        touchId = beginTouch.fingerId;
        beginPosition = beginTouch.position;
        currentTouch = beginTouch;
    }

    public bool setCurrentTouch(Touch touch) {
        if (touch.fingerId != touchId) {
            return false;
        }

        currentTouch = touch;
        return true;
    }

    public Touch getCurrentTouch() {
        return currentTouch;
    }

    public float movingDistance() {
        return (currentTouch.position - beginPosition).magnitude;
    }

    public float currentSpeed() {
        return currentTouch.deltaPosition.magnitude / currentTouch.deltaTime;
    }

    public Vector2 getBeginPosition() {
        return beginPosition;
    }

    public Vector2 getCurrentPosition() {
        return currentTouch.position;
    }

    public int getTouchId() {
        return touchId;
    }

    public TouchPhase getTouchPhase() {
        return currentTouch.phase;
    }
}
