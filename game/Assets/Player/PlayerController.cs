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
        public bool canMove = true;
        [SerializeField] private float moveSpeed;
        Animator anim;
        Transform Oretr;


        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _inputM = GetComponent<InputManager>();
            anim = GetComponent<Animator>();
            Oretr = GameObject.FindWithTag("Ore").transform;
        }

        private void FixedUpdate()
        {
            Move();
        }

        void Update()
        {
            if (canMove == true)
            {
                CloseEnough();
            }
        }

        private void Move()
        {
            _rb.linearVelocity = _inputM.Move * moveSpeed;
            anim.SetBool("WalkingUp", _inputM.Move == Vector2.up);
            anim.SetBool("WalkingDown", _inputM.Move == Vector2.down);
            anim.SetBool("WalkingLeft", _inputM.Move == Vector2.left);
            anim.SetBool("WalkingRight", _inputM.Move == Vector2.right);

        }

        void CloseEnough()
        {
            if (Vector2.Distance(transform.position, Oretr.position) < 1.2)
            {
                if (_inputM.InteractPressed == true)
                {
                    canMove = false;
                    //de interact voor de game en de player niet bewgen
                }
                //hier de interact en de player stoppen met bewegen door de player script stoppen
            }
        }
    }
}