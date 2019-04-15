using UnityEngine;
using System.Collections;
using System;

public class CanonShell : Projectile {

    public float explosionRange = 4f;
    public GameObject explosionEffect;

    void Awake()
    {
        damageAmount = 3;
        speed = 30f;
    }

	// Update is called once per frame
	void Update () {
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
        GameObject effect = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);
        Explode();
        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRange);
        foreach(Collider col in colliders)
        {
            if(col.tag == "Enemy")
            {
                col.gameObject.GetComponent<Enemy>().Damage(damageAmount);
            }
        }
    }
}
