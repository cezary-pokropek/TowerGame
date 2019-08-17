using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Start patrolling");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            //print("Patrolling" + " " + waypoint.name);
            yield return new WaitForSeconds(1f);

        };
        print("Stop patrolling");
    }
}
