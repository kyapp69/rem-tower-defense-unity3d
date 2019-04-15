using UnityEngine;
using System.Collections;
using System;

public class Bullet : Projectile
{

    // Use this for initialization
    void Awake()
    {
        damageAmount = 1;
        speed = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().Damage(damageAmount);
        }
        
        Destroy(gameObject);
    }

}
