using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform partOfRoation;

    public float range;

    private string enemyTag = "Enemy";

    private Transform target;

    public float turnSpeed = 10f;

    public GameObject bulletPrefabs;

    public Transform firepoint;

    public float fireRate = 1f;

    private float fireCountdown = 0f;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        Vector3 dir = target.position - transform.position;
        Quaternion lookRoation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partOfRoation.rotation, lookRoation, Time.deltaTime*turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y , 0f);

        if (fireCountdown <= 0 && Vector3.Distance(target.position, transform.position) <= range)
        {
            Shoot();
            fireCountdown = fireRate;
        }
        fireCountdown -= Time.deltaTime;

        if(Vector3.Distance(target.position, transform.position) >= range)
        {
            target = null;
        }
    }

    private void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefabs, firepoint.position, firepoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        GameObject nearestTarget = null;

        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if ( distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestTarget = enemy;
            }
        }

        if(nearestTarget != null && shortestDistance <= range)
        {
            Debug.Log(nearestTarget.name);
            target = nearestTarget.transform;
        }

    }
}
