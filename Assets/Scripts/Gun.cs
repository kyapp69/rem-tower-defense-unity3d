using UnityEngine;
using System.Collections;

public class Gun : Tower {

	// Use this for initialization
	void Awake () {
        aimRange = 20f;
        shootRange = 18;
        reloadTime = 1f;
        angularSpeed = 3f;
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null)
            return;
        RotateHead();

        if(Vector3.Distance(target.position, transform.position) <= shootRange)
        {
            Shoot();
        }
        timer -= Time.deltaTime;
	}
}
