using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActorData : MonoBehaviour
{
    public Transform holdingPoint;
    public AIActorData selfRef;

    private void Start()
    {
        selfRef = this;
    }

}
