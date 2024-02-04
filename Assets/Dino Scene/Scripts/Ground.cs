//ground
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ground : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Update()
    {
        float speed = GameManager.Instance.gameSpeed / transform.localScale.x; // the speed should be the game speed divided by the scale of the x axis
        meshRenderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
    }
}
