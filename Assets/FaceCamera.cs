using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(cam);
    }



}
