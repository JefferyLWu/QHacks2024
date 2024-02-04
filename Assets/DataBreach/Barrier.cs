using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public int health;
    public List<Sprite> images;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet")){
            health -= 1;
            Destroy(collision.gameObject); 
        }
        if (health < 1)
        {
            gameObject.SetActive(false);
        }
    }
}
