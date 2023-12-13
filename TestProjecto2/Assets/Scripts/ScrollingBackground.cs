using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private Renderer bckRenderer;
    [SerializeField]
    private Transform _followObject;
    // Update is called once per frame
    void Update()
    {
        bckRenderer.material.mainTextureOffset = new Vector2(_followObject.position.x * speed, _followObject.position.y * speed);
    }
}
