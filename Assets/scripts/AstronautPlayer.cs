using UnityEngine;
using System.Collections;

namespace AstronautPlayer
{
    public class AstronautPlayer : MonoBehaviour
    {
        private Animator anim;
        private CharacterController controller;

        public float speed = 5.0f;          // Forward/backward movement speed
        public float turnSpeed = 200.0f;    // Turning speed
        public float jumpHeight = 2.0f;     // Jump height
        public float gravity = 9.8f;        // Gravity value
        private Vector3 moveDirection = Vector3.zero;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            anim = gameObject.GetComponentInChildren<Animator>();
        }

        void Update()
        {
            // Get horizontal and vertical input
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            // Handle turning (rotate in place)
            if (horizontal != 0)
            {
                transform.Rotate(0, horizontal * turnSpeed * Time.deltaTime, 0);
            }

            if (controller.isGrounded)
            {
                // Forward/backward movement
                moveDirection = transform.forward * vertical * speed;

                // Update animation
                if (vertical != 0)
                {
                    anim.SetInteger("AnimationPar", 1); // Walking animation
                }
                else
                {
                    anim.SetInteger("AnimationPar", 0); // Idle animation
                }

                // Jumping
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);
                }
            }
            else
            {
                // Allow movement while airborne
                Vector3 airMovement = transform.forward * vertical * speed;
                moveDirection.x = airMovement.x;
                moveDirection.z = airMovement.z;

                // Optional: Update animation for airborne state (if you have a jump/fall animation)
                anim.SetInteger("AnimationPar", 2); // Example: Jump/fall animation
            }

            // Apply gravity
            moveDirection.y -= gravity * Time.deltaTime;

            // Move the controller
            controller.Move(moveDirection * Time.deltaTime);
        }
    }
}

