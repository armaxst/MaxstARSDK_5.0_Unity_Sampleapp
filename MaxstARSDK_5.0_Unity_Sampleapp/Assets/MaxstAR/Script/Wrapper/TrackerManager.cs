/*==============================================================================
Copyright 2017 Maxst, Inc. All Rights Reserved.
==============================================================================*/

using UnityEngine;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace maxstAR
{
	/// <summary>
	/// Control AR Engine (Singletone)
	/// </summary>
	public class TrackerManager
	{
		/// <summary>
		/// Code scanner
		/// </summary>
		public const int TRACKER_TYPE_CODE_SCANNER = 0X01;

		/// <summary>
		/// Planar image Tracker
		/// </summary>
		public const int TRACKER_TYPE_IMAGE = 0X02;

		/// <summary>
		/// Marker Tracker
		/// </summary>
		public const int TRACKER_TYPE_MARKER = 0X04;

		/// <summary>
		/// Object Tracker(Object data should be created via SLAM tracker)
		/// </summary>
		public const int TRACKER_TYPE_OBJECT = 0X08;

		/// <summary>
		/// Visual slam tracker (Can create surface data and save it)
		/// </summary>
		public const int TRACKER_TYPE_SLAM = 0x10;

		/// <summary>
		/// Instant Tracker
		/// </summary>
		public const int TRACKER_TYPE_INSTANT = 0x20;

        /// <summary>
        /// Cloud Recognizer
        /// </summary>
        public const int TRACKER_TYPE_CLOUD_RECOGNIZER = 0x30;

        public const int TRACKER_TYPE_QR_TRACKER = 0x40;

        public const int TRACKER_TYPE_IMAGE_FUSION = 0x80;

        public const int TRACKER_TYPE_OBJECT_FUSION = 0X100;

        public const int TRACKER_TYPE_QR_FUSION = 0x400;

		public const int TRACKER_TYPE_MARKER_FUSION = 0x800;

		public const int TRACKER_TYPE_INSTANT_FUSION = 0x10000;

		private static TrackerManager instance = null;
        private float[] glPoseMatrix = new float[16];
        private TrackingState trackingState = null;
        private GameObject cloudGameObject;

        private string secretId = null;
        private string secretKey = null;

        /// <summary>
        /// Additional tracking option
        /// 1 : Normal Tracking (Image tracker only)
        /// 2 : Extended Tracking (Image tracker only)
        /// 4 : Multi Target Tracking (Image tracker only)
        /// 8 : Jitter Reduction Activation (Marker, Image and Object)
        /// 16 : Jitter Reduction Deactivation (Marker, Image and Object)
		/// 16 : Cloud Recognition Auto Deactivation (Cloud Recognizer)
		/// 16 : Cloud Recognition Auto Activation (Cloud Recognizer)
        /// </summary>
        public enum TrackingOption
		{
			/// <summary>
			/// Normal Tracking
			/// </summary>
			NORMAL_TRACKING = 1,

			/// <summary>
			/// Extended Tracking
			/// </summary>
			EXTEND_TRACKING = 2,

			/// <summary>
			/// Multiple Target Tracking
			/// </summary>
			MULTI_TRACKING = 4,

			/// <summary>
			/// Jitter Reduction Activation
			/// </summary>
			JITTER_REDUCTION_ACTIVATION = 8,

            /// <summary>
            /// Jitter Reduction Deactivation
			/// </summary>
            JITTER_REDUCTION_DEACTIVATION = 16,

			/// <summary>
			/// Cloud Recognition Auto Deactivation
			/// </summary>
			CLOUD_RECOGNITION_AUTO_DEACTIVATION = 32,

			/// <summary>
			/// Cloud Recognition Auto Activation
			/// </summary>
			CLOUD_RECOGNITION_AUTO_ACTIVATION = 64,

            /// <summary>
            /// Enhanced tracking
            /// </summary>
            ENHANCED_MODE = 128

        }

		//private SurfaceMesh surfaceMesh = null;
		private GuideInfo guideInfo = null;
		private CloudRecognitionController cloudRecognitionController;

		/// <summary>
		/// Get TrackerManager instance
		/// </summary>
		/// <returns></returns>
		public static TrackerManager GetInstance()
		{
			if (instance == null)
			{
				instance = new TrackerManager();

			}

            return instance;
		}

		private TrackerManager()
		{
			
		}

        private void InitializeCloud()
        {
            cloudRecognitionController = CloudRecognitionController.Instance;
        }

        /// <summary>Set secret ID and key for access of cloud recognition.</summary>
        /// <param name="secretId">secret ID</param>
        /// <param name="secretKey">secret key</param>
        public void SetCloudRecognitionSecretIdAndSecretKey(string secretId, string secretKey)
        {
            this.secretId = secretId;
            this.secretKey = secretKey;
        }

		/// <summary>Start Tracker.</summary>
		/// <param name="trackerType">Bit mask of tracker type.</param>
		public void StartTracker(int trackerType)
		{
            if (trackerType == TRACKER_TYPE_CLOUD_RECOGNIZER) {
                if (instance.cloudRecognitionController == null)
                {
                    instance.InitializeCloud();
                }

                cloudRecognitionController.SetCloudRecognitionSecretIdAndSecretKey(this.secretId, this.secretKey);
                cloudRecognitionController.StartTracker();
            } else {
                NativeAPI.maxst_TrackerManager_startTracker(trackerType);
            }
		}

		/// <summary>Stop Tracker.</summary>
		public void StopTracker()
		{
            if(cloudRecognitionController != null) {
                cloudRecognitionController.StopTracker();
            }

            NativeAPI.maxst_TrackerManager_stopTracker();
        }

		/// <summary>Destroy Tracker.</summary>
		public void DestroyTracker()
		{
            if (cloudRecognitionController != null)
            {
                cloudRecognitionController.DestroyTracker();
            }
            NativeAPI.maxst_TrackerManager_destroyTracker();
        }

		/// <summary>Add the Trackable data to the Map List.</summary>
		/// <param name="trackingFileName">File path of map for map addition.</param>
		/// <param name="isAndroidAssetFile">Map file position for addition. True is in Asset folder.</param>
		public void AddTrackerData(string trackingFileName, bool isAndroidAssetFile = false)
		{
            NativeAPI.maxst_TrackerManager_addTrackerData(trackingFileName, isAndroidAssetFile);
        }

		/// <summary>Delete the Trackable data from the Map List.</summary>
		/// <param name="trackingFileName">trackingFileName map file name. 
		/// This name should be same which added. If set "" (empty) file list will be cleared</param>
		public void RemoveTrackerData(string trackingFileName = "")
		{
            NativeAPI.maxst_TrackerManager_removeTrackerData(trackingFileName);
        }

		/// <summary>Load the Trackable data.</summary>
		public void LoadTrackerData()
		{
            NativeAPI.maxst_TrackerManager_loadTrackerData();
        }

		/// <summary>Change Image Tracke Mode.</summary>
		public void SetTrackingOption(TrackingOption trackingOption)
		{
			if (trackingOption == TrackingOption.CLOUD_RECOGNITION_AUTO_DEACTIVATION || trackingOption == TrackingOption.CLOUD_RECOGNITION_AUTO_ACTIVATION) {
				if (trackingOption == TrackingOption.CLOUD_RECOGNITION_AUTO_DEACTIVATION) {
					cloudRecognitionController.SetAutoEnable (false);
				} else {
					cloudRecognitionController.SetAutoEnable (true);
				}
			} else {
				NativeAPI.maxst_TrackerManager_setTrackingOption((int)trackingOption);

				if (trackingOption == TrackingOption.MULTI_TRACKING)
				{
					AbstractARManager.Instance.SetWorldCenterMode(AbstractARManager.WorldCenterMode.CAMERA);
				}
			}
            
		}

		/// <summary>Check that the Trackable data loading is finished.</summary>
		/// <returns>Return map loading status. True is completed.</returns>
		public bool IsTrackerDataLoadCompleted()
		{
            return NativeAPI.maxst_TrackerManager_isTrackerDataLoadCompleted();
        }

        public bool IsFusionSupported()
        {
            return NativeAPI.maxst_TrackerManager_isFusionSupported();
        }

        public void RequestARCoreApk()
        {
#if !UNITY_EDITOR
            AndroidJavaClass javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            if(currentActivity != null) {
                AndroidJavaClass maxstARClass = new AndroidJavaClass("com.maxst.ar.TrackerManager");

                if(maxstARClass != null) {
                    maxstARClass.CallStatic<string>("requestARCoreApk", currentActivity);
                }
            
            }
#endif
        }

        public int GetFusionTrackingState()
        {
            return NativeAPI.maxst_TrackerManager_getFusionTrackingState();
        }

		/// <summary>Set Vocabulary.</summary>
		public void SetVocabulary(string vocFilename, bool isAndroidAssetFile = false)
		{
            NativeAPI.maxst_TrackerManager_setVocabulary(vocFilename, isAndroidAssetFile);
        }

		/// <summary>
		/// Upate tracking state. This function should be called before GetTrackingResult
		/// </summary>
		/// <returns>TrackingState instance</returns>
		public TrackingState UpdateTrackingState()
		{
			ulong trackingStateCPtr = 0;

            trackingStateCPtr = NativeAPI.maxst_TrackerManager_updateTrackingState();

            trackingState = new TrackingState(trackingStateCPtr);
			return trackingState;
		}

		/// <summary>
		/// Get saved TrackingState value
		/// </summary>
		/// <returns>TrackingState instance</returns>
		public TrackingState GetTrackingState()
		{
			return trackingState;
		}

		/// <summary>Gets the x, y, 0 coordinates on the world coordinate corresponding to x, y in the Screen coordinate.</summary>
		/// <param name="screen">Input screen coordinates 2d.</param>
		/// <returns>World coordinates 3d</returns>
		public Vector3 GetWorldPositionFromScreenCoordinate(Vector2 screen)
		{
			float[] s = new float[2];
			float[] w = new float[3];

			s[0] = screen.x;
			s[1] = Screen.height - screen.y;

            NativeAPI.maxst_TrackerManager_getWorldPositionFromScreenCoordinate(s, w);

            Vector3 world = new Vector3(w[0], -w[2], -w[1]);

			return world;
		}          

		/// <summary>Start SLAM learning.</summary>
		public void FindSurface()
		{
            NativeAPI.maxst_TrackerManager_findSurface();
        }

		/// <summary>SLAM stops learning.</summary>
		public void QuitFindingSurface()
		{
            NativeAPI.maxst_TrackerManager_quitFindingSurface();
        }

		/// <summary>
		/// Find Cloud Image (works on Cloud Recognizer)
		/// Must to set CLOUD_RECOGNITION_AUTO_DEACTIVATION at setTrackingOption
		/// Use before startTracker.
		/// </summary>
		public void FindImageOfCloudRecognition() {
			cloudRecognitionController.SetCloudRecognitionSecretIdAndSecretKey(this.secretId, this.secretKey);
			cloudRecognitionController.FindImageOfCloudRecognition();
		}

        /// <summary>
        /// Get guide information of the found surface on SLAM after the FindSurface method has been called
        /// </summary>
        /// <returns>SurfaceMesh instance</returns>
        public GuideInfo GetGuideInfo()
        {
            if (guideInfo == null)
            {
                guideInfo = new GuideInfo();
            }

            guideInfo.UpdateGuideInfo();
            return guideInfo;
        }

		/// <summary>Saves SLAM learning results.</summary>
		/// <param name="outputFileName">File path of map for save.</param>
		/// <returns>Return save result of success or fail. True is saved.</returns>
		public SurfaceThumbnail SaveSurfaceData(string outputFileName)
		{
			SurfaceThumbnail surfaceThumbnail = null;
			ulong SurfaceThumbnail_cPtr = 0;
            SurfaceThumbnail_cPtr = NativeAPI.maxst_TrackerManager_saveSurfaceData(outputFileName);

            if (SurfaceThumbnail_cPtr == 0)
			{
				return null;
			}
			else
			{
				surfaceThumbnail = new SurfaceThumbnail(SurfaceThumbnail_cPtr);
			}

			return surfaceThumbnail;
		}
	}
}