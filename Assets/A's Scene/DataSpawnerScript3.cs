using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSpawnerScript3 : MonoBehaviour
{

    public static DataSpawnerScript3 Instance;

    public GameObject[] dataObjects;
    private int[] numDataObjects = { 0, 0, 0};
    private int[] probabilities = { 0, 0, 0, 0, 1, 1, 1, 2, 2, 2 };
    public GameObject dataSpawner;
    public GameObject spawnSquare;
    private bool corruptedDone = false;
    private bool incompleteDone = false;

    public int scoreToWin = 3;

    private double timer = 0;
    private double timeToSpawn = 1.1;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnData(6);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < timeToSpawn)
        {
            timer += Time.deltaTime;
        }
        else
        {

            if (!corruptedDone && ScoreManagerScript.Instance.getCorrupted() >= scoreToWin)
            {
                for (int i = 0; i < probabilities.Length; i++)
                {
                    if (probabilities[i] == 2 && i % 2 == 0)
                    {
                        probabilities[i] = 0;
                    }
                    else if (probabilities[i] == 2 && i % 2 != 0 && !incompleteDone)
                    {
                        probabilities[i] = 1;
                    }
                    else if (probabilities[i] == 2)
                        probabilities[i] = 0;
                }
                corruptedDone = true;
            }

            if (!incompleteDone && ScoreManagerScript.Instance.getIncomplete() >= scoreToWin)
            {
                for (int i = 0; i < probabilities.Length; i++)
                {
                    if (probabilities[i] == 1 && i % 2 == 0)
                    {
                        probabilities[i] = 0;
                    }
                    else if (probabilities[i] == 21 && i % 2 != 0 && !corruptedDone)
                    {
                        probabilities[i] = 2;
                    }
                    else if (probabilities[i] == 1)
                        probabilities[i] = 0;
                }
                incompleteDone = true;
            }

            if (numDataObjects[0] + numDataObjects[1] + numDataObjects[2] > 30)
            {
                spawnData(2);
                Debug.Log("2 spawned");
            }
            else
            {
                spawnData(3);
                Debug.Log("3 spawned");
            }
            timer = 0;
        }

        if (incompleteDone && corruptedDone)
            ScoreManagerScript.Instance.finishGame();
    }

    public void spawnData(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int randomIndex = probabilities[Random.Range(0, probabilities.Length)];
            Vector2 pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.x);
            float x = pos.x + Random.Range(-spawnSquare.transform.localScale.x / 2, spawnSquare.transform.localScale.x / 2);
            float y = pos.y + Random.Range(-spawnSquare.transform.localScale.y / 2, spawnSquare.transform.localScale.y / 2);
            // UnityEngine.Debug.Log("x: " + x + ", y: " + y);
            GameObject instantiatedObject = Instantiate(dataObjects[randomIndex], new Vector2(x, y), Quaternion.identity) as GameObject;
            numDataObjects[randomIndex] += 1;
        }
    }
}
