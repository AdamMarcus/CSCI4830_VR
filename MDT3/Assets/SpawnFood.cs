using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnFood : MonoBehaviour
{
    public float bowlXRange = 1f;
    public float bowlYRange = 3.8f;
    public float bowlZRange = -3.7f;
    //public BowlPrefab newBowl;
    //public FoodPrefab food;
    public PiePrefab pie;
    public CakePrefab cake;
    public WatermellonPrefab watermellon;
    public BreadPrefab bread;
    //public FoodPrefab food;
    public System.Random random;

    private int maxBowlCount = 20;

    private int bowlCount = 0;

    private int bowlIDIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();
        bowlXRange = gameObject.transform.position.x;
        bowlYRange = gameObject.transform.position.y;
        bowlZRange = gameObject.transform.position.z;
}

    // Update is called once per frame
    void Update()
    {
        if (random.Next(200) == 1 && bowlCount <= maxBowlCount)
        {
            int destTableNum = random.Next(1, 5);

            FoodPrefab newFood;

            if (destTableNum == 1)
            {
                
                newFood = Instantiate(pie);
            }
            else if (destTableNum == 2)
            {
                newFood = Instantiate(bread);
            }
            else if (destTableNum == 3)
            {
                newFood = Instantiate(cake);
            }
            else
            {
                newFood = Instantiate(watermellon);
            }

            newFood.name = "Bowl " + bowlIDIndex;
            newFood.destTable = "Table" + destTableNum;
            float randX = random.Next(-3, 3);
            float randY = random.Next(1);
            float randZ = random.Next(0, 1);
            newFood.transform.position = new Vector3(bowlXRange - randX + .5f, bowlYRange, bowlZRange - randZ + .5f);

            bowlIDIndex += 1;
            bowlCount += 1;
        }
    }
}
