using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMe : MonoBehaviour
{
    public GameObject menuCanvas1;
   // public GameObject menuCanvas2;
    public Camera FirstPersonCamera;
    [Range(0, 1)]
    public float smoothFactor = 0.5f;

    // how far to stay away fromt he center

    public float offsetRadius = 0.3f;
    public float distanceToHead = 4;

    public void Update()
    {
        // make the UI always face towards the camera
        menuCanvas1.transform.rotation = FirstPersonCamera.transform.rotation;
        //menuCanvas2.transform.rotation = FirstPersonCamera.transform.rotation;

        var cameraCenter = FirstPersonCamera.transform.position + FirstPersonCamera.transform.forward * distanceToHead;

        var currentPos = menuCanvas1.transform.position;

        // in which direction from the center?
        var direction = currentPos - cameraCenter;

        // target is in the same direction but offsetRadius
        // from the center
        var targetPosition = cameraCenter + direction.normalized * offsetRadius;

        // finally interpolate towards this position
        menuCanvas1.transform.position = Vector3.Lerp(currentPos, targetPosition, smoothFactor);
        //menuCanvas2.transform.position = Vector3.Lerp(currentPos, targetPosition, smoothFactor);
    }
}
