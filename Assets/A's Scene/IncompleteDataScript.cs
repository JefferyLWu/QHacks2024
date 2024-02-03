using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncompleteDataScript : RegularDataScript
{
    public GameObject newObj;
    public void replaceObject()
    {
        Vector3 pos = gameObject.transform.position;
        Destroy(gameObject);
        GameObject newObject = Instantiate(newObj, pos, Quaternion.identity);
    }
}
