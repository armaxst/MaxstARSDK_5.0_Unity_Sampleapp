using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using JsonFx.Json;
using System.Text;
using maxstAR;

namespace maxstAR {
    public class CloudRecognitionAPIController : MaxstSingleton<CloudRecognitionAPIController> {
        string cloudURL = "https://developer.maxst.com";

        public void Recognize(string secretId, string secretKey, string featureBase64, System.Action<string> completed) {
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var now = Math.Round((DateTime.UtcNow - unixEpoch).TotalSeconds);
            var payload = new Dictionary<string, object>()
            {
                { "iat", now },
                { "secId", secretId }
            };

            string payloadJsonString = JsonWriter.Serialize(payload);

            string jwt = JWTEncode(secretKey, payloadJsonString);
            string token = "Token " + jwt;

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization", token},
                { "Content-Type", "application/json"}
            };

            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "RecogArrayStr", featureBase64},
                { "ReqV", "4.0.x"}
            };

            StartCoroutine(APIController.POST(cloudURL + "/api/Recognize", headers, parameters, 10, (resultString) => 
            {
                completed(resultString);
            }));
        }

        public void DownloadCloudDataAndSave(string url, string fileNameWithExtension, System.Action<string> completed) {
            string applicationRootFolderPath = "";
    #if UNITY_EDITOR
            applicationRootFolderPath = Application.dataPath + "/../data/";

            if (!File.Exists(applicationRootFolderPath))
            {
                if (!Directory.Exists(applicationRootFolderPath))
                {
                    Directory.CreateDirectory(applicationRootFolderPath);
                }
            }
    #elif UNITY_IOS 
            applicationRootFolderPath = Application.persistentDataPath;
    #else
            applicationRootFolderPath = Application.persistentDataPath;
    #endif
            string savePath = applicationRootFolderPath + "/" + fileNameWithExtension;
            StartCoroutine(APIController.DownloadFile(url, savePath, (string localPath) =>
            {
                completed(localPath);
            }));
        }

        private byte[] jwtData = new byte[1024 * 1024];
        private string JWTEncode(string secretKey, string payloadJsonString)
        {
            int[] resultLength = { 0, 0 };
            Array.Clear(jwtData, 0, jwtData.Length);
            NativeAPI.maxst_CloudManager_JWTEncode(secretKey, payloadJsonString, jwtData);

            return Encoding.UTF8.GetString(jwtData).TrimEnd('\0');
        }

        public void destroyApi()
        {
            DestroySingleTon();
        }
    }
}
