using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HandScript : MonoBehaviour
{
    public bool enter = true;
    public bool stay = true;
    public bool exit = true;
    public float moveSpeed;
    public bool isGrab = false;

    public FoodPrefab thisFood;
    public AudioClip handGrab;
    
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Awake()
    {
        //// move and reduce the size of the cube
        //transform.position = new Vector3(0, 0.25f, 0.75f);
        //transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        //// add isTrigger
        //var boxCollider = gameObject.AddComponent<BoxCollider>();
        //boxCollider.isTrigger = true;

        //moveSpeed = 1.0f;

        //// create a sphere for this cube to interact with
        //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere.gameObject.transform.position = new Vector3(0, 0, 0);
        //sphere.gameObject.AddComponent<Rigidbody>();
        //sphere.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //sphere.gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed);
        //transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
            Debug.Log("entered: " + other.name);
            updateGrab(other);
        }
    }

    // stayCount allows the OnTriggerStay to be displayed less often
    // than it actually occurs.
    private float stayCount = 0.0f;
    private void OnTriggerStay(Collider other)
    {
        if (stay)
        {
            //if (stayCount > 0.25f)
            //{
                //Debug.Log("staying");
                stayCount = stayCount - 0.25f;
            updateGrab(other);
            //}
            //else
            //{
            //    stayCount = stayCount + Time.deltaTime;
            //}
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (exit)
        {
            Debug.Log("exit");
        }
    }

    private void updateGrab(Collider collisionObject)
    {
        // Check if button is down
        if (Input.GetButtonDown("Fire1"))
        {
            isGrab = true;
            // Create new stroke
            //currentStroke = Instantiate(strokePrefab);
        }
        else isGrab &= !Input.GetButtonUp("Fire1");

        // While the pen is drawing
        if (isGrab)
        {
            Debug.Log("GRAB");
            Debug.Log(collisionObject.name);
            audioSource.PlayOneShot(handGrab, 0.7F); 
            collisionObject.gameObject.transform.position = transform.position;
            //// Get a reference to the line renderer
            //LineRenderer line = currentStroke.GetComponent<LineRenderer>();

            //// Automatically add a point if there are no positions
            //if (line.positionCount == 0)
            //{
            //    line.positionCount += 1;
            //    line.SetPosition(line.positionCount - 1, transform.position);
            //}
            //else
            //{
            //    // Get a reference to the last point added
            //    Vector3 lastPosition = line.GetPosition(line.positionCount - 1);
            //    // compute a vector that points from the last position to the current position
            //    Vector3 distanceVec = transform.position - lastPosition;

            //    // Add a point if the current position is far enough away
            //    if (distanceVec.sqrMagnitude > minDistance * minDistance)
            //    {
            //        line.positionCount += 1;
            //        line.SetPosition(line.positionCount - 1, transform.position);
            //    }
            //}
        }
    }
}
//using UnityEngine;

//public class Example : MonoBehaviour
//{
//    // Destroy everything that enters the trigger
//    void OnTriggerEnter(Collider other)
//    {
//        Destroy(other.gameObject);
//    }
//}