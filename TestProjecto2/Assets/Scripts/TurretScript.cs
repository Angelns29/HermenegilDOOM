using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public float range;
    public Transform Target;
    bool detected = false;
    Vector2 direction;

    public GameObject Bullet;
    public float fireRate;
    float delay = 0;
    public Transform shootPoint;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;
        direction = targetPos  - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction,range);
    

        if ( rayInfo.collider.gameObject.CompareTag("Player"))
        {
            if (detected == false) detected = true;
        }
        else{
            if (detected == true) detected = false;
        }

        if (detected)
        {
            transform.up = direction;
            if(Time.time > delay)
            {
                delay = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
    void Shoot()
    {
       GameObject bulletins= Instantiate(Bullet,shootPoint.position, Quaternion.identity);
        bulletins.GetComponent<Rigidbody2D>().AddForce(direction * force);

    }
}
