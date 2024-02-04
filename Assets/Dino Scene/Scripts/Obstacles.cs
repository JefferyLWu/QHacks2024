using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private float leftedge;
    private void Start()
    {
        leftedge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }
    private void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime; //moves objects at the same speed as the ground

        if (transform.position.x < leftedge)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {

        }
    }
}
