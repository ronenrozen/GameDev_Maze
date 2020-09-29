using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MotionDoorLeft : MonoBehaviour
{
    public GameObject camera;
    public GameObject door;
    public int threshold = 20;
    int isOutside = 1;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        door = GameObject.FindGameObjectWithTag("leftDoor");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = camera.transform.position;

        Vector3 doorPosition = this.transform.position;

        if (isClose(cameraPosition,doorPosition)) {

            if (doorPosition.x < -20 || doorPosition.x > -10) {
                isOutside = isOutside * - 1;
            }
            Vector3 newPos =  new Vector3(4f * isOutside * Time.deltaTime,0,0); 
            door.transform.position += newPos; 
            
        }
    }

    bool isClose(Vector3 cameraPosition,Vector3 doorPosition )
    {
        return Math.Abs(cameraPosition.x - doorPosition.x) < threshold && Math.Abs(cameraPosition.y - doorPosition.y) < threshold && Math.Abs(cameraPosition.z - doorPosition.z) < threshold;
    }
}
