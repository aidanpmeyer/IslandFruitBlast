using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRecognizer : MonoBehaviour
{

    public OVRInput.Controller controller;
    public float inputThreshold = 0.1f;

    private bool isMoving = false;
    private bool isPressed = false;

    public Transform movementSource;
    public float newPositionThreshold = 0.05f;
    private List<Vector3> positionList = new List<Vector3>();

    private float indexTriggerState = 0;
    private float oldIndexTriggerState = 0;

    // Update is called once per frame


    // https://www.youtube.com/watch?v=GRSOrkmasMM
    void Update()
    {
        oldIndexTriggerState = indexTriggerState;
        indexTriggerState = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);

        if (indexTriggerState > 0.9f && oldIndexTriggerState < 0.9f) {
            isPressed = true;
        }

        if (!isMoving && isPressed) {
            StartMovement();
        } else if (isMoving && !isPressed) {
            EndMovement();
        } else if (isMoving && isPressed) {
            UpdateMovement();
        }
    }

    void StartMovement() {
        isMoving = true;
        positionList.Clear();
        positionList.Add(movementSource.position);
    }

    void EndMovement() {
        isMoving = false;
    }

    void UpdateMovement() {
        Vector3 lastPosition = positionList[positionList.Count - 1];
        if (Vector3.Distance(movementSource.position, lastPosition) > newPositionThreshold) {
            positionList.Add(movementSource.position);
        }
    }

    public bool getIsMoving() 
    {
        return isMoving;
    }


}
