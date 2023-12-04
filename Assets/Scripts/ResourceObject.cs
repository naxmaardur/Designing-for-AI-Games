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
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    public virtual void Use()
    {
        Destroy(gameObject);
    }
    public virtual void Use(AIActorData data)
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
