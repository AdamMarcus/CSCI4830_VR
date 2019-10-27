using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public GameObject parent;
	private int targetLayer = 1 << 8; // Layer 8 (targets)
	private static bool fireIsDown = false;
	private static Vector3 lastRaycastHit;
	public CapsulePrefab teleLocation;
	public CapsulePrefab tempTele;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetAxis("Horizontal") != 0)
		{
			// Move the attached parent based on the right vector of this object multiplied by the horizontal axis value
			parent.transform.position += (transform.right) * Input.GetAxis("Horizontal") / 4;
		}

		if (Input.GetAxis("Vertical") != 0)
		{
			// Move the attached parent based on the right vector of this object multiplied by the horizontal axis value
			parent.transform.position += (transform.forward) * Input.GetAxis("Vertical") / 4;
		}



        // User pressed the button, raycast to create the indicator and set button press down.
		if (Input.GetAxis("Fire1") == 1 && !fireIsDown)
		{
			// The Unity raycast hit object, which will store the output of our raycast

			RaycastHit hit;
			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			// Does the ray intersect any objects excluding the player layer
			// Parameters: position to start the ray, direction to project the ray, output for raycast, limit of ray length, and layer mask
			if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, targetLayer))
			{
				// The object we hit will be in the collider property of our hit object.
				// We can get the name of that object by accessing it's Game Object then the name property
				Debug.Log(hit.collider.gameObject.name);
				
				Debug.Log("Initial Hit");
				Debug.Log(hit.point.x + ", " + hit.point.y);

				tempTele = Instantiate(teleLocation);
				updateLastRaycastHit(hit);
				tempTele.transform.position = lastRaycastHit;
				fireIsDown = true;
			}
			else
			{
				Debug.Log("No initial Hit");
			}
		}



        // User is holding the button down, move the indicator
		if (Input.GetAxis("Fire1") == 1 && fireIsDown)
		{
			Debug.Log("Held Down Fire");

			// The Unity raycast hit object, which will store the output of our raycast

			RaycastHit hit;
			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			// Does the ray intersect any objects excluding the player layer
			// Parameters: position to start the ray, direction to project the ray, output for raycast, limit of ray length, and layer mask
			if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, targetLayer))
			{
				// The object we hit will be in the collider property of our hit object.
				// We can get the name of that object by accessing it's Game Object then the name property
				Debug.Log(hit.collider.gameObject.name);

				Debug.Log("Moved hit");
				Debug.Log(hit.point.x + ", " + hit.point.y);

                updateLastRaycastHit(hit);				

				tempTele.transform.position = lastRaycastHit;
			}
			else
			{
				Debug.Log("No moved Hit");
			}

		}



        // User has released the button, teleport and destroy indicator
		if (Input.GetAxis("Fire1") == 0 && fireIsDown)
		{
			Debug.Log("Released Fire Button");
			parent.transform.position = lastRaycastHit;
			Debug.Log("Teleported");
			Debug.Log(lastRaycastHit);

			Destroy(tempTele.gameObject);

			fireIsDown = false;
		}
	}

    void updateLastRaycastHit(RaycastHit hit)
	{
		lastRaycastHit = new Vector3(hit.point.x, hit.point.y + 1.0f, hit.point.z);
	}
}
