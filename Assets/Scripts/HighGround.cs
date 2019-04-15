using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class HighGround : MonoBehaviour {

    private Color defaultColor;
    public Color hoverColor;
    private Renderer rend;
    private GameObject tower;
    private Vector3 offset = new Vector3(0, 1.52f, 0);

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            // pointer is over our UI and should not be considered in world space
            return;
        }

        if (BuildManager.Instance.buildMode == true)
        {
            rend.material.color = hoverColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = defaultColor;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            // pointer is over our UI and should not be considered in world space
            return;
        }

        if(tower != null)
        {
            // already build a tower on this ground
            BuildManager.Instance.buildMode = false;
            return;
        }

        if(BuildManager.Instance.buildMode == true)
        {
            Gold goldManager = GameObject.Find("Gold Manager").GetComponent<Gold>();
            GameObject towerToBuild = BuildManager.Instance.GetTowerToBuild();
            bool flag = goldManager.checkGold(towerToBuild);
            if (flag)
            {
                goldManager.reduceMoney(towerToBuild);
                tower = (GameObject)Instantiate(towerToBuild, transform.position + offset, transform.rotation);
                BuildManager.Instance.buildMode = false;
            } else
            {
                StartCoroutine(goldManager.writeWarning());
            }
        }
       
    }

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void LitTile()
    {
        rend.material.color = hoverColor;
    }
}
