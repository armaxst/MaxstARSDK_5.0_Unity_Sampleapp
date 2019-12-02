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
    internal class MapViewer
    {
        private static MapViewer instance = null;

        internal static MapViewer GetInstance()
        {
            if (instance == null)
            {
                instance = new MapViewer();
            }
            return instance;
        }

        private MapViewer()
        {
        }

        internal int Initialize(string fileName)
        {
            return NativeAPI.maxst_MapViewer_initialize(fileName);
        }

        internal void Deinitialize()
        {
            NativeAPI.maxst_MapViewer_deInitialize();
        }

        internal void GetJson(byte[] jsonData, int length)
        {
            NativeAPI.maxst_MapViewer_getJson(jsonData, length);
        }

        internal int Create(int idx)
        {
            return NativeAPI.maxst_MapViewer_create(idx);
        }

        internal void GetIndices(out int indices)
        {
            NativeAPI.maxst_MapViewer_getIndices(out indices);
        }

        internal void GetTexCoords(out float texCoords)
        {
            NativeAPI.maxst_MapViewer_getTexCoords(out texCoords);
        }

        internal int GetImageSize(int idx)
        {
            return NativeAPI.maxst_MapViewer_getImageSize(idx);
        }

        internal void GetImage(int idx, out byte image)
        {
            NativeAPI.maxst_MapViewer_getImage(idx, out image);
        }
    }
}