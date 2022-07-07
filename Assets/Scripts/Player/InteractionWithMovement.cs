using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithMovement : MonoBehaviour
{
    private GameObject _player;
    private PlayerInput _playerInput;
    private Rigidbody2D _rb;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("mainPlayer");
        _playerInput = _player.GetComponent<PlayerInput>();
        _rb = _player.GetComponent<Rigidbody2D>();
    }

    public void EnableMovement()
    {
        _rb.bodyType = RigidbodyType2D.Dynamic;
        _playerInput.enabled = true;
    }

    public void DisableMovement()
    {
        _rb.bodyType = RigidbodyType2D.Static;
        _playerInput.enabled = false;
    }
}
