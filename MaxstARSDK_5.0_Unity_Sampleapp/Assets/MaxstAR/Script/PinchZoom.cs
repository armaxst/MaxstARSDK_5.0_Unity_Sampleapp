using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using maxstAR;

public class PinchZoom : MonoBehaviour
{
    private float CameraZoomSpeed;
    private float CurrentCameraZoom;

    Touch touchZero;
    Touch touchOne;

    Vector2 touchZeroPrevPos;
    Vector2 touchOnePrevPos ;
                            
    float prevTouchDeltaMag ;
    float touchDeltaMag ;

    float deltaMagnitudediff;

    public PinchZoom()
    {
        CameraZoomSpeed = 0.05f;
        CurrentCameraZoom = 0.0f;
    }

    private void Update()
    {
        if (Input.touchCount == 2)
        {
            touchZero = Input.GetTouch(0);
            touchOne = Input.GetTouch(1);

            touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            deltaMagnitudediff = touchDeltaMag - prevTouchDeltaMag;

            CurrentCameraZoom += deltaMagnitudediff * CameraZoomSpeed;

            CurrentCameraZoom = Mathf.Clamp(CurrentCameraZoom, 0.0f, CameraDevice.GetInstance().getMaxZoomValue());

            CameraDevice.GetInstance().SetZoom((int)CurrentCameraZoom);
        }
    }
}
