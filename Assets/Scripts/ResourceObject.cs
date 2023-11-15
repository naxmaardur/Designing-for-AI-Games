using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceObject : MonoBehaviour
{
    public bool PickedUp;

    protected Transform followPoint;

    public void PickUp(Transform point)
    {
        PickedUp = true;
        followPoint = point;
    }

    public void Drop()
    {
        PickedUp = false;
        followPoint = null;
    }

    public virtual void Use()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (followPoint != null)
        {
            transform.position = followPoint.position;
        }
    }

}