using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : MonoBehaviour
{
    [SerializeField] private EnemyTemplate chStats;

    private ChaserExplode boom;
    public GameObject player;
    public float speed;

    private float distance;
    
    private void Start()
    {
        boom = ChaserExplode.instance;
    }

    // Update is called once per frame
    void Update()
    {
        //Coge la distancia entre el enemigo y el jugador
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        //Encuentra el angulo entre dos puntos, la multiplicación convierte de radian a grado
        float angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //El condicional sirve para que el enemigo se empiece a mover si el jugador esta a cierta distancia de el
        if (distance <= 6)
        {
            //Mueve al enemigo hacia el jugador
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            //Hace girar al enemigo para estar mirando al enemigo
            transform.rotation = Quaternion.Euler(Vector3.forward * angel);
            if (distance <= 2)
            {
                //El enemigo explota
                boom.Kaboom();
                Debug.Log("A");
            }
        }
    }
}
