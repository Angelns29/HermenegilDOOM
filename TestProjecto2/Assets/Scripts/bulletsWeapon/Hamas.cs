using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamas : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float lastBulletShot;
    [SerializeField] private float bulletCD;

    public Camera weaponCam;
    public Transform[] spawners;
    public GameObject bulletPrefab;


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

        //Dirección entre arma y posición del mouse
        Vector3 mouseDirection = mouseWorldPos - transform.position;
        //cordenada sin usar
        mouseDirection.z = 0;
        //Signed angle devuelve el angulo entre dos vectores.
        float angel = (Vector3.SignedAngle(Vector3.right, mouseDirection, Vector3.forward) + 360) % 360;

        return angel;
    }

    //Se asegura de si el jugador dispara o no
    public void ItFires()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastBulletShot > bulletCD)
        {
            foreach (Transform firepoint in spawners)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = firepoint.position;
                bullet.transform.rotation = firepoint.rotation;
                lastBulletShot = Time.time;
                Destroy(bullet, 2f);
            }
        }
    }
}
