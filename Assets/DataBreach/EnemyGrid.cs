using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrid : MonoBehaviour
{
    public List<GameObject> enemies;
    public int length;
    public int width;
    public float speed;
    public float heightIncrement;
    public float gridSize;
    public Vector2 startPos;

    private Vector3 leftEdge;
    private Vector3 rightEdge;

    private Vector2 direction = Vector2.right;
    private Vector3 spawnPosition;
    private GameObject enemy;

    public float timeBeforeIncrease;
    public float speedIncrease;

    private IEnumerator increaseSpeed;

    public GameObject player;

    void Start()
    {
        leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        for (int i = 0; i < length; i++)
        {
            spawnPosition.y = i*gridSize - (length/2) * gridSize + startPos.y;
            for (int j = 0; j < width; j++)
            {
                spawnPosition.x = j * gridSize - ((width/2)-0.5f)*gridSize + startPos.x;
                enemy = Instantiate(enemies[Random.Range(0, enemies.Count)], spawnPosition, Quaternion.identity, transform);
                enemy.transform.position = spawnPosition;
                enemy.SetActive(true);
            }
        }
        increaseSpeed = SpeedUp();
        StartCoroutine(increaseSpeed);
    }

    public IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(timeBeforeIncrease);
        speed += speedIncrease;
        SpawnNextWave();
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime* new Vector3(direction.x, direction.y);

        foreach (Transform enemy in transform)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (direction == Vector2.right && enemy.position.x >= (rightEdge.x-0.5) || direction == Vector2.left && enemy.position.x <= (leftEdge.x + 0.5))
            {
                direction *= -1;
                NextRow();
            }
            if (enemy.position.y < Camera.main.ViewportToWorldPoint(Vector3.zero).y)
            {
                player.GetComponent<PlayerShoot>().GameOver();
            }

        }
    }

    private void NextRow()
    {
        transform.position += new Vector3(0, -heightIncrement);
    }

    private void SpawnNextWave()
    {
        Debug.Log("Hi");
        for (int j = 0; j < width; j++)
        {
            spawnPosition.x = j * gridSize - ((width / 2) - 0.5f) * gridSize + startPos.x;
            enemy = Instantiate(enemies[Random.Range(0, enemies.Count)], spawnPosition, Quaternion.identity, transform);
            enemy.transform.position = spawnPosition;
            enemy.SetActive(true);
        }
        StopCoroutine(increaseSpeed);
        increaseSpeed = SpeedUp();
        StartCoroutine(increaseSpeed);
    }
}
