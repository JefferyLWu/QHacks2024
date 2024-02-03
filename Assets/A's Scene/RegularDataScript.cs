using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularDataScript : MonoBehaviour
{
    private float moveSpeed = 3.5f;
    public float aliveTime = 0;
    private float maxAliveTime = 8;
    private float changeDirectionInterval = 1.2f;
    private Vector2 targetDirection;
    private float elapsedTime = 0f;


    void Start()
    {
        SetRandomDirection();
        Destroy(gameObject, maxAliveTime);
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        // transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= changeDirectionInterval)
        {
            SetRandomDirection();
            elapsedTime = 0f;
        }

        // transform.Translate(targetDirection * moveSpeed * Time.deltaTime);

        Vector2 newPosition = (Vector2)transform.position + (targetDirection * moveSpeed * Time.deltaTime);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }

    void SetRandomDirection()
    {
        targetDirection = new Vector2(Random.Range(-0.75f, 0.75f), Random.Range(-0.75f, 0.75f)).normalized;
    }
}
