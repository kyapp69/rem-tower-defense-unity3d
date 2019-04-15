using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour
{

    void OnMouseDown()
    {
        BuildManager.Instance.buildMode = false;
    }
}
