using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIndicator : MonoBehaviour
{
    public GameObject goCanvas;
    public GameObject goTarget;
    RectTransform CanvasRect;
    public RectTransform UI_Element;
    public Camera currentCamera;

    float Scale;
    float Angle;
    float ScreenDiagonalAngle;
    Vector3 ViewportPosition;
    Vector2 WorldObject_ScreenPosition;
    float Axis;

    // Start is called before the first frame update
    void Start()
    {
        Axis = 90.0f;
        CanvasRect = goCanvas.GetComponent<RectTransform>();
        ScreenDiagonalAngle = Axis - (Mathf.Atan2(CanvasRect.sizeDelta.y, CanvasRect.sizeDelta.x) * 180 / Mathf.PI);
    }

    // Update is called once per frame
    void Update()
    {
        ViewportPosition = currentCamera.WorldToViewportPoint(goTarget.transform.position);

        WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));

        if (ViewportPosition.z < 0)
            WorldObject_ScreenPosition *= -1;

        Angle = Mathf.Atan2(WorldObject_ScreenPosition.y, WorldObject_ScreenPosition.x) * 180/Mathf.PI;

        if(Mathf.Abs(Angle) > Mathf.Abs(Axis - ScreenDiagonalAngle) && Mathf.Abs(Angle) < Mathf.Abs(Axis + ScreenDiagonalAngle))
            Scale = Mathf.Abs((CanvasRect.rect.height/ 2.0f) / WorldObject_ScreenPosition.y);
        else
            Scale = Mathf.Abs((CanvasRect.rect.width / 2.0f) / WorldObject_ScreenPosition.x);

        //now you can set the position of the ui element
        UI_Element.anchoredPosition = WorldObject_ScreenPosition * Scale;
        UI_Element.eulerAngles = new Vector3(0, 0, Angle);
    }
}
