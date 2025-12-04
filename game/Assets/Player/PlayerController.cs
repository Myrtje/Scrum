using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game.Manager;

namespace game.PlayerControl
{
    public class PlayerController : MonoBehaviour
    {
        Rigidbody2D _rb;
        InputManager _inputM;
        [SerializeField] private float moveSpeed;
        Animator anim;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _inputM = GetComponent<InputManager>();
            anim = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _rb.linearVelocity = _inputM.Move * moveSpeed;
            anim.SetBool("WalkingUp", _inputM.Move == Vector2.up);
            anim.SetBool("WalkingDown", _inputM.Move == Vector2.down);
            anim.SetBool("WalkingLeft", _inputM.Move == Vector2.left);
            anim.SetBool("WalkingRight", _inputM.Move == Vector2.right);
        }
    }
}