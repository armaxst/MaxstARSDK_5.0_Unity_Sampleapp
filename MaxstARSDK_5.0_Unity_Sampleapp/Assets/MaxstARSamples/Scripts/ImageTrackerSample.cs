/*==============================================================================
Copyright 2017 Maxst, Inc. All Rights Reserved.
==============================================================================*/

using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine.Networking;

using maxstAR;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageTrackerSample : ARBehaviour
{
	private Dictionary<string, ImageTrackableBehaviour> imageTrackablesMap =
		new Dictionary<string, ImageTrackableBehaviour>();

    private CameraBackgroundBehaviour cameraBackgroundBehaviour = null;

    public Text goGuideText;    
    public GameObject goGuideImage;
    public GameObject goGuideVideo;
    public GameObject goResultGuideImage;
    public GameObject goResultGuideVideo;
    private bool isGuideResultPlayerEnded = true;
    private GuideStep CurrentStep = GuideStep.Recognizing;

    private enum GuideStep
    {
        Recognizing = 0,
        ContentAugment
    }

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
        goResultGuideVideo.GetComponent<VideoPlayer>().loopPointReached += CheckOver;

        imageTrackablesMap.Clear();
		ImageTrackableBehaviour[] imageTrackables = FindObjectsOfType<ImageTrackableBehaviour>();
		foreach (var trackable in imageTrackables)
		{
			imageTrackablesMap.Add(trackable.TrackableName, trackable);
			Debug.Log("Trackable add: " + trackable.TrackableName);
		}

		TrackerManager.GetInstance().StartTracker(TrackerManager.TRACKER_TYPE_IMAGE);
		AddTrackerData();
		StartCamera();
        TrackerManager.GetInstance().SetTrackingOption(TrackerManager.TrackingOption.JITTER_REDUCTION_ACTIVATION);

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
		foreach (var trackable in imageTrackablesMap)
		{
			if (trackable.Value.TrackerDataFileName.Length == 0)
			{
				continue;
			}

			if (trackable.Value.StorageType == StorageType.AbsolutePath)
			{
				TrackerManager.GetInstance().AddTrackerData(trackable.Value.TrackerDataFileName);
                TrackerManager.GetInstance().LoadTrackerData();
            }
			else if(trackable.Value.StorageType == StorageType.StreamingAssets)
			{
				if (Application.platform == RuntimePlatform.Android)
				{
                    StartCoroutine(MaxstARUtil.ExtractAssets(trackable.Value.TrackerDataFileName, (filePah) =>
                    {
                        TrackerManager.GetInstance().AddTrackerData(filePah, false);
                        TrackerManager.GetInstance().LoadTrackerData();
                    }));
				}
				else
				{
					TrackerManager.GetInstance().AddTrackerData(Application.streamingAssetsPath + "/" + trackable.Value.TrackerDataFileName);
                    TrackerManager.GetInstance().LoadTrackerData();
                }
			}
		}
	}

	private void DisableAllTrackables()
	{
		foreach (var trackable in imageTrackablesMap)
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
        
        if (trackingResult.GetCount() == 0)
        {
            if (GuideStep.Recognizing != CurrentStep)
                SetGuidePopup(GuideStep.Recognizing);
        }
        else
        {
            if (GuideStep.ContentAugment != CurrentStep)
                SetGuidePopup(GuideStep.ContentAugment);
        }

        if (goResultGuideImage.activeSelf)
        {
            if (isGuideResultPlayerEnded == false)
                return;
            else
                goResultGuideImage.SetActive(false);
        }
               
        for (int i = 0; i < trackingResult.GetCount(); i++)
		{
			Trackable trackable = trackingResult.GetTrackable(i);
			imageTrackablesMap[trackable.GetName()].OnTrackSuccess(
				trackable.GetId(), trackable.GetName(), trackable.GetPose());
		}
	}

    void CheckOver(VideoPlayer vp)
    {
        isGuideResultPlayerEnded = true;
    }

    private void SetGuidePopup(GuideStep GuideStep)
    {
        switch (GuideStep)
        {
            case GuideStep.Recognizing:
                if (!goGuideImage.activeSelf)
                {
                    goResultGuideImage.SetActive(false);
                    goGuideImage.SetActive(true);
                }

                goGuideText.text = "View an Image";
                CurrentStep = GuideStep.Recognizing;
                break;

            case GuideStep.ContentAugment:
                if (!goResultGuideImage.activeSelf)
                {
                    goGuideImage.SetActive(false);
                    goResultGuideImage.SetActive(true);
                }
                goGuideText.text = "Check out AR Tracker's robust tracking performance.";
                CurrentStep = GuideStep.ContentAugment;
                break;
        }
    }

    public void SetNormalMode()
	{
        TrackerManager.GetInstance().SetTrackingOption(TrackerManager.TrackingOption.NORMAL_TRACKING);
	}

	public void SetExtendedMode()
	{
		TrackerManager.GetInstance().SetTrackingOption(TrackerManager.TrackingOption.EXTEND_TRACKING);
	}

	public void SetMultiMode()
	{
		TrackerManager.GetInstance().SetTrackingOption(TrackerManager.TrackingOption.MULTI_TRACKING);
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
			TrackerManager.GetInstance().StartTracker(TrackerManager.TRACKER_TYPE_IMAGE);
		}
	}

	void OnDestroy()
	{
		imageTrackablesMap.Clear();
		TrackerManager.GetInstance().SetTrackingOption(TrackerManager.TrackingOption.NORMAL_TRACKING);
		TrackerManager.GetInstance().StopTracker();
		TrackerManager.GetInstance().DestroyTracker();
		StopCamera();
	}
}