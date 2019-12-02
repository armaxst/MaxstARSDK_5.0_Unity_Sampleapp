/*==============================================================================
Copyright 2017 Maxst, Inc. All Rights Reserved.
==============================================================================*/

using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace maxstAR
{
    /// <summary>
    /// Contains tracked targets informations
    /// </summary>
    public class TrackingResult
    {
        private ulong cPtr;
        private int count;
        private List<Trackable> trackables = new List<Trackable>();

        internal TrackingResult(ulong cPtr)
        {
            this.cPtr = cPtr;
            this.count = NativeAPI.maxst_TrackingResult_getCount(this.cPtr);

            for (int i = 0; i < this.count; i++)
            {
                Trackable trackable = new Trackable(NativeAPI.maxst_TrackingResult_getTrackable(cPtr, i));
                trackables.Add(trackable);
            }
        }

		/// <summary>
		/// Get tracking target count. Current version ar engine could not track multi target.
		/// That feature will be implemented not so far future.
		/// </summary>
		/// <returns>tracking target count</returns>
		public int GetCount()
		{
            return this.count;
        }

		/// <summary>
		/// Get tracking target information
		/// </summary>
		/// <param name="index">target index</param>
		/// <returns>Trackable class instance</returns>
		public Trackable GetTrackable(int index)
		{
            return trackables[index];
		}
    }
}
