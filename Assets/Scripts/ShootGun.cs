using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootGun : MonoBehaviour
{

    public float bulletVelocity = 0f;
    public Transform spawnPoint;
    public GameObject bullet;
    public ParticleSystem muzzleFlash;
    public AudioSource gunSound;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireBullet(ActivateEventArgs arg){
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletVelocity;
        muzzleFlash.Play();
        gunSound.Play();
        Destroy(spawnedBullet, 5);
        
    }
}

