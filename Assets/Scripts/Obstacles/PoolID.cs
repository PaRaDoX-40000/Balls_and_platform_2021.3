using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolID
{
    public int ID;
    public List<GameObject> objects = new List<GameObject>();

    public PoolID(int ID , List<GameObject> objects)
    {
        this.ID = ID;
        this.objects = objects;
    }
}
