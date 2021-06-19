using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace F
{
    public class Anima : MonoBehaviour
    {
        Animator animator;
        private CharacterController characterController;

        private void Start()
        {
            animator = GetComponent<Animator>();
            characterController = GetComponent<CharacterController>();
        }
        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("StandardWalk", true);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                animator.SetBool("StandardWalk", false);
            }
            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("LeftWalk", true);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                animator.SetBool("LeftWalk", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("BackWalk", true);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {

                animator.SetBool("BackWalk", false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("RightWalk", true);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("RightWalk", false);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("Dash", true);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                animator.SetBool("Dash", false);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("Jump", true);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("Jump", false);
            }

        }
    }
}