/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ValidationManager : MonoBehaviour
{
    private static ValidationManager instance;
    private bool isValidationRunning = false;

    public static ValidationManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject manager = new GameObject("ValidationManager");
                instance = manager.AddComponent<ValidationManager>();
            }
            return instance;
        }
    }

    private int lastValidationFrame = -1;

    public void ValidateOrder(System.Action validationAction)
    {
        int currentFrame = Time.frameCount;

        if (isValidationRunning || currentFrame == lastValidationFrame)
        {
            // Already running or has run this frame, skip.
            return;
        }

        isValidationRunning = true;
        validationAction?.Invoke();
        lastValidationFrame = currentFrame;
        isValidationRunning = false;
    }
}
*/

/* USE THIS ONE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidationManager : MonoBehaviour
{
    private static ValidationManager instance;
    private bool isValidationRunning = false;
    private bool isClearingRunning = false;

    public static ValidationManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject manager = new GameObject("ValidationManager");
                instance = manager.AddComponent<ValidationManager>();
            }
            return instance;
        }
    }

    private int lastValidationFrame = -1;
    private int lastClearFrame = -1;

    public void ValidateOrder(System.Action validationAction)
    {
        int currentFrame = Time.frameCount;

        if (isValidationRunning || currentFrame == lastValidationFrame)
        {
            return; // Skip if already running or executed in the same frame
        }

        isValidationRunning = true;
        validationAction?.Invoke();
        lastValidationFrame = currentFrame;
        isValidationRunning = false;
    }

    public void ClearPlate(System.Action clearAction)
    {
        int currentFrame = Time.frameCount;

        if (isClearingRunning || currentFrame == lastClearFrame)
        {
            return; // Skip if already running or executed in the same frame
        }

        isClearingRunning = true;
        clearAction?.Invoke();
        lastClearFrame = currentFrame;
        isClearingRunning = false;
    }
} */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidationManager : MonoBehaviour
{
    private static ValidationManager instance;
    private bool isValidationRunning = false;
    private bool isClearingRunning = false;
    private float validationCooldown = 1f; // Time in seconds before another validation can happen
    private float lastValidationTime = -1f; // Time of the last validation

    public static ValidationManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject manager = new GameObject("ValidationManager");
                instance = manager.AddComponent<ValidationManager>();
            }
            return instance;
        }
    }

    private int lastClearFrame = -1;

    public void ValidateOrder(System.Action validationAction)
    {
        float currentTime = Time.time;

        if (isValidationRunning || currentTime - lastValidationTime < validationCooldown)
        {
            return; // Skip if validation is still running or cooldown has not passed
        }

        isValidationRunning = true;
        validationAction?.Invoke();
        lastValidationTime = currentTime; // Update the time of the last validation
        isValidationRunning = false;
    }

    public void ClearPlate(System.Action clearAction)
    {
        int currentFrame = Time.frameCount;

        if (isClearingRunning || currentFrame == lastClearFrame)
        {
            return; // Skip if already running or executed in the same frame
        }

        isClearingRunning = true;
        clearAction?.Invoke();
        lastClearFrame = currentFrame;
        isClearingRunning = false;
    }
}

