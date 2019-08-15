using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Waypoint> path;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(FollowPath());
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    IEnumerator FollowPath()
    {
        print("Start patrolling");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print("Patrolling" + " " + waypoint.name);
            yield return new WaitForSeconds(1f);

        };
        print("Stop patrolling");
    }
}
