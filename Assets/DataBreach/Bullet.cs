using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timer;
    [HideInInspector]
    public float speed;

    private void Start()
    {
        Destroy(gameObject, timer);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed, 0);
        
    }
}
