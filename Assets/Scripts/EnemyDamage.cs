using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem EnemyDeathParticlePrefab;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;

    AudioSource myAudioSource;

    // Use this for initialization
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
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
        hitParticlePrefab.Play();
        myAudioSource.PlayOneShot(enemyHitSFX);
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(EnemyDeathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;
        Destroy(vfx.gameObject, destroyDelay);
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position);

        Destroy(gameObject);
    }


}