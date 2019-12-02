/*==============================================================================
Copyright 2017 Maxst, Inc. All Rights Reserved.
==============================================================================*/

using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

namespace maxstAR
{
	/// <summary>
	/// Initialize system environment with app key, screen size and orientation
	/// </summary>
	public abstract class AbstractARManager : MonoBehaviour
	{
		private static AbstractARManager instance = null;

		internal static AbstractARManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = FindObjectOfType<AbstractARManager>();
				}

				return instance;
			}
		}

		private int screenWidth = 0;
		private int screenHeight = 0;
		private ScreenOrientation orientation = ScreenOrientation.Unknown;
		private float nearClipPlane = 0.0f;
		private float farClipPlane = 0.0f;
		private Camera arCamera = null;

		/// <summary>
		/// Intialize sdk
		/// </summary>
		protected void Init()
		{
			InitInternal();

			if (Application.platform == RuntimePlatform.Android ||
				Application.platform == RuntimePlatform.IPhonePlayer)
			{
				MaxstAR.SetScreenOrientation((int)Screen.orientation);
			}
			else
			{
				MaxstAR.SetScreenOrientation((int)ScreenOrientation.LandscapeLeft);
			}

			MaxstAR.OnSurfaceChanged(Screen.width, Screen.height);
		}

		/// <summary>
		/// Set device orientation and surface size
		/// </summary>
		void InitInternal()
		{
			// If CameraBackgroundBehaviour is not activated when start application, projection matrix 
			// can not be made because screen width and height isn't set properly yet.
			if (screenWidth != Screen.width || screenHeight != Screen.height)
			{
				screenWidth = Screen.width;
				screenHeight = Screen.height;
				MaxstAR.OnSurfaceChanged(screenWidth, screenHeight);
			}

			if (Application.platform == RuntimePlatform.Android ||
				Application.platform == RuntimePlatform.IPhonePlayer)
			{
				MaxstAR.SetScreenOrientation((int)Screen.orientation);
			}
			else
			{
				MaxstAR.SetScreenOrientation((int)ScreenOrientation.LandscapeLeft);
			}

			arCamera = GetComponent<Camera>();
            
		}

		void Update()
		{
            // If world center is target then tracking pose should be set to main camera's transform
            if (worldCenterMode == WorldCenterMode.TARGET)
			{
                TrackingState trackingState = TrackerManager.GetInstance().UpdateTrackingState();
				TrackingResult trackingResult = trackingState.GetTrackingResult();
				if (trackingResult.GetCount() > 0)
				{
					Trackable trackable = trackingResult.GetTrackable(0);
					Matrix4x4 targetPose = trackable.GetTargetPose().inverse;

					if (targetPose == Matrix4x4.zero)
						return;

					Quaternion rotation = Quaternion.Euler(90, 0, 0);
					Matrix4x4 m = Matrix4x4.TRS(new Vector3(0, 0, 0), rotation, new Vector3(1, 1, 1));
					targetPose = m * targetPose;

					Camera.main.transform.position = MatrixUtils.PositionFromMatrix(targetPose);
					Camera.main.transform.rotation = MatrixUtils.QuaternionFromMatrix(targetPose);
					Camera.main.transform.localScale = MatrixUtils.ScaleFromMatrix(targetPose);
				}
			}
		}

		/// <summary>
		/// Release sdk
		/// </summary>
		protected void Deinit()
		{
		}

		/// <summary>
		/// The world center mode defines what is the center in game view.
		/// If camera is world center then trackable's transform is changed when tracking success.
		/// If traget is world center then main camera's transform is chagned when tracking success.
		/// </summary>
		public enum WorldCenterMode
		{
			/// <summary>
			/// Camera is world center
			/// </summary>
			CAMERA = 0,
			/// <summary>
			/// Target is world center
			/// </summary>
			TARGET = 1
		}

		[SerializeField]
		private WorldCenterMode worldCenterMode;

		/// <summary>
		/// Get world center mode value
		/// </summary>
		public WorldCenterMode WorldCenterModeSetting
		{
			get
			{
				return worldCenterMode;
			}
		}

		public Camera GetARCamera()
		{
			return arCamera;
		}

		/// <summary>
		/// Set world center mode
		/// </summary>
		/// <param name="worldCenterMode">World center enum value</param>
		public void SetWorldCenterMode(WorldCenterMode worldCenterMode)
		{
			this.worldCenterMode = worldCenterMode;
		}

		void OnPreRender()
		{
            if (screenWidth != Screen.width || screenHeight != Screen.height)
			{
				screenWidth = Screen.width;
				screenHeight = Screen.height;
				MaxstAR.OnSurfaceChanged(screenWidth, screenHeight);
            }

            if (orientation != Screen.orientation)
			{
				orientation = Screen.orientation;

				if (Application.platform == RuntimePlatform.Android ||
					Application.platform == RuntimePlatform.IPhonePlayer)
				{
					MaxstAR.SetScreenOrientation((int)orientation);
                }
			}

            if (nearClipPlane != arCamera.nearClipPlane || farClipPlane != arCamera.farClipPlane)
			{
				nearClipPlane = arCamera.nearClipPlane;
				farClipPlane = arCamera.farClipPlane;
			}

            arCamera.projectionMatrix = CameraDevice.GetInstance().GetProjectionMatrix();
        }
	}
}