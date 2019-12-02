/*==============================================================================
Copyright 2017 Maxst, Inc. All Rights Reserved.
==============================================================================*/

using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using UnityEngine.UI;

using maxstAR;

public class InstantFusionTrackerSample : ARBehaviour
{
	[SerializeField]
	private Text startBtnText = null;

	private Vector3 touchToWorldPosition = Vector3.zero;
	private Vector3 touchSumPosition = Vector3.zero;
	private bool findSurfaceDone = false;

	private InstantTrackableBehaviour instantTrackable = null;
    private CameraBackgroundBehaviour cameraBackgroundBehaviour = null;

    public GameObject guideView;

    void Awake()
    {
		Init();

        AndroidRuntimePermissions.Permission[] result = AndroidRuntimePermissions.RequestPermissions("android.permission.WRITE_EXTERNAL_STORAGE", "android.permission.CAMERA");
        if (result[0] == AndroidRuntimePermissions.Permission.Granted && result[1] == AndroidRuntimePermissions.Permission.Granted)
            Debug.Log("We have all the permissions!");
        else
            Debug.Log("Some permission(s) are not granted...");

        cameraBackgroundBehaviour = FindObjectOfType<CameraBackgroundBehaviour>();
        if (cameraBackgroundBehaviour == null)
        {
            Debug.LogError("Can't find CameraBackgroundBehaviour.");
            return;
        }
    }

    void Start()
	{
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        instantTrackable = FindObjectOfType<InstantTrackableBehaviour>();
		if (instantTrackable == null)
		{
			return;
		}

		instantTrackable.OnTrackFail();

        if (TrackerManager.GetInstance().IsFusionSupported())
        {
            CameraDevice.GetInstance().SetARCoreTexture();
            TrackerManager.GetInstance().StartTracker(TrackerManager.TRACKER_TYPE_INSTANT_FUSION);
        }
        else
        {
            TrackerManager.GetInstance().RequestARCoreApk();
        }

        // For see through smart glass setting
        if (ConfigurationScriptableObject.GetInstance().WearableType == WearableCalibration.WearableType.OpticalSeeThrough)
        {
            WearableManager.GetInstance().GetDeviceController().SetStereoMode(true);

            CameraBackgroundBehaviour cameraBackground = FindObjectOfType<CameraBackgroundBehaviour>();
            cameraBackground.gameObject.SetActive(false);

            WearableManager.GetInstance().GetCalibration().CreateWearableEye(Camera.main.transform);

            // BT-300 screen is splited in half size, but R-7 screen is doubled.
            if (WearableManager.GetInstance().GetDeviceController().IsSideBySideType() == true)
            {
                // Do something here. For example resize gui to fit ratio
            }
        }
    }

	void Update()
	{
		TrackingState state = TrackerManager.GetInstance().UpdateTrackingState();

        if (state == null)
        {
            return;
        }

        cameraBackgroundBehaviour.UpdateCameraBackgroundImage(state);

        int fusionState = TrackerManager.GetInstance().GetFusionTrackingState();
        if (fusionState == -1)
        {
            guideView.SetActive(true);
            return;
        }
        else
        {
            guideView.SetActive(false);
        }

        TrackingResult trackingResult = state.GetTrackingResult();

		if (trackingResult.GetCount() == 0)
		{
			instantTrackable.OnTrackFail();
			return;
		}		

		if (Input.touchCount > 0)
		{
			UpdateTouchDelta(Input.GetTouch(0).position);
		}

        if (instantTrackable == null)
        {
            return;
        }

        Trackable trackable = trackingResult.GetTrackable(0);
        Matrix4x4 poseMatrix = trackable.GetPose() * Matrix4x4.Translate(touchSumPosition);
		instantTrackable.OnTrackSuccess(trackable.GetId(), trackable.GetName(), poseMatrix);
	}

	private void UpdateTouchDelta(Vector2 touchPosition)
	{
		switch (Input.GetTouch(0).phase)
		{
			case TouchPhase.Began:
                touchToWorldPosition = TrackerManager.GetInstance().GetWorldPositionFromScreenCoordinate(touchPosition);
                break;

			case TouchPhase.Moved:
                Vector3 currentWorldPosition = TrackerManager.GetInstance().GetWorldPositionFromScreenCoordinate(touchPosition);
                touchSumPosition += (currentWorldPosition - touchToWorldPosition);
                touchToWorldPosition = currentWorldPosition;
                break;
		}
	}

	void OnApplicationPause(bool pause)
	{
		if (pause)
		{
			TrackerManager.GetInstance().StopTracker();
		}
		else
		{
            if (TrackerManager.GetInstance().IsFusionSupported())
            {
                CameraDevice.GetInstance().SetARCoreTexture();
                TrackerManager.GetInstance().StartTracker(TrackerManager.TRACKER_TYPE_INSTANT_FUSION);
            }
            else
            {
                TrackerManager.GetInstance().RequestARCoreApk();
            }
        }
	}

	void OnDestroy()
	{
		TrackerManager.GetInstance().StopTracker();
		TrackerManager.GetInstance().DestroyTracker();
	}

	public void OnClickStart()
	{
		if (!findSurfaceDone)
		{
			TrackerManager.GetInstance().FindSurface();
			if (startBtnText != null)
			{
				startBtnText.text = "Stop Tracking";
			}
			findSurfaceDone = true;
			touchSumPosition = Vector3.zero;
		}
		else
		{
			TrackerManager.GetInstance().QuitFindingSurface();
			if (startBtnText != null)
			{
				startBtnText.text = "Start Tracking";
			}
			findSurfaceDone = false;
		}
	}
}
