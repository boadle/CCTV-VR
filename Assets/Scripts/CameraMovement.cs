﻿using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private float speed = 2.0f;
	private float zoomSpeed = 2.0f;

	public float minX = -360.0f;
	public float maxX = 360.0f;
	
	public float minY = -45.0f;
	public float maxY = 45.0f;

    public float minZ = -45.0f;
    public float maxZ = 45.0f;

    public float sensX = 100.0f;
    public float sensY = 100.0f;
    public float sensZ = 100.0f;
	
	float rotationX = 0.0f;
	float rotationY = 0.0f;
    float rotationZ = 0.0f;

    void Update () {

		//float scroll = Input.GetAxis("Mouse ScrollWheel");
		//transform.Translate(0, scroll * zoomSpeed, scroll * zoomSpeed, Space.World);

		//if (Input.GetKey(KeyCode.RightArrow)){
		//	transform.position += Vector3.right * speed * Time.deltaTime;
		//}
		//if (Input.GetKey(KeyCode.LeftArrow)){
		//	transform.position += Vector3.left * speed * Time.deltaTime;
		//}
		//if (Input.GetKey(KeyCode.UpArrow)){
		//	transform.position += Vector3.forward * speed * Time.deltaTime;
		//}
		//if (Input.GetKey(KeyCode.DownArrow)){
		//	transform.position += Vector3.back * speed * Time.deltaTime;
		//}
//
		if (Input.GetMouseButton (1)) {
			rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
           // rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;
        //    rotationZ += Input.GetAxis ("Mouse Y") * sensZ * Time.deltaTime;
		//	rotationZ = Mathf.Clamp (rotationZ, minZ, maxZ);
			transform.localEulerAngles = new Vector3 (-rotationZ, rotationX, 0);
		}
	}
}
