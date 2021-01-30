using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemy : MonoBehaviour
{
    public GameObject arrow;

    public Transform shootPivot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot(Vector3 direction)
    {
        GameObject projectile = Instantiate(arrow, transform.position, shootPivot.rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = (projectile.transform.forward * 80f);

    }
}
