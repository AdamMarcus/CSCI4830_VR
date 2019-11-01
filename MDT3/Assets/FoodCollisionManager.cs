using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class FoodCollisionManager : MonoBehaviour
{
    public FoodPrefab thisFood;
    public AudioClip foodCollideGood;
    public AudioClip foodCollideBad;
    
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log(collisionInfo.collider.name);
        Debug.Log("--------------------------");
        thisFood = gameObject.GetComponent<FoodPrefab>();
        if (thisFood.destTable == collisionInfo.collider.name)
        {
            Debug.Log("DESTROY FOOD, COLLISION");
            audioSource.PlayOneShot(foodCollideGood, 0.7F); 
            System.Threading.Thread.Sleep(500);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Not collision dest: " + collisionInfo.collider.name);
            audioSource.PlayOneShot(foodCollideBad, 0.7F);
        }
        Debug.Log("--------------------------");
    }
}
