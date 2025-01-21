using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectCooking : MonoBehaviour
{
    // Assign the object you want to activate in the Inspector
    public GameObject objectToActivate;

    private void Start()
    {
        StartCoroutine(ActivateAndDeactivate());
    }

    private IEnumerator ActivateAndDeactivate()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Activate the specified object
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }

        // Deactivate this object
        gameObject.SetActive(false);
    }
}
