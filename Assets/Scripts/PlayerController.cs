using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

	public Vector3 movement;
	public float verticalSpeedForce;
	public float horizontalSpeedForce;
	public float verticalSpeedAcceleration;
	public float horizontalSpeedAcceleration;
	public float verticalSpeedLinear;
	public float horizontalSpeedLinear;
	public Earth earth;
	public ControlType controlType;
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		 movement = new Vector3 ( moveVertical,0.0f,moveHorizontal);
		
		if(movement!=Vector3.zero)
		switch (controlType) {
		case ControlType.Acceleration:
			{
				Debug.Log ("Acceleration");
				earth.earthBody.AddTorque (-transform.up * moveVertical * verticalSpeedAcceleration,ForceMode.Acceleration);
				earth.earthBody.AddTorque (transform.forward * moveHorizontal* horizontalSpeedAcceleration,ForceMode.Acceleration);
				break;
			}
		case ControlType.Force:
			{
				Debug.Log ("Force");
				earth.earthBody.AddTorque (-transform.up * moveVertical * verticalSpeedForce,ForceMode.Force);
				earth.earthBody.AddTorque (transform.forward * moveHorizontal* horizontalSpeedForce,ForceMode.Force);
				break;
			}
		case ControlType.Linear:
			{
				Debug.Log ("Linear");
				earth.transform.Rotate (-Vector3.up, moveVertical * verticalSpeedLinear);
				earth.transform.Rotate (Vector3.forward, moveHorizontal * horizontalSpeedLinear);
				break;
			}
		case ControlType.Impulse:
			{
				Debug.Log ("Impulse");
				earth.earthBody.AddTorque (-transform.up * moveVertical * verticalSpeedForce,ForceMode.Impulse);
				earth.earthBody.AddTorque (transform.forward * moveHorizontal* horizontalSpeedForce,ForceMode.Impulse);
				break;
			}
		case ControlType.VelocityChange:
			{
				Debug.Log ("VelocityChange");
				earth.earthBody.AddTorque (-transform.up * moveVertical * verticalSpeedForce,ForceMode.VelocityChange);
				earth.earthBody.AddTorque (transform.forward * moveHorizontal* horizontalSpeedForce,ForceMode.VelocityChange);
				break;
			}
		}

	}

	public enum ControlType
	{
		Acceleration,

		Force,
		Linear,
		Impulse,
		VelocityChange
	}
}



