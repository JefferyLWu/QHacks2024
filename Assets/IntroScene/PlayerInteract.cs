using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject interactText;
    public GameObject interactingObject = null;
    private bool isInteract;


    // Start is called before the first frame update
    void Start()
    {
        interactText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && isInteract == true)
        {
            interactingObject.GetComponent<ObjectInteract>().Interacted();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (interactingObject == null)
        {
            interactText.transform.position = new Vector3(collider.gameObject.GetComponent<ObjectInteract>().interactDistance.x, collider.gameObject.GetComponent<ObjectInteract>().interactDistance.y) + collider.gameObject.transform.position;
            interactText.SetActive(true);
            isInteract = true;
            interactingObject = collider.gameObject;
        }

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (interactingObject == collider.gameObject)
        {
            interactText.SetActive(false);
            isInteract = false;
            interactingObject = null;
        }

    }
}
