using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnTarget : MonoBehaviour
{
    public int boxRange = 20;
    public TargetPrefab target;
    public System.Random random;

    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        if (random.Next(100) == 1)
        {
            TargetPrefab newTarget = Instantiate(target);
            float randX = random.Next(2 * boxRange);
            float randY = random.Next(2 * boxRange);
            float randZ = random.Next(2 * boxRange);
            newTarget.transform.position = new Vector3(boxRange - randX, boxRange - randY, boxRange - randZ);
        }
    }
}
