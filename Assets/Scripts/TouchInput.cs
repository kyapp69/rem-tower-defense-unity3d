using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchInput : MonoBehaviour
{
    // Display text for Checking Changes
    //public Text DisplayText;

    //First/Last finger position
    Vector3 fp, lp;

    //Distance needed for a swipe to take some Action
    public float distance = 20;
    public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
    public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.

    public float speed = 30f;

    // boundary of the map
    private float maxFieldOfView = 65.0f;
    private float minFieldOfView = 15.0f;


    void Update()
    {
        //Check the touch inputs
        if (Input.touchCount == 2)
        {
            // 2 input means we handle gesture for zooming

            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;



            float temp = GetComponent<Camera>().fieldOfView + (deltaMagnitudeDiff * perspectiveZoomSpeed);

            // checking the boundary for zoom in and zoom out
            if (temp >= maxFieldOfView)
            {
                GetComponent<Camera>().fieldOfView = maxFieldOfView;

                GetComponent<Camera>().fieldOfView = Mathf.Clamp(GetComponent<Camera>().fieldOfView, 0.1f, 179.9f);
            }
            else if (temp <= minFieldOfView)
            {
                GetComponent<Camera>().fieldOfView = minFieldOfView;

                GetComponent<Camera>().fieldOfView = Mathf.Clamp(GetComponent<Camera>().fieldOfView, 0.1f, 179.9f);
            }
            else
            {
                // Otherwise change the field of view based on the change in distance between the touches.
                GetComponent<Camera>().fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

                // Clamp the field of view to make sure it's between 0 and 180.
                GetComponent<Camera>().fieldOfView = Mathf.Clamp(GetComponent<Camera>().fieldOfView, 0.1f, 179.9f);
            }
        }

        else
        {
            // handle for tap

            foreach (Touch touch in Input.touches)
            {
                RaycastHit hit = new RaycastHit();
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit))
                    hit.transform.gameObject.SendMessage("LitTile");
                                   
            }
        }
    }
}