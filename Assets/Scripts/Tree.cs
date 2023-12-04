using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : ResourceSource
{

    float health = 4;

    private void Start()
    {
        health = Random.Range(2, 6);
    }


    public override void UseSource()
    {
        health--;
        if (health <= 0)
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
}
