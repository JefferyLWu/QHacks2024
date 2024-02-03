using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject interactText;
    public GameObject interactingObject = null;
    public GameObject eventSystem;
    public bool canInteract;


    // Start is called before the first frame update
    void Start()
    {
        interactText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && canInteract == true)
        {
            canInteract = false;
            eventSystem.GetComponent<EventHandler>().Events(interactingObject.GetComponent<ObjectInteract>().eventType, new List<GameObject>{this.gameObject, interactingObject});
            
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        interactText.transform.position = new Vector3(collider.gameObject.GetComponent<ObjectInteract>().interactDistance.x, collider.gameObject.GetComponent<ObjectInteract>().interactDistance.y) + collider.gameObject.transform.position;
        interactText.SetActive(true);
        interactingObject = collider.gameObject;
        canInteract = true;

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (interactingObject == collider.gameObject)
        {
            interactText.SetActive(false);
            canInteract = false;
            interactingObject = null;
        }

    }
}
