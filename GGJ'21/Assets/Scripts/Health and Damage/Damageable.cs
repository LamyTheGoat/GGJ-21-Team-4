using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Damageable
{

    public void TakeDamage(float damage);
    
    public void TakeDamage(float damage, Vector3 attacker, float punchForce);

    public void Destroy();




}
