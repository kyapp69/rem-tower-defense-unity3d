using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    public void PurchaseGun()
    {
        buildManager.SetTowerToBuild(buildManager.gunTurretPrefab);
    }

    public void PurchaseMachineGun()
    {
        buildManager.SetTowerToBuild(buildManager.machineGunTurretPrefab);
    }

    public void PurchaseCanon(){
        buildManager.SetTowerToBuild(buildManager.CanonPrefab);
    }

    // Use this for initialization
    void Start () {
        buildManager = BuildManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
