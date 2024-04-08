using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBending : MonoBehaviour
{

    public GameObject rock;
    public GameObject wall;
    public Transform rockSpawnPoint;
    public Transform wallSpawnPoint;
    public bool rightShootHand; 
    public bool leftShootHand;
    public bool rightWallHand; 
    public bool leftWallHand;
    public GameObject lastSpawnedWall;
    
    public float delayTime = 0f;
    public float wallDelayTime = 0f;
    public float rockVelocity = 3f;
    public float wallShootDelay = 0f;

    float leftRockShootTimer = 0f;
    float rightRockShootTimer = 0f;

    float leftWallTimer = 0f;
    float rightWallTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(leftWallHand && rightWallHand) delayTime = 0;
        if(rightShootHand && leftShootHand && delayTime < 0.5f )SpawnRock();
        if(rightWallHand && leftWallHand && wallDelayTime < 0 && rightWallTimer < 0.5f && leftWallTimer < 0.5f)SpawnWall();
        delayTime += Time.deltaTime;
        wallDelayTime -= Time.deltaTime;
        rightRockShootTimer += Time.deltaTime;
        leftRockShootTimer += Time.deltaTime;
        leftWallTimer += Time.deltaTime;
        rightWallTimer += Time.deltaTime;
        wallShootDelay += Time.deltaTime;
    }


    public void SpawnRock(){
        if(wallShootDelay<1f)lastSpawnedWall.GetComponent<Rigidbody>().velocity = rockSpawnPoint.forward * rockVelocity * 3;
        else{
            GameObject spawnedRock = Instantiate(rock);
            spawnedRock.transform.position = rockSpawnPoint.position;
            Quaternion spawnPointRotation = rockSpawnPoint.rotation;
            Quaternion yRotation = Quaternion.Euler(0f, spawnPointRotation.eulerAngles.y, 0f);
            spawnedRock.transform.rotation = yRotation;
            spawnedRock.GetComponent<Rigidbody>().velocity = rockSpawnPoint.forward * rockVelocity * ((1/delayTime)/20);
            delayTime = 1f;
            Destroy(spawnedRock, 5);
        }
    } 

    public void SpawnWall(){
        wallShootDelay = 0;
        wallDelayTime = 1f;
        GameObject spawnedWall = Instantiate(wall);
        spawnedWall.transform.position = wallSpawnPoint.position;
        Quaternion spawnPointRotation = wallSpawnPoint.rotation;
        Quaternion yRotation = Quaternion.Euler(0f, spawnPointRotation.eulerAngles.y, 0f);
        spawnedWall.transform.rotation = yRotation;
        lastSpawnedWall = spawnedWall;
        Destroy(spawnedWall, 10);
    }

    public void setLeftStartHand(bool b){
        leftWallHand = b;
    }

    public void setRightStartHand(bool b){
        rightWallHand = b;
    }

    public void setLeftEndHand(bool b){
        leftShootHand = b;
    }

    public void setRightEndHand(bool b){
        rightShootHand = b;
    }

    public void setLeftWallHand(bool b){
        leftWallTimer = 0;
        wallDelayTime = 0;
    }

    public void setRightWallHand(bool b){
        rightWallTimer = 0;
        wallDelayTime = 0;
    }

    

}
