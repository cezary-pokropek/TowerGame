using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem goalParticle;

    // Use this for initialization
    void Start ()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }
	

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Start patrolling");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            //print("Patrolling" + " " + waypoint.name);
            yield return new WaitForSeconds(movementPeriod);

        };
        //print("Stop patrolling");
        SelfDestruct();
    }

    private void SelfDestruct()
    {
        var vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;

        Destroy(vfx.gameObject, destroyDelay);
        Destroy(gameObject); // the enemy
    }

}
