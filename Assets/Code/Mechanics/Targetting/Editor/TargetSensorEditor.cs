using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(TargetSensor))]
public class TargetSensorEditor : Editor
{
    private void OnSceneGUI()
    {
        TargetSensor targetDector = (TargetSensor)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(targetDector.transform.position, Vector3.up, Vector3.forward, 360, targetDector.SensorRange);
    }
}
