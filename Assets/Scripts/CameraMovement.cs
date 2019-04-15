using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float speed = 10f;
    private float xmin = -70.0f;
    private float xmax = 4.0f;
    private float zmin = -40.0f;
    private float zmax = 23.0f;

	// Update is called once per frame
	void Update () {

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
        
        // check the device orientation
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
        {
            float xDir = -Input.acceleration.y * 0.5f;
            Vector3 dir = new Vector3(xDir, 0.0f, 0.0f);
            transform.Translate(dir, Space.World);
        } else if (Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            float xDir = Input.acceleration.y * 0.5f;
            Vector3 dir = new Vector3(xDir, 0.0f, 0.0f);
            transform.Translate(dir, Space.World);
        }

        // move the camera by tilting the phone
        movement = new Vector3(Input.acceleration.x, 0.0f, Input.acceleration.y);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        if (this.transform.position.x < xmin)
        {
            transform.position = new Vector3(xmin, transform.position.y, transform.position.z);
        }
        if (this.transform.position.z < zmin)
        {
            transform.position = new Vector3(this.transform.position.x, this.transform.position.y, zmin);
        }
        if (this.transform.position.x > xmax)
        {
            transform.position = new Vector3(xmax, this.transform.position.y, this.transform.position.z);
        }
        if (this.transform.position.z > zmax)
        {
            transform.position = new Vector3(this.transform.position.x, this.transform.position.y, zmax);
        }
    }
}
