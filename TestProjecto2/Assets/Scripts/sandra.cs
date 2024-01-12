using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class sandra : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private new Collider2D coll;
    private Rigidbody2D enemy;

    public Camera weaponCam;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
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

    private void OnCollisionEnter2D(Rigidbody2D enemy)
    {
        if (coll.CompareTag("Enemy")) 
        {
            enemy.AddForce((transform.position - enemy.transform.position) * -1500, ForceMode2D.Impulse);
        }
    }
}
