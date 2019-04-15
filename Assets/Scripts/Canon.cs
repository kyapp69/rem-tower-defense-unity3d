using UnityEngine;
using System.Collections;

public class Canon : Tower
{

    // Use this for initialization
    void Awake()
    {
        aimRange = 19f;
        shootRange = 17;
        reloadTime = 6f;
        angularSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        RotateHead();

        if (Vector3.Distance(target.position, transform.position) <= shootRange)
        {
            Shoot();
        }
        timer -= Time.deltaTime;
    }

    public new void Shoot()
    {
        if (timer <= 0f)
        {
            Fire();
            timer = reloadTime;
        }
    }

    public new void Fire()
    {
        GameObject shellGO = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation) as GameObject;
        CanonShell shell = shellGO.GetComponent<CanonShell>();

        if (shell != null)
        {
            shell.LockTarget(target);
        }
        GameObject.Destroy(shellGO, 2f);
    }


}
