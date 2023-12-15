using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChaserExplode : MonoBehaviour
{
    [DoNotSerialize] public static ChaserExplode instance;
    [SerializeField]private float radio = 3;

    [SerializeField] private float expForce = 33033;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else Destroy(gameObject);
    }

    public void Kaboom()
    {
        Collider2D[] obj = Physics2D.OverlapCircleAll(transform.position, radio);
        foreach (Collider2D col in obj)
        {
            Rigidbody2D rb2D = col.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                Vector2 direction = col.transform.position - transform.position;
                float distance = 1 + direction.magnitude;
                float finalForce = expForce * distance;
                rb2D.AddForce(direction * finalForce);
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
