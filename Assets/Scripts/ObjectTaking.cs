using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTaking : MonoBehaviour
{
    [SerializeField] private Transform _hand;

    private void Update()
    {
        var ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out var hitInfo, 3f))
        {
            var hitObject = hitInfo.collider.gameObject;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hitObject.GetComponent<InteractableItem>())
                {
                    if (_hand.childCount == 0)
                    {
                        hitObject.transform.SetParent(_hand);
                        hitObject.GetComponent<Rigidbody>().isKinematic = true;
                        hitObject.transform.position = _hand.position;
                    }

                    else if (_hand.childCount == 1)
                    {
                        _hand.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                        _hand.transform.GetChild(0).transform.SetParent(null, true);
                        hitObject.transform.SetParent(_hand);
                        hitObject.GetComponent<Rigidbody>().isKinematic = true;
                        hitObject.transform.position = _hand.position;
                    }
                }
            }
        }
        
        if (Input.GetMouseButtonDown(0) && _hand.childCount == 1)
        {
            _hand.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            _hand.transform.GetChild(0).GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
            _hand.transform.GetChild(0).transform.SetParent(null, true);
        }
    }
}