using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundCamera : MonoBehaviour
{
    public float pitch;

    public float yaw;

    public float distance;
    
    public Transform lookAt;

    public Transform camera;
    
    void Update()
    {
        Vector3 lRightVector = new Vector3(lookAt.transform.forward.z, 0f, -lookAt.transform.forward.x);
        var lUpVector = Vector3.Cross(lookAt.transform.forward, lRightVector);
        var lAngle = Quaternion.AngleAxis(yaw, lUpVector) * Quaternion.AngleAxis(pitch, lRightVector);
        var lRotation = lAngle * lookAt.transform.forward;
        camera.transform.position = lRotation.normalized * distance;
        camera.transform.LookAt(lookAt);
    }
}
