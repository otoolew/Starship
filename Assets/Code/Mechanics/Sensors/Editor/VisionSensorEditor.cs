using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(VisionSensor))]
public class VisionSensorEditor : Editor
{
    private void OnSceneGUI()
    {
        VisionSensor visionDector = (VisionSensor)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(visionDector.transform.position, Vector3.up, Vector3.forward, 360, visionDector.ViewRadius);
    }
}
