using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovement : MonoBehaviour
{
    public float speed;
    public Vector2 boundaries;

    // Update is called once per frame
    void FixedUpdate()
    {
        float verInput = Input.GetAxis("Horizontal");
        verInput *= speed;
        transform.position = transform.position + new Vector3(verInput, 0, 0);
    }
}
