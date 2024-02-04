using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoBox : MonoBehaviour
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
    public List<ObjectInteract> nameText;
    public GameManager gm;
    private float temp;
    private int textOrd = 0;

    
    // Start is called before the first frame update

    public void StartTalk()
    {
        index = 0;
        isInteracting = true;

        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        float temp = gm.gameSpeed;
        gm.gameSpeed = 0f;


        names = nameText[textOrd].names;
        sentences = nameText[textOrd].text;
        index++;
        if (textOrd >= nameText.Count){
            textOrd = 0;
        }
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
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            isInteracting = false;
            gm.gameSpeed = temp;
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
