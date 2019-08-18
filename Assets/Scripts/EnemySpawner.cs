using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(RepeatedlySpawnEnemies());//start a co-routine
	}
	
    IEnumerator RepeatedlySpawnEnemies()  //coroutine
    {
        while (true)// forever
        {
            // spawn enemy
            print("Spawning");
            yield return new WaitForSeconds(secondsBetweenSpawns); // wait a few sec
        }

    }


}
