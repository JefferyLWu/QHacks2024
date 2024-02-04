using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndreeaWalkingScript : MonoBehaviour
{
    public float speed = 0.1f;
    public float sprint = 2f;

    public Collider2D upCollider;
    public Collider2D downCollider;
    public Collider2D leftCollider;
    public Collider2D rightCollider;

    private bool topBool = true;
    private bool leftBool = true;
    private bool bottomBool = true;
    private bool rightBool = true;

    public bool frozen;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!frozen)
        {
            float horInput = Input.GetAxis("Horizontal");
            float verInput = Input.GetAxis("Vertical");

            if (verInput > 0)
            {
                upCollider.enabled = true;
                downCollider.enabled = false;
                leftCollider.enabled = false;
                rightCollider.enabled = false;

                if (!topBool)
                    verInput = 0;
            }

            else if (verInput < 0)
            {
                upCollider.enabled = false;
                downCollider.enabled = true;
                leftCollider.enabled = false;
                rightCollider.enabled = false;

                if (!bottomBool)
                    verInput = 0;
            }

            else if (horInput > 0)
            {
                upCollider.enabled = false;
                downCollider.enabled = false;
                leftCollider.enabled = false;
                rightCollider.enabled = true;

                if (!rightBool)
                    horInput = 0;
            }

            else if (horInput < 0)
            {
                upCollider.enabled = false;
                downCollider.enabled = false;
                leftCollider.enabled = true;
                rightCollider.enabled = false;

                if (!leftBool)
                    horInput = 0;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                horInput *= sprint;
                verInput *= sprint;
            }

            transform.position = transform.position + new Vector3(horInput * speed, verInput * speed, 0);
        }

    }

    public void Freeze()
    {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        frozen = true;
    }

    public void Unfreeze()
    {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        frozen = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BorderTop")
        {
            topBool = false;
        }
        else
            topBool = true;

        if (collision.gameObject.name == "BorderLeft")
        {
            leftBool = false;
        }
        else
            leftBool = true;
        if (collision.gameObject.name == "BorderBottom")
        {
            bottomBool = false;
        }
        else
            bottomBool = true;
        if (collision.gameObject.name == "BorderRight")
        {
            rightBool = false;
        }
        else
            rightBool = true;
    }
}
