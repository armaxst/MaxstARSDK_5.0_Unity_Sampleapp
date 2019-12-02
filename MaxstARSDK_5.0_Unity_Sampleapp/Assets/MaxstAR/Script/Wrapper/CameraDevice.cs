/*==============================================================================
Copyright 2017 Maxst, Inc. All Rights Reserved.
==============================================================================*/

using UnityEngine;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

#if PLATFORM_ANDROID
#if UNITY_2018_3_OR_NEWER
using UnityEngine.Android;
#endif
#endif

namespace maxstAR
{
    /// <summary>
    /// class for camera device handling
    /// </summary>
    public class CameraDevice
    {
        /// <summary>
        /// Camera focus mode
        /// </summary>
        public enum FocusMode
        {
            /// <summary>
            /// Continuous focus mode. This focus mode is proper for AR
            /// </summary>
            FOCUS_MODE_CONTINUOUS_AUTO = 1,
            /// <summary>
            /// Single auto focus mode
            /// </summary>
            FOCUS_MODE_AUTO = 2
        }

        /// <summary>
        /// Supported camera type (Mobile only)
        /// </summary>
        public enum CameraType
        {
            /// <summary>
            /// Rear camera
            /// </summary>
            Rear = 0,

            /// <summary>
            /// Face camera
            /// </summary>
            Face = 1,
        }

        /// <summary>
        /// Supported camera resolution
        /// </summary>
        public enum CameraResolution
        {
            /// <summary>
            /// 640 * 480 (4:3 Resolution)
            /// </summary>
            Resolution640x480,

            /// <summary>
            /// 1280 * 720 (16:9 Resolution)
            /// </summary>
            Resolution1280x720,

            /// <summary>
            /// 1920 * 1080 (16:9 Resolution)
            /// </summary>
            Resolution1920x1080,
        }

        /// <summary>
        /// Flip video
        /// </summary>
        public enum FlipDirection
        {
            /// <summary>
            /// Horizontal flip
            /// </summary>
            HORIZONTAL = 0,

            /// <summary>
            /// Vertical flip
            /// </summary>
            VERTICAL = 1
        }

        private static CameraDevice instance = null;

        /// <summary>
        /// Get a CameraDevice instance.
        /// </summary>
        /// <returns>Return the CameraDevice instance</returns>
        public static CameraDevice GetInstance()
        {
            if (instance == null)
            {
                instance = new CameraDevice();
            }
            return instance;
        }

        private int cameraId = 0;
        private int preferredWidth = 0;
        private int preferredHeight = 0;

        private CameraDevice()
        {
        }

        /// <summary>
        /// Start camera preview
        /// </summary>
        public ResultCode Start()
        {
#if PLATFORM_ANDROID
#if UNITY_2018_3_OR_NEWER
            if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                Permission.RequestUserPermission(Permission.Camera);
             }
#endif
#endif
            int cameraType = 0;
            if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor)
            {
                cameraType = AbstractConfigurationScriptableObject.GetInstance().WebcamType;
            }
            else
            {
                cameraType = (int)AbstractConfigurationScriptableObject.GetInstance().CameraType;
            }

            CameraDevice.CameraResolution cameraResolution = AbstractConfigurationScriptableObject.GetInstance().CameraResolution;
            switch (cameraResolution)
            {
                case CameraDevice.CameraResolution.Resolution640x480:
                    preferredWidth = 640;
                    preferredHeight = 480;
                    break;

                case CameraDevice.CameraResolution.Resolution1280x720:
                    preferredWidth = 1280;
                    preferredHeight = 720;
                    break;

                case CameraDevice.CameraResolution.Resolution1920x1080:
                    preferredWidth = 1920;
                    preferredHeight = 1080;
                    break;

                default:
                    preferredWidth = 640;
                    preferredHeight = 480;
                    break;
            }

            Debug.Log("Camera id : " + cameraId);

            return (ResultCode)NativeAPI.maxst_CameraDevice_start(cameraType, preferredWidth, preferredHeight);
        }

        /// <summary>
        /// Set external camera image to AR engine.(Free, Enterprise license key can activate this interface. Mobile only supported)
        /// </summary>
        /// <param name="data">Byte array of camera image</param>
        /// <param name="length">Lenght of data buffer</param>
        /// <param name="width">Width of camera image</param>
        /// <param name="height">Height of camera image</param>
        /// <param name="format">Color format</param>
        /// <returns>True success</returns>
        public bool SetNewFrame(byte[] data, int length, int width, int height, ColorFormat format)
        {
            return NativeAPI.maxst_CameraDevice_setNewFrame(data, length, width, height, (int)format);
        }

        /// <summary>
        /// Set external camera image to AR engine.(Free, Enterprise license key can activate this interface. Mobile only supported)
        /// </summary>
        /// <param name="data">Native address of camera image</param>
        /// <param name="length">Lenght of data buffer</param>
        /// <param name="width">Width of camera image</param>
        /// <param name="height">Height of camera image</param>
        /// <param name="format">Color format</param>
        /// <returns>True success</returns>
        public bool SetNewFrame(ulong data, int length, int width, int height, ColorFormat format)
        {
            return NativeAPI.maxst_CameraDevice_setNewFramePtr(data, length, width, height, (int)format);
        }

		/// <summary>
		/// Set external camera image and timestamp to AR engine.(Free, Enterprise license key can activate this interface. Mobile only supported)
		/// </summary>
		/// <param name="data">Byte array of camera image</param>
		/// <param name="length">Lenght of data buffer</param>
		/// <param name="width">Width of camera image</param>
		/// <param name="height">Height of camera image</param>
		/// <param name="format">Color format</param>
		/// <param name="timestamp">Timestamp</param>
		/// <returns>True success</returns>
		public bool SetNewFrameAndTimestamp(byte[] data, int length, int width, int height, ColorFormat format, ulong timestamp)
		{
            return NativeAPI.maxst_CameraDevice_setNewFrameAndTimestamp(data, length, width, height, (int)format, timestamp);
        }

		/// <summary>
		/// Set external camera image and timestamp to AR engine.(Free, Enterprise license key can activate this interface. Mobile only supported)
		/// </summary>
		/// <param name="data">Native address of camera image</param>
		/// <param name="length">Lenght of data buffer</param>
		/// <param name="width">Width of camera image</param>
		/// <param name="height">Height of camera image</param>
		/// <param name="format">Color format</param>
		/// <param name="timestamp">Timestamp</param>
		/// <returns>True success</returns>
		public bool SetNewFrameAndTimestamp(ulong data, int length, int width, int height, ColorFormat format, ulong timestamp)
		{
            return NativeAPI.maxst_CameraDevice_setNewFramePtrAndTimestamp(data, length, width, height, (int)format, timestamp);
        }

        /// <summary>
        /// Set camera focus mode
        /// </summary>
        /// <param name="focusMode"></param>
        /// <returns></returns>
        public bool SetFocusMode(FocusMode focusMode)
        {
            return NativeAPI.maxst_CameraDevice_setFocusMode((int)focusMode);
        }

		/// <summary>
        /// Turn on/off flash light
        /// </summary>
		public bool SetFlashLightMode(bool toggle)
		{
            return NativeAPI.maxst_CameraDevice_setFlashLightMode(toggle);
        }

		/// <summary>
		/// Toggle auto white balance lock (Android only supported now)
		/// </summary>
		public bool SetAutoWhiteBalanceLock(bool toggle)
		{
            return NativeAPI.maxst_CameraDevice_setAutoWhiteBalanceLock(toggle);
        }

		/// <summary>
		/// Flip video background 
		/// </summary>
		/// <param name="direction">Flip direction</param>
		/// <param name="on">True to set. False to rest</param>
		public void FlipVideo(FlipDirection direction, bool on)
		{
            NativeAPI.maxst_CameraDevice_flipVideo((int)direction, on);
		}

        public bool IsVideoFlipped(FlipDirection direction)
        {
            return NativeAPI.maxst_CameraDevice_isVideoFlipped((int)direction);
        }

        /// <summary>
        /// Set Camera Zoom Scale
        /// </summary>
        /// <param name="zoomValue">zoomScale Zoom value</param>
        /// <returns>result Zoom.</returns>
        public bool SetZoom(float zoomValue)
        { 
            return NativeAPI.maxst_CameraDevice_setZoom(zoomValue);
        }

        /// <summary>
        /// Get Camera Device Max Zoom value.
        /// </summary>
        /// <returns>Max Zoom value.</returns>
        public float getMaxZoomValue()
        {
            return NativeAPI.maxst_CameraDevice_getMaxZoomValue();
        }

        /// <summary>
        /// Get parameter key list  (Android only supported now)
        /// </summary>
        /// <returns>parameter key list</returns>
        public List<string> GetParamList()
		{
			List<string> paramList = new List<string>();
            int size = NativeAPI.maxst_CameraDevice_getParamList();
            for (int i = 0; i < size; i++)
            {
                int keyLength = NativeAPI.maxst_CameraDevice_Param_getKeyLength(i);
                byte[] keyBytes = new byte[keyLength];
                NativeAPI.maxst_CameraDevice_Param_getKey(i, keyBytes);
                string keyString = Encoding.UTF8.GetString(keyBytes).TrimEnd('\0');
                paramList.Add(keyString);
            }

            return paramList;
		}


		/// <summary>
		/// Set camera parameter (Android only supported now)
		/// </summary>
		/// <param name="key">Parameter key</param>
		/// <param name="boolTypeValue">Parameter value</param>
		/// <returns> True if setting success</returns>
		public bool SetParam(string key, bool boolTypeValue)
		{
            return NativeAPI.maxst_CameraDevice_setBoolTypeParameter(key, boolTypeValue);
        }

		/// <summary>
		/// Set camera parameter (Android only supported now)
		/// </summary>
		/// <param name="key">Parameter key</param>
		/// <param name="intTypeValue">Parameter value</param>
		/// <returns> True success</returns>
		public bool SetParam(string key, int intTypeValue)
		{
            return NativeAPI.maxst_CameraDevice_setIntTypeParameter(key, intTypeValue);
        }

		/// <summary>
		/// Set camera parameter (Android only supported now)
		/// </summary>
		/// <param name="key">Parameter key</param>
		/// <param name="min">min value</param>
		/// <param name="max">min value</param>
		/// <returns> True success</returns>
		public bool SetParam(string key, int min, int max)
		{
            return NativeAPI.maxst_CameraDevice_setRangeTypeParameter(key, min, max);
        }

		/// <summary>
		/// Set camera parameter (Android only supported now)
		/// </summary>
		/// <param name="key">Parameter key</param>
		/// <param name="stringTypeValue">Parameter value</param>
		/// <returns> True if setting success</returns>
		public bool SetParam(string key, string stringTypeValue)
		{
            return NativeAPI.maxst_CameraDevice_setStringTypeParameter(key, stringTypeValue);
        }

        /// <summary>
        /// Stop camera preview
        /// </summary>
		public ResultCode Stop()
        {
            return (ResultCode)NativeAPI.maxst_CameraDevice_stop();
        }

        /// <summary>
        /// </summary>
        /// <returns>get camera preview width</returns>
        public int GetWidth()
        {
            return NativeAPI.maxst_CameraDevice_getWidth();
        }

        /// <summary>
        /// </summary>
        /// <returns>get camera preview height</returns>
        public int GetHeight()
        {
            return NativeAPI.maxst_CameraDevice_getHeight();
        }

		/// <summary>
		/// Get projection matrix
		/// </summary>
		/// <returns>Matrix4x4 projection matrix</returns>
		public Matrix4x4 GetProjectionMatrix()
		{
			float[] glProjection = new float[16];
    
            NativeAPI.maxst_CameraDevice_getProjectionMatrix(glProjection);

            return MatrixUtils.ConvertGLProjectionToUnityProjection(glProjection);
		}

        /// <summary>
        /// Get background plane info
        /// </summary>
        /// <returns>float[5] background plane info</returns>
        public float[] GetBackgroundPlaneInfo()
        {
            float[] values = new float[5];
            NativeAPI.maxst_CameraDevice_getBackgroundPlaneInfo(values);
            return values;
        }

        /// <summary>
        /// Get flip state
        /// </summary>
        /// <returns>Horizontal flip</returns>
        public bool IsFlipHorizontal()
		{
			return NativeAPI.maxst_CameraDevice_isVideoFlipped((int)CameraDevice.FlipDirection.HORIZONTAL);
		}

		/// <summary>
		/// Get flip state
		/// </summary>
		/// <returns>Vertical flip</returns>
		public bool IsFlipVertical()
		{
            return NativeAPI.maxst_CameraDevice_isVideoFlipped((int)CameraDevice.FlipDirection.VERTICAL);
        }

        public bool CheckCameraMove(TrackedImage image)
        {
            return NativeAPI.maxst_CameraDevice_checkCameraMove(image.GetImageCptr());
        }

        public void SetARCoreTexture()
        {
            NativeAPI.maxst_CameraDevice_setARCoreTexture();
        }
    }
}