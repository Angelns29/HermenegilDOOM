using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Stripper : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float lastBulletShot;
    [SerializeField] private float bulletCD;

    public Camera weaponCam;
    public Transform spawner;
    [NonSerialized] public GameObject bulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsMouse();
        ItFires();
    }

    private void RotateTowardsMouse()
    {
        //Obtiene el angulo entre el arma y el mouse
        float angel = GetAngelTowardsMouse();

        transform.rotation = Quaternion.Euler(0, 0, angel);
        spriteRenderer.flipY = angel >= 90 && angel <= 270;
    }

    private float GetAngelTowardsMouse()
    {
       Vector3 mouseWorldPos = weaponCam.ScreenToWorldPoint(Input.mousePosition);

       //Direcci�n entre arma y posici�n del mouse
       Vector3 mouseDirection = mouseWorldPos - transform.position;
       //cordenada sin usar
       mouseDirection.z = 0;
        //Signed angle devuelve el angulo entre dos vectores.
        float angel = (Vector3.SignedAngle(Vector3.right, mouseDirection, Vector3.forward) + 360) % 360;

        return angel;
    }

    //Se asegura de si el jugador dispara o no
    private void ItFires()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastBulletShot > bulletCD)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = spawner.position;
            bullet.transform.rotation = transform.rotation;
            lastBulletShot = Time.time;
            Destroy(bullet, 2f);
        }
    }
}
