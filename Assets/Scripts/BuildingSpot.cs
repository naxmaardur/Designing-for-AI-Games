using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpot : MonoBehaviour
{
    public int resourcesNeededToBuild;
    public List<Wood> resources = new();
    public bool HasEnoughResources;

    public int BuildProgress;
    private AIActorData worker;

    [SerializeField]
    private GameObject building;

    [SerializeField]
    private Transform[] workLocations;


    private void Start()
    {
        FindObjectOfType<Village>().AddBuildingSpot(this);
    }


    public void AddResource(Wood wood)
    {
        resources.Add(wood);
        wood.Use();
        if(resources.Count >= resourcesNeededToBuild)
        {
            HasEnoughResources = true;
            Debug.Log("HasAllResources");
        }
    }




    public void BuildUpdate()
    {
        BuildProgress++;
        if (resources.Count != 0)
        {
            Wood wood = resources[0];
            resources.RemoveAt(0);
            Destroy(wood.gameObject);
        }
        if(BuildProgress >= resourcesNeededToBuild)
        {
            //spawnBuilding
            Debug.Log("Done Building");
            Instantiate(building, transform.position, transform.rotation);
            FindObjectOfType<Village>().RemoveBuildingSpot(this);
            foreach(Wood wood in resources)
            {
                Destroy(wood);
            }
            Destroy(gameObject);
        }
    }


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
        if(actor == worker)
        {
            worker = null;
        }
    }

    public bool IsClaimed()
    {
        if(worker == null)
        {
            return false;
        }
        return true;
    }

    public Vector3 GetWorkLocation()
    {
        return workLocations[Random.Range(0, workLocations.Length)].position;
    }
}
