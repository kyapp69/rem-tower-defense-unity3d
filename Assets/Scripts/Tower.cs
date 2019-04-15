using UnityEngine;
using System.Collections;

public abstract class Tower : MonoBehaviour {

    public Transform target;
    public float aimRange;
    public float shootRange;
    public float reloadTime;
    public float angularSpeed;
    private string enemyTag = "Enemy";
    public Transform head;      
    public float timer = 0f;

    public GameObject projectilePrefab;
    public Transform firePoint;

    void Start()
    {
        // find target from time = 0s for every 0.5s instead of every frame
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, aimRange);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDis = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float dis = Vector3.Distance(transform.position, enemy.transform.position);
            if(dis <= aimRange && dis < shortestDis)
            {
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    public void RotateHead()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion rotateDir = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(head.rotation, rotateDir, Time.deltaTime * angularSpeed).eulerAngles;
        head.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    public void Fire()
    {
        GameObject bulletGO = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation) as GameObject;
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.LockTarget(target);
        }
        GameObject.Destroy(bulletGO, 2f);
    }

    public void Shoot()
    {
        if (timer <= 0f)
        {
            Fire();
            timer = reloadTime;
        }
    }

}
