using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, Damageable
{

    public GameObject deathPrefab;
    public int Hp;


    public void TakeDamage(float damage, Vector3 attacker, float punchForce)
    {
        Hp -= (int)damage;
        Vector3 flyDirection = (transform.position-attacker).normalized ;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(flyDirection.x, flyDirection.y) * punchForce, ForceMode2D.Impulse);
        if (Hp <= 0)
        {
            Destroy();
        }
    }
    
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
