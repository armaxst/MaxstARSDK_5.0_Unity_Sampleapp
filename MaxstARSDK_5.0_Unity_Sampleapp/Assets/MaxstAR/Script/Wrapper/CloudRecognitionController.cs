using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Threading;
using System.Text;
using JsonFx.Json;

using maxstAR;
namespace maxstAR
{
    class CloudRecognitionController : MaxstSingleton<CloudRecognitionController>
    {

        public enum CloudState
        {
            CLOUDSTATE_CONNECT = 51,
            CLOUDSTATE_CONNECTING = 52,
            CLOUDSTATE_TRACKING = 53,
            CLOUDSTATE_STOP = 54,
            CLOUDSTATE_START = 55,
            CLOUDSTATE_FEATURE_COLLECT_READY = 56,
            CLOUDSTATE_UNKNOWN = 58,
        }

        private string secretId = null;
        private string secretKey = null;
        private CloudState cloudState = CloudState.CLOUDSTATE_STOP;
        private bool loopState = false;
        private bool restart = false;
		private bool autoState = true;

        private byte[] cloudFeatureData = new byte[1024 * 1024];

        private Thread cloudThread;
        private Semaphore cloudSemaphore = new Semaphore(0, 3);
        private string featureBase64 = null;
        private bool isGetFeatureState = false;
        private bool isDestroy = false;

        internal void SetCloudRecognitionSecretIdAndSecretKey(string secretId, string secretKey)
        {
            this.secretId = secretId;
            this.secretKey = secretKey;
        }

        internal CloudState GetCloudStatus()
        {
            return cloudState;
        }

        internal void StartTracker()
        {
			if(!autoState) {
				return;
			}

            if (this.secretId != null && this.secretKey != null)
            {
                if (cloudState == CloudState.CLOUDSTATE_STOP)
                {
                    cloudState = CloudState.CLOUDSTATE_START;
                    cloudThread = new Thread(StartCloud) { Name = "CloudThread" };
                    cloudThread.Start();
                } else {
                    restart = true;
                }
            }
        }

        internal void StopTracker()
        {
			autoState = true;
            this.cloudState = CloudState.CLOUDSTATE_STOP;
        }

        internal void DestroyTracker()
        {
            isDestroy = true;
            CloudRecognitionAPIController.Instance.destroyApi();
            DestroySingleTon();

        }

        public void FindImageOfCloudRecognition() {
			if(autoState) {
				return;
			}

			new Thread (() => {
				TrackingState trackingState = TrackerManager.GetInstance().GetTrackingState();
				TrackingResult trackingResult = trackingState.GetTrackingResult();
				TrackedImage trackedImage = trackingState.GetImage();

				int trackingCount = trackingResult.GetCount();
				if (trackingCount == 0)
				{
					if (cloudState == CloudState.CLOUDSTATE_TRACKING || cloudState == CloudState.CLOUDSTATE_STOP)
					{
						cloudState = CloudState.CLOUDSTATE_FEATURE_COLLECT_READY;
					}
				}
				else
				{
					cloudState = CloudState.CLOUDSTATE_TRACKING;
				}

				if(cloudState != CloudState.CLOUDSTATE_FEATURE_COLLECT_READY) {
					return;
				}

               
                GetCloudRecognition(trackedImage, (bool cloudResult, string featureBase64) =>
					{
                       if (cloudResult)
						{
							this.featureBase64 = featureBase64;
							this.cloudState = CloudState.CLOUDSTATE_CONNECT;
						}
						else
						{
							this.cloudState = CloudState.CLOUDSTATE_FEATURE_COLLECT_READY;
						}

						if (this.restart)
						{
							this.loopState = true;
							this.restart = false;
						}
                    });
			}).Start();
		}

		public void SetAutoEnable(bool enable) {
			autoState = enable;
		}

        private void Update()
        {
            if (cloudState == CloudState.CLOUDSTATE_CONNECT)
            {
                cloudState = CloudState.CLOUDSTATE_CONNECTING;

                CloudRecognitionAPIController.Instance.Recognize(this.secretId, this.secretKey, featureBase64, (recognitionResult) =>
                {
                    if (this.restart == true && recognitionResult == null)
                    {
                        this.cloudState = CloudState.CLOUDSTATE_FEATURE_COLLECT_READY;

                        return;
                    }

                    CloudRecognitionData cloudRecognitionData = null;
                    try
                    {
                        cloudRecognitionData = JsonReader.Deserialize<CloudRecognitionData>(recognitionResult);
                    }
                    catch (Exception ex)
                    {
                        Debug.Log("error");
                        this.cloudState = CloudState.CLOUDSTATE_FEATURE_COLLECT_READY;
                        return;
                    }
                    
                    if (recognitionResult != null && cloudRecognitionData.ImgId != "" && cloudRecognitionData.ImgGSUrl != "")
                    {
                        Debug.Log(recognitionResult);
                        string fileName = Path.GetFileName(cloudRecognitionData.ImgGSUrl);
                        CloudRecognitionAPIController.Instance.DownloadCloudDataAndSave(cloudRecognitionData.ImgGSUrl, fileName, (localPath) =>
                        {
                            if (this.restart == true)
                            {
                                this.cloudState = CloudState.CLOUDSTATE_FEATURE_COLLECT_READY;
                                return;
                            }

                            if (localPath == null)
                            {
                                this.cloudState = CloudState.CLOUDSTATE_FEATURE_COLLECT_READY;
                                return;
                            }

                            TrackingState trackingState = TrackerManager.GetInstance().GetTrackingState();
                            TrackingResult trackingResult = trackingState.GetTrackingResult();
                            if (trackingResult.GetCount() > 0)
                            {
                                cloudState = CloudState.CLOUDSTATE_TRACKING;
                            }
                            else
                            {
                                string mapDirectory = Path.GetDirectoryName(localPath);
                                string mapFilePath = mapDirectory + "/" + Path.GetFileNameWithoutExtension(localPath) + ".2dmap";
                                string imageFilePath = localPath;

                                string customToBase64 = "";
                                if (cloudRecognitionData.Custom != null)
                                {
                                    byte[] customToByteArray = Encoding.UTF8.GetBytes(cloudRecognitionData.Custom);
                                    customToBase64 = Convert.ToBase64String(customToByteArray);
                                }

                                string command = "";
                                if (File.Exists(mapFilePath))
                                {
                                    command = "{\"cloud\":\"add_image\",\"cloud_2dmap_path\":\"" + mapFilePath + "\",\"image_width\":" + cloudRecognitionData.RealWidth + ",\"cloud_name\":\"" + cloudRecognitionData.Name + "\",\"cloud_meta\":\"" + customToBase64 + "\"}";
                                }
                                else
                                {
                                    command = "{\"cloud\":\"add_image\",\"cloud_image_path\":\"" + imageFilePath + "\",\"output_path\":\"" + mapFilePath + "\",\"image_width\":" + cloudRecognitionData.RealWidth + ",\"cloud_name\":\"" + cloudRecognitionData.Name + "\",\"cloud_meta\":\"" + customToBase64 + "\"}";
                                }
                              
                                if (this.restart == true || command == "")
                                {
                                    this.cloudState = CloudState.CLOUDSTATE_FEATURE_COLLECT_READY;
                                    return;
                                }

                                TrackerManager.GetInstance().StartTracker(TrackerManager.TRACKER_TYPE_IMAGE);
                                CloudRecognizerCache.GetInstance().ADD(fileName, command);
                                CloudRecognizerCache.GetInstance().LOAD();

                                cloudState = CloudState.CLOUDSTATE_TRACKING;
                            }
                        });
                    }
                    else
                    {
                        this.cloudState = CloudState.CLOUDSTATE_FEATURE_COLLECT_READY;
                    }

                });
            }
        }

        internal void StartCloud()
        {
			loopState = true;
            this.cloudState = CloudState.CLOUDSTATE_FEATURE_COLLECT_READY;
			while (this.loopState)
            {
                Thread.Sleep(100);

                TrackingState trackingState = TrackerManager.GetInstance().UpdateTrackingState();
                TrackingResult trackingResult = trackingState.GetTrackingResult();
                TrackedImage trackedImage = trackingState.GetImage();

                int trackingCount = trackingResult.GetCount();
                if (trackingCount == 0)
                {
                    if (cloudState == CloudState.CLOUDSTATE_TRACKING)
                    {
                        cloudState = CloudState.CLOUDSTATE_FEATURE_COLLECT_READY;
                    }
                }
                else
                {
                    cloudState = CloudState.CLOUDSTATE_TRACKING;
                }

                if (trackingCount == 0 && (cloudState == CloudState.CLOUDSTATE_TRACKING || cloudState == CloudState.CLOUDSTATE_FEATURE_COLLECT_READY))
                {
                    if (!TrackerManager.GetInstance().IsTrackerDataLoadCompleted() || cloudState == CloudState.CLOUDSTATE_STOP)
                    {
                        continue;
                    }

                    isGetFeatureState = true;
                    bool isCameraMove = CameraDevice.GetInstance().CheckCameraMove(trackedImage);
                    isGetFeatureState = false;
                    if (isCameraMove)
                    {
                        GetCloudRecognition(trackedImage, (bool cloudResult, string featureBase64) =>
                        {
                            if (cloudResult)
                            {

                                this.featureBase64 = featureBase64;
                                this.cloudState = CloudState.CLOUDSTATE_CONNECT;
                            }
                            else
                            {
                                this.cloudState = CloudState.CLOUDSTATE_FEATURE_COLLECT_READY;
                            }

                            if (this.restart)
                            {
                                this.loopState = true;
                                this.restart = false;
                            }
                            cloudSemaphore.Release();
                        });
                        cloudSemaphore.WaitOne();
                    }
                }

                if (this.cloudState == CloudState.CLOUDSTATE_STOP)
                {
					this.loopState = false;
                }
            }
        }

        private bool GetFeatureClient(TrackedImage trackedImage, byte[] descriptData, int[] resultLength)
        {
            return NativeAPI.maxst_CloudManager_GetFeatureClient(trackedImage.GetImageCptr(), descriptData, resultLength);
        }

        private void GetCloudRecognition(TrackedImage trackedImage, System.Action<bool, string> complete)
        {
            if (secretId == null || secretKey == null)
            {
                complete(false, null);
                Debug.LogError("invalid SecretId, SecretKey");
            }
            else
            {
                if(secretId.Length < 10 || secretKey.Length < 10) {
                    complete(false, null);
                    Debug.LogError("invalid SecretId, SecretKey");
                    return;
                }
                int[] resultLength = { 0, 0 };
                bool recognitionResult = false;
                if (TrackerManager.GetInstance().IsTrackerDataLoadCompleted() || cloudState == CloudState.CLOUDSTATE_FEATURE_COLLECT_READY)
                {
                    isGetFeatureState = true;
                    recognitionResult = GetFeatureClient(trackedImage, this.cloudFeatureData, resultLength);
                    isGetFeatureState = false;
                }

                if (isDestroy)
                {
                    DestroySingleTon();
                }

                if (this.restart == true)
                {
                    complete(false, null);
                } else {
                    if (recognitionResult && resultLength[0] > 0)
                    {
                        string sendString = Convert.ToBase64String(this.cloudFeatureData, 0, resultLength[0]);
                        complete(true, sendString);
                    }
                    else
                    {
                        complete(false, null);
                    }
                }
            }
        }
    }
}
