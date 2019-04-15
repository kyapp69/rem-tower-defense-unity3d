using UnityEngine;
using System.Collections;

public class Tracker : MonoBehaviour {

    public static Transform[] wayPoints;

    void Awake()
    {
        wayPoints = new Transform[transform.childCount];
        for(int i=0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = transform.GetChild(i);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
