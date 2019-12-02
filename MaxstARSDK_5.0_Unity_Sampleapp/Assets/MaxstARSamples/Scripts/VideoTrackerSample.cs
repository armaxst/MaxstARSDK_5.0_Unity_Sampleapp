/*==============================================================================
Copyright 2019 Maxst, Inc. All Rights Reserved.
==============================================================================*/

using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.Video;

using maxstAR;

public class VideoTrackerSample : ARBehaviour
{
    private Dictionary<string, ImageTrackableBehaviour> imageTrackablesMap =
        new Dictionary<string, ImageTrackableBehaviour>();

    private CameraBackgroundBehaviour cameraBackgroundBehaviour = null;

    private VideoPlayer videoPlayer;
    public bool CameraMode = true;

    void Awake()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
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

        imageTrackablesMap.Clear();
        ImageTrackableBehaviour[] imageTrackables = FindObjectsOfType<ImageTrackableBehaviour>();
        foreach (var trackable in imageTrackables)
        {
            imageTrackablesMap.Add(trackable.TrackableName, trackable);
            Debug.Log("Trackable add: " + trackable.TrackableName);
        }

        AddTrackerData();
        TrackerManager.GetInstance().StartTracker(TrackerManager.TRACKER_TYPE_IMAGE);

   
        videoPlayer.playOnAwake = false;
        videoPlayer.isLooping = true;
        videoPlayer.sendFrameReadyEvents = true;
        videoPlayer.frameReady += OnNewFrame;

        if (Application.platform == RuntimePlatform.Android)
        {
            StartCoroutine(MaxstARUtil.ExtractAssets("MaxstAR/tracking_video.mp4", (filePah) =>
            {
                videoPlayer.url = filePah;
                SwitchCameraToVideo(CameraMode);
            }));
        }
        else
        {
            videoPlayer.url = Application.streamingAssetsPath + "/MaxstAR/tracking_video.mp4";
            SwitchCameraToVideo(CameraMode);
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


    private Texture2D texture2D = null;

    void OnNewFrame(VideoPlayer source, long frameIdx)
    {
        RenderTexture renderTexture = source.texture as RenderTexture;

        if (texture2D == null)
        {
            texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);
        }

        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();
        RenderTexture.active = null;


        CameraDevice.GetInstance().SetNewFrame(texture2D.GetRawTextureData(), texture2D.GetRawTextureData().Length, texture2D.width, texture2D.height, ColorFormat.RGBA8888);
    }

    public void SwitchCameraToVideo(bool isCamera)
    {
        if (isCamera)
        {
            StartCamera();
        }
        else
        {
            videoPlayer.Play();
        }
    }

    public void PauseAndPlayVideo()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
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

        for (int i = 0; i < trackingResult.GetCount(); i++)
        {
            Trackable trackable = trackingResult.GetTrackable(i);
            imageTrackablesMap[trackable.GetName()].OnTrackSuccess(
                trackable.GetId(), trackable.GetName(), trackable.GetPose());
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
            videoPlayer.Pause();

        }
        else
        {
            if (CameraMode)
            {
                StartCamera();
            }
            else
            {
                videoPlayer.Play();
            }
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