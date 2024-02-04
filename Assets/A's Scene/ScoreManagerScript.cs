using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreManagerScript : MonoBehaviour
{
    public static ScoreManagerScript Instance;

    public TMP_Text corruptedText;
    public TMP_Text incompleteText;
    public GameObject exitObj;

    [SerializeField] TextMeshProUGUI timerText;
    float remainingTime = 60f;
    private bool timerIsActive = true;

    private int corrupted = 0;
    private int incomplete = 0;

    public GameObject gamveOverUI;

    private void Awake()
    {
        Instance = this;
        exitObj.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        corruptedText.text = "Corrupted Data Destroyed: " + corrupted.ToString() + "/" + DataSpawnerScript3.Instance.scoreToWin.ToString();
        incompleteText.text = "Incomplete Data Fixed: " + incomplete.ToString() + "/" + DataSpawnerScript3.Instance.scoreToWin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime < 0)
        {
            remainingTime = 0;
            gameOver();
            timerIsActive = false;
        }
        else
        {
            if (timerIsActive)
            {
                remainingTime -= Time.deltaTime;
                int minutes = Mathf.FloorToInt(remainingTime / 60);
                int seconds = Mathf.FloorToInt(remainingTime % 60);
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                timerText.text = "";
            }
            
        }
    }

    public void AddCountCorrupted()
    {
        corrupted += 1;
        corruptedText.text = "Corrupted Data Destroyed: " + corrupted.ToString() + "/" + DataSpawnerScript3.Instance.scoreToWin.ToString();
    }

    public void AddCountIncomplete()
    {
        incomplete += 1;
        incompleteText.text = "Incomplete Data Fixed: " + incomplete.ToString() + "/" + DataSpawnerScript3.Instance.scoreToWin.ToString();
    }

    public int getCorrupted()
    {
        return corrupted;
    }

    public int getIncomplete()
    {
        return incomplete;
    }

    public void finishGame()
    {
        timerIsActive = false;
        exitObj.SetActive(true);
        DataSpawnerScript3.Instance.dataSpawner.SetActive(false);
        DeleteAllPrefabInstances();
    }

    public void gameOver()
    {
        timerIsActive = false;
        DataSpawnerScript3.Instance.dataSpawner.SetActive(false); // add
        DeleteAllPrefabInstances();
        gamveOverUI.SetActive(true);
    }

    void DeleteAllPrefabInstances()
    {
        // Find all GameObjects with the specified tag
        GameObject[] prefabInstances = GameObject.FindGameObjectsWithTag("badData");

        // Iterate through each instance and destroy it
        foreach (GameObject instance in prefabInstances)
        {
            Destroy(instance);
        }
    }
}
