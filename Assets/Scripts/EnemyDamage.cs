using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] int hitPoints = 10;

    // Use this for initialization
    void Start()
    {

    }
    private void OnParticleCollision(GameObject other)
    {
        //print("I'm hit!");
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints -= 1;
        //print("Hit Points left: " + hitPoints);
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }


}