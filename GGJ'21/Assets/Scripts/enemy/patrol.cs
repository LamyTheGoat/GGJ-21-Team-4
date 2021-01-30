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
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (groundInfo.collider == false)
            {
                if (movingR == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingR = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingR = true;
                }
            }
        }
    }

    private void chasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.Translate(Vector2.right * ChaseSpeed * Time.deltaTime);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            transform.Translate(Vector2.right * ChaseSpeed * Time.deltaTime);

        }

    }
}
