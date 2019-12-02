/*==============================================================================
Copyright 2017 Maxst, Inc. All Rights Reserved.
==============================================================================*/

using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace maxstAR
{
	[CustomEditor(typeof(QrCodeTrackableBehaviour))]
	public class QrCodeTrackableEditor : Editor
	{
        private QrCodeTrackableBehaviour qrCodeTrackableBehaviour;

		public void OnEnable()
		{
			if (PrefabUtility.GetPrefabType(target) == PrefabType.Prefab)
			{
				return;
			}
		}

		public override void OnInspectorGUI()
		{
            bool isDirty = false;

            qrCodeTrackableBehaviour = (QrCodeTrackableBehaviour)target;

            EditorGUILayout.Separator();

            string oldSearchingWords = qrCodeTrackableBehaviour.QrCodeSearchingWords;
            string newSearchingWords = EditorGUILayout.TextField("QR-Code Searching words : ", qrCodeTrackableBehaviour.QrCodeSearchingWords);

            if (oldSearchingWords != newSearchingWords)
            {
                qrCodeTrackableBehaviour.QrCodeSearchingWords = newSearchingWords;
                isDirty = true;
            }

			if (GUI.changed && isDirty)
			{
                EditorUtility.SetDirty(qrCodeTrackableBehaviour);
				EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
				SceneManager.Instance.SceneUpdated();
			}
		}
	}
}