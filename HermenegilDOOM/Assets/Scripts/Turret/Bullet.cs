using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    private TurretScript _turret;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _turret = GetComponent<TurretScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            _rb.totalForce = new Vector2(100,100);
            gameObject.SetActive(false);
            if (collision.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement player))
            {
                player.TakeDamage(_turret.damage);
            }
        }
    }
}
