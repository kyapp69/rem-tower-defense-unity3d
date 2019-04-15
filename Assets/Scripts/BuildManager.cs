using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {

    public static BuildManager Instance;

    // prefabs  
    public GameObject gunTurretPrefab;
    public GameObject machineGunTurretPrefab;
    public GameObject CanonPrefab;

    private GameObject towerToBuild;
    public bool buildMode = false;

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }

	// Use this for initialization
	void Awake () {
        // singleton
        Instance = this;
	}

    void Start()
    {
        // change this to UI based option later
        towerToBuild = gunTurretPrefab;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetTowerToBuild(GameObject tower)
    {
        towerToBuild = tower;
        buildMode = true;
    }
}
