using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtiltyFunctions
{
    //returns the current position of the mouse in world space aligned with the ground
    public static Vector3 getPosition(LayerMask layermask)
    {
        Vector3 MousePotion = Input.mousePosition;
        MousePotion.z = 100.0f;
        MousePotion = Camera.main.ScreenToWorldPoint(MousePotion);
        RaycastHit hit;
        Vector3 v3 = new Vector3();
        if (Physics.Raycast(Camera.main.transform.position, Vector3Direction(Camera.main.transform.position, MousePotion), out hit, Mathf.Infinity, layermask))
        {
            v3 = hit.point;
        }
        Debug.DrawRay(Camera.main.transform.position, Vector3Direction(Camera.main.transform.position, MousePotion) * 200, Color.red);
        return v3;
    }
    //returns  the direction between two vectors
    public static Vector3 Vector3Direction(Vector3 from, Vector3 to)
    {
        return (to - from).normalized;
    }
}
