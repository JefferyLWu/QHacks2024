using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    bool isDead = false;
    public GameObject bullet;
    public float bulletSpeed;
    public Vector3 pos;
    private int health = 3;
    private GameObject bulletInstance;

    public TextMeshProUGUI healthName;
    public GameObject gameOverUI;

    private void Start()
    {
        healthName.text = health.ToString();
    }
    void Update()
    {
        if (isDead == false && Input.GetKeyDown(KeyCode.Space))
        {
            
            bulletInstance = Instantiate(bullet, gameObject.transform.position + pos, Quaternion.identity) as GameObject;
            bulletInstance.GetComponent<Bullet>().speed = bulletSpeed;
            bulletInstance.tag = "PlayerBullet";
            bulletInstance.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
        if (collision.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            if (health == 1)
            {
                GameOver();
            }
            else
            {
                health--;
                healthName.text = health.ToString();

            }
        }
    }

    public void GameOver()
    {
        isDead = true;
        gameObject.SetActive(false);
        healthName.gameObject.transform.parent.gameObject.SetActive(false);
        gameOverUI.SetActive(true);

    }

}
