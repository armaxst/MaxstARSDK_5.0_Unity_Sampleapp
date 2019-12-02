/*==============================================================================
Copyright 2017 Maxst, Inc. All Rights Reserved.
==============================================================================*/

using UnityEngine;
using System.Collections;

public class HomeSceneManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnImageTargetClick()
    {
        SceneStackManager.Instance.LoadScene("Home", "ImageTracker");
    }

    public void OnImageFusionTrackerClick()
    {
        SceneStackManager.Instance.LoadScene("Home", "ImageFusionTracker");
    }
}