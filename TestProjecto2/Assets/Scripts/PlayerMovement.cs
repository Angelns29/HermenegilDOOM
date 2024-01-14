using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    [SerializeField] private float _speed;
    private PlayerInput _pinput;
    private Rigidbody2D _rb;
    private Animator _animator;
    private Vector2 _movementInput;
    private PlayerInput _playerInput;

    private UIManager _uiManager;
    private AudioManager _audioManager;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        _uiManager = UIManager.instance;
        _audioManager = AudioManager.instance;
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        _movementInput = ctx.ReadValue<Vector2>();
        if (_movementInput.x != 0 || _movementInput.y != 0)
        {
            _animator.SetFloat("Horizontal", _movementInput.x);
            _animator.SetFloat("Vertical", _movementInput.y);
            _animator.SetBool("isMoving", true);
            _rb.velocity = _movementInput * _speed;
        }
        else
        {
            _animator.SetBool("isMoving", false);
            _rb.velocity = new Vector2(0,0);
        }
        
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        _uiManager.SetGameOver();
        _audioManager.StartGameOverTheme();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name=="NextLevel") {
            if (SceneManager.GetActiveScene().name == "SampleScene") SceneManager.LoadScene(1);
            else GameOver();
        }
    }
}
