using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float speed;

    private Transform nextPoint;
    private int pointIndes = 0;

	// Use this for initialization
	void Start () {
        speed = Speed.speed;
        nextPoint = Tracker.wayPoints[0];
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = nextPoint.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(nextPoint.position, transform.position) <= 0.5f)
        {
            NextWaypoint();
        }
	}

    private void NextWaypoint()
    {
        pointIndes++;
        if (pointIndes >= Tracker.wayPoints.Length)
        {
            return;
        }
    
        nextPoint = Tracker.wayPoints[pointIndes];
    }
}
