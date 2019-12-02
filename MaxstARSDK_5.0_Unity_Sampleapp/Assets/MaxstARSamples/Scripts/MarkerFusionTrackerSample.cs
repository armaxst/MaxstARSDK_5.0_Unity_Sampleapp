/*==============================================================================
Copyright 2017 Maxst, Inc. All Rights Reserved.
==============================================================================*/

using UnityEngine;
using System.Collections.Generic;
using System.Text;

using maxstAR;

public class MarkerFusionTrackerSample : ARBehaviour
{
	private Dictionary<int, MarkerTrackerBehaviour> markerTrackableMap =
		new Dictionary<int, MarkerTrackerBehaviour>();

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

        MarkerTrackerBehaviour[] markerTrackables = FindObjectsOfType<MarkerTrackerBehaviour>();

		foreach (var trackable in markerTrackables)
		{
            trackable.SetMarkerTrackerFileName(trackable.MarkerID, trackable.MarkerSize);
			markerTrackableMap.Add(trackable.MarkerID, trackable);
			Debug.Log("Trackable id: " + trackable.MarkerID);
            Debug.Log(trackable.TrackerDataFileName);
		}

        if(TrackerManager.GetInstance().IsFusionSupported())
        {
            CameraDevice.GetInstance().SetARCoreTexture();
            TrackerManager.GetInstance().StartTracker(TrackerManager.TRACKER_TYPE_MARKER_FUSION);
            AddTrackerData();
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

	private void AddTrackerData()
	{
		foreach (var trackable in markerTrackableMap)
		{
			if (trackable.Value.TrackerDataFileName.Length == 0)
			{
				continue;
			}

			TrackerManager.GetInstance().AddTrackerData(trackable.Value.TrackerDataFileName);
            TrackerManager.GetInstance().AddTrackerData("{\"marker\":\"set_scale\",\"id\":\"0\", \"scale\":0.059}", false);
            TrackerManager.GetInstance().AddTrackerData("{\"marker\":\"set_scale\",\"id\":\"1\", \"scale\":0.059}", false);
        }

		TrackerManager.GetInstance().LoadTrackerData();
	}

	private void DisableAllTrackables()
	{
		foreach (var trackable in markerTrackableMap)
		{
			trackable.Value.OnTrackFail();
		}
	}

	void Update()
	{
		DisableAllTrackables();

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

        string recognizedID = null;
		for (int i = 0; i < trackingResult.GetCount(); i++)
		{
			Trackable trackable = trackingResult.GetTrackable(i);
            int markerId = -1;
            if (int.TryParse(trackable.GetName(), out markerId)) {
                if (markerTrackableMap.ContainsKey(markerId))
                {
                    markerTrackableMap[markerId].OnTrackSuccess(
                        trackable.GetId(), trackable.GetName(), trackable.GetPose());

                    recognizedID += trackable.GetId().ToString() + ", ";
                }
            }
		}

        Debug.Log("Recognized Marker id : " + recognizedID);
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
                TrackerManager.GetInstance().StartTracker(TrackerManager.TRACKER_TYPE_MARKER_FUSION);
                AddTrackerData();
            }
            else
            {
                TrackerManager.GetInstance().RequestARCoreApk();
            }
        }
	}

	void OnDestroy()
	{
		markerTrackableMap.Clear();
		TrackerManager.GetInstance().StopTracker();
		TrackerManager.GetInstance().DestroyTracker();
	}
}
