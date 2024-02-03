using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptedDataScript : RegularDataScript
{
    public void destroyObject()
    {
        Destroy(gameObject);
    }
}
