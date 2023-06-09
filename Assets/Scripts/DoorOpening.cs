using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    private void Update()
    {
        var ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out var hitInfo, 3f))
        {
            var hitObject = hitInfo.collider.gameObject;

            if (Input.GetKeyDown(KeyCode.E))
            {
                hitObject.GetComponent<Door>()?.SwitchDoorState();
            }
        }
    }
}