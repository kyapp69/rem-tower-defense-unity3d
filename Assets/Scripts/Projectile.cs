using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {

    public float speed;
    public Transform target;
    public int damageAmount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LockTarget(Transform _target)
    {
        target = _target;
    }
}
