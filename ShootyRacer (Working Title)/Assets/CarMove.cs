using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour {
	
	Rigidbody RB;
	
	float Speed;
	public float Acceleration = 100;
	public float MaxSpeed = 50;
	public float RotSpeed = 2;
	
	public Transform Cam;
	
	public Vector3 Pos;
	public float CamSpeed = 5;
	
	void Start () {
		RB = GetComponent<Rigidbody>();
	}
	
	void Update () {
		Speed += (Input.GetAxis ("Vertical")-0.5f) * Time.deltaTime * Acceleration;
		Speed = Mathf.Clamp (Speed, 0, MaxSpeed);
		Vector3 GoForce = transform.forward * Speed;
		RB.velocity = new Vector3 (GoForce.x, RB.velocity.y, GoForce.z);
		RB.angularVelocity = transform.up * Input.GetAxis ("Horizontal")*(Mathf.Abs(Input.GetAxis ("Vertical")))*RotSpeed;
		
		Cam.position = Vector3.Lerp (Cam.position, transform.position+(transform.forward*Pos.z)+(transform.up*Pos.y), CamSpeed*Time.deltaTime);
		Cam.LookAt (transform.position);
	}
}
