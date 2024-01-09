using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strippersBullet : MonoBehaviour
{
    private new Rigidbody2D rb;
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position + transform.right * speed * Time.fixedDeltaTime);
    }
}
