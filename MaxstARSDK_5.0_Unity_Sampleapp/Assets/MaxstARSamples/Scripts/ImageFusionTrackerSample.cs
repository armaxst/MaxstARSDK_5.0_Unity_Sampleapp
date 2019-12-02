/*==============================================================================
Copyright 2017 Maxst, Inc. All Rights Reserved.
==============================================================================*/

using UnityEngine;
using System.Collections.Generic;

using maxstAR;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ImageFusionTrackerSample : ARBehaviour
{
	private Dictionary<string, ImageTrackableBehaviour> imageTrackablesMap =
		new Dictionary<string, ImageTrackableBehaviour>();

    private CameraBackgroundBehaviour cameraBackgroundBehaviour = null;
    public GameObject goEarth;
    public GameObject goArrow;

    [SerializeField]
    private Text goGuideText;
    [SerializeField]
    private GameObject goGuideVideo;
    [SerializeField]
    private GameObject goResultGuideVideo;

    [SerializeField]
    private GameObject goGuideImage;
    [SerializeField]
    private GameObject goResultGuideImage;

    private bool isGuideResultPlayerEnded = true;

    private enum GuideStep
    {
        Initializing = 0,
        Recognizing,
        ContentAugment
    }

    private GuideStep CurrentStep = GuideStep.Initializing;

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

        if(TrackerManager.GetInstance().IsFusionSupported())
        {
            CameraDevice.GetInstance().SetARCoreTexture();
            TrackerManager.GetInstance().StartTracker(TrackerManager.TRACKER_TYPE_IMAGE_FUSION);
            AddTrackerData();
        }
        else
        {
            TrackerManager.GetInstance().RequestARCoreApk();
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
			else if (trackable.Value.StorageType == StorageType.StreamingAssets)
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
        if (goEarth.GetComponent<VisibleObject>().GetVisible())
        {
            goArrow.SetActive(false);
        }
        else
        {
            if(GuideStep.ContentAugment == CurrentStep)
                goArrow.SetActive(true);
        }

        DisableAllTrackables();

		TrackingState state = TrackerManager.GetInstance().UpdateTrackingState();

        if (state == null)
            return;

        cameraBackgroundBehaviour.UpdateCameraBackgroundImage(state);

        int fusionState = TrackerManager.GetInstance().GetFusionTrackingState();
        if (fusionState == -1)
        {            
            if (GuideStep.Initializing != CurrentStep)
                SetGuidePopup(GuideStep.Initializing);
            return;
        }

        TrackingResult trackingResult = state.GetTrackingResult();

        if(trackingResult.GetCount() == 0)
        {
            if (GuideStep.Recognizing != CurrentStep)
                SetGuidePopup(GuideStep.Recognizing);
        }
        else
        {
            if (GuideStep.ContentAugment != CurrentStep)
                SetGuidePopup(GuideStep.ContentAugment);
        }

        if(goResultGuideImage.activeSelf)
        {
            if (isGuideResultPlayerEnded == false)
                return;
            else
                goResultGuideImage.SetActive(false);
        }

        Debug.Log("EARTH VISIBLE = " + goEarth.GetComponent<VisibleObject>().GetVisible());


        //if (goEarth.GetComponent<VisibleObject>().GetVisible())
        //    goArrow.SetActive(false);
        //else
        //    goArrow.SetActive(true);

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
                TrackerManager.GetInstance().StartTracker(TrackerManager.TRACKER_TYPE_IMAGE_FUSION);
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
		imageTrackablesMap.Clear();
		TrackerManager.GetInstance().SetTrackingOption(TrackerManager.TrackingOption.NORMAL_TRACKING);
		TrackerManager.GetInstance().StopTracker();
		TrackerManager.GetInstance().DestroyTracker();
	}

    private void SetGuidePopup(GuideStep GuideStep)
    {
        switch (GuideStep)
        {
            case GuideStep.Initializing:
                if(!goGuideImage.activeSelf)
                {
                    goResultGuideImage.SetActive(false);
                    goGuideImage.SetActive(true);
                }
                goGuideVideo.GetComponent<VideoPlayer>().clip = Resources.Load<VideoClip>("GuideVideo/mp4/initializing") as VideoClip;
                goGuideText.text = "Aim the phone at the image and slowly move your camera in circle.";                
                CurrentStep = GuideStep.Initializing;
                break;

            case GuideStep.Recognizing:
                if (!goGuideImage.activeSelf)
                {
                    goResultGuideImage.SetActive(false);
                    goGuideImage.SetActive(true);
                }

                goGuideVideo.GetComponent<VideoPlayer>().clip = Resources.Load<VideoClip>("GuideVideo/mp4/image") as VideoClip;
                goGuideText.text = "View an Image";
                CurrentStep = GuideStep.Recognizing;
                break;

            case GuideStep.ContentAugment:
                if (!goResultGuideImage.activeSelf)
                {
                    goGuideImage.SetActive(false);
                    goResultGuideImage.SetActive(true);
                }
                goGuideText.text = "Check out AR Fusion Tracker's extended tracking performance.";
                CurrentStep = GuideStep.ContentAugment;
                break;
        }
    }
}