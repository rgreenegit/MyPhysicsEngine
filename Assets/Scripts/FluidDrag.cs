using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidDrag : MonoBehaviour {

	[Range(0, 2f)]
	public float velocityExponent;		// [none]

	public float dragConstant;			// ??

	private PhysicsEngine physicsEngine;

	// Use this for initialization
	void Start () {
		physicsEngine = GetComponent<PhysicsEngine>();
	}

	void FixedUpdate () {
		Vector3 velocityVector = physicsEngine.velocityVector; // current velocity
		float speed = velocityVector.magnitude; // current speed
		float dragSize = CalculateDrag(speed); // drag for current speed
		Vector3 dragVector = dragSize * -velocityVector.normalized; // drag in opposite direction to current velocity
		physicsEngine.AddForce (dragVector); // apply drag force
	}

	float CalculateDrag(float speed){
		return dragConstant * Mathf.Pow(speed, velocityExponent);
	}
}
