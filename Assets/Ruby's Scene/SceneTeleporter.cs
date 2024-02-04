using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleporter : MonoBehaviour
{
    public string sceneNameToLoad; // Assign this in the Inspector
    private SpriteRenderer teleporterSpriteRenderer;
    private bool isTeleporterActive = true;

     // Static variable to ensure the PlayerPrefs are only reset once per game session
    private static bool isInitialized = false;

    private void Awake()
    {
        // Ensure this runs only once per game session
        if (!isInitialized)
        {
            // Reset PlayerPrefs at the start of a new session (if needed)
            PlayerPrefs.SetInt("TeleporterShouldBeGreen", 0);
            PlayerPrefs.SetInt("ReturnedFromKBTestsScene", 0);
            isInitialized = true;
        }

        teleporterSpriteRenderer = GetComponent<SpriteRenderer>();
        CheckTeleporterStatus();
    }

    private void CheckTeleporterStatus()
    {
        // Check if the player is returning from "KB Test Scene" to "KB Scene"
        if (PlayerPrefs.GetInt("ReturnedFromKBTestsScene", 0) == 1)
        {
            Debug.Log("Player returned from KB Tests Scene. Changing color to green.");
            // Change color to green
            teleporterSpriteRenderer.color = Color.green;
            // Save the state
            PlayerPrefs.SetInt("TeleporterShouldBeGreen", 1);
            // Disable the teleporter
            isTeleporterActive = false;
        }
        else
        {
            Debug.Log("Player did not return from KB Tests Scene. Checking saved state.");
            // Check saved state and set color accordingly
            if (PlayerPrefs.GetInt("TeleporterShouldBeGreen", 0) == 1)
            {
                teleporterSpriteRenderer.color = Color.green;
                // Disable the teleporter
                isTeleporterActive = false;
            }
            else
            {
                // Set to default color if needed
                teleporterSpriteRenderer.color = Color.white; // or any other default color
                // Activate the teleporter
                isTeleporterActive = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isTeleporterActive) // Make sure the player has a tag named "Player"
        {
            if (SceneManager.GetActiveScene().name == "KB Tests Scene" && sceneNameToLoad == "KB Scene")
            {
                Debug.Log("Setting PlayerPrefs - ReturnedFromKBTestsScene to 1");
                PlayerPrefs.SetInt("ReturnedFromKBTestsScene", 1);
            }

            TeleportToScene(sceneNameToLoad);
        }
    }

    private void TeleportToScene(string sceneName)
    {
        Debug.Log("Loading scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
        Debug.Log("Scene loaded: " + sceneName);

        // If we're going back to the main scene, check the teleporter status immediately after load
        if (sceneName == "KB Scene")
        {
            CheckTeleporterStatus();
        }
    }

}
