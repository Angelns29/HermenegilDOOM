using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChaserExplode : MonoBehaviour
{
    [DoNotSerialize] public static ChaserExplode instance;
    [SerializeField]private float radio = 3;

    [SerializeField] private float expForce = 1945;
    private Animator _anim;
    private Rigidbody2D _rb;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else Destroy(gameObject);
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
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
        _rb.velocity = Vector2.zero;
        _anim.SetTrigger("isBoom");
        StartCoroutine(GoodBye());

    }
    IEnumerator GoodBye()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
