using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] bullets;
    public Vector3 rotation;

    public int spawnRateRange = 5;
    public int maxSpeedRange = 5;
    public int minSpeedRange = 2;

    void FixedUpdate()
    {
        if (Random.Range(0, spawnRateRange) == 1)
        {
            SpawnBullet();
        }
        
    }

    void SpawnBullet()
    {
        int RNG = Random.Range(0, 50);
        if (RNG == 0)
        {
            SpawnFriendly();
        }
        else//
        {
            GenericEnemy();
        }

        /*
        if(RNG == 2)
        {
            InverseEnemy();
        }
        if (RNG == 3)
        {
            ClockwiseEnemy()
        }
        if(RNG == 4)
        {
            AntiClockWiseEnemy();
        }*/
    }


    void GenericEnemy()
    {
        int speed = Random.Range(minSpeedRange, maxSpeedRange);   // RNG
        GameObject projectile = Instantiate(bullets[0]);
        projectile.transform.position = transform.position;
        projectile.GetComponent<Rigidbody2D>().velocity = rotation.normalized * speed;
    }


    void SpawnFriendly()
    {
        int speed = Random.Range(minSpeedRange, maxSpeedRange);    // RNG
        GameObject projectile = Instantiate(bullets[1]);
        projectile.transform.position = transform.position;
        projectile.GetComponent<Rigidbody2D>().velocity = rotation.normalized * speed;
    }
}
