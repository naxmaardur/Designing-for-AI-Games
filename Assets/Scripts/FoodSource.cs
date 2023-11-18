using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSource : ResourceSource
{
    public override void UseSource()
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
    }
}
