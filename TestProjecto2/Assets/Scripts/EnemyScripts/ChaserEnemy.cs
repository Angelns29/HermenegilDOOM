using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : MonoBehaviour
{
    public float speed;
    public float moveRadius;
    public float exploteRadius;

    public bool shouldRotate = true;

    public LayerMask playerLayer;

    private Transform _player;
    private Rigidbody2D _rb;
    private Animator _anim;
    private Vector2 _movement;
    public Vector3 _direction;

    private bool _isInMoveRadius;
    private bool _isInExploteRadius;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _player = GameObject.FindWithTag("Player").transform;

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
        if (_isInExploteRadius) _rb.velocity = Vector2.zero;
    }
    private void MoveCharacter(Vector2 dir)
    {
        _rb.MovePosition((Vector2)transform.position + (dir*speed*Time.deltaTime));
    }

}
