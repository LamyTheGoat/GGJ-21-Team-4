using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{
    public float speed=2;
    public float ChaseSpeed=4;
    public float agroRange=5;
    public Transform player;
    private bool movingR = true;
    public Transform groundDetection;
    private CharacterController2D charController;

    private void Start()
    {
        charController = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f, LayerMask.GetMask("GroundAndPatrol"));

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer < agroRange)
        {
            if (distanceToPlayer < 2) 
            { 
                Debug.Log("!!!"); 
            }
            else
            {
                if (groundInfo.collider == true)
                {
                    chasePlayer();

                }

            }
        }
        else
        {

            if (groundInfo.collider == false)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            }
            charController.Move(transform.localScale.x/Mathf.Abs(transform.localScale.x) *speed * Time.fixedDeltaTime, false, false);
        }
    }

    private void chasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            int coef = transform.localScale.x < 0 ? -1 : 1;
            transform.localScale = new Vector3(transform.localScale.x * coef, transform.localScale.y, transform.localScale.z);
            
        }
        else
        {
            int coef = transform.localScale.x > 0 ? -1 : 1;
            transform.localScale = new Vector3(transform.localScale.x * coef, transform.localScale.y, transform.localScale.z);

        }
        charController.Move(transform.localScale.x/Mathf.Abs(transform.localScale.x) * ChaseSpeed * Time.fixedDeltaTime, false, false);

    }
}
