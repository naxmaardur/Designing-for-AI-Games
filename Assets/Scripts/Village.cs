using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    List<AIActorData> actors = new();
    List<BuildingSpot> spots = new();
    List<House> houses = new();
    [SerializeField]
    LayerMask mask;
    [SerializeField]
    GameObject buildingSpot;

    public float SearchRange;



    public void AddActor(AIActorData aIActor)
    {
        actors.Add(aIActor);
        if (actors.Count != 0 && houses.Count != 0)
        {
            if ((actors.Count / 2f) > (houses.Count + spots.Count))
            {
                SpawnnewBuildingSpot();
            }
        }
    }


    public void AddBuildingSpot(BuildingSpot buildingSpot)
    {
        spots.Add(buildingSpot);
    }

    public void RemoveBuildingSpot(BuildingSpot buildingSpot)
    {
        spots.Remove(buildingSpot);
    }

    public void AddBuilding(House house)
    {
        houses.Add(house);
        SearchRange += 5;
        UpdateRange();
    }



    private void UpdateRange()
    {
        foreach (AIActorData aIActor in actors)
        {
            aIActor.SearchRange = SearchRange;
        }
    }

    private void SpawnnewBuildingSpot()
    {
        if ((actors.Count / 2f) <= (houses.Count + spots.Count)) { return; }

        Vector3 targetpoint;

        targetpoint = Random.insideUnitCircle * (SearchRange * 0.75f);
        targetpoint.z = targetpoint.y;
        targetpoint.y = 0;
        targetpoint = transform.position + targetpoint;

        Collider[] colliders = Physics.OverlapBox(targetpoint, new Vector3(3.5f, 3.5f, 3.5f), Quaternion.identity, mask);

        if (colliders.Length != 0)
        {
            SpawnnewBuildingSpot();
            return;
        }

        Instantiate(buildingSpot, targetpoint, Quaternion.identity);
    }




    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, SearchRange);
    }

}
