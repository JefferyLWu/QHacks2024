using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInteractDataScript : MonoBehaviour
{
    public GameObject[] interactTexts = new GameObject[2];
    public GameObject interactingObject = null;
    public GameObject eventSystem;
    private bool[] canInteract = new bool[2];


    // Start is called before the first frame update
    void Start()
    {
        interactTexts[0].SetActive(false);
        interactTexts[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && canInteract[0] == true)
        {
            canInteract[0] = false;
            // eventSystem.GetComponent<EventHandler>().Events(interactingObject.GetComponent<ObjectInteract>().eventType, new List<GameObject> { this.gameObject, interactingObject });
            try
            {
                interactingObject.GetComponent<IncompleteDataScript>().replaceObject();
                Debug.Log("You replaces an incomplete data!");
            }
            catch (Exception E)
            {
                Debug.Log("Error replaced an incomplete data: " + E);
            }
        } else if (Input.GetKeyDown(KeyCode.Q) && canInteract[1] == true)
        {
            canInteract[1] = false;
            // eventSystem.GetComponent<EventHandler>().Events(interactingObject.GetComponent<ObjectInteract>().eventType, new List<GameObject> { this.gameObject, interactingObject });
            try
            {
                interactingObject.GetComponent<CorruptedDataScript>().destroyObject();
                Debug.Log("You destroyed a corrupted data!");
            }
            catch (Exception E)
            {
                Debug.Log("Error destroying a corrupted data: " + E);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        int index = 0;
        if (collider.gameObject.name.Contains("CorruptedDataObject"))
        {
            index = 1;
        } else if (collider.gameObject.name.Contains("IncompleteDataObject"))
        {
            index = 0;
        }
        interactTexts[index].transform.position = new Vector3(collider.gameObject.GetComponent<ObjectInteract>().interactDistance.x, collider.gameObject.GetComponent<ObjectInteract>().interactDistance.y) + collider.gameObject.transform.position;
        interactTexts[index].SetActive(true);
        interactingObject = collider.gameObject;
        canInteract[index] = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (interactingObject == collider.gameObject)
        {
            int index = 0;
            if (collider.gameObject.name.Contains("CorruptedDataObject"))
            {
                index = 1;
            }
            else if (collider.gameObject.name.Contains("IncompleteDataObject"))
            {
                index = 0;
            }
            else
                return;
            interactTexts[index].SetActive(false);
            canInteract[index] = false;
            interactingObject = null;
        }

    }
}
