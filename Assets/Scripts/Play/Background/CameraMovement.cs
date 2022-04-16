using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera cam;
    public Vector3 offset;

    void Update()
    {
        cam.transform.position = new Vector3(this.transform.position.x + offset.x, 0, offset.z);
    }
}
