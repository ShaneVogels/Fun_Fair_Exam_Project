using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private GameObject raycastOrigin; // The GameObject from which the raycast will originate
    [SerializeField] private float rayDistance = 5f; // Maximum raycast distance

    // List to store interactable objects, each with its own TMP_Text for interaction
    [SerializeField] List<Interactable> interactables = new List<Interactable>();

    [SerializeField] TMP_Text interactionTextUI; // TextMeshPro object to display interaction text

    void Update()
    {
        // Raycast from the specified GameObject (e.g., player's hand or another object)
        Ray ray = new Ray(raycastOrigin.transform.position, raycastOrigin.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // Find the interactable based on the tag of the hit object
            GameStand hitStand = hit.collider.gameObject.GetComponent<GameStand>();

            if (hitStand != null)
            {
                // Show interaction text for the relevant object
                ShowInteractionText(hitStand.text);

                // Check for player input to interact
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hitStand.Interact(); // Execute the associated behavior
                    HideInteractionText(); // Hide text after interaction
                }
            }
            else
            {
                // Hide text if no interactable object is hit
                HideInteractionText();
            }
        }
        else
        {
            // Hide text if no object is hit
            HideInteractionText();
        }
    }

    public void ShowInteractionText(string interactionText)
    {
        if (interactionTextUI != null)
        {
            interactionTextUI.text = interactionText;
            interactionTextUI.gameObject.SetActive(true);
        }
    }

    // Hide interaction text from any interactable
    private void HideInteractionText()
    {
        if (interactionTextUI != null)
        {
            interactionTextUI.gameObject.SetActive(false);
        }
    }

    // Finds an interactable object by its tag
    private Interactable GetInteractableByTag(string tag)
    {
        return interactables.Find(interactable => interactable.tag == tag);
    }

    // Interactable class to store interaction details
    [System.Serializable]
    private class Interactable
    {
        public string tag; // Tag to identify interactable object
        [SerializeField] string interactionText; // Interaction text to display
        public System.Action Interact; // Action to perform when interacted with
//        [SerializeField] script behaviorScript; // Script component to execute when interacting with the object

        // Constructor to initialize interactable objects
        public Interactable(string tag, string interactionText, MonoBehaviour behaviorScript, TMP_Text interactionTextUI)
        {
            this.tag = tag;
            this.interactionText = interactionText;
//            this.behaviorScript = behaviorScript;

            // Assign the Interact action to call a method in the provided script
            this.Interact = () =>
            {
                if (behaviorScript != null)
                {
                    // Execute a method in the script if provided
                    behaviorScript.Invoke("Interact", 0f); // Call the method "Interact" from the script (optional method name)
                }
            };
        }

        // Show the interaction text


        // Hide the interaction text
        public void HideInteractionText()
        {

        }
    }
}
