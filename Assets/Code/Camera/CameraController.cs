using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public CameraSettings cameraSettings;

    private void Start()
    {
        transform.Rotate(cameraSettings.tiltAngle);
    }
    private void LateUpdate()
    {
        transform.position = target.position + cameraSettings.offset;
    }
}
