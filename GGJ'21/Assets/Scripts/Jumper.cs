using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float force;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>().velocity.y > 1.4f)
        {
            other.GetComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Impulse);
        }
    }
}
