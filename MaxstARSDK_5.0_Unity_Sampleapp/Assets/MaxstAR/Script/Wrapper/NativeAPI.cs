using System;
using System.Runtime.InteropServices;

namespace maxstAR
{
    internal class NativeAPI
    {
#if UNITY_IOS && !UNITY_EDITOR
        const string MaxstARLibName = "__Internal";
#else
        const string MaxstARLibName = "MaxstAR";
#endif

        #region -- System setting
        [DllImport(MaxstARLibName)]
        public static extern void maxst_init(string licenseKey);
        #endregion

        #region -- MaxstAR setting
        [DllImport(MaxstARLibName)]
        public static extern void maxst_getVersion(byte[] versionBytes, int bytesLength);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_onSurfaceChanged(int surfaceWidth, int surfaceHeight);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_setScreenOrientation(int orientation);
        #endregion

        #region -- Camera device setting
        [DllImport(MaxstARLibName)]
        public static extern int maxst_CameraDevice_start(int cameraId, int preferredWidth, int preferredHeight);

        [DllImport(MaxstARLibName)]
        public static extern int maxst_CameraDevice_stop();

        [DllImport(MaxstARLibName)]
        public static extern bool maxst_CameraDevice_setNewFrame(byte[] data, int length, int width, int height, int format);

        [DllImport(MaxstARLibName)]
        public static extern bool maxst_CameraDevice_setNewFramePtr(ulong data, int length, int width, int height, int format);

        [DllImport(MaxstARLibName)]
        public static extern bool maxst_CameraDevice_setNewFrameAndTimestamp(byte[] data, int length, int width, int height, int format, ulong timestamp);

        [DllImport(MaxstARLibName)]
        public static extern bool maxst_CameraDevice_setNewFramePtrAndTimestamp(ulong data, int length, int width, int height, int format, ulong timestamp);

        [DllImport(MaxstARLibName)]
        public static extern bool maxst_CameraDevice_setFocusMode(int focusMode);

        [DllImport(MaxstARLibName)]
        public static extern bool maxst_CameraDevice_setFlashLightMode(bool toggle);

        [DllImport(MaxstARLibName)]
        public static extern bool maxst_CameraDevice_setAutoWhiteBalanceLock(bool toggle);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_CameraDevice_flipVideo(int direction, bool toggle);

        [DllImport(MaxstARLibName)]
        public static extern bool maxst_CameraDevice_isVideoFlipped(int direction);

        [DllImport(MaxstARLibName)]
        public static extern bool maxst_CameraDevice_setZoom(float value);

        [DllImport(MaxstARLibName)]
        public static extern float maxst_CameraDevice_getMaxZoomValue();

        [DllImport(MaxstARLibName)]
        public static extern int maxst_CameraDevice_getParamList();

        [DllImport(MaxstARLibName)]
        public static extern int maxst_CameraDevice_Param_getKeyLength(int index);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_CameraDevice_Param_getKey(int index, byte[] key);

        [DllImport(MaxstARLibName)]
        public static extern bool maxst_CameraDevice_setBoolTypeParameter(string key, bool boolValue);

        [DllImport(MaxstARLibName)]
        public static extern bool maxst_CameraDevice_setIntTypeParameter(string key, int intValue);

        [DllImport(MaxstARLibName)]
        public static extern bool maxst_CameraDevice_setRangeTypeParameter(string key, int min, int max);

        [DllImport(MaxstARLibName)]
        public static extern bool maxst_CameraDevice_setStringTypeParameter(string key, string stringValue);

        [DllImport(MaxstARLibName)]
        public static extern int maxst_CameraDevice_getWidth();

        [DllImport(MaxstARLibName)]
        public static extern int maxst_CameraDevice_getHeight();

        [DllImport(MaxstARLibName)]
        public static extern void maxst_CameraDevice_getProjectionMatrix(float[] matrix);

        [DllImport(MaxstARLibName)]
        public static extern bool maxst_CameraDevice_checkCameraMove(ulong TrackedImage_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_CameraDevice_getBackgroundPlaneInfo(float[] values);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_CameraDevice_setARCoreTexture();
        #endregion

        #region -- TrackerManager settings
        [DllImport(MaxstARLibName)]
        public static extern void maxst_TrackerManager_startTracker(int trackerMask);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_TrackerManager_stopTracker();

        [DllImport(MaxstARLibName)]
        public static extern void maxst_TrackerManager_destroyTracker();

        [DllImport(MaxstARLibName)]
        public static extern void maxst_TrackerManager_addTrackerData(string trackingFileName, bool isAndroidAssetFile = false);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_TrackerManager_removeTrackerData(string trackingFileName = "");

        [DllImport(MaxstARLibName)]
        public static extern void maxst_TrackerManager_loadTrackerData();

        [DllImport(MaxstARLibName)]
        public static extern void maxst_TrackerManager_setTrackingOption(int option);

        [DllImport(MaxstARLibName)]
        public static extern bool maxst_TrackerManager_isTrackerDataLoadCompleted();

        [DllImport(MaxstARLibName)]
        public static extern bool maxst_TrackerManager_isFusionSupported();

        [DllImport(MaxstARLibName)]
        public static extern int maxst_TrackerManager_getFusionTrackingState();

        [DllImport(MaxstARLibName)]
        public static extern void maxst_TrackerManager_setVocabulary(string vocFilename, bool assetFile);

        [DllImport(MaxstARLibName)]
        public static extern ulong maxst_TrackerManager_updateTrackingState();

        [DllImport(MaxstARLibName)]
        public static extern void maxst_TrackerManager_findSurface();

        [DllImport(MaxstARLibName)]
        public static extern void maxst_TrackerManager_quitFindingSurface();

        [DllImport(MaxstARLibName)]
        public static extern ulong maxst_TrackerManager_getGuideInfo();

        [DllImport(MaxstARLibName)]
        public static extern ulong maxst_TrackerManager_saveSurfaceData(string outputFileName);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_TrackerManager_getWorldPositionFromScreenCoordinate(float[] screen, float[] world);

        [DllImport(MaxstARLibName)]
        public static extern bool maxst_CloudManager_GetFeatureClient(ulong TrackedImage_cPtr, byte[] descriptData, int[] resultLength);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_CloudManager_JWTEncode(string secretKey, string payloadString, byte[] resultData);
        #endregion

        #region -- TrackingResult
        [DllImport(MaxstARLibName)]
        public static extern int maxst_TrackingResult_getCount(ulong TrackingResult_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern ulong maxst_TrackingResult_getTrackable(ulong TrackingResult_cPtr, int index);
        #endregion

        #region -- Trackable
        [DllImport(MaxstARLibName)]
        public static extern void maxst_Trackable_getId(ulong Trackable_cPtr, byte[] id);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_Trackable_getName(ulong Trackable_cPtr, byte[] name);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_Trackable_getCloudName(ulong Trackable_cPtr, byte[] cloudName);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_Trackable_getCloudMeta(ulong Trackable_cPtr, byte[] cloudMeta, int[] length);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_Trackable_getPose(ulong Trackable_cPtr, float[] pose);

        [DllImport(MaxstARLibName)]
        public static extern float maxst_Trackable_getWidth(ulong Trackable_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern float maxst_Trackable_getHeight(ulong Trackable_cPtr);
        #endregion

        #region -- TrackingState
        [DllImport(MaxstARLibName)]
        public static extern ulong maxst_TrackingState_getTrackingResult(ulong TrackingState_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern ulong maxst_TrackingState_getImage(ulong TrackingState_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern int maxst_TrackingState_getCodeScanResultLength(ulong TrackingState_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_TrackingState_getCodeScanResult(ulong TrackingState_cPtr, byte[] result, int length);
        #endregion

        #region -- Guide Info
        [DllImport(MaxstARLibName)]
        public static extern float maxst_GuideInfo_getInitializingProgress(ulong GuideInfo_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern int maxst_GuideInfo_getKeyframeCount(ulong GuideInfo_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern int maxst_GuideInfo_getFeatureCount(ulong GuideInfo_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_GuideInfo_getFeatureBuffer(ulong GuideInfo_cPtr, float[] data, int length);

        [DllImport(MaxstARLibName)]
        public static extern int maxst_GuideInfo_getTagAnchorsLength(ulong GuideInfo_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_GuideInfo_getTagAnchors(ulong GuideInfo_cPtr, byte[] data, int length);
        #endregion

        #region -- SurfaceThumbnail
        [DllImport(MaxstARLibName)]
        public static extern int maxst_SurfaceThumbnail_getWidth(ulong SurfaceThumbnail_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern int maxst_SurfaceThumbnail_getHeight(ulong SurfaceThumbnail_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern int maxst_SurfaceThumbnail_getLength(ulong SurfaceThumbnail_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern int maxst_SurfaceThumbnail_getBpp(ulong SurfaceThumbnail_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern int maxst_SurfaceThumbnail_getData(ulong SurfaceThumbnail_cPtr, byte[] data, int length);
        #endregion

        #region -- SensorDevice
        [DllImport(MaxstARLibName)]
        public static extern void maxst_SensorDevice_startSensor();

        [DllImport(MaxstARLibName)]
        public static extern void maxst_SensorDevice_stopSensor();
        #endregion


        #region -- MapViewer
        [DllImport(MaxstARLibName)]
        public static extern int maxst_MapViewer_initialize(string fileName);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_MapViewer_deInitialize();

        [DllImport(MaxstARLibName)]
        public static extern void maxst_MapViewer_getJson(byte[] jsonData, int length);

        [DllImport(MaxstARLibName)]
        public static extern int maxst_MapViewer_create(int idx);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_MapViewer_getIndices(out int indices);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_MapViewer_getTexCoords(out float texCoords);

        [DllImport(MaxstARLibName)]
        public static extern int maxst_MapViewer_getImageSize(int idx);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_MapViewer_getImage(int idx, out byte image);
        #endregion

        #region -- Wearable Calibration
        [DllImport(MaxstARLibName)]
        public static extern bool maxst_WearableCalibration_isActivated();

        [DllImport(MaxstARLibName)]
        public static extern bool maxst_WearableCalibration_init(string modelName);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_WearableCalibration_deinit();

        [DllImport(MaxstARLibName)]
        public static extern void maxst_WearableCalibration_setSurfaceSize(int width, int height);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_WearableCalibration_getProjectionMatrix(float[] projection, int eyeType);
        #endregion

        #region -- Image Extractor
        [DllImport(MaxstARLibName)]
        public static extern int maxst_TrackedImage_getIndex(ulong Image_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern int maxst_TrackedImage_getWidth(ulong Image_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern int maxst_TrackedImage_getHeight(ulong Image_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern int maxst_TrackedImage_getLength(ulong Image_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern int maxst_TrackedImage_getFormat(ulong Image_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_TrackedImage_getData(ulong Image_cPtr, byte[] buffer, int size);

        [DllImport(MaxstARLibName)]
        public static extern ulong maxst_TrackedImage_getDataPtr(ulong Image_cPtr);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_TrackedImage_getYuv420spY_UVPtr(ulong Image_cPtr, out IntPtr y_Ptr, out IntPtr uv_Ptr);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_TrackedImage_getYuv420spY_U_VPtr(ulong Image_cPtr, out IntPtr y_Ptr, out IntPtr u_Ptr, out IntPtr v_Ptr);

        [DllImport(MaxstARLibName)]
        public static extern void maxst_TrackedImage_getYuv420_888YUVPtr(ulong Image_cPtr, out IntPtr y_Ptr, out IntPtr u_Ptr, out IntPtr v_Ptr, bool supportRG16Texture);
		#endregion

	}
}
