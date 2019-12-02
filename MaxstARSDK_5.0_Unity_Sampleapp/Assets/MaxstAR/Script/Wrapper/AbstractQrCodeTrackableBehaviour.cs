﻿/*==============================================================================
Copyright 2017 Maxst, Inc. All Rights Reserved.
==============================================================================*/

using UnityEngine;
using System.IO;
using System;
using System.Runtime.InteropServices;
using JsonFx.Json;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using UnityEngine.Rendering;

namespace maxstAR
{
    /// <summary>
    /// Handle tracking file definition in editor and runtime target image visibility
    /// </summary>
    public abstract class AbstractQrCodeTrackableBehaviour : AbstractTrackableBehaviour
    {
        [SerializeField]
        private string textureDir = null;

        [SerializeField]
        private float targetWidth = 0;

        [SerializeField]
        private float targetHeight = 0;

        /// <summary>
        /// Image target real width
        /// </summary>
        public float TargetWidth
        {
            get { return targetWidth; }
        }

        /// <summary>
        /// Image target real height
        /// </summary>
        public float TargetHeight
        {
            get { return targetHeight; }
        }

        void Start()
        {
            Renderer myRenderer = GetComponent<Renderer>();
            myRenderer.enabled = false;
            Destroy(myRenderer);
        }

        /// <summary>
        /// Notify tracking file changed and change target image texture and scale, etc.
        /// </summary>
        /// <param name="trackerFileName"></param>
        protected override void OnTrackerDataFileChanged(string trackerFileName)
        {
            Debug.Log("OnTrackerDataFileChanged : " + trackerFileName);
        }

        private void ChangeObjectProperty(string textureName, float scale)
        {
            Debug.Log("scale : " + scale);

            if (File.Exists(textureName))
            {
                StartCoroutine(MaxstARUtil.LoadImageFromFileWithSizeAndTexture(Application.streamingAssetsPath + "/../../" + textureName, (width, height, texture) =>
                {
                    Texture2D localTexture = texture;
                    if (texture)
                    {
                        MeshFilter imagePlaneMeshFilter = gameObject.GetComponent<MeshFilter>();
                        if (imagePlaneMeshFilter.sharedMesh == null)
                        {
                            imagePlaneMeshFilter.sharedMesh = new Mesh();
                            imagePlaneMeshFilter.sharedMesh.name = "ImagePlane";
                        }

                        float imageW = 1.0f;
                        float imageH = (float)height / (float)width;

                        float vertexWidth = imageW * 0.5f * scale;
                        float vertexHeight = imageH * 0.5f * scale;
                        imagePlaneMeshFilter.sharedMesh.vertices = new Vector3[]
                        {
                            new Vector3(-vertexWidth, 0.0f, -vertexHeight),
                            new Vector3(-vertexWidth, 0.0f, vertexHeight),
                            new Vector3(vertexWidth, 0.0f, -vertexHeight),
                            new Vector3(vertexWidth, 0.0f, vertexHeight)
                        };

                        targetWidth = imageW * scale;
                        targetHeight = imageH * scale;

                        imagePlaneMeshFilter.sharedMesh.triangles = new int[] { 0, 1, 2, 2, 1, 3 };
                        imagePlaneMeshFilter.sharedMesh.uv = new Vector2[]
                        {
                            new Vector2(0, 0),
                            new Vector2(0, 1),
                            new Vector2(1, 0),
                            new Vector2(1, 1),
                        };

                        if (gameObject.GetComponent<MeshRenderer>().sharedMaterial == null)
                        {
                            gameObject.GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Unlit/Texture"));
                        }

                        gameObject.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_MainTex", texture);
                    }
                }));

            }
        }
    }
}
