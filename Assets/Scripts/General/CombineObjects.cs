/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineObjects : MonoBehaviour
{
    private Vector2 mousePosition;
    private float offsetX, offsetY;

    public static bool mouseButtonReleased;

    private void OnMouseDown()
    {
        mouseButtonReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - offsetX, mousePosition.y - offsetY);
    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        string thisGameobjectName = name.Substring(0, name.IndexOf("_"));
        string collisionGameobjectName = collision.gameObject.name.Substring(0, collision.gameObject.name.IndexOf("_"));

        if (mouseButtonReleased && thisGameobjectName == "chili" && thisGameobjectName == collisionGameobjectName)
        {
            // Cast to GameObject when using Resources.Load
            Instantiate(Resources.Load<GameObject>("blender_chili_only"), transform.position, Quaternion.identity);
            mouseButtonReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (mouseButtonReleased && thisGameobjectName == "belacan" && thisGameobjectName == collisionGameobjectName)
        {
            Instantiate(Resources.Load<GameObject>("blender_belacan_only"), transform.position, Quaternion.identity);
            mouseButtonReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    } 

    
} */
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineObjects : MonoBehaviour
{
    private Vector2 mousePosition;
    private float offsetX, offsetY;

    public static bool mouseButtonReleased;

    private void OnMouseDown()
    {
        mouseButtonReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - offsetX, mousePosition.y - offsetY);
    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        string thisGameobjectName = name.Substring(0, name.IndexOf("_"));
        string collisionGameobjectName = collision.gameObject.name.Substring(0, collision.gameObject.name.IndexOf("_"));

        if (mouseButtonReleased && thisGameobjectName == "Chili" && thisGameobjectName == collisionGameobjectName)
        {
            // Cast to GameObject when using Resources.Load
            Instantiate(Resources.Load<GameObject>("blender_chili_only"), transform.position, Quaternion.identity);
            mouseButtonReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (mouseButtonReleased && thisGameobjectName == "belacan" && thisGameobjectName == collisionGameobjectName)
        {
            Instantiate(Resources.Load<GameObject>("blender_belacan_only"), transform.position, Quaternion.identity);
            mouseButtonReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
} */ 

/* V1.0: Can combine but the final object appears where the mouse is
using UnityEngine;

public class CombineObjects : MonoBehaviour
{
    public GameObject toCombineWith;  // The game object to combine with
    public GameObject newObject; // The prefab of the new combined object
    private bool hasCombined = false;  // Flag to track if combining has already occurred

    // Start is called before the first frame update
    void Start()
    {
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
        // Debug log to track object instantiation
        Debug.Log("Instantiating new combined object at: " + toCombineWith.transform.position);

        // Instantiate the new object at the position of the ToCombineWith object
        Instantiate(newObject, toCombineWith.transform.position, Quaternion.identity);

        // Destroy the combining objects after combining
        Destroy(toCombineWith);
        Destroy(otherObject);

        // Destroy the current object (the one this script is on)
        Destroy(gameObject);  // This will destroy the current object (the one this script is attached to)
    }

    // Debug function to reset the flag in case you want to test again
    public void ResetCombineFlag()
    {
        hasCombined = false;
    }
} */


/*
using UnityEngine;

public class CombineObjects : MonoBehaviour
{
    public GameObject toCombineWith;  // The game object to combine with
    public GameObject newObject; // The prefab of the new combined object
    private bool hasCombined = false;  // Flag to track if combining has already occurred

    // Start is called before the first frame update
    void Start()
    {
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
        // Debug log to track object instantiation
        Debug.Log("Instantiating new combined object at: " + toCombineWith.transform.position);

        // Instantiate the new object at the position, rotation, and scale of the ToCombineWith object
        GameObject newCombinedObject = Instantiate(newObject, toCombineWith.transform.position, toCombineWith.transform.rotation);

        // Optionally, copy the scale if necessary
        //newCombinedObject.transform.localScale = toCombineWith.transform.localScale;

        // Destroy the combining objects after combining
        Destroy(toCombineWith);
        Destroy(otherObject);

        // Destroy the current object (the one this script is on)
        Destroy(gameObject);  // This will destroy the current object (the one this script is attached to)
    }

    // Debug function to reset the flag in case you want to test again
    public void ResetCombineFlag()
    {
        hasCombined = false;
    }
} */

/* USE THIS ONE
using UnityEngine;

public class CombineObjects : MonoBehaviour
{
    public GameObject toCombineWith;  // The game object to combine with
    public GameObject newObject; // The prefab of the new combined object
    private bool hasCombined = false;  // Flag to track if combining has already occurred

    // Start is called before the first frame update
    void Start()
    {
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
        // Debug log to track object instantiation
        Debug.Log("Instantiating new combined object at: " + toCombineWith.transform.position);

        // Instantiate the new object at the position, rotation, and scale of the ToCombineWith object
        GameObject newCombinedObject = Instantiate(newObject, toCombineWith.transform.position, toCombineWith.transform.rotation);

        // Optionally, copy the scale if necessary
        //newCombinedObject.transform.localScale = toCombineWith.transform.localScale;

        // Destroy the combining objects after combining
        Destroy(toCombineWith);
        Destroy(otherObject);

        // Destroy the current object (the one this script is on)
        Destroy(gameObject);  // This will destroy the current object (the one this script is attached to)
    }

    // Debug function to reset the flag in case you want to test again
    public void ResetCombineFlag()
    {
        hasCombined = false;
    }
} */

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineObjects : MonoBehaviour
{
    private Vector2 mousePosition;
    private float offsetX, offsetY;

    public static bool mouseButtonReleased;

    private void OnMouseDown()
    {
        mouseButtonReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - offsetX, mousePosition.y - offsetY);
    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        string thisGameObjectName = name;  // Use the full name
        string collisionGameObjectName = collision.gameObject.name;  // Use the full name

        // Debugging logs to track the comparison
        Debug.Log("This GameObject: " + thisGameObjectName);
        Debug.Log("Collision GameObject: " + collisionGameObjectName);

        if (mouseButtonReleased)
        {
            // First condition: Chili + Blender -> Blender Chili Only
            if (thisGameObjectName == "chili" && collisionGameObjectName == "blender")
            {
                Debug.Log("Chili is mixing with Blender");
                var blenderChiliPrefab = Resources.Load<GameObject>("blender_chili_only");
                if (blenderChiliPrefab == null)
                {
                    Debug.LogError("blender_chili_only prefab is missing or the path is incorrect.");
                }
                else
                {
                    Instantiate(blenderChiliPrefab, transform.position, Quaternion.identity);
                }
                mouseButtonReleased = false;
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            // Second condition: Belacan + Blender -> Blender Belacan Only
            else if (thisGameObjectName == "belacan" && collisionGameObjectName == "blender")
            {
                Debug.Log("Belacan is mixing with Blender");
                var blenderBelacanPrefab = Resources.Load<GameObject>("blender_belacan_only");
                if (blenderBelacanPrefab == null)
                {
                    Debug.LogError("blender_belacan_only prefab is missing or the path is incorrect.");
                }
                else
                {
                    Instantiate(blenderBelacanPrefab, transform.position, Quaternion.identity);
                }
                mouseButtonReleased = false;
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            // Third condition: Belacan + Blender Chili Only -> Blender 2 Complete
            else if (thisGameObjectName == "belacan" && collisionGameObjectName == "blender_chili_only")
            {
                Debug.Log("Belacan is mixing with Blender Chili Only");
                var blenderCompletePrefab = Resources.Load<GameObject>("blender_2_complete");
                if (blenderCompletePrefab == null)
                {
                    Debug.LogError("blender_2_complete prefab is missing or the path is incorrect.");
                }
                else
                {
                    Instantiate(blenderCompletePrefab, transform.position, Quaternion.identity);
                }
                mouseButtonReleased = false;
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            // Fourth condition: Chili + Blender Belacan Only -> Blender 2 Complete
            else if (thisGameObjectName == "chili" && collisionGameObjectName == "blender_belacan_only")
            {
                Debug.Log("Chili is mixing with Blender Belacan Only");
                var blenderCompletePrefab = Resources.Load<GameObject>("blender_2_complete");
                if (blenderCompletePrefab == null)
                {
                    Debug.LogError("blender_2_complete prefab is missing or the path is incorrect.");
                }
                else
                {
                    Instantiate(blenderCompletePrefab, transform.position, Quaternion.identity);
                }
                mouseButtonReleased = false;
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }

} */


/*USE THIS ONE
using UnityEngine;

public class CombineObjects : MonoBehaviour
{
    public GameObject toCombineWith;  // The game object to combine with
    public GameObject newObject; // The prefab of the new combined object
    private bool hasCombined = false;  // Flag to track if combining has already occurred

    // Start is called before the first frame update
    void Start()
    {
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
        // Debug log to track object instantiation
        Debug.Log("Instantiating new combined object at: " + toCombineWith.transform.position);

        // Instantiate the new object at the position, rotation, and scale of the ToCombineWith object
        GameObject newCombinedObject = Instantiate(newObject, toCombineWith.transform.position, toCombineWith.transform.rotation);

        // Optionally, copy the scale if necessary
        //newCombinedObject.transform.localScale = toCombineWith.transform.localScale;

        // Destroy the combining objects after combining
        Destroy(toCombineWith);
        Destroy(otherObject);

        // Destroy the current object (the one this script is on)
        Destroy(gameObject);  // This will destroy the current object (the one this script is attached to)
    }

    // Debug function to reset the flag in case you want to test again
    public void ResetCombineFlag()
    {
        hasCombined = false;
    }
} */



/*
using UnityEngine;

public class CombineObjects : MonoBehaviour
{
    public GameObject toCombineWith;  // The game object to combine with
    public GameObject newObject; // The prefab of the new combined object
    private bool hasCombined = false;  // Flag to track if combining has already occurred

    // Start is called before the first frame update
    void Start()
    {
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
        // Debug log to track object instantiation
        Debug.Log("Instantiating new combined object at: " + toCombineWith.transform.position);

        // Instantiate the new object at the position, rotation, and scale of the ToCombineWith object
        GameObject newCombinedObject = Instantiate(newObject, toCombineWith.transform.position, toCombineWith.transform.rotation);

        // Optionally, copy the scale if necessary
        //newCombinedObject.transform.localScale = toCombineWith.transform.localScale;

        // Destroy the combining objects after combining
        Destroy(toCombineWith);
        Destroy(otherObject);

        // Destroy the current object (the one this script is on)
        Destroy(gameObject);  // This will destroy the current object (the one this script is attached to)
    }

    // Debug function to reset the flag in case you want to test again
    public void ResetCombineFlag()
    {
        hasCombined = false;
    }
} */

/*
using UnityEngine;

public class CombineObjects : MonoBehaviour
{
    public GameObject toCombineWith;  // The game object to combine with
    public GameObject newObject;  // The prefab of the new combined object
    public AudioClip combineSound;  // The sound to play when combining
    private bool hasCombined = false;  // Flag to track if combining has already occurred

    // Start is called before the first frame update
    void Start()
    {
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
        // Play the sound at the location of the combining object
        if (combineSound != null)
        {
            AudioSource.PlayClipAtPoint(combineSound, transform.position);
        }

        // Activate the newObject
        Debug.Log("Activating the new combined object.");
        newObject.SetActive(true);

        // Set the objects involved in combining to inactive
        toCombineWith.SetActive(false);
        otherObject.SetActive(false);

        // Set the current object (the one this script is on) to inactive
        gameObject.SetActive(false);
    }

    // Debug function to reset the flag in case you want to test again
    public void ResetCombineFlag()
    {
        hasCombined = false;
    }
} */

using UnityEngine;

public class CombineObjects : MonoBehaviour
{
    public GameObject toCombineWith;  // The game object to combine with
    public GameObject newObject;  // The prefab of the new combined object
    public AudioClip combineSound;  // The sound to play when combining
    private bool hasCombined = false;  // Flag to track if combining has already occurred

    // Start is called before the first frame update
    void Start()
    {
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

    // Activate the newObject
    Debug.Log("Activating the new combined object.");
    newObject.SetActive(true);

    // Set the objects involved in combining to inactive
    toCombineWith.SetActive(false);
    otherObject.SetActive(false);

    // Set the current object (the one this script is on) to inactive
    gameObject.SetActive(false);
}

    // Debug function to reset the flag in case you want to test again
    public void ResetCombineFlag()
    {
        hasCombined = false;
    }
}
