/*==============================================================================
Copyright 2017 Maxst, Inc. All Rights Reserved.
==============================================================================*/

using UnityEngine;
using System.Collections.Generic;
using System.Text;

using maxstAR;

public class MarkerTrackerSample : ARBehaviour
{
	private Dictionary<int, MarkerTrackerBehaviour> markerTrackableMap =
		new Dictionary<int, MarkerTrackerBehaviour>();

    private CameraBackgroundBehaviour cameraBackgroundBehaviour = null;

    void Awake()
    {
		Init();

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
		AddTrackerData();
		StartCamera();
		TrackerManager.GetInstance().StartTracker(TrackerManager.TRACKER_TYPE_MARKER);

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

    public void OnClickedNormal()
    {
        TrackerManager.GetInstance().SetTrackingOption(TrackerManager.TrackingOption.NORMAL_TRACKING);
    }

    public void OnClickedEnhanced()
    {
        TrackerManager.GetInstance().SetTrackingOption(TrackerManager.TrackingOption.ENHANCED_MODE);
    }

    void OnApplicationPause(bool pause)
	{
		if (pause)
		{
			TrackerManager.GetInstance().StopTracker();
			StopCamera();
		}
		else
		{
			StartCamera();
			TrackerManager.GetInstance().StartTracker(TrackerManager.TRACKER_TYPE_MARKER);			
		}
	}

	void OnDestroy()
	{
		markerTrackableMap.Clear();
		TrackerManager.GetInstance().StopTracker();
		TrackerManager.GetInstance().DestroyTracker();
		StopCamera();
	}
}
