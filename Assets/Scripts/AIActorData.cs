using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActorData : MonoBehaviour
{
    public Transform holdingPoint;
    public AIActorData selfRef;
    public float health;
    public float hunger;
    public float energy;

    private void Start()
    {
        selfRef = this;
    }

}
