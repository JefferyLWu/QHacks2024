using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSpawnerScript3 : MonoBehaviour
{

    public GameObject[] dataObjects;
    private int[] numDataObjects = { 0, 0, 0};
    private int[] probabilities = { 0, 0, 0, 0, 1, 1, 1, 2, 2, 2 };
    public GameObject dataSpawner;
    public GameObject spawnSquare;

    private double timer = 0;
    private double timeToSpawn = 1.1;

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
