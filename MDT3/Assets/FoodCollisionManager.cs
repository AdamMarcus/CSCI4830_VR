using UnityEngine;

public class FoodCollisionManager : MonoBehaviour
{
    public BowlPrefab thisBowl;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log(collisionInfo.collider.name);
        Debug.Log("--------------------------");
        thisBowl = gameObject.GetComponent<BowlPrefab>();
        if (thisBowl.destTable == collisionInfo.collider.name)
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
