﻿/*
SCRIPT TAKEN FROM: 
https://github.com/RedHenDev/Unity_scripts/blob/master/MouseLook_tut/MouseLook_tut/Assets/eyeLook.cs
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLook : MonoBehaviour
{
	// Mouse direction.
	public Vector2 mD;
    public float overRotateAngle = 10;

	// The capsule parent!
	//private Transform myBody;

	void Start () {

		//myBody = this.transform.parent.transform;

		Cursor.lockState = CursorLockMode.Locked;

	}
	

	void Update () {

		//bool clampMe = false;


		// Do we want to see mouse cursor again?
		if (Input.GetKey (KeyCode.Escape)) {
			Cursor.lockState = CursorLockMode.None;
		}


		float movement = Input.GetAxis ("Vertical");
		movement *= Time.deltaTime;

		// How much has the mouse moved?
		Vector2 mC = new Vector2
			(Input.GetAxisRaw ("Mouse X") * 3f,
				Input.GetAxisRaw("Mouse Y") * 3f);

		// To prevent over-rotation...
		if (this.transform.rotation.eulerAngles.x < overRotateAngle ||
			this.transform.rotation.eulerAngles.x > 360f-overRotateAngle) {
			mD += mC;
		} else
			mD.y -= mC.y * 3f;
		// Multiply by 3f in order to create a little 'bounce'
		// so that user does not rotate beyond threshold.

		Debug.Log 
		(this.transform.localRotation.eulerAngles.x + " <- my rotation :)");


//			myBody.localRotation =
//			Quaternion.AngleAxis (mD.x, Vector3.up);


	

		Quaternion qR = this.transform.localRotation =
						Quaternion.AngleAxis (mD.x, Vector3.up);

		// The actual rotation happening!
		this.transform.localRotation = qR *
					Quaternion.AngleAxis (-mD.y, Vector3.right);
			
		this.transform.Translate
			(Vector3.forward * movement);

	}
}
