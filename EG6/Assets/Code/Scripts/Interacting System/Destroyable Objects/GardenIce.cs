using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenIce : DestroyableByPenguin
{
    protected override void Start() 
    {
        base.Start();
        _durability = 24;
    }
}
