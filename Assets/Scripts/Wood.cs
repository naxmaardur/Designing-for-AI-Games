using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : ResourceObject
{
    public override void Use()
    {
        followPoint = null;
    }
}
