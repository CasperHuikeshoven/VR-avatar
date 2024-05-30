using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTracking : MonoBehaviour
{
    
    public GameObject prefabToSpawn;
    public GameObject leftHand;
    public GameObject rightHand;

    float deltaTime;
    
    void Update()
    {
        deltaTime+= Time.deltaTime;
        if(deltaTime >= 1/20){
            SpawnAtHand(leftHand);
            SpawnAtHand(rightHand);
            deltaTime = 0;
        }
    }

    public void SpawnAtHand(GameObject hand){
        GameObject spawnedObject = Instantiate(prefabToSpawn);
        spawnedObject.transform.position = hand.transform.position;
        Destroy(spawnedObject, 0.1f);
    }
}
