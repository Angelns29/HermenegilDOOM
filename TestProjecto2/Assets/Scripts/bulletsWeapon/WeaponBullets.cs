using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBullet : MonoBehaviour
{
    public BulletDamage bullet;
    private new Rigidbody2D rb;
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<ChaserEnemy>(out ChaserEnemy enemyBoom))
        {
            enemyBoom.TakeDamage(bullet.damage);
        }

        else if(collision.gameObject.TryGetComponent<TurretScript>(out TurretScript enemySt))
        {
            enemySt.TakeDamage(bullet.damage);
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position + transform.right * speed * Time.fixedDeltaTime);
    }
}
