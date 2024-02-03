using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSpawnerScript2 : MonoBehaviour
{

    public GameObject dataSprite;
    public GameObject dataSpawner;
    public GameObject spawnSquare;

    private double timer = 0;
    private double timeToSpawn = 0.75;

    // Start is called before the first frame update
    void Start()
    {
        spawnData(5);
        UnityEngine.Debug.Log("Start!");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < timeToSpawn) // add limits on number of sprites
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnData(3);
            timer = 0;
        }
    }

    public void spawnData(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector2 pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.x);
            float x = pos.x + Random.Range(-spawnSquare.transform.localScale.x / 2, spawnSquare.transform.localScale.x / 2);
            float y = pos.y + Random.Range(-spawnSquare.transform.localScale.y / 2, spawnSquare.transform.localScale.y / 2);
            // UnityEngine.Debug.Log("x: " + x + ", y: " + y);
            Instantiate(dataSprite, new Vector2(x, y), Quaternion.identity);
        }
    }
}
