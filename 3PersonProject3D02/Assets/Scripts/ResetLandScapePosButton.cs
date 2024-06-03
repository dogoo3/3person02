using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MoveLandScape))]
public class ResetLandScapePosButton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MoveLandScape generator = (MoveLandScape)target;

        GUI.enabled = Application.isPlaying;
        if(GUILayout.Button("Reset Landscape Position"))
        {
            generator.ResetLandScapePosition();
        }
    }
}
