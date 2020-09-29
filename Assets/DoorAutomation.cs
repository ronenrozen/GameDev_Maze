using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorAutomation : MonoBehaviour
{
    public GameObject camera;
    public int threshold = 100;
    int isOutside = 1;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = camera.transform.position;
        Vector3 doorPosition = this.transform.position;
        float angleX = transform.rotation.eulerAngles.x; 
        float angleY = transform.rotation.eulerAngles.y; 
        float angleZ = transform.rotation.eulerAngles.z; 
        if (isClose(cameraPosition,doorPosition)){

            if (angleY < 0 || angleY > 90) {
                isOutside = isOutside * -1;
            }
            
            transform.Rotate(0f,10f * isOutside * Time.deltaTime,0f);
            
        }
    }

    bool isClose(Vector3 cameraPosition,Vector3 doorPosition )
    {
        return Math.Abs(cameraPosition.x - doorPosition.x) < threshold && Math.Abs(cameraPosition.y - doorPosition.y) < threshold && Math.Abs(cameraPosition.z - doorPosition.z) < threshold;
    }
}
