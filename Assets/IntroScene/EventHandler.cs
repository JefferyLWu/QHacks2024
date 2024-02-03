using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public void Events(int choice, List<GameObject> items)
    {
        if (choice == 1)
        {
            gameObject.GetComponent<TextScript>().StartTalk(items[0], items[1]);
        }

    }
}
