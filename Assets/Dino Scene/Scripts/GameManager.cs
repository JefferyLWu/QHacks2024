//GameManager
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }//instance has a public getter but private setter
    public float initialGameSpeed = 5f; //initial speed
    public float gameSpeedIncrease = 0.1f; //increment the game speed 
    public float gameSpeed { get; set; } //game speed

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiScoreText;
    public Button retryButton;
   

    private Player player;
    private Spawner spawner;
    private float score;

    private void Awake()
    {
        //check that the instance does not exist
        if (Instance == null)
        {
            Instance = this; //if the instnace does not exist, then we cna assign this instance to this value
        }
        else
        {
            DestroyImmediate(gameObject); //if the instance does exist, destroy the new one immediately
        }
    }

    private void OnDestroy() //built-in unity function
    {
        if (Instance == this)
        {
            Instance = null; //if the instance  is equal to this, we will assign it
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        spawner =FindObjectOfType<Spawner>();
        NewGame(); // at the start of the game, call new game function
    }

    public void NewGame()
    {
        Obstacles[] obstacles = FindObjectsOfType<Obstacles>();

        foreach(var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
        gameSpeed = initialGameSpeed; //start game at initial speed
        enabled = true;
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        UpdateHiScore();
    }

    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;
        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        UpdateHiScore();

    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }

    private void UpdateHiScore()
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);
        if (score > hiscore) 
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }
        hiScoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");
    }
}