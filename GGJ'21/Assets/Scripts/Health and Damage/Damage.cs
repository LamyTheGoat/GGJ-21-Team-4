using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    public float damage = 10;
    public float punchForce;

    public void Start()
    {
        if (parent == null)
        {
            parent = gameObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != parent && !other.CompareTag(parent.tag))
        {
            Damageable d = other.gameObject.GetComponent<Damageable>();
            if (d != null)
            {
                if (punchForce > 0)
                {
                    d.TakeDamage(damage, transform.position, punchForce);
                }
                else
                {
                    d.TakeDamage(damage);
                }
            }
        }
    }
}
