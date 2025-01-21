using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlenderAction : MonoBehaviour
{
    [SerializeField] private GameObject newObject; // Reference to the new object to activate
    [SerializeField] private AudioClip clickSound; // Sound to play when the object is clicked

    private void OnMouseDown()
    {
        // Play the click sound
        if (clickSound != null)
        {
            AudioSource.PlayClipAtPoint(clickSound, transform.position);
        }

        // When the current object is clicked
        if (newObject != null)
        {
            newObject.SetActive(true); // Activate the new object
        }

        gameObject.SetActive(false); // Deactivate the current object (or use Destroy(gameObject) to delete it)
    }
}
