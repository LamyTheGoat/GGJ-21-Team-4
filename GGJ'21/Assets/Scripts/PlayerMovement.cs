using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMove;
    public float moveSpeed = 40f;
    private CharacterController2D charController;
    private bool jump;
    public ParticleSystem dust;

    private void Start()
    {
        charController = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        if(Input.GetKeyDown((KeyCode.Space)))
        {
            CreateDust();
            jump = true;
        }

    }

    private void FixedUpdate()
    {
        charController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
    private void CreateDust()
    {
        dust.Play();
    }
}
