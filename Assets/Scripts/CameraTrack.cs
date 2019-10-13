using UnityEngine;
using System.Collections;

public class CameraTrack : MonoBehaviour
{
      public float turnSpeed = 50f;
      public float slower = 0.5f;
    
	void Update ()
    {
       if(Input.GetKey(KeyCode.UpArrow))
            transform.Rotate(Vector3.right, -turnSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.DownArrow))
            transform.Rotate(Vector3.right, turnSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

	if(Input.GetKey(KeyCode.Z))
      	    GetComponent<Camera>().fieldOfView = GetComponent<Camera>().fieldOfView+1;
	
	if(Input.GetKey(KeyCode.X))
      	    GetComponent<Camera>().fieldOfView = GetComponent<Camera>().fieldOfView-1;

	
    }
}