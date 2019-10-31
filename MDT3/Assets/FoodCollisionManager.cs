using UnityEngine;

public class FoodCollisionManager : MonoBehaviour
{
    public FoodPrefab thisFood;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log(collisionInfo.collider.name);
        Debug.Log("--------------------------");
        thisFood = gameObject.GetComponent<FoodPrefab>();
        if (thisFood.destTable == collisionInfo.collider.name)
        {
            Debug.Log("DESTROY FOOD, COLLISION");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Not collision dest: " + collisionInfo.collider.name);
        }
        Debug.Log("--------------------------");
    }
}
