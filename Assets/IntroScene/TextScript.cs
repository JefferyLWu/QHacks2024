using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScript : MonoBehaviour
{
    public GameObject TextUI;
    public TextMeshProUGUI personName;
    public TextMeshProUGUI phrase;
    public float typeSpeed;
    int index;
    List<string> names;
    List<string> sentences;
    private IEnumerator textCoroutine;
    private bool isInteracting = false;
    private GameObject player;
    // Start is called before the first frame update

    public void StartTalk(GameObject person, GameObject interactable)
    {
        index = 0;
        isInteracting = true;

        player = person;
        player.GetComponent<Walking>().Freeze();


        names = interactable.GetComponent<ObjectInteract>().names;
        sentences = interactable.GetComponent<ObjectInteract>().text;

        TextUI.SetActive(true);
        textCoroutine = Typing();
        NextSentence();
    }

    IEnumerator Typing()
    {
        personName.text = names[index];
        phrase.text = "";
        foreach (char letter in sentences[index].ToCharArray())
        {
            phrase.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    public void NextSentence()
    {
        if (index < names.Count)
        {
            StopCoroutine(textCoroutine);
            textCoroutine = Typing();
            StartCoroutine(textCoroutine);
            index++;
        }
        else
        {
            TextUI.SetActive(false);
            player.GetComponent<Walking>().Unfreeze();
            isInteracting = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInteracting == true)
        {
            NextSentence();
        }
    }
}
