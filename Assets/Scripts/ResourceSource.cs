using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSource : MonoBehaviour
{
    private AIActorData worker;
    [SerializeField]
    private GameObject resource;
    [SerializeField]
    private int minResource;
    [SerializeField]
    private int maxResource;
    [SerializeField]
    private float spawnRadius;
    public bool TryClaim(AIActorData actor)
    {
        if (IsClaimed())
        {
            return false;
        }

        worker = actor;
        return true;
    }

    public void UnClaim(AIActorData actor)
    {
        if (actor == worker)
        {
            worker = null;
        }
    }

    public bool IsClaimed()
    {
        if (worker == null)
        {
            return false;
        }
        return true;
    }



    public virtual void UseSource()
    {
        int amountToSpawn = Random.Range(minResource, maxResource);
        for (int i = 0; i < amountToSpawn; i++)
        {
            Vector3 randomPoint = Random.insideUnitCircle * spawnRadius;
            randomPoint.z = randomPoint.y;
            randomPoint.y = 0;
            randomPoint += transform.position;
            Instantiate(resource, randomPoint, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
