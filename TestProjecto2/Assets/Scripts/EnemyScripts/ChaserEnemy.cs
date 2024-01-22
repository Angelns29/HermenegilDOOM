using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChaserEnemy : MonoBehaviour, IDamageble
{
    public float speed;
    public float moveRadius;
    public float exploteRadius;
    public EnemyTemplate enemyTemplate;

    public bool shouldRotate = true;

    public LayerMask playerLayer;

    private Transform _player;
    private Rigidbody2D _rb;
    private Animator _anim;
    private Vector2 _movement;
    public Vector3 _direction;
    private ChaserExplode boom;

    private bool _isInMoveRadius;
    private bool _isInExploteRadius;

    private AudioManager _audioManager;
    private float currentHP;

    private void Start()
    {
        boom = GetComponent<ChaserExplode>();
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _player = GameObject.FindWithTag("Player").transform;
        _audioManager = AudioManager.instance;
        currentHP = enemyTemplate.health;

    }
    private void Update()
    {
        _anim.SetBool("isMoving", _isInMoveRadius);

        _isInMoveRadius = Physics2D.OverlapCircle(transform.position, moveRadius, playerLayer);
        _isInExploteRadius = Physics2D.OverlapCircle(transform.position, exploteRadius, playerLayer);

        _direction = _player.position - transform.position;
        float angel = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        _direction.Normalize();
        _movement = _direction;

        if (shouldRotate)
        {
            _anim.SetFloat("Horizontal",_direction.x);
            _anim.SetFloat("Vertical", _direction.y);
        }

    }
    private void FixedUpdate()
    {
        if (_isInMoveRadius && !_isInExploteRadius) MoveCharacter(_movement);
        if (_isInExploteRadius) {
            boom.Kaboom();
            _audioManager.PlaySFX(_audioManager.enemyDie);
            _rb.velocity = Vector2.zero;
            
        }
         
    }
    private void MoveCharacter(Vector2 dir)
    {
        _rb.MovePosition((Vector2)transform.position + (dir*speed*Time.deltaTime));
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
