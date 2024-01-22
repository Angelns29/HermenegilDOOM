using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Pool;
using TMPro;
using static Damage;

public class TurretScript : MonoBehaviour, IDamageable
{
    public EnemyTemplate enemyTemplate;
    public float range;
    public Transform Target;
    bool detected = false;
    Vector2 direction;

    public float fireRate;
    float delay = 0;
    public Transform shootPoint;
    public float force;

    private Animator _anim;
    private float currentHP;


    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        currentHP = enemyTemplate.health;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;
        direction = targetPos  - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction,range);
        
        if (rayInfo.collider != null)
        {
            if (rayInfo.collider.gameObject.CompareTag(Target.tag))
            {
                if (detected == false)
                {
                    Debug.Log("B");
                    detected = true;
                    _anim.SetBool("isAttacking", true);
                }
            }
            else
            {
                if (detected == true)
                {
                    Debug.Log("A");
                    detected = false;
                    _anim.SetBool("isAttacking", false);
                }
            }
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
        GameObject bullet = TurretPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.SetPositionAndRotation(shootPoint.position, transform.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().AddForce(direction * force);
            
        }
        


    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
