using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobFollow : MonoBehaviour
{
    public float speed;
    public float moveRadius;
    public float stopRadius;

    public bool shouldRotate = true;

    public LayerMask playerLayer;

    private Transform _player;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    public Vector3 _direction;

    private bool _isInMoveRadius;
    private bool _isInStopRadius;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindWithTag("Player").transform;

    }
    private void Update()
    {
        _isInMoveRadius = Physics2D.OverlapCircle(transform.position, moveRadius, playerLayer);
        _isInStopRadius = Physics2D.OverlapCircle(transform.position, stopRadius, playerLayer);

        _direction = _player.position - transform.position;
        float angel = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        _direction.Normalize();
        _movement = _direction;
    }
    private void FixedUpdate()
    {
        if (_isInMoveRadius && !_isInStopRadius) MoveCharacter(_movement);
        if (_isInStopRadius) _rb.velocity = Vector2.zero;
    }
    private void MoveCharacter(Vector2 dir)
    {
        _rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }
}
