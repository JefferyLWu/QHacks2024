using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float shootTime;
    public float minTime;
    private float waitTime;
    public float bulletSpeed;
    public GameObject bullet;
    public Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    public IEnumerator Shoot()
    {
        waitTime = Random.Range(minTime, shootTime);
        yield return new WaitForSeconds(waitTime);
        GameObject bulletInstance;
        bulletInstance = Instantiate(bullet, gameObject.transform.position + position, Quaternion.identity) as GameObject;
        bulletInstance.GetComponent<Bullet>().speed = -bulletSpeed;
        bulletInstance.tag = "EnemyBullet";
        bulletInstance.SetActive(true);
        StartCoroutine(Shoot());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
