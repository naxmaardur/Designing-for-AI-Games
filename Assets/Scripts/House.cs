using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject sleepSpot;
    private List<AIActorData> aIActors = new();


    public void AddActor(AIActorData actor)
    {
        if (aIActors.Contains(actor)) { return; }
        aIActors.Add(actor);
    }
    public void RemoveActor(AIActorData actor)
    {
        aIActors.Remove(actor);
    }


    public int GetActorsCount()
    {
        return aIActors.Count;
    }




}
