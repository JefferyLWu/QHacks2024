using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMovement : MonoBehaviour
{
    public Vector2 borders;
    public float speed;
    public float varaiblilty;
    public Vector2 direction;

    private Vector2 startPos;
    private float finalSpeed;

    private void Start()
    {
        startPos = gameObject.transform.position;
        newDir();
    }
    void FixedUpdate()
    {


        if (Mathf.Abs(gameObject.transform.position.x-startPos.x) < borders.x && Mathf.Abs(gameObject.transform.position.y - startPos.y) < borders.y)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(direction.x* finalSpeed, direction.y* finalSpeed);
        }
        else
        {
            newDir();
            gameObject.GetComponent<RectTransform>().anchoredPosition3D = (gameObject.transform.position - new Vector3(startPos.x, startPos.y))*finalSpeed;
        }
    }

    void newDir()
    {
        direction = new Vector2(Random.Range(-1000, 1000), Random.Range(-1000, 1000)).normalized;
        finalSpeed = speed;
    }
    
}
