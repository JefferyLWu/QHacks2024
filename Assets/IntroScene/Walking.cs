using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public float speed = 0.1f;
    public float sprint = 2f;

    public Collider2D upCollider;
    public Collider2D downCollider;
    public Collider2D leftCollider;
    public Collider2D rightCollider;

    // Update is called once per frame
    void FixedUpdate()
    {
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");

        if (verInput > 0)
        {
            upCollider.enabled = true;
            downCollider.enabled = false;
            leftCollider.enabled = false;
            rightCollider.enabled = false;
        }

        else if (verInput < 0)
        {
            upCollider.enabled = false;
            downCollider.enabled = true;
            leftCollider.enabled = false;
            rightCollider.enabled = false;
        }

        else if (horInput > 0)
        {
            upCollider.enabled = false;
            downCollider.enabled = false;
            leftCollider.enabled = false;
            rightCollider.enabled = true;
        }

        else if (horInput < 0)
        {
            upCollider.enabled = false;
            downCollider.enabled = false;
            leftCollider.enabled = true;
            rightCollider.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)){
            horInput *= sprint;
            verInput *= sprint;
        }

        transform.position = transform.position + new Vector3(horInput * speed, verInput * speed, 0);

    }
}
