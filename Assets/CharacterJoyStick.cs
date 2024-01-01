using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animarket
{

    public class CharacterJoyStick : MonoBehaviour
    {
        public FixedJoystick Joystick;
        private Animator animator;
        Rigidbody2D rb;
        Vector2 move;
        public float moveSpeed;
        SpriteRenderer spriteRenderer;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            move.x = Joystick.Horizontal;
            move.y = Joystick.Vertical;

            animator.SetBool("IsWalking", move != Vector2.zero);

            if (move.x < 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (move.x > 0)
            {
                spriteRenderer.flipX = true;
            }
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
        }
    }
}