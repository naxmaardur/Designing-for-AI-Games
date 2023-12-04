using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickRandomMesh : MonoBehaviour
{
    private void Start()
    {
        int i = 0;
        int target = Random.Range(0, transform.childCount);
        foreach (Transform child in transform)
        {
            if(i == target)
            {
                i++;
                child.gameObject.SetActive(true);
                continue;
            }

            i++;
            child.gameObject.SetActive(false);
        }
    }
}
