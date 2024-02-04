using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitObjectScript : MonoBehaviour
{
    public string sceneToLoad;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with the specific object
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Char")
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
