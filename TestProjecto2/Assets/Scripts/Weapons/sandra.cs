using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class sandra : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D enemy;
    private float damage;

    public Camera weaponCam;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        damage = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsMouse();
    }

    private void RotateTowardsMouse()
    {
        //Obtiene el angulo entre el arma y el mouse
        float angel = GetAngelTowardsMouse();

        transform.rotation = Quaternion.Euler(0, 0, angel);
    }

    private float GetAngelTowardsMouse()
    {
        Vector3 mouseWorldPos = weaponCam.ScreenToWorldPoint(Input.mousePosition);

        //Dirección entre arma y posición del mouse
        Vector3 mouseDirection = mouseWorldPos - transform.position;
        //cordenada sin usar
        mouseDirection.z = 0;
        //Signed angle devuelve el angulo entre dos vectores.
        float angel = (Vector3.SignedAngle(Vector3.right, mouseDirection, Vector3.forward) + 360) % 360;

        return angel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<ChaserEnemy>(out ChaserEnemy enemyBoom))
        {
            Vector2 dir = transform.position - collision.gameObject.transform.position;
            enemy.AddForce(dir * -10, ForceMode2D.Impulse);
            enemyBoom.TakeDamage(damage);
        }

        else if (collision.gameObject.TryGetComponent<TurretScript>(out TurretScript enemySt))
        {
            enemySt.TakeDamage(damage);
        }
    }
}
