using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMonitor : MonoBehaviour
{
	// Will be used to store a reference to the text mesh component
	private TextMesh textMesh;

	// Use this for initialization
	void Start()
	{
		// Get the instance of the TextMesh component on this game object and store it
		textMesh = gameObject.GetComponentInChildren<TextMesh>();
	}

    void Update()
	{
		//ResetLogMessage();
		//Debug.Log("Hello Debug");
		//Joystick left = 0 -> -1
		//Joystick right = 0 -> 1
		if (Input.GetAxis("Horizontal") != 0)
			Debug.Log("Horizontal: " + Input.GetAxis("Horizontal"));
		//Joystick up = 0 -> 1
		//Joystick down = 0 -> -1
		if (Input.GetAxis("Vertical") != 0)
			Debug.Log("Vertical: " + Input.GetAxis("Vertical"));
		//Joystick up = 0 -> 1
		//Joystick down = 0 -> -1
		if (Input.GetAxis("Fire1") != 0)
			Debug.Log("Fire1: " + Input.GetButtonDown("Fire1"));
		//Joystick up = 0 -> 1
		//Joystick down = 0 -> -1
		if (Input.GetAxis("Fire2") != 0)
			Debug.Log("Fire2: " + Input.GetAxis("Fire2"));
		//Joystick up = 0 -> 1
		//Joystick down = 0 -> -1
		if (Input.GetAxis("Fire3") != 0)
			Debug.Log("Fire3: " + Input.GetAxis("Fire3"));
		//Joystick up = 0 -> 1
		//Joystick down = 0 -> -1
		if (Input.GetAxis("Jump") != 0)
			Debug.Log("Jump: " + Input.GetButtonDown("Jump"));
		//Joystick up = 0 -> 1
		//Joystick down = 0 -> -1
		if (Input.GetAxis("Mouse X") != 0)
			Debug.Log("Mouse X: " + Input.GetAxis("Mouse X"));
		//Joystick up = 0 -> 1
		//Joystick down = 0 -> -1
		if (Input.GetAxis("Mouse Y") != 0)
			Debug.Log("Mouse Y: " + Input.GetAxis("Mouse Y"));
		//Joystick up = 0 -> 1
		//Joystick down = 0 -> -1
		if (Input.GetAxis("Mouse ScrollWheel") != 0)
			Debug.Log("Mouse ScrollWheel: " + Input.GetAxis("Mouse ScrollWheel"));
		//Joystick up = 0 -> 1
		//Joystick down = 0 -> -1if (!= 0)
		if (Input.GetAxis("Submit") != 0)
			Debug.Log("Submit: " + Input.GetAxis("Submit"));
		//Joystick up = 0 -> 1
		//Joystick down = 0 -> -1
		if (Input.GetAxis("Cancel") != 0)
			Debug.Log("Cancel: " + Input.GetAxis("Cancel"));

		//string temp = Input.inputString;
		//if (temp != " ")
		//	//ResetLogMessage();
		//	Debug.Log(temp);

		//Trigger key = 1
	}

	//Called by Unity when this object is enabled in the scene
	void OnEnable()
	{
		// Attach the LogMessage function as a callback for the logMessageReceived event in Unity
		Application.logMessageReceived += LogMessage;
	}

	// Called by Unity when this object is disabled in the scene
	void OnDisable()
	{
		Application.logMessageReceived -= LogMessage;
	}

	public void LogMessage(string message, string stackTrace, LogType type)
	{
		// Set the text 
		//textMesh.text = textMesh.text + "\n" + message;
		textMesh.text = message;
	}

	public void ResetLogMessage()
	{
		// Set the text 
		textMesh.text = "";
	}
}
