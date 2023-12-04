using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject sleepSpot;
    private List<AIActorData> actorsClaimingHouse = new();
    private List<AIActorData> actorsInsideHouse = new();
    [SerializeField]
    private AIActorData actorPrefab;
    [SerializeField]
    private ParticleSystem particleSystem;
    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private LayerMask actorMask;


    private List<AIActorData> preferedActors = new();


    private void Start()
    {
        FindObjectOfType<Village>().AddBuilding(this);

        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(7.417919f, 1, 5.684546f), Quaternion.identity, mask);
        foreach (Collider col in colliders)
        {
            Destroy(col.gameObject);
        }

        Collider[] actors = Physics.OverlapBox(transform.position, new Vector3(7.417919f, 1, 5.684546f), Quaternion.identity, actorMask);
        foreach (Collider col in actors)
        {
            AIActorData aIActor = col.GetComponent<AIActorData>();
            aIActor.Teleport(transform.position + Vector3.up);
        }
    }

    public void AddActor(AIActorData actor)
    {
        if (actorsClaimingHouse.Contains(actor)) { return; }
        if (preferedActors.Contains(actor))
        {
            foreach (AIActorData aIActor in preferedActors)
            {
                    aIActor.energy = 0;
            }
        }
        actorsClaimingHouse.Add(actor);
    }
    public void RemoveActor(AIActorData actor)
    {
        actorsClaimingHouse.Remove(actor);
    }

    public void AddInsideActor(AIActorData actor)
    {
        if (actorsInsideHouse.Contains(actor)) { return; }
        
        if(preferedActors.Count < 2 && !preferedActors.Contains(actor) && actor.preferedHouse == null)
        {
            actor.preferedHouse = this;
            preferedActors.Add(actor);
        }
        actorsInsideHouse.Add(actor);

        if (actorsInsideHouse.Count == 2)
        {
            spawnActor();
        }
        if (actorsInsideHouse.Count == 1)
        {
            if(Random.Range(0,100) < 25)
            {
                spawnActor();
            }
        }
    }
    public void RemoveInsideActor(AIActorData actor)
    {
        actorsInsideHouse.Remove(actor);
    }


    public int GetActorsCount()
    {
        return actorsClaimingHouse.Count;
    }
    public int GetPreferedActorCount()
    {
        return preferedActors.Count;
    }

    private void spawnActor()
    {
        particleSystem.Play();
        Instantiate(actorPrefab, transform.position+Vector3.up, Quaternion.identity);
    }
}
