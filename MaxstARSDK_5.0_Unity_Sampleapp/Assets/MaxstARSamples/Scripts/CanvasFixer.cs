using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CanvasFixer : MonoBehaviour {

    float SCALE = 0.0f;
    float DEVICE_FIX = 2.6f;

    void Start()
    {
        CanvasScaler canvasScaler = GetComponent<CanvasScaler>();
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
#if UNITY_EDITOR
		DEVICE_FIX = 1.72f;
#elif UNITY_IOS
        DEVICE_FIX = 1.41f;
        if(UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhoneXR) {
            DEVICE_FIX = 1.5f;
        }
#elif UNITY_ANDROID
        DEVICE_FIX = 1.6f;
#endif

        FixCanvasScaleFactor();
	}
#if UNITY_EDITOR

    void Update()
    {
		CanvasScaler canvasScaler = GetComponent<CanvasScaler>();
		canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
        FixCanvasScaleFactor();
    }
#endif
    private void FixCanvasScaleFactor () {

        // Get scale needed to maintain physical size

        float physicalScale = (96.0f / 72.0f) * (Screen.dpi / 96.0f);
        // Get real screen width (physical width, not screen resolution)
        //float screenDimensionsWidth = (2.54f * Screen.width / Screen.dpi);
        // If screen is really small (less than 11cm, such a smartphone), then apply a lower scale, otherwise maintain physical size regardless of screen size/resolution:
        float screenDimensionsWidth = (2.54f * Screen.width / Screen.dpi);

        SCALE = physicalScale * 0.66f;
    
        CanvasScaler cs = GetComponent<CanvasScaler> ();
        if (cs.scaleFactor != SCALE) {
            cs.scaleFactor = (float)(SCALE / DEVICE_FIX);
        }

    }
}
