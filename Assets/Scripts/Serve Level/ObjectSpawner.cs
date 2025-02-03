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
        if (currentObjectB != null && !isSnapped)
        {
            // Make the object disappear (destroy it)
            Destroy(currentObjectB);
        }
        ClearPlate(); // Clear objects on the plate
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
}*/


/* V4
using UnityEngine;
using System.Linq;

using System.Collections.Generic;  // Add this to fix the List<> errors

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
            if (currentObjectB != null && !isSnapped)
            {
                // Make the object disappear (destroy it)
                Destroy(currentObjectB);
            }
            ClearPlate(); // Clear objects on the plate
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ValidateOrder();
        }
    }

    private void ValidateOrder()
{
    bool hasOnlyRotiCanai = plate.objectsOnPlate.Count == 1 && plate.objectsOnPlate[0].name.Contains("roti_canai");
    
    if (hasOnlyRotiCanai)
    {
        Debug.Log("right order");
        CustomerSpawner customerSpawner = FindObjectOfType<CustomerSpawner>();
        if (customerSpawner != null)
        {
            customerSpawner.RemoveCustomerAndSpeechBubble();
        }
    }
    else
    {
        Debug.Log("wrong order");
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


/* V5
using UnityEngine;
using System.Collections.Generic;  // Add this to fix the List<> errors

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
            if (currentObjectB != null && !isSnapped)
            {
                // Make the object disappear (destroy it)
                Destroy(currentObjectB);
            }
            ClearPlate(); // Clear objects on the plate
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ValidateOrder();
        }
    }

    private void ValidateOrder()
{
    CustomerSpawner customerSpawner = FindObjectOfType<CustomerSpawner>();
    if (customerSpawner == null)
    {
        Debug.LogError("CustomerSpawner not found.");
        return;
    }

    // Check the speech bubble order type
    string speechBubbleOrder = customerSpawner.currentSpeechBubble.name;

    if (speechBubbleOrder.Contains("order_2"))
    {
        // Validate for "order_2" (only roti canai required)
        if (plate.objectsOnPlate.Count == 1 && plate.objectsOnPlate[0].name.Contains("roti_canai"))
        {
            Debug.Log("Right order for Order 2: Roti Canai!");
            customerSpawner.RemoveCustomerAndSpeechBubble();
            ClearPlate(); // Clear the plate since the order is correct
        }
        else
        {
            Debug.Log("Wrong order for Order 2. Plate remains unchanged.");
        }
    }
    else if (speechBubbleOrder.Contains("order_1"))
    {
        // Validate for "order_1" (specific items in any order)
        string[] requiredItems = { "rice", "peanut", "sambal", "anchovies", "cucumber", "egg" };

        // Ensure plate contains exactly the required number of items
        if (plate.objectsOnPlate.Count != requiredItems.Length)
        {
            Debug.Log("Wrong order for Order 1. Incorrect number of items. Plate remains unchanged.");
            return;
        }

        // Create a dictionary to count the occurrences of required items
        Dictionary<string, int> requiredItemCounts = new Dictionary<string, int>();
        foreach (string item in requiredItems)
        {
            requiredItemCounts[item] = 0;
        }

        // Count items on the plate
        foreach (GameObject item in plate.objectsOnPlate)
        {
            foreach (string requiredItem in requiredItems)
            {
                if (item.name.Contains(requiredItem))
                {
                    requiredItemCounts[requiredItem]++;
                    break;
                }
            }
        }

        // Validate if each required item is present exactly once
        foreach (KeyValuePair<string, int> kvp in requiredItemCounts)
        {
            if (kvp.Value != 1)
            {
                Debug.Log($"Wrong order for Order 1. {kvp.Key} count is {kvp.Value}, expected 1. Plate remains unchanged.");
                return;
            }
        }

        Debug.Log("Right order for Order 1!");
        customerSpawner.RemoveCustomerAndSpeechBubble();
        ClearPlate(); // Clear the plate since the order is correct
    }
    else
    {
        Debug.Log("Unknown order type. Plate remains unchanged.");
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


/* V5: with customer reaction
using UnityEngine;
using System.Collections.Generic;  // Add this to fix the List<> errors

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
            if (currentObjectB != null && !isSnapped)
            {
                // Make the object disappear (destroy it)
                Destroy(currentObjectB);
            }
            ClearPlate(); // Clear objects on the plate
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ValidateOrder();
        }
    }

    private void ValidateOrder()
{
    CustomerSpawner customerSpawner = FindObjectOfType<CustomerSpawner>();
    if (customerSpawner == null)
    {
        Debug.LogError("CustomerSpawner not found.");
        return;
    }

    // Check the speech bubble order type
    string speechBubbleOrder = customerSpawner.currentSpeechBubble.name;

    if (speechBubbleOrder.Contains("order_2"))
    {
        // Validate for "order_2" (only roti canai required)
        if (plate.objectsOnPlate.Count == 1 && plate.objectsOnPlate[0].name.Contains("roti_canai"))
        {
            Debug.Log("Right order for Order 2: Roti Canai!");
            customerSpawner.RemoveCustomerAndSpeechBubble(true); // Pass true for correct order
            ClearPlate(); // Clear the plate since the order is correct
        }
        else
        {
            Debug.Log("Wrong order for Order 2. Plate remains unchanged.");
            customerSpawner.RemoveCustomerAndSpeechBubble(false); // Pass false for incorrect order
        }
    }
    else if (speechBubbleOrder.Contains("order_1"))
    {
        // Validate for "order_1" (specific items in any order)
        string[] requiredItems = { "rice", "peanut", "sambal", "anchovies", "cucumber", "egg" };

        // Ensure plate contains exactly the required number of items
        if (plate.objectsOnPlate.Count != requiredItems.Length)
        {
            Debug.Log("Wrong order for Order 1. Incorrect number of items. Plate remains unchanged.");
            customerSpawner.RemoveCustomerAndSpeechBubble(false); // Pass false for incorrect order
            return;
        }

        // Create a dictionary to count the occurrences of required items
        Dictionary<string, int> requiredItemCounts = new Dictionary<string, int>();
        foreach (string item in requiredItems)
        {
            requiredItemCounts[item] = 0;
        }

        // Count items on the plate
        foreach (GameObject item in plate.objectsOnPlate)
        {
            foreach (string requiredItem in requiredItems)
            {
                if (item.name.Contains(requiredItem))
                {
                    requiredItemCounts[requiredItem]++;
                    break;
                }
            }
        }

        // Validate if each required item is present exactly once
        foreach (KeyValuePair<string, int> kvp in requiredItemCounts)
        {
            if (kvp.Value != 1)
            {
                Debug.Log($"Wrong order for Order 1. {kvp.Key} count is {kvp.Value}, expected 1. Plate remains unchanged.");
                customerSpawner.RemoveCustomerAndSpeechBubble(false); // Pass false for incorrect order
                return;
            }
        }

        Debug.Log("Right order for Order 1!");
        customerSpawner.RemoveCustomerAndSpeechBubble(true); // Pass true for correct order
        ClearPlate(); // Clear the plate since the order is correct
    }
    else
    {
        Debug.Log("Unknown order type. Plate remains unchanged.");
        customerSpawner.RemoveCustomerAndSpeechBubble(false); // Pass false for incorrect order
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


/* V6: No longer says it's right and then wrong
using UnityEngine;
using System.Collections.Generic;

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
            if (Input.GetMouseButtonDown(0))
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentObjectB != null && !isSnapped)
            {
                Destroy(currentObjectB);
            }
            ClearPlate();
        }

        // Validate the order when the W key is pressed
        if (Input.GetKeyDown(KeyCode.W))
        {
            ValidateOrder();
        }
    }

    private void ValidateOrder()
    {
        CustomerSpawner customerSpawner = FindObjectOfType<CustomerSpawner>();
        if (customerSpawner == null)
        {
            Debug.LogError("CustomerSpawner not found.");
            return;
        }

        string speechBubbleOrder = customerSpawner.currentSpeechBubble.name;

        if (plate.objectsOnPlate.Count == 0)
        {
            Debug.Log("Validation failed: Plate is empty.");
            return;
        }

        if (speechBubbleOrder.Contains("order_2"))
        {
            if (plate.objectsOnPlate.Count == 1 && plate.objectsOnPlate[0].name.Contains("roti_canai"))
            {
                Debug.Log("Right order for Order 2: Roti Canai!");
                customerSpawner.RemoveCustomerAndSpeechBubble();
                ClearPlate();
            }
            else
            {
                Debug.Log("Wrong order for Order 2.");
            }
        }
        else if (speechBubbleOrder.Contains("order_1"))
        {
            string[] requiredItems = { "rice", "peanut", "sambal", "anchovies", "cucumber", "egg" };

            if (plate.objectsOnPlate.Count != requiredItems.Length)
            {
                Debug.Log("Wrong order for Order 1: Incorrect number of items.");
                return;
            }

            Dictionary<string, int> requiredItemCounts = new Dictionary<string, int>();
            foreach (string item in requiredItems)
            {
                requiredItemCounts[item] = 0;
            }

            foreach (GameObject item in plate.objectsOnPlate)
            {
                foreach (string requiredItem in requiredItems)
                {
                    if (item.name.Contains(requiredItem))
                    {
                        requiredItemCounts[requiredItem]++;
                        break;
                    }
                }
            }

            foreach (KeyValuePair<string, int> kvp in requiredItemCounts)
            {
                if (kvp.Value != 1)
                {
                    Debug.Log($"Wrong order for Order 1: {kvp.Key} count is {kvp.Value}, expected 1.");
                    return;
                }
            }

            Debug.Log("Right order for Order 1!");
            customerSpawner.RemoveCustomerAndSpeechBubble();
            ClearPlate();
        }
        else
        {
            Debug.Log("Unknown order type.");
        }
    }

    private bool IsObjectBOnPlate(GameObject objectB)
    {
        if (plate == null) return false;
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }

    private void ClearPlate()
    {
        if (plate != null)
        {
            plate.ClearAllObjects();

            currentObjectB = null;
            isSnapped = false;

            Debug.Log("Plate cleared.");
        }
    }
} */

/* V6: fix reaction but customer move slow 
using UnityEngine;
using System.Collections.Generic;

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
            if (Input.GetMouseButtonDown(0))
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentObjectB != null && !isSnapped)
            {
                Destroy(currentObjectB);
            }
            ClearPlate();
        }

        // Validate the order when the W key is pressed
        if (Input.GetKeyDown(KeyCode.W))
        {
            ValidateOrder();
        }
    }

    private void ValidateOrder()
{
    CustomerSpawner customerSpawner = FindObjectOfType<CustomerSpawner>();
    if (customerSpawner == null)
    {
        Debug.LogError("CustomerSpawner not found.");
        return;
    }

    string speechBubbleOrder = customerSpawner.currentSpeechBubble.name;

    if (plate.objectsOnPlate.Count == 0)
    {
        Debug.Log("Validation failed: Plate is empty.");
        return;
    }

    if (speechBubbleOrder.Contains("order_2"))
    {
        if (plate.objectsOnPlate.Count == 1 && plate.objectsOnPlate[0].name.Contains("roti_canai"))
        {
            Debug.Log("Right order for Order 2: Roti Canai!");
            customerSpawner.RemoveCustomerAndSpeechBubble(true);
            ClearPlate();
        }
        else
        {
            Debug.Log("Wrong order for Order 2.");
            customerSpawner.RemoveCustomerAndSpeechBubble(false);
        }
    }
    else if (speechBubbleOrder.Contains("order_1"))
    {
        string[] requiredItems = { "rice", "peanut", "sambal", "anchovies", "cucumber", "egg" };

        if (plate.objectsOnPlate.Count != requiredItems.Length)
        {
            Debug.Log("Wrong order for Order 1: Incorrect number of items.");
            customerSpawner.RemoveCustomerAndSpeechBubble(false);
            return;
        }

        // Check if the items are in the correct order
        for (int i = 0; i < requiredItems.Length; i++)
        {
            if (!plate.objectsOnPlate[i].name.Contains(requiredItems[i]))
            {
                Debug.Log($"Wrong order for Order 1: Item at position {i + 1} is incorrect.");
                customerSpawner.RemoveCustomerAndSpeechBubble(false);
                return;
            }
        }

        Debug.Log("Right order for Order 1!");
        customerSpawner.RemoveCustomerAndSpeechBubble(true);
        ClearPlate();
    }
    else
    {
        Debug.Log("Unknown order type.");
    }
}


    private bool IsObjectBOnPlate(GameObject objectB)
    {
        if (plate == null) return false;
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }

    private void ClearPlate()
    {
        if (plate != null)
        {
            plate.ClearAllObjects();

            currentObjectB = null;
            isSnapped = false;

            Debug.Log("Plate cleared.");
        }
    }
} */


/* V7
using UnityEngine;
using System.Collections.Generic;

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
            if (Input.GetMouseButtonDown(0))
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentObjectB != null && !isSnapped)
            {
                Destroy(currentObjectB);
            }
            ClearPlate();
        }

        // Validate the order when the W key is pressed
        if (Input.GetKeyDown(KeyCode.W))
        {
            ValidateOrder();
        }
    }

    private void ValidateOrder()
{
    CustomerSpawner customerSpawner = FindObjectOfType<CustomerSpawner>();
    if (customerSpawner == null)
    {
        Debug.LogError("CustomerSpawner not found.");
        return;
    }

    string speechBubbleOrder = customerSpawner.currentSpeechBubble.name;

    if (plate.objectsOnPlate.Count == 0)
    {
        Debug.Log("Validation failed: Plate is empty.");
        return;
    }

    if (speechBubbleOrder.Contains("order_2"))
    {
        if (plate.objectsOnPlate.Count == 1 && plate.objectsOnPlate[0].name.Contains("roti_canai"))
        {
            Debug.Log("Right order for Order 2: Roti Canai!");
            customerSpawner.RemoveCustomerAndSpeechBubble(true);
            ClearPlate();
        }
        else
        {
            Debug.Log("Wrong order for Order 2.");
            customerSpawner.RemoveCustomerAndSpeechBubble(false);
        }
    }
    else if (speechBubbleOrder.Contains("order_1"))
    {
        string[] requiredItems = { "rice", "peanut", "sambal", "anchovies", "cucumber", "egg" };

        if (plate.objectsOnPlate.Count != requiredItems.Length)
        {
            Debug.Log("Wrong order for Order 1: Incorrect number of items.");
            customerSpawner.RemoveCustomerAndSpeechBubble(false);
            return;
        }

        // Check if the items are in the correct order
        for (int i = 0; i < requiredItems.Length; i++)
        {
            if (!plate.objectsOnPlate[i].name.Contains(requiredItems[i]))
            {
                Debug.Log($"Wrong order for Order 1: Item at position {i + 1} is incorrect.");
                customerSpawner.RemoveCustomerAndSpeechBubble(false);
                return;
            }
        }

        Debug.Log("Right order for Order 1!");
        customerSpawner.RemoveCustomerAndSpeechBubble(true);
        ClearPlate();
    }
    else
    {
        Debug.Log("Unknown order type.");
    }
}


    private bool IsObjectBOnPlate(GameObject objectB)
    {
        if (plate == null) return false;
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }

    private void ClearPlate()
    {
        if (plate != null)
        {
            plate.ClearAllObjects();

            currentObjectB = null;
            isSnapped = false;

            Debug.Log("Plate cleared.");
        }
    }
} */


/* V8
using UnityEngine;
using System.Collections.Generic;

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
            if (Input.GetMouseButtonDown(0))
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentObjectB != null && !isSnapped)
            {
                Destroy(currentObjectB);
            }
            ClearPlate();
        }

        // Validate the order when the W key is pressed
        if (Input.GetKeyDown(KeyCode.W))
        {
            ValidateOrder();
        }
    }

    private void ValidateOrder()
{
    CustomerSpawner customerSpawner = FindObjectOfType<CustomerSpawner>();
    if (customerSpawner == null)
    {
        Debug.LogError("CustomerSpawner not found.");
        return;
    }

    string speechBubbleOrder = customerSpawner.currentSpeechBubble.name;

    if (plate.objectsOnPlate.Count == 0)
    {
        Debug.Log("Validation failed: Plate is empty.");
        return;
    }

    if (speechBubbleOrder.Contains("order_2"))
    {
        if (plate.objectsOnPlate.Count == 1 && plate.objectsOnPlate[0].name.Contains("roti_canai"))
        {
            Debug.Log("Right order for Order 2: Roti Canai!");
            customerSpawner.RemoveCustomerAndSpeechBubble(true);
            ClearPlate();
        }
        else
        {
            Debug.Log("Wrong order for Order 2.");
            customerSpawner.RemoveCustomerAndSpeechBubble(false);
        }
    }
    else if (speechBubbleOrder.Contains("order_1"))
    {
        string[] requiredItems = { "rice", "peanut", "sambal", "anchovies", "cucumber", "egg" };

        if (plate.objectsOnPlate.Count != requiredItems.Length)
        {
            Debug.Log("Wrong order for Order 1: Incorrect number of items.");
            customerSpawner.RemoveCustomerAndSpeechBubble(false);
            return;
        }

        // Check if the items are in the correct order
        for (int i = 0; i < requiredItems.Length; i++)
        {
            if (!plate.objectsOnPlate[i].name.Contains(requiredItems[i]))
            {
                Debug.Log($"Wrong order for Order 1: Item at position {i + 1} is incorrect.");
                customerSpawner.RemoveCustomerAndSpeechBubble(false);
                return;
            }
        }

        Debug.Log("Right order for Order 1!");
        customerSpawner.RemoveCustomerAndSpeechBubble(true);
        ClearPlate();
    }
    else
    {
        Debug.Log("Unknown order type.");
    }
}


    private bool IsObjectBOnPlate(GameObject objectB)
    {
        if (plate == null) return false;
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }

    private void ClearPlate()
    {
        if (plate != null)
        {
            plate.ClearAllObjects();

            currentObjectB = null;
            isSnapped = false;

            Debug.Log("Plate cleared.");
        }
    }
} */
/*V10: Fix Nasi lemak order so it doesn't matter which order they put
using UnityEngine;
using System.Collections.Generic;

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
            if (Input.GetMouseButtonDown(0))
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentObjectB != null && !isSnapped)
            {
                Destroy(currentObjectB);
            }
            ClearPlate();
        }

        // Validate the order when the W key is pressed
        if (Input.GetKeyDown(KeyCode.W))
        {
            ValidateOrder();
        }
    }

    private void ValidateOrder()
{
    CustomerSpawner customerSpawner = FindObjectOfType<CustomerSpawner>();
    if (customerSpawner == null)
    {
        Debug.LogError("CustomerSpawner not found.");
        return;
    }

    string speechBubbleOrder = customerSpawner.currentSpeechBubble.name;

    if (plate.objectsOnPlate.Count == 0)
    {
        Debug.Log("Validation failed: Plate is empty.");
        return;
    }

    if (speechBubbleOrder.Contains("order_2"))
    {
        if (plate.objectsOnPlate.Count == 1 && plate.objectsOnPlate[0].name.Contains("roti_canai"))
        {
            Debug.Log("Right order for Order 2: Roti Canai!");
            customerSpawner.RemoveCustomerAndSpeechBubble(true);
            ClearPlate();
        }
        else
        {
            Debug.Log("Wrong order for Order 2.");
            customerSpawner.RemoveCustomerAndSpeechBubble(false);
        }
    }
    else if (speechBubbleOrder.Contains("order_1"))
{
    string[] requiredItems = { "rice", "peanut", "sambal", "anchovies", "cucumber", "egg" };

    if (plate.objectsOnPlate.Count != requiredItems.Length)
    {
        Debug.Log("Wrong order for Order 1: Incorrect number of items.");
        customerSpawner.RemoveCustomerAndSpeechBubble(false);
        return;
    }

    // Create a list of plate items to check for required items
    List<string> plateItems = new List<string>();
    foreach (var item in plate.objectsOnPlate)
    {
        plateItems.Add(item.name);
    }

    // Check if all required items are present on the plate, regardless of order
    foreach (string requiredItem in requiredItems)
    {
        if (!plateItems.Exists(item => item.Contains(requiredItem)))
        {
            Debug.Log($"Wrong order for Order 1: Missing {requiredItem}.");
            customerSpawner.RemoveCustomerAndSpeechBubble(false);
            return;
        }
    }

    Debug.Log("Right order for Order 1!");
    customerSpawner.RemoveCustomerAndSpeechBubble(true);
    ClearPlate();
}

    else
    {
        Debug.Log("Unknown order type.");
    }
}


    private bool IsObjectBOnPlate(GameObject objectB)
    {
        if (plate == null) return false;
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }

    private void ClearPlate()
    {
        if (plate != null)
        {
            plate.ClearAllObjects();

            currentObjectB = null;
            isSnapped = false;

            Debug.Log("Plate cleared.");
        }
    }
} */


/*V1: Fix nasi lemak order validation
using UnityEngine;
using System.Collections.Generic;

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
            if (Input.GetMouseButtonDown(0))
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentObjectB != null && !isSnapped)
            {
                Destroy(currentObjectB);
            }
            ClearPlate();
        }

        // Validate the order when the W key is pressed
        if (Input.GetKeyDown(KeyCode.W))
        {
            ValidateOrder();
        }
    }

    private void ValidateOrder()
{
    CustomerSpawner customerSpawner = FindObjectOfType<CustomerSpawner>();
    if (customerSpawner == null)
    {
        Debug.LogError("CustomerSpawner not found.");
        return;
    }

    string speechBubbleOrder = customerSpawner.currentSpeechBubble.name;

    if (plate.objectsOnPlate.Count == 0)
    {
        Debug.Log("Validation failed: Plate is empty.");
        return;
    }

    if (speechBubbleOrder.Contains("order_2"))
    {
        if (plate.objectsOnPlate.Count == 1 && plate.objectsOnPlate[0].name.Contains("roti_canai"))
        {
            Debug.Log("Right order for Order 2: Roti Canai!");
            customerSpawner.RemoveCustomerAndSpeechBubble(true);
            ClearPlate();
        }
        else
        {
            Debug.Log("Wrong order for Order 2.");
            customerSpawner.RemoveCustomerAndSpeechBubble(false);
        }
    }
    else if (speechBubbleOrder.Contains("order_1"))
{
    string[] requiredItems = { "rice", "peanut", "sambal", "anchovies", "cucumber", "egg" };

    if (plate.objectsOnPlate.Count != requiredItems.Length)
    {
        Debug.Log("Wrong order for Order 1: Incorrect number of items.");
        customerSpawner.RemoveCustomerAndSpeechBubble(false);
        return;
    }

    // Create a list of plate items to check for required items
    List<string> plateItems = new List<string>();
    foreach (var item in plate.objectsOnPlate)
    {
        plateItems.Add(item.name);
    }

    // Check if all required items are present on the plate, regardless of order
    foreach (string requiredItem in requiredItems)
    {
        if (!plateItems.Exists(item => item.Contains(requiredItem)))
        {
            Debug.Log($"Wrong order for Order 1: Missing {requiredItem}.");
            customerSpawner.RemoveCustomerAndSpeechBubble(false);
            return;
        }
    }

    Debug.Log("Right order for Order 1!");
    customerSpawner.RemoveCustomerAndSpeechBubble(true);
    ClearPlate();
}

    else
    {
        Debug.Log("Unknown order type.");
    }
}


    private bool IsObjectBOnPlate(GameObject objectB)
    {
        if (plate == null) return false;
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }

    private void ClearPlate()
    {
        if (plate != null)
        {
            plate.ClearAllObjects();

            currentObjectB = null;
            isSnapped = false;

            Debug.Log("Plate cleared.");
        }
    }
} */

/*V2: Working happiness bar
using UnityEngine;
using System.Collections.Generic;

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
            if (Input.GetMouseButtonDown(0))
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentObjectB != null && !isSnapped)
            {
                Destroy(currentObjectB);
            }
            ClearPlate();
        }

        // Validate the order when the W key is pressed
        if (Input.GetKeyDown(KeyCode.W))
        {
            ValidateOrder();
        }
    }

    private void ValidateOrder()
{
    CustomerSpawner customerSpawner = FindObjectOfType<CustomerSpawner>();
    if (customerSpawner == null)
    {
        Debug.LogError("CustomerSpawner not found.");
        return;
    }

    string speechBubbleOrder = customerSpawner.currentSpeechBubble.name;

    if (plate.objectsOnPlate.Count == 0)
    {
        Debug.Log("Validation failed: Plate is empty.");
        return;
    }

    if (speechBubbleOrder.Contains("order_2"))
    {
        if (plate.objectsOnPlate.Count == 1 && plate.objectsOnPlate[0].name.Contains("roti_canai"))
        {
            Debug.Log("Right order for Order 2: Roti Canai!");
            customerSpawner.RemoveCustomerAndSpeechBubble(true);
            ClearPlate();
        }
        else
        {
            Debug.Log("Wrong order for Order 2.");
            customerSpawner.RemoveCustomerAndSpeechBubble(false);
        }
    }
    else if (speechBubbleOrder.Contains("order_1"))
{
    string[] requiredItems = { "rice", "peanut", "sambal", "anchovies", "cucumber", "egg" };

    if (plate.objectsOnPlate.Count != requiredItems.Length)
    {
        Debug.Log("Wrong order for Order 1: Incorrect number of items.");
        customerSpawner.RemoveCustomerAndSpeechBubble(false);
        return;
    }

    // Create a list of plate items to check for required items
    List<string> plateItems = new List<string>();
    foreach (var item in plate.objectsOnPlate)
    {
        plateItems.Add(item.name);
    }

    // Check if all required items are present on the plate, regardless of order
    foreach (string requiredItem in requiredItems)
    {
        if (!plateItems.Exists(item => item.Contains(requiredItem)))
        {
            Debug.Log($"Wrong order for Order 1: Missing {requiredItem}.");
            customerSpawner.RemoveCustomerAndSpeechBubble(false);
            return;
        }
    }

    Debug.Log("Right order for Order 1!");
    customerSpawner.RemoveCustomerAndSpeechBubble(true);
    ClearPlate();
}

    else
    {
        Debug.Log("Unknown order type.");
    }
}


    private bool IsObjectBOnPlate(GameObject objectB)
    {
        if (plate == null) return false;
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }

    private void ClearPlate()
    {
        if (plate != null)
        {
            plate.ClearAllObjects();

            currentObjectB = null;
            isSnapped = false;

            Debug.Log("Plate cleared.");
        }
    }
} */

/*
using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectBPrefab;
    public GameObject currentObjectB;
    public PlateHover plate;
    private bool isSnapped = false;

    void Update()
    {
        if (plate.objectsOnPlate.Count >= 6)
        {
            Debug.Log("Plate is full. Cannot attach more objects.");
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
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

            if (currentObjectB != null && !isSnapped)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;
                currentObjectB.transform.position = mousePosition;
            }

            if (currentObjectB != null && plate != null && !isSnapped)
            {
                if (IsObjectBOnPlate(currentObjectB))
                {
                    Vector3 snapPosition = plate.GetClosestSnapPoint(currentObjectB.transform.position);
                    currentObjectB.transform.position = snapPosition;
                    isSnapped = true;

                    plate.SetSnappedPosition(snapPosition);
                    plate.objectB = currentObjectB;

                    plate.AddObjectToPlate(currentObjectB);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentObjectB != null && !isSnapped)
            {
                Destroy(currentObjectB);
            }
            ClearPlate();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            // Use the centralized manager to handle validation
            ValidationManager.Instance.ValidateOrder(() =>
            {
                ValidateOrder();
            });
        }
    }

    private void ValidateOrder()
    {
        CustomerSpawner customerSpawner = FindObjectOfType<CustomerSpawner>();
        if (customerSpawner == null)
        {
            Debug.LogError("CustomerSpawner not found.");
            return;
        }

        string speechBubbleOrder = customerSpawner.currentSpeechBubble.name;

        if (plate.objectsOnPlate.Count == 0)
        {
            Debug.Log("Validation failed: Plate is empty.");
            return;
        }

        if (speechBubbleOrder.Contains("order_2"))
        {
            if (plate.objectsOnPlate.Count == 1 && plate.objectsOnPlate[0].name.Contains("roti_canai"))
            {
                Debug.Log("Right order for Order 2: Roti Canai!");
                customerSpawner.RemoveCustomerAndSpeechBubble(true);
                ClearPlate();
            }
            else
            {
                Debug.Log("Wrong order for Order 2.");
                customerSpawner.RemoveCustomerAndSpeechBubble(false);
            }
        }
        else if (speechBubbleOrder.Contains("order_1"))
        {
            string[] requiredItems = { "rice", "peanut", "sambal", "anchovies", "cucumber", "egg" };

            if (plate.objectsOnPlate.Count != requiredItems.Length)
            {
                Debug.Log("Wrong order for Order 1: Incorrect number of items.");
                customerSpawner.RemoveCustomerAndSpeechBubble(false);
                return;
            }

            List<string> plateItems = new List<string>();
            foreach (var item in plate.objectsOnPlate)
            {
                plateItems.Add(item.name);
            }

            foreach (string requiredItem in requiredItems)
            {
                if (!plateItems.Exists(item => item.Contains(requiredItem)))
                {
                    Debug.Log($"Wrong order for Order 1: Missing {requiredItem}.");
                    customerSpawner.RemoveCustomerAndSpeechBubble(false);
                    return;
                }
            }

            Debug.Log("Right order for Order 1!");
            customerSpawner.RemoveCustomerAndSpeechBubble(true);
            ClearPlate();
        }
        else
        {
            Debug.Log("Unknown order type.");
        }
    }

    private bool IsObjectBOnPlate(GameObject objectB)
    {
        if (plate == null) return false;
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }

    private void ClearPlate()
    {
        if (plate != null)
        {
            plate.ClearAllObjects();

            currentObjectB = null;
            isSnapped = false;

            Debug.Log("Plate cleared.");
        }
    }
} */

using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectBPrefab;
    public GameObject currentObjectB;
    public PlateHover plate;
    private bool isSnapped = false;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    void Update()
    {
        if (plate.objectsOnPlate.Count >= 6)
        {
            Debug.Log("Plate is full. Cannot attach more objects.");
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
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
                        audioManager.PlaySFX(audioManager.pickup); //play sound effect
                        isSnapped = false;
                    }
                }
            }

            if (currentObjectB != null && !isSnapped)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;
                currentObjectB.transform.position = mousePosition;
            }

            if (currentObjectB != null && plate != null && !isSnapped)
            {
                if (IsObjectBOnPlate(currentObjectB))
                {
                    Vector3 snapPosition = plate.GetClosestSnapPoint(currentObjectB.transform.position);
                    currentObjectB.transform.position = snapPosition;
                    isSnapped = true;

                    plate.SetSnappedPosition(snapPosition);
                    plate.objectB = currentObjectB;

                    plate.AddObjectToPlate(currentObjectB);
                    audioManager.PlaySFX(audioManager.plate);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentObjectB != null && !isSnapped)
            {
                Destroy(currentObjectB);
            }

            // Use ValidationManager to handle clearing
            ValidationManager.Instance.ClearPlate(() =>
            {
                ClearPlate();
            });
            audioManager.PlaySFX(audioManager.delete);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            // Use the centralized manager to handle validation
            ValidationManager.Instance.ValidateOrder(() =>
            {
                ValidateOrder();
            });
        }
    }

    private void ValidateOrder()
    {
        CustomerSpawner customerSpawner = FindObjectOfType<CustomerSpawner>();
        if (customerSpawner == null)
        {
            Debug.LogError("CustomerSpawner not found.");
            return;
        }

        string speechBubbleOrder = customerSpawner.currentSpeechBubble.name;

        if (plate.objectsOnPlate.Count == 0)
        {
            Debug.Log("Validation failed: Plate is empty.");
            return;
        }

        if (speechBubbleOrder.Contains("order_2"))
        {
            if (plate.objectsOnPlate.Count == 1 && plate.objectsOnPlate[0].name.Contains("roti_canai"))
            {
                Debug.Log("Right order for Order 2: Roti Canai!");
                customerSpawner.RemoveCustomerAndSpeechBubble(true);
                ClearPlate();
            }
            else
            {
                Debug.Log("Wrong order for Order 2.");
                customerSpawner.RemoveCustomerAndSpeechBubble(false);
            }
        }
        else if (speechBubbleOrder.Contains("order_1"))
        {
            string[] requiredItems = { "rice", "peanut", "sambal", "anchovies", "cucumber", "egg" };

            if (plate.objectsOnPlate.Count != requiredItems.Length) //check number of items on the plate
            {
                Debug.Log("Wrong order for Order 1: Incorrect number of items.");
                customerSpawner.RemoveCustomerAndSpeechBubble(false);
                return;
            }

            List<string> plateItems = new List<string>(); //get the name of the content on the plate
            foreach (var item in plate.objectsOnPlate)
            {
                plateItems.Add(item.name);
            }

            foreach (string requiredItem in requiredItems) //check the name on the plate against the require items
            {
                if (!plateItems.Exists(item => item.Contains(requiredItem)))
                {
                    Debug.Log($"Wrong order for Order 1: Missing {requiredItem}.");
                    customerSpawner.RemoveCustomerAndSpeechBubble(false);
                    return;
                }
            }

            Debug.Log("Right order for Order 1!");
            customerSpawner.RemoveCustomerAndSpeechBubble(true);
            ClearPlate();
        }
        else if (speechBubbleOrder.Contains("order_3"))
        {
            if (plate.objectsOnPlate.Count == 1 && plate.objectsOnPlate[0].name.Contains("char_kway_teow"))
            {
                Debug.Log("Right order for Order 3: Char Kway Teow!");
                customerSpawner.RemoveCustomerAndSpeechBubble(true);
                ClearPlate();
            }
            else
            {
                Debug.Log("Wrong order for Order 3.");
                customerSpawner.RemoveCustomerAndSpeechBubble(false);
            }
        }
        else if (speechBubbleOrder.Contains("order_4"))
        {
            string[] requiredItems = { "rice", "peanut", "sambal", "chicken", "cucumber", "egg" };

            if (plate.objectsOnPlate.Count != requiredItems.Length)
            {
                Debug.Log("Wrong order for Order 1: Incorrect number of items.");
                customerSpawner.RemoveCustomerAndSpeechBubble(false);
                return;
            }

            List<string> plateItems = new List<string>();
            foreach (var item in plate.objectsOnPlate)
            {
                plateItems.Add(item.name);
            }

            foreach (string requiredItem in requiredItems)
            {
                if (!plateItems.Exists(item => item.Contains(requiredItem)))
                {
                    Debug.Log($"Wrong order for Order 1: Missing {requiredItem}.");
                    customerSpawner.RemoveCustomerAndSpeechBubble(false);
                    return;
                }
            }

            Debug.Log("Right order for Order 1!");
            customerSpawner.RemoveCustomerAndSpeechBubble(true);
            ClearPlate();
        }
        else
        {
            Debug.Log("Unknown order type.");
        }
    }

    private bool IsObjectBOnPlate(GameObject objectB)
    {
        if (plate == null) return false;
        return plate.GetComponent<Collider2D>().bounds.Contains(objectB.transform.position);
    }

    private void ClearPlate()
    {
        if (plate != null)
        {
            plate.ClearAllObjects();

            currentObjectB = null;
            isSnapped = false;
            

            Debug.Log("Plate cleared.");
        }
    }
}
