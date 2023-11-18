using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : ResourceObject
{
    [SerializeField]
    private float foodValue;
    public override void Use(AIActorData data)
    {
        data.hunger += foodValue;
        base.Use();
    }
}
