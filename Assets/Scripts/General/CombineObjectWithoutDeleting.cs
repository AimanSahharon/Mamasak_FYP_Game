using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineObjectWithoutDeleting : MonoBehaviour
{
    public GameObject toCombineWith;  // The game object to combine with
    public GameObject newObject;  // The prefab of the new combined object
    public AudioClip combineSound;  // The sound to play when combining
    private bool hasCombined = false;  // Flag to track if combining has already occurred

    private Vector3 originalPosition;  // To store the original position of this object

    // Start is called before the first frame update
    void Start()
    {
        // Store the original position
        originalPosition = transform.position;

        // Check if required references are assigned
        if (toCombineWith == null || newObject == null)
        {
            Debug.LogError("Missing references to ToCombineWith or newObject.");
        }
    }

    // This function will detect triggers or collisions
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug log to confirm when the collision occurs
        Debug.Log("Triggered with: " + other.gameObject.name);

        // Check if it's the correct object we want to combine with and only combine once
        if (!hasCombined && other.gameObject == toCombineWith)
        {
            Debug.Log("Combining objects...");
            Combine(other.gameObject);
            hasCombined = true;  // Mark as combined to prevent multiple combines
        }
    }

    // Function to handle the combining process
    void Combine(GameObject otherObject)
{
    // Play the sound at the location of the combining object with increased volume
    if (combineSound != null)
    {
        float volume = 2.0f; // Maximum volume (adjust this if necessary)
        AudioSource.PlayClipAtPoint(combineSound, transform.position, volume);
    }

    // Activate the newObject at the combined position
    if (newObject != null)
    {
        newObject.transform.position = toCombineWith.transform.position; // Position new object
        newObject.SetActive(true);
    }

    // Deactivate the combined objects
    toCombineWith.SetActive(false);
    otherObject.SetActive(false);

    // Move this object back to its original position
    transform.position = originalPosition;

    // Reset mouseclick flag if using MoveObject script
    MoveObject moveScript = GetComponent<MoveObject>();
    if (moveScript != null)
    {
        moveScript.mouseclick = false;
    }
}


    // Debug function to reset the flag in case you want to test again
    public void ResetCombineFlag()
    {
        hasCombined = false;
    }
}
