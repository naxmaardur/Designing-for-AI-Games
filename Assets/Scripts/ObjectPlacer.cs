using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField]
    private GameObject preview1;
    [SerializeField]
    private GameObject preview2;

    [SerializeField]
    private GameObject treePrefab;
    [SerializeField]
    private GameObject foodSourcePrefab;


    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private LayerMask GroundMask;

    bool canPlace;

    private void Update()
    {
        transform.position = UtiltyFunctions.getPosition(GroundMask);

        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(0.5f, 0.5f, 0.5f), Quaternion.identity, mask);

        if(colliders.Length > 0)
        {
            canPlace = false;
            preview1.SetActive(false);
            preview2.SetActive(true);
        }
        else
        {
            canPlace = true;
            preview1.SetActive(true);
            preview2.SetActive(false);
        }
        if (!canPlace) { return; }
        if (Input.GetMouseButton(0))
        {
            Instantiate(treePrefab, transform.position, Quaternion.identity);
        }
        if (Input.GetMouseButton(1))
        {
            Instantiate(foodSourcePrefab, transform.position, Quaternion.identity);
        }
    }
}
