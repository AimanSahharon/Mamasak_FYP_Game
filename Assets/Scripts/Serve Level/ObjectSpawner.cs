/*using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectBPrefab; // Assign the Object B prefab
    public GameObject currentObjectB;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            // Check if clicked on Object A
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // If an Object B is already spawned, destroy it
                if (currentObjectB != null)
                {
                    Destroy(currentObjectB);
                }

                // Spawn Object B at mouse position
                Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                spawnPosition.z = 0; // Ensure it stays in 2D
                currentObjectB = Instantiate(objectBPrefab, spawnPosition, Quaternion.identity);
            }
        }

        // Allow dragging the spawned Object B
        if (currentObjectB != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            currentObjectB.transform.position = mousePosition;
        }
    }
} */

/*
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectBPrefab; // Assign the Object B prefab
    public GameObject currentObjectB;
    public PlateHover plate; // Reference to PlateHover script

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            // Check if clicked on the plate
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // If an Object B is already spawned, destroy it
                if (currentObjectB != null)
                {
                    Destroy(currentObjectB);
                }

                // Spawn Object B at mouse position
                Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                spawnPosition.z = 0; // Ensure it stays in 2D
                currentObjectB = Instantiate(objectBPrefab, spawnPosition, Quaternion.identity);
            }
        }

        // Allow dragging the spawned Object B
        if (currentObjectB != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            currentObjectB.transform.position = mousePosition;
        }

        // Check for collision and snap Object B to plate if it's on top of the plate
        if (currentObjectB != null && plate != null)
        {
            // Check if the objectB is close enough to the plate
            if (IsObjectBOnPlate(currentObjectB))
            {
                Vector3 snapPosition = plate.GetClosestSnapPoint(currentObjectB.transform.position);
                currentObjectB.transform.position = snapPosition; // Snap to closest point
            }
        }
    }

    private bool IsObjectBOnPlate(GameObject objectB)
    {
        // Simple check to see if Object B is over the plate. You can adjust this based on your needs.
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }
} */

/*
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectBPrefab; // Assign the Object B prefab
    public GameObject currentObjectB;
    public PlateHover plate; // Reference to PlateHover script
    private bool isSnapped = false; // Flag to check if Object B has snapped

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            // Check if clicked on the plate
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // If an Object B is already spawned, destroy it
                if (currentObjectB != null)
                {
                    Destroy(currentObjectB);
                    isSnapped = false; // Reset the snap flag
                }

                // Spawn Object B at mouse position
                Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                spawnPosition.z = 0; // Ensure it stays in 2D
                currentObjectB = Instantiate(objectBPrefab, spawnPosition, Quaternion.identity);
            }
        }

        // Allow dragging the spawned Object B
        if (currentObjectB != null && !isSnapped) // Only drag if not snapped
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            currentObjectB.transform.position = mousePosition;
        }

        // Check for collision and snap Object B to plate if it's on top of the plate
        if (currentObjectB != null && plate != null && !isSnapped)
        {
            // Check if the objectB is close enough to the plate
            if (IsObjectBOnPlate(currentObjectB))
            {
                Vector3 snapPosition = plate.GetClosestSnapPoint(currentObjectB.transform.position);
                currentObjectB.transform.position = snapPosition; // Snap to closest point
                isSnapped = true; // Set snapped flag to true so it stops moving
            }
        }
    }

    private bool IsObjectBOnPlate(GameObject objectB)
    {
        // Simple check to see if Object B is over the plate. You can adjust this based on your needs.
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }
} */


/*
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectBPrefab; // Assign the Object B prefab
    public GameObject currentObjectB;
    public PlateHover plate; // Reference to PlateHover script
    private bool isSnapped = false; // Flag to check if Object B has snapped

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            // Check if clicked on the plate
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // If an Object B is already spawned, destroy it
                if (currentObjectB != null)
                {
                    Destroy(currentObjectB);
                    isSnapped = false; // Reset the snap flag
                }

                // Spawn Object B at mouse position
                Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                spawnPosition.z = 0; // Ensure it stays in 2D
                currentObjectB = Instantiate(objectBPrefab, spawnPosition, Quaternion.identity);
            }
        }

        // Allow dragging the spawned Object B
        if (currentObjectB != null && !isSnapped) // Only drag if not snapped
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            currentObjectB.transform.position = mousePosition;
        }

        // Check for collision and snap Object B to plate if it's on top of the plate
        if (currentObjectB != null && plate != null && !isSnapped)
        {
            // Check if the objectB is close enough to the plate
            if (IsObjectBOnPlate(currentObjectB))
            {
                Vector3 snapPosition = plate.GetClosestSnapPoint(currentObjectB.transform.position);
                currentObjectB.transform.position = snapPosition; // Snap to closest point
                isSnapped = true; // Set snapped flag to true so it stops moving

                // Set the snapped position in PlateHover to update Object B's position with the plate
                plate.SetSnappedPosition(snapPosition);
                plate.objectB = currentObjectB; // Set reference to Object B
            }
        }
    }

    private bool IsObjectBOnPlate(GameObject objectB)
    {
        // Simple check to see if Object B is over the plate. You can adjust this based on your needs.
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }
} */


/*
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectBPrefab; // Assign the Object B prefab
    public GameObject currentObjectB;
    public PlateHover plate; // Reference to PlateHover script
    private bool isSnapped = false; // Flag to check if Object B has snapped

    void Update()
    {
        // Check for the left mouse button click
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            // Check if clicked on the plate
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // If Object B is already spawned and hasn't been snapped, destroy it
                if (currentObjectB != null && !isSnapped)
                {
                    Destroy(currentObjectB);
                }

                // Spawn Object B at mouse position only if it's not snapped or if no Object B exists
                if (currentObjectB == null || isSnapped)
                {
                    Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    spawnPosition.z = 0; // Ensure it stays in 2D
                    currentObjectB = Instantiate(objectBPrefab, spawnPosition, Quaternion.identity);
                    isSnapped = false; // Reset snapped flag since we're spawning a new object
                }
            }
        }

        // Allow dragging the spawned Object B
        if (currentObjectB != null && !isSnapped) // Only drag if not snapped
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            currentObjectB.transform.position = mousePosition;
        }

        // Check for collision and snap Object B to plate if it's on top of the plate
        if (currentObjectB != null && plate != null && !isSnapped)
        {
            // Check if the objectB is close enough to the plate
            if (IsObjectBOnPlate(currentObjectB))
            {
                Vector3 snapPosition = plate.GetClosestSnapPoint(currentObjectB.transform.position);
                currentObjectB.transform.position = snapPosition; // Snap to closest point
                isSnapped = true; // Set snapped flag to true so it stops moving

                // Set the snapped position in PlateHover to update Object B's position with the plate
                plate.SetSnappedPosition(snapPosition);
                plate.objectB = currentObjectB; // Set reference to Object B
            }
        }
    }

    private bool IsObjectBOnPlate(GameObject objectB)
    {
        // Simple check to see if Object B is over the plate. You can adjust this based on your needs.
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }
} */

/*using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectBPrefab; // Assign the Object B prefab
    public GameObject currentObjectB;
    public PlateHover plate; // Reference to PlateHover script
    private bool isSnapped = false; // Flag to check if Object B has snapped

    void Update()
    {
        // Check for the left mouse button click
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            // Check if clicked on the plate
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // If Object B is already spawned and hasn't been snapped, destroy it
                if (currentObjectB != null && !isSnapped)
                {
                    Destroy(currentObjectB);
                }

                // Spawn Object B at mouse position only if it's not snapped or if no Object B exists
                if (currentObjectB == null || isSnapped)
                {
                    Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    spawnPosition.z = 0; // Ensure it stays in 2D
                    currentObjectB = Instantiate(objectBPrefab, spawnPosition, Quaternion.identity);
                    isSnapped = false; // Reset snapped flag since we're spawning a new object
                }
            }
        }

        // Allow dragging the spawned Object B
        if (currentObjectB != null && !isSnapped) // Only drag if not snapped
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            currentObjectB.transform.position = mousePosition;
        }

        // Check for collision and snap Object B to plate if it's on top of the plate
        if (currentObjectB != null && plate != null && !isSnapped)
        {
            // Check if the objectB is close enough to the plate
            if (IsObjectBOnPlate(currentObjectB))
            {
                Vector3 snapPosition = plate.GetClosestSnapPoint(currentObjectB.transform.position);
                currentObjectB.transform.position = snapPosition; // Snap to closest point
                isSnapped = true; // Set snapped flag to true so it stops moving

                // Set the snapped position in PlateHover to update Object B's position with the plate
                plate.SetSnappedPosition(snapPosition);
                plate.objectB = currentObjectB; // Set reference to Object B
            }
        }
    }

    private bool IsObjectBOnPlate(GameObject objectB)
    {
        // Simple check to see if Object B is over the plate. You can adjust this based on your needs.
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }
} */

/*

using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectBPrefab; // Assign the Object B prefab
    public GameObject currentObjectB;
    public PlateHover plate; // Reference to PlateHover script
    private bool isSnapped = false; // Flag to check if Object B has snapped

    void Update()
    {
        // Check for the left mouse button click
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            // Check if clicked on the plate
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // If Object B is already spawned and hasn't been snapped, destroy it
                if (currentObjectB != null && !isSnapped)
                {
                    // Free the snap point before destroying the object
                    plate.FreeSnapPoint(plate.snappedPosition);
                    Destroy(currentObjectB);
                }

                // Spawn Object B at mouse position only if it's not snapped or if no Object B exists
                if (currentObjectB == null || isSnapped)
                {
                    Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    spawnPosition.z = 0; // Ensure it stays in 2D
                    currentObjectB = Instantiate(objectBPrefab, spawnPosition, Quaternion.identity);
                    isSnapped = false; // Reset snapped flag since we're spawning a new object
                }
            }
        }

        // Allow dragging the spawned Object B
        if (currentObjectB != null && !isSnapped) // Only drag if not snapped
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            currentObjectB.transform.position = mousePosition;
        }

        // Check for collision and snap Object B to plate if it's on top of the plate
        if (currentObjectB != null && plate != null && !isSnapped)
        {
            // Check if the objectB is close enough to the plate
            if (IsObjectBOnPlate(currentObjectB))
            {
                Vector3 snapPosition = plate.GetClosestSnapPoint(currentObjectB.transform.position);
                currentObjectB.transform.position = snapPosition; // Snap to closest point
                isSnapped = true; // Set snapped flag to true so it stops moving

                // Set the snapped position in PlateHover to update Object B's position with the plate
                plate.SetSnappedPosition(snapPosition);
                plate.objectB = currentObjectB; // Set reference to Object B
            }
        }
    }

    private bool IsObjectBOnPlate(GameObject objectB)
    {
        // Simple check to see if Object B is over the plate. You can adjust this based on your needs.
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }
} */


/*
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectBPrefab; // Assign the Object B prefab
    public GameObject currentObjectB;
    public PlateHover plate; // Reference to PlateHover script
    private bool isSnapped = false; // Flag to check if Object B has snapped

    void Update()
    {
        // Check for the left mouse button click
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                if (currentObjectB != null && !isSnapped)
                {
                    Destroy(currentObjectB);
                }

                if (currentObjectB == null || isSnapped)
                {
                    Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    spawnPosition.z = 0;
                    currentObjectB = Instantiate(objectBPrefab, spawnPosition, Quaternion.identity);
                    isSnapped = false;
                }
            }
        }

        // Allow dragging the spawned Object B
        if (currentObjectB != null && !isSnapped)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            currentObjectB.transform.position = mousePosition;
        }

        // Check for collision and snap Object B to plate
        if (currentObjectB != null && plate != null && !isSnapped)
        {
            if (IsObjectBOnPlate(currentObjectB))
            {
                Vector3 snapPosition = plate.GetClosestSnapPoint(currentObjectB.transform.position);
                currentObjectB.transform.position = snapPosition;
                isSnapped = true;

                plate.SetSnappedPosition(snapPosition);
                plate.objectB = currentObjectB;
            }
        }

        // Clear the plate when the S key is pressed
        if (Input.GetKeyDown(KeyCode.S)) // Detect the S key press
        {
            ClearPlate();
        }
    }

    private bool IsObjectBOnPlate(GameObject objectB)
    {
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }

    private void ClearPlate()
    {
        if (currentObjectB != null && isSnapped)
        {
            // Free the snap point occupied by the current object
            plate.FreeSnapPoint(plate.GetSnappedPosition());

            // Destroy the current object
            Destroy(currentObjectB);

            // Reset the state
            currentObjectB = null;
            isSnapped = false;

            Debug.Log("Plate cleared.");
        }
    }

   
} */


/* V1
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectBPrefab; // Assign the Object B prefab
    public GameObject currentObjectB;
    public PlateHover plate; // Reference to PlateHover script
    private bool isSnapped = false; // Flag to check if Object B has snapped

    void Update()
    {
        // Check for the left mouse button click
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                if (currentObjectB != null && !isSnapped)
                {
                    Destroy(currentObjectB);
                }

                if (currentObjectB == null || isSnapped)
                {
                    Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    spawnPosition.z = 0;
                    currentObjectB = Instantiate(objectBPrefab, spawnPosition, Quaternion.identity);
                    isSnapped = false;
                }
            }
        }

        // Allow dragging the spawned Object B
        if (currentObjectB != null && !isSnapped)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            currentObjectB.transform.position = mousePosition;
        }

        // Check for collision and snap Object B to plate
        if (currentObjectB != null && plate != null && !isSnapped)
        {
            if (IsObjectBOnPlate(currentObjectB))
            {
                Vector3 snapPosition = plate.GetClosestSnapPoint(currentObjectB.transform.position);
                currentObjectB.transform.position = snapPosition;
                isSnapped = true;

                plate.SetSnappedPosition(snapPosition);
                plate.objectB = currentObjectB;
            }
        }

        // Clear the plate when the S key is pressed
        if (Input.GetKeyDown(KeyCode.S)) // Detect the S key press
        {
            ClearPlate();
        }
    }

    private bool IsObjectBOnPlate(GameObject objectB)
    {
        if (plate == null) return false;
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }

    private void ClearPlate()
    {
        if (currentObjectB != null && isSnapped && plate != null)
        {
            // Free the snap point occupied by the current object
            plate.FreeSnapPoint(plate.GetSnappedPosition());

            // Destroy the current object
            Destroy(currentObjectB);

            // Reset the state
            currentObjectB = null;
            isSnapped = false;

            Debug.Log("Plate cleared.");
        }
    }
} */

/* V2
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectBPrefab; // Assign the Object B prefab
    public GameObject currentObjectB;
    public PlateHover plate; // Reference to PlateHover script
    private bool isSnapped = false; // Flag to check if Object B has snapped

    void Update()
    {
        // Check for the left mouse button click
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                if (currentObjectB != null && !isSnapped)
                {
                    Destroy(currentObjectB);
                }

                if (currentObjectB == null || isSnapped)
                {
                    Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    spawnPosition.z = 0;
                    currentObjectB = Instantiate(objectBPrefab, spawnPosition, Quaternion.identity);
                    isSnapped = false;
                }
            }
        }

        // Allow dragging the spawned Object B
        if (currentObjectB != null && !isSnapped)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            currentObjectB.transform.position = mousePosition;
        }

        // Check for collision and snap Object B to plate
        if (currentObjectB != null && plate != null && !isSnapped)
        {
            if (IsObjectBOnPlate(currentObjectB))
            {
                Vector3 snapPosition = plate.GetClosestSnapPoint(currentObjectB.transform.position);
                currentObjectB.transform.position = snapPosition;
                isSnapped = true;

                plate.SetSnappedPosition(snapPosition);
                plate.objectB = currentObjectB;

                // Add the object to the plate's list of objects
                plate.AddObjectToPlate(currentObjectB);
            }
        }

        // Clear the plate when the S key is pressed
        if (Input.GetKeyDown(KeyCode.S)) // Detect the S key press
        {
            ClearPlate();
        }
    }

    // Check if the object is on the plate
    private bool IsObjectBOnPlate(GameObject objectB)
    {
        if (plate == null) return false;
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }

    // Clear the plate of all objects
    private void ClearPlate()
    {
        if (plate != null)
        {
            // Call PlateHover to clear all objects
            plate.ClearAllObjects();

            // Reset the state
            currentObjectB = null;
            isSnapped = false;

            Debug.Log("Plate cleared.");
        }
    }
} */

/*V3
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectBPrefab; // Assign the Object B prefab
    public GameObject currentObjectB;
    public PlateHover plate; // Reference to PlateHover script
    private bool isSnapped = false; // Flag to check if Object B has snapped

    void Update()
    {
        // Check if the plate is full
        if (plate.objectsOnPlate.Count >= 6)
        {
            Debug.Log("Plate is full. Cannot attach more objects.");
        }
        else
        {
            // Check for the left mouse button click
            if (Input.GetMouseButtonDown(0)) // Left mouse button click
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    if (currentObjectB != null && !isSnapped)
                    {
                        Destroy(currentObjectB);
                    }

                    if (currentObjectB == null || isSnapped)
                    {
                        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        spawnPosition.z = 0;
                        currentObjectB = Instantiate(objectBPrefab, spawnPosition, Quaternion.identity);
                        isSnapped = false;
                    }
                }
            }

            // Allow dragging the spawned Object B
            if (currentObjectB != null && !isSnapped)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;
                currentObjectB.transform.position = mousePosition;
            }

            // Check for collision and snap Object B to plate
            if (currentObjectB != null && plate != null && !isSnapped)
            {
                if (IsObjectBOnPlate(currentObjectB))
                {
                    Vector3 snapPosition = plate.GetClosestSnapPoint(currentObjectB.transform.position);
                    currentObjectB.transform.position = snapPosition;
                    isSnapped = true;

                    plate.SetSnappedPosition(snapPosition);
                    plate.objectB = currentObjectB;

                    // Add the object to the plate's list of objects
                    plate.AddObjectToPlate(currentObjectB);
                }
            }
        }

        // Clear the plate when the S key is pressed
        if (Input.GetKeyDown(KeyCode.S)) // Detect the S key press
        {
            ClearPlate();
        }
    }

    // Check if the object is on the plate
    private bool IsObjectBOnPlate(GameObject objectB)
    {
        if (plate == null) return false;
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }

    // Clear the plate of all objects
    private void ClearPlate()
    {
        if (plate != null)
        {
            // Call PlateHover to clear all objects
            plate.ClearAllObjects();

            // Reset the state
            currentObjectB = null;
            isSnapped = false;

            Debug.Log("Plate cleared.");
        }
    }
} */

using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectBPrefab; // Assign the Object B prefab
    public GameObject currentObjectB;
    public PlateHover plate; // Reference to PlateHover script
    private bool isSnapped = false; // Flag to check if Object B has snapped

    void Update()
    {
        // Check if the plate is full
        if (plate.objectsOnPlate.Count >= 6)
        {
            Debug.Log("Plate is full. Cannot attach more objects.");
        }
        else
        {
            // Check for the left mouse button click
            if (Input.GetMouseButtonDown(0)) // Left mouse button click
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    if (currentObjectB != null && !isSnapped)
                    {
                        Destroy(currentObjectB);
                    }

                    if (currentObjectB == null || isSnapped)
                    {
                        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        spawnPosition.z = 0;
                        currentObjectB = Instantiate(objectBPrefab, spawnPosition, Quaternion.identity);
                        isSnapped = false;
                    }
                }
            }

            // Allow dragging the spawned Object B
            if (currentObjectB != null && !isSnapped)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;
                currentObjectB.transform.position = mousePosition;
            }

            // Check for collision and snap Object B to plate
            if (currentObjectB != null && plate != null && !isSnapped)
            {
                if (IsObjectBOnPlate(currentObjectB))
                {
                    Vector3 snapPosition = plate.GetClosestSnapPoint(currentObjectB.transform.position);
                    currentObjectB.transform.position = snapPosition;
                    isSnapped = true;

                    plate.SetSnappedPosition(snapPosition);
                    plate.objectB = currentObjectB;

                    // Add the object to the plate's list of objects
                    plate.AddObjectToPlate(currentObjectB);
                }
            }
        }

        // Clear the plate when the S key is pressed
        if (Input.GetKeyDown(KeyCode.S)) // Detect the S key press
        {
            ClearPlate();
        }
    }

    // Check if the object is on the plate
    private bool IsObjectBOnPlate(GameObject objectB)
    {
        if (plate == null) return false;
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }

    // Clear the plate of all objects
    private void ClearPlate()
    {
        if (plate != null)
        {
            // Call PlateHover to clear all objects
            plate.ClearAllObjects();

            // Reset the state
            currentObjectB = null;
            isSnapped = false;

            Debug.Log("Plate cleared.");
        }
    }
}

