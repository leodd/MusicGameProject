using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class TouchManager : MonoBehaviour {

    public delegate bool TouchRespond(TouchUnit touchUnit);

    public static event TouchRespond onRespond;

    private List<TouchUnit> touchList = new List<TouchUnit>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (onRespond == null) {
            return;
        }

        TouchUnit touchUnit;

        if (Input.touchCount > 0) {
            for (int i = 0; i < Input.touchCount; i++) {
                Touch touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Began)
                {
                    touchUnit = new TouchUnit(Input.GetTouch(i));
                    if (!onRespond(touchUnit))
                    {
                        touchList.Add(touchUnit);
                    }
                }
                else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    touchUnit = findTouchById(touch.fingerId);
                    if (touchUnit != null)
                    {
                        touchUnit.setCurrentTouch(touch);
                        if (onRespond(touchUnit))
                        {
                            touchList.Remove(touchUnit);
                        }
                    }
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
                    touchUnit = findTouchById(touch.fingerId);
                    if (touchUnit != null) {
                        touchUnit.setCurrentTouch(touch);
                        onRespond(touchUnit);
                        touchList.Remove(touchUnit);
                    }
                }
            }
        }
        else if (Input.GetMouseButton(0))
        {
            onRespond(null);
        }
    }

    private TouchUnit findTouchById(int id) {
        for (int i = 0; i < touchList.Count; i++) {
            if (touchList[i].getTouchId() == id) {
                return touchList[i];
            }
        }

        return null;
    }
}
