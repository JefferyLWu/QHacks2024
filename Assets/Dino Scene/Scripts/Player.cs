//PLAYER
using UnityEngine;
//MANAGES JUMP

public class Player : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction; //direction that the character is moving
    public float gravity = 9.81f * 2f; //the player needs gravity when they jump! (made the gravity more intense for the desired effect)
    public float jumpforce = 8f;
    private void Awake() //function that unity calls automatically
    {
        character = GetComponent<CharacterController>(); //get the character contorller component from the character object

    }

    private void OnEnable()//another built in funciton that is called automatically everytime the script is enabled (script is disabled when game over)
    {
        direction = Vector3.zero; //whenever player is re-enabled, you want to set the positoon fo the player to 0
    }

    private void Update() //unity calls this function every single second your frame is running
    {
        direction += Vector3.down * gravity * Time.deltaTime; //moving downwards with gravity over a period of time (this force builds up over time)

        //check if the character is grounded (if it is, then we can check for jump input:
        if (character.isGrounded)
        {
            direction = Vector3.down; //apply force to push player down

            if (Input.GetButton("Jump")) //unity has a built in access value for jump (which we set to the space bar)
            {
                direction = Vector3.up * jumpforce; //up direction
            }
        }
        character.Move(direction * Time.deltaTime); //move the character in desired direction
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
        if (other.CompareTag("Info"))
        {
            Destroy(other.gameObject);
            gameObject.GetComponent<InfoBox>().StartTalk();
            
        }
    }
}
