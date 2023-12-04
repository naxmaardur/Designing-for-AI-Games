using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CMFreelookOnlyWhenRightMouseDown : MonoBehaviour
{
    void Start()
    {
        CinemachineCore.GetInputAxis = GetAxisCustom;
    }
    public float GetAxisCustom(string axisName)
    {
        if (axisName == "Mouse X")
        {
            if (Input.GetMouseButton(2))
            {
                return UnityEngine.Input.GetAxis("Mouse X");
            }
            else
            {
                return 0;
            }
        }
        else if (axisName == "Mouse Y")
        {
            return Input.mouseScrollDelta.y;
        }
        return UnityEngine.Input.GetAxis(axisName);
    }
}
