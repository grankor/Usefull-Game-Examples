using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Controller isn't complete.
/// It includes a method which draws a ray and detects collisions.
/// </summary>
public class CharacterControl : MonoBehaviour
{
    /// <summary>
    /// Assigned in the UI. The transfor for the camera is used to identify the direction the ray should be facing.
    /// </summary>
    public Camera MainCamera;

    /// <summary>
    /// This mask is defined in the inspector.
    /// This is so the ray only interacts with the objects we want it to detect.
    /// You should only include objects which inherit IInteractable
    /// </summary>
    [Tooltip("Forward Interaction")]
    public LayerMask LOSMask;

    /// <summary>
    /// This class isn't included, but is has methods included which shows a message about what the player is interacting with.
    /// </summary>
    private UIController _uiController;

    /// <summary>
    /// Find the UI Controller on Awake.
    /// </summary>
    private void Awake
    {
        _uiController = FindObjectOfType<UIController>();
    }

    /// <summary>
    /// I use Fixed Update to keep the interactions in sync with the physics.
    /// </summary>
    private void FixedUpdate()
    {
        CheckForwardInteraction();
    }
    
    /// <summary>
    /// This example uses a Ray to detect forward interaction.
    /// Similar logic can be used during collisions as well.
    /// </summary>
    private void CheckForwardInteraction()
    {
        Vector3 forward = MainCamera.transform.TransformDirection(Vector3.forward) * 5;
        var rayStart = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
        Ray ray = new Ray(rayStart, forward);

        // Draw the ray and read the output from 'out'
        // The LOSMask mask is applied here. 
        // QueryTriggerInteraction.Ignore is used so that we only get non-trigger colliders, which are physical objects in the game.
        if (Physics.Raycast(ray, out RaycastHit hit, 5, LOSMask, QueryTriggerInteraction.Ignore))
        {
            {
                /*
                // Here get get our interface from the attached object.
                // GetComponentInParent is used, because some objects, like chests, may have multiple children with colliders, and we don't
                // want to have the interface on every object.
                */
                var obj = hit.collider.gameObject.GetComponentInParent<IInteractable>();
                _uiController.ShowInteractionWindow(obj.GetMessage()); // A call to our UI controller to show the message from the interface.
                if (Input.GetKeyUp(KeyCode.F))
                {
                    obj.Interact();
                }
            }
        }
        else
        {
            _uiController.HideInteractionWindow(); // Hides the interaction window if we aren't interacting with anything.
        }
    }
}
