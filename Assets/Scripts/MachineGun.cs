using UnityEngine;
using System.Collections;

public class MachineGun : Tower
{
    // Use this for initialization
    void Awake()
    {
        aimRange = 14f;
        shootRange = 12;
        reloadTime = 0.4f;
        angularSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (target == null)
            return;
        RotateHead();

        if (Vector3.Distance(target.position, transform.position) <= shootRange)
        {
            Shoot();
        }     
    }

}
