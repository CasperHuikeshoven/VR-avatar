using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float startVelocity = 0f; 
    float velocity = 0f;
    public float gravity = 9.8f;
    public bool gravityOn = false;
    
    void Start()
    {
        //When the bullet gets spawned the velocity gets set to the start velocity
        velocity = startVelocity;

    }

    void Update()
    {  
        //Every frame the bullet goes forward and down if grafityOn is true
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
        if(gravityOn)transform.Translate(Vector3.down * gravity * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other){

        Debug.Log("Huts");

        //If the bullet hits an Object with tag Environment the bullet gets destroyed
        if(other.CompareTag("Environment")){

            Destroy(gameObject);
            
        }
        

    }
}
