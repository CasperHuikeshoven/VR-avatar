using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectConnector : MonoBehaviour
{

    public Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion cameraRotation = cameraTransform.rotation;
        Quaternion yRotation = Quaternion.Euler(0f, cameraRotation.eulerAngles.y, 0f);
        transform.rotation = yRotation;
        
        Vector3 cameraXZ = cameraTransform.position;
        Vector3 newPosition = new Vector3(cameraXZ.x, transform.position.y, cameraXZ.z);
        transform.position = newPosition;
    }
}
