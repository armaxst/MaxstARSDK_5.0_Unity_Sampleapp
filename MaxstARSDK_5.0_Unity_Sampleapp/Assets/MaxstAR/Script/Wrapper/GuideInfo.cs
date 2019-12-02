/*==============================================================================
Copyright 2017 Maxst, Inc. All Rights Reserved.
==============================================================================*/

using UnityEngine;
using System.Text;
using System;
using System.Collections.Generic;
using JsonFx.Json;

namespace maxstAR
{
	/// <summary>
	/// Contains surface's data generated from slam tracking
	/// </summary>
    public class GuideInfo
    {
        private const int MAX_VERTICES = 2000;

        private float progress = 0.0f;
        private int keyframeCount = 0;
        private int featureCount = 0;
        private int tagAnchorsLength = 0;
        private static float[] featureBuffer = null;
        private byte[] tagAnchorBuffer = null;
        private TagAnchor[] tagAnchors = new TagAnchor[0];

        public void UpdateGuideInfo()
        {
            ulong GuideInfo_cPtr = NativeAPI.maxst_TrackerManager_getGuideInfo();
            if (GuideInfo_cPtr != 0)
            {
                progress = NativeAPI.maxst_GuideInfo_getInitializingProgress(GuideInfo_cPtr);
                keyframeCount = NativeAPI.maxst_GuideInfo_getKeyframeCount(GuideInfo_cPtr);
                featureCount = NativeAPI.maxst_GuideInfo_getFeatureCount(GuideInfo_cPtr);
                int tempTagAnchorsLength = NativeAPI.maxst_GuideInfo_getTagAnchorsLength(GuideInfo_cPtr);

                if (featureBuffer == null)
                {
                    featureBuffer = new float[MAX_VERTICES * 3];
                }

                if(tempTagAnchorsLength != tagAnchorsLength)
                {
                    tagAnchorsLength = tempTagAnchorsLength;
                    tagAnchorBuffer = new byte[tagAnchorsLength];
                    NativeAPI.maxst_GuideInfo_getTagAnchors(GuideInfo_cPtr, tagAnchorBuffer, tagAnchorsLength);

                    string json = Encoding.UTF8.GetString(tagAnchorBuffer);

                    tagAnchors = JsonHelperForAnchor.FromJson<TagAnchor>(json);
                }

                NativeAPI.maxst_GuideInfo_getFeatureBuffer(GuideInfo_cPtr, featureBuffer, featureCount * 3);

            }
        }

		/// <summary>
		/// Get a percentage of progress during an initialization step of SLAM
		/// </summary>
		/// <returns>Slam initializing progress</returns>
        public float GetInitializingProgress()
        {
            return progress;
        }

		/// <summary>
        /// Get projected feature count in SLAM (float * 3 = 1 feature)
		/// </summary>
		/// <returns>projected feature count for SLAM</returns>
        public int GetFeatureCount()
        {
            return featureCount;
        }

		/// <summary>
        /// Get keyframe count in SLAM
		/// </summary>
		/// <returns>keyframe count for SLAM</returns>
        public int GetKeyframeCount()
        {
            return keyframeCount;
        }

		/// <summary>
		/// Get projected feature buffer for SLAM (Always returns same address so vertex count must be considered)
		/// </summary>
		/// <returns>feature buffer</returns>
        public float[] GetFeatureBuffer()
        {
            return featureBuffer;
        }

        public TagAnchor[] GetTagAnchors()
        {
            return tagAnchors;
        }
    }
}
