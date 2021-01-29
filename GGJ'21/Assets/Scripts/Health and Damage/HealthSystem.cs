using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, Damageable
{

    public GameObject deathPrefab;
    public int Hp;


    public void TakeDamage(float damage)
    {
        Hp -= (int)damage;
        if (Hp <= 0)
        {
            Destroy();
        }
    }

    public virtual void Destroy()
    {
        Instantiate(deathPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
