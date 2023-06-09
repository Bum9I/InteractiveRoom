using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HighlightController : MonoBehaviour
{
    private Camera _camera;
    private InteractableItem _lastHighlightedObject;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        var currentHighlightedObject = GetSelectedHighlightableObject();

        var isNewObject = currentHighlightedObject != _lastHighlightedObject;
        if (isNewObject)
        {
            if (_lastHighlightedObject != null)
            {
                _lastHighlightedObject.RemoveFocus();
            }
            
            if (currentHighlightedObject != null)
            {
                currentHighlightedObject.SetFocus();
            }
            
            _lastHighlightedObject = currentHighlightedObject;
        }
    }

    private InteractableItem GetSelectedHighlightableObject()
    {
        var ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out var hitInfo, 3f))
        {
            var highlightableObject = hitInfo.collider.GetComponent<InteractableItem>();
            return highlightableObject;
        }

        return null;
    }
}