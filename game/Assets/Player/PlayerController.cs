using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game.Manager;

namespace game.PlayerControl
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private InputManager _inputM;
        [SerializeField] private float moveSpeed;
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _inputM = GetComponent<InputManager>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _rb.linearVelocity = _inputM.Move * moveSpeed;
        }
    }
}