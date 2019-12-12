using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPrefab : MonoBehaviour
{
    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log("Get Triggered");
        anim.SetBool("Explode", true);
<<<<<<< HEAD
        // yield return new WaitForSeconds(5);
        // gameObject.destroy();
=======
>>>>>>> c16ca6a2f762a37c7ba3d578ef615084a8e2fa20
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
