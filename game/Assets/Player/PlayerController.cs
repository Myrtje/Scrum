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
        public MovingBar movingBar;
        public GameObject movingBarHUD;
        public bool canMove = true;
        [SerializeField] private float moveSpeed;
        Animator anim;
        public bool nexttoOre = false;


        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _inputM = GetComponent<InputManager>();
            anim = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            if (canMove == true)
            {
                Move();
            }
        }

        public void Update()
        {
            if (_inputM.InteractPressed == true  && nexttoOre == true)
            {
                movingBar.startminigame = true;
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


        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ore"))
            {
                print("iets");
                nexttoOre = true;
            }
        }
        public void OnTriggerExit2D(Collider2D other)
        {
            print("nogiets");
            nexttoOre = false;
        }
    }
}