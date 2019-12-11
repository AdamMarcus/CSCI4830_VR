using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private LineRenderer lr;
    public HitMarkerPrefab hm;

    public int bombDropHeight;

    public BombPrefab bomb;

    public HitMarkerPrefab newHM;
    
    // Start is called before the first frame update
    void Start()
    {
        lr.GetComponent<LineRenderer>();

        // newHM = Instantiate(hm);
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        RaycastHit hit;   
        // lr.SetPosition(0, tip of laser pointer);
        if (Physics.Raycast(transform.position, transform.forward, out hit)) {
            Debug.Log("Raycast hit");
            if (hit.collider) {
                Debug.Log("Hit collide");

                // Get dist from laser
                float h1 = Mathf.Sqrt(Mathf.Pow(hit.point.x, 2) + Mathf.Pow(hit.point.y, 2));
                float h2 = Mathf.Sqrt(Mathf.Pow(h1, 2) + Mathf.Pow(hit.point.z, 2));
                
                //Move point a little closer so it does not appear inside the surface it is contacting
                Vector3 destHelmetPoint = new Vector3(0, 0, h2 + 1f);

                lineRenderer.SetPosition(1, destHelmetPoint);
                Debug.Log("Set Point:" + destHelmetPoint);

                // HitMarkerPrefab newHM = Instantiate(hm);
                newHM.transform.position = hit.point;
                newHM.gameObject.SetActive(true);

                if (Input.GetButtonDown("Fire1"))
                {
                    BombPrefab newBomb = Instantiate(bomb);
                    // Vector3 bombPos = 
                    newBomb.transform.position = new Vector3(hit.point.x, bombDropHeight, hit.point.z);
                }
            }
            
        }
        else {
            Debug.Log("No Hit");
            lineRenderer.SetPosition(1, new Vector3(0, 0, 90000));
            newHM.gameObject.SetActive(false);
        }
    }
}
