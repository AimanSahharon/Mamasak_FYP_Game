/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlateHover : MonoBehaviour
{
    private Vector3 originalPosition;
    public float hoverOffset = 0.2f; // Amount to move the object upwards when hovered

    private void Start()
    {
        // Store the object's original position
        originalPosition = transform.position;
    }

    private void OnMouseEnter()
    {
        // Move the object up when the mouse enters
        transform.position = new Vector3(originalPosition.x, originalPosition.y + hoverOffset, originalPosition.z);
    }

    private void OnMouseExit()
    {
        // Return the object to its original position when the mouse exits
        transform.position = originalPosition;
    }
} */

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateHover : MonoBehaviour
{
    private Vector3 originalPosition;
    public float hoverOffset = 0.2f; // Amount to move the object upwards when hovered
    public Transform[] snapPoints; // Array to hold the snap points

    private void Start()
    {
        // Store the object's original position
        originalPosition = transform.position;
    }

    private void OnMouseEnter()
    {
        // Move the object up when the mouse enters
        transform.position = new Vector3(originalPosition.x, originalPosition.y + hoverOffset, originalPosition.z);
    }

    private void OnMouseExit()
    {
        // Return the object to its original position when the mouse exits
        transform.position = originalPosition;
    }

    // Method to snap an object to the closest snap point
    public Vector3 GetClosestSnapPoint(Vector3 objectPosition)
    {
        Vector3 closestPoint = snapPoints[0].position;
        float closestDistance = Vector3.Distance(objectPosition, closestPoint);

        foreach (var point in snapPoints)
        {
            float distance = Vector3.Distance(objectPosition, point.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPoint = point.position;
            }
        }

        return closestPoint;
    }
} */

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateHover : MonoBehaviour
{
    private Vector3 originalPosition;
    public float hoverOffset = 0.2f; // Amount to move the object upwards when hovered
    public Transform[] snapPoints; // Array to hold the snap points

    private void Start()
    {
        // Store the object's original position
        originalPosition = transform.position;
    }

    private void OnMouseEnter()
    {
        // Move the object up when the mouse enters
        transform.position = new Vector3(originalPosition.x, originalPosition.y + hoverOffset, originalPosition.z);
    }

    private void OnMouseExit()
    {
        // Return the object to its original position when the mouse exits
        transform.position = originalPosition;
    }

    // Method to snap an object to the closest snap point
    public Vector3 GetClosestSnapPoint(Vector3 objectPosition)
    {
        Vector3 closestPoint = snapPoints[0].position;
        float closestDistance = Vector3.Distance(objectPosition, closestPoint);

        foreach (var point in snapPoints)
        {
            float distance = Vector3.Distance(objectPosition, point.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPoint = point.position;
            }
        }

        return closestPoint;
    }
} */

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateHover : MonoBehaviour
{
    private Vector3 originalPosition;
    public float hoverOffset = 0.2f; // Amount to move the object upwards when hovered
    public Transform[] snapPoints; // Array to hold the snap points
    public GameObject objectB; // Reference to Object B

    private Vector3 snappedPosition; // To track the snapped position of Object B

    private void Start()
    {
        // Store the object's original position
        originalPosition = transform.position;
    }

    private void OnMouseEnter()
    {
        // Move the plate up when the mouse enters
        transform.position = new Vector3(originalPosition.x, originalPosition.y + hoverOffset, originalPosition.z);

        // If Object B is snapped, move it along with the plate
        if (objectB != null && snappedPosition != Vector3.zero)
        {
            objectB.transform.position = new Vector3(snappedPosition.x, snappedPosition.y + hoverOffset, snappedPosition.z);
        }
    }

    private void OnMouseExit()
    {
        // Return the plate to its original position when the mouse exits
        transform.position = originalPosition;

        // If Object B is snapped, return it to its snapped position
        if (objectB != null && snappedPosition != Vector3.zero)
        {
            objectB.transform.position = snappedPosition;
        }
    }

    // Method to snap an object to the closest snap point
    public Vector3 GetClosestSnapPoint(Vector3 objectPosition)
    {
        Vector3 closestPoint = snapPoints[0].position;
        float closestDistance = Vector3.Distance(objectPosition, closestPoint);

        foreach (var point in snapPoints)
        {
            float distance = Vector3.Distance(objectPosition, point.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPoint = point.position;
            }
        }

        return closestPoint;
    }

    // Method to set the snapped position of Object B
    public void SetSnappedPosition(Vector3 position)
    {
        snappedPosition = position;
    }
} */
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateHover : MonoBehaviour
{
    private Vector3 originalPosition;
    public float hoverOffset = 0.2f; // Amount to move the object upwards when hovered
    public Transform[] snapPoints; // Array to hold the snap points
    public GameObject objectB; // Reference to Object B

    private Vector3 snappedPosition; // To track the snapped position of Object B

    private void Start()
    {
        // Store the object's original position
        originalPosition = transform.position;
    }

   private void OnMouseEnter()
    {
        // Move the plate up when the mouse enters
        transform.position = new Vector3(originalPosition.x, originalPosition.y + hoverOffset, originalPosition.z);

        // If Object B is snapped, move it along with the plate
        if (objectB != null && snappedPosition != Vector3.zero)
        {
            objectB.transform.position = new Vector3(snappedPosition.x, snappedPosition.y + hoverOffset, snappedPosition.z);
        }
    }

    private void OnMouseExit()
    {
        // Return the plate to its original position when the mouse exits
        transform.position = originalPosition;

        // If Object B is snapped, return it to its snapped position
        if (objectB != null && snappedPosition != Vector3.zero)
        {
            objectB.transform.position = snappedPosition;
        }
    } 

    // Method to snap an object to the closest snap point
    public Vector3 GetClosestSnapPoint(Vector3 objectPosition)
    {
        Vector3 closestPoint = snapPoints[0].position;
        float closestDistance = Vector3.Distance(objectPosition, closestPoint);

        foreach (var point in snapPoints)
        {
            float distance = Vector3.Distance(objectPosition, point.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPoint = point.position;
            }
        }

        return closestPoint;
    }

    // Method to set the snapped position of Object B
    public void SetSnappedPosition(Vector3 position)
    {
        snappedPosition = position;
    }
} */

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateHover : MonoBehaviour
{
    private Vector3 originalPosition;
    public float hoverOffset = 0.2f; // Amount to move the object upwards when hovered
    public Transform[] snapPoints; // Array to hold the snap points
    public GameObject objectB; // Reference to Object B

    public Vector3 snappedPosition; // To track the snapped position of Object B
    public List<Transform> occupiedSnapPoints = new List<Transform>(); // List of occupied snap points

    private void Start()
    {
        // Store the object's original position
        originalPosition = transform.position;
    }

    // Method to snap an object to the closest snap point
    public Vector3 GetClosestSnapPoint(Vector3 objectPosition)
    {
        Vector3 closestPoint = snapPoints[0].position;
        float closestDistance = Vector3.Distance(objectPosition, closestPoint);

        foreach (var point in snapPoints)
        {
            // Skip snap points that are already occupied
            if (occupiedSnapPoints.Contains(point))
                continue;

            float distance = Vector3.Distance(objectPosition, point.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPoint = point.position;
            }
        }

        return closestPoint;
    }

    // Method to set the snapped position of Object B
    public void SetSnappedPosition(Vector3 position)
    {
        snappedPosition = position;

        // Add this snap point to the list of occupied points
        foreach (var point in snapPoints)
        {
            if (point.position == position && !occupiedSnapPoints.Contains(point))
            {
                occupiedSnapPoints.Add(point);
            }
        }
    }

    // Method to free a snap point if Object B is removed or unsnapped
    public void FreeSnapPoint(Vector3 position)
    {
        foreach (var point in snapPoints)
        {
            if (point.position == position)
            {
                occupiedSnapPoints.Remove(point);
                break;
            }
        }
    }
} */

/*V1
using System.Collections.Generic;
using UnityEngine;

public class PlateHover : MonoBehaviour
{
    private Vector3 originalPosition;
    public float hoverOffset = 0.2f; // Amount to move the object upwards when hovered
    public Transform[] snapPoints; // Array to hold the snap points
    public GameObject objectB; // Reference to Object B

    public Vector3 snappedPosition; // To track the snapped position of Object B
    public List<Transform> occupiedSnapPoints = new List<Transform>(); // List of occupied snap points

    private void Start()
    {
        // Store the object's original position
        originalPosition = transform.position;
    }

    // Method to snap an object to the closest snap point
    public Vector3 GetClosestSnapPoint(Vector3 objectPosition)
    {
        if (snapPoints == null || snapPoints.Length == 0)
        {
            Debug.LogError("No snap points assigned!");
            return objectPosition;
        }

        Vector3 closestPoint = snapPoints[0].position;
        float closestDistance = Vector3.Distance(objectPosition, closestPoint);

        foreach (var point in snapPoints)
        {
            // Skip snap points that are already occupied
            if (occupiedSnapPoints.Contains(point))
                continue;

            float distance = Vector3.Distance(objectPosition, point.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPoint = point.position;
            }
        }

        return closestPoint;
    }

    // Method to set the snapped position of Object B
    public void SetSnappedPosition(Vector3 position)
    {
        snappedPosition = position;

        // Add this snap point to the list of occupied points
        foreach (var point in snapPoints)
        {
            if (Vector3.Distance(point.position, position) < 0.01f && !occupiedSnapPoints.Contains(point))
            {
                occupiedSnapPoints.Add(point);
                break;
            }
        }
    }

    // In PlateHover.cs

// Method to get the snapped position of the object B
public Vector3 GetSnappedPosition()
{
    return snappedPosition;
}

// Method to free a snap point if Object B is removed or unsnapped
public void FreeSnapPoint(Vector3 position)
{
    foreach (var point in snapPoints)
    {
        if (Vector3.Distance(point.position, position) < 0.01f)
        {
            occupiedSnapPoints.Remove(point);
            break;
        }
    }
}
   
} */


/*V2
using System.Collections.Generic;
using UnityEngine;

public class PlateHover : MonoBehaviour
{
    private Vector3 originalPosition;
    public float hoverOffset = 0.2f; // Amount to move the object upwards when hovered
    public Transform[] snapPoints; // Array to hold the snap points
    public GameObject objectB; // Reference to Object B

    public Vector3 snappedPosition; // To track the snapped position of Object B
    public List<Transform> occupiedSnapPoints = new List<Transform>(); // List of occupied snap points
    public List<GameObject> objectsOnPlate = new List<GameObject>(); // Track all objects on the plate

    private void Start()
    {
        // Store the object's original position
        originalPosition = transform.position;
    }

    // Method to snap an object to the closest snap point
    public Vector3 GetClosestSnapPoint(Vector3 objectPosition)
    {
        if (snapPoints == null || snapPoints.Length == 0)
        {
            Debug.LogError("No snap points assigned!");
            return objectPosition;
        }

        Vector3 closestPoint = snapPoints[0].position;
        float closestDistance = Vector3.Distance(objectPosition, closestPoint);

        foreach (var point in snapPoints)
        {
            // Skip snap points that are already occupied
            if (occupiedSnapPoints.Contains(point))
                continue;

            float distance = Vector3.Distance(objectPosition, point.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPoint = point.position;
            }
        }

        return closestPoint;
    }

    // Method to set the snapped position of Object B
    public void SetSnappedPosition(Vector3 position)
    {
        snappedPosition = position;

        // Add this snap point to the list of occupied points
        foreach (var point in snapPoints)
        {
            if (Vector3.Distance(point.position, position) < 0.01f && !occupiedSnapPoints.Contains(point))
            {
                occupiedSnapPoints.Add(point);
                break;
            }
        }
    }

    // Add the snapped object to the list of objects on the plate
    public void AddObjectToPlate(GameObject objectB)
    {
        if (!objectsOnPlate.Contains(objectB))
        {
            objectsOnPlate.Add(objectB);
        }
    }

    // Method to clear all objects on the plate
    public void ClearAllObjects()
    {
        foreach (var objectB in objectsOnPlate)
        {
            if (objectB != null)
            {
                // Free the snap point and destroy the object
                FreeSnapPoint(objectB.transform.position);
                Destroy(objectB);
            }
        }
        objectsOnPlate.Clear(); // Clear the list
    }

    // Method to get the snapped position of the object B
    public Vector3 GetSnappedPosition()
    {
        return snappedPosition;
    }

    // Method to free a snap point if Object B is removed or unsnapped
    public void FreeSnapPoint(Vector3 position)
    {
        foreach (var point in snapPoints)
        {
            if (Vector3.Distance(point.position, position) < 0.01f)
            {
                occupiedSnapPoints.Remove(point);
                break;
            }
        }
    }
} */

/* V3
using System.Collections.Generic;
using UnityEngine;

public class PlateHover : MonoBehaviour
{
    private Vector3 originalPosition;
    public float hoverOffset = 0.2f; // Amount to move the object upwards when hovered
    public Transform[] snapPoints; // Array to hold the snap points
    public GameObject objectB; // Reference to Object B

    public Vector3 snappedPosition; // To track the snapped position of Object B
    public List<Transform> occupiedSnapPoints = new List<Transform>(); // List of occupied snap points
    public List<GameObject> objectsOnPlate = new List<GameObject>(); // Track all objects on the plate

    private void Start()
    {
        // Store the object's original position
        originalPosition = transform.position;
    }

    // Method to snap an object to the closest snap point
    public Vector3 GetClosestSnapPoint(Vector3 objectPosition)
    {
        if (snapPoints == null || snapPoints.Length == 0)
        {
            Debug.LogError("No snap points assigned!");
            return objectPosition;
        }

        Vector3 closestPoint = snapPoints[0].position;
        float closestDistance = Vector3.Distance(objectPosition, closestPoint);

        foreach (var point in snapPoints)
        {
            // Skip snap points that are already occupied
            if (occupiedSnapPoints.Contains(point))
                continue;

            float distance = Vector3.Distance(objectPosition, point.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPoint = point.position;
            }
        }

        return closestPoint;
    }

    // Method to set the snapped position of Object B
    public void SetSnappedPosition(Vector3 position)
    {
        snappedPosition = position;

        // Add this snap point to the list of occupied points
        foreach (var point in snapPoints)
        {
            if (Vector3.Distance(point.position, position) < 0.01f && !occupiedSnapPoints.Contains(point))
            {
                occupiedSnapPoints.Add(point);
                break;
            }
        }
    }

    // Add the snapped object to the list of objects on the plate
    public void AddObjectToPlate(GameObject objectB)
    {
        if (!objectsOnPlate.Contains(objectB))
        {
            objectsOnPlate.Add(objectB);
        }
    }

    // Method to clear all objects on the plate
    public void ClearAllObjects()
    {
        foreach (var objectB in objectsOnPlate)
        {
            if (objectB != null)
            {
                // Free the snap point and destroy the object
                FreeSnapPoint(objectB.transform.position);
                Destroy(objectB);
            }
        }
        objectsOnPlate.Clear(); // Clear the list
    }

    // Method to get the snapped position of the object B
    public Vector3 GetSnappedPosition()
    {
        return snappedPosition;
    }

    // Method to free a snap point if Object B is removed or unsnapped
    public void FreeSnapPoint(Vector3 position)
    {
        foreach (var point in snapPoints)
        {
            if (Vector3.Distance(point.position, position) < 0.01f)
            {
                occupiedSnapPoints.Remove(point);
                break;
            }
        }
    }
} */

using System.Collections.Generic;
using UnityEngine;

public class PlateHover : MonoBehaviour
{
    private Vector3 originalPosition;
    public float hoverOffset = 0.2f; // Amount to move the object upwards when hovered
    public Transform[] snapPoints; // Array to hold the snap points
    public GameObject objectB; // Reference to Object B

    public Vector3 snappedPosition; // To track the snapped position of Object B
    public List<Transform> occupiedSnapPoints = new List<Transform>(); // List of occupied snap points
    public List<GameObject> objectsOnPlate = new List<GameObject>(); // Track all objects on the plate

    private void Start()
    {
        // Store the object's original position
        originalPosition = transform.position;
    }

    // Method to snap an object to the closest snap point
    public Vector3 GetClosestSnapPoint(Vector3 objectPosition)
    {
        if (snapPoints == null || snapPoints.Length == 0)
        {
            Debug.LogError("No snap points assigned!");
            return objectPosition;
        }

        Vector3 closestPoint = snapPoints[0].position;
        float closestDistance = Vector3.Distance(objectPosition, closestPoint);

        foreach (var point in snapPoints)
        {
            // Skip snap points that are already occupied
            if (occupiedSnapPoints.Contains(point))
                continue;

            float distance = Vector3.Distance(objectPosition, point.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPoint = point.position;
            }
        }

        return closestPoint;
    }

    // Method to set the snapped position of Object B
    public void SetSnappedPosition(Vector3 position)
    {
        snappedPosition = position;

        // Add this snap point to the list of occupied points
        foreach (var point in snapPoints)
        {
            if (Vector3.Distance(point.position, position) < 0.01f && !occupiedSnapPoints.Contains(point))
            {
                occupiedSnapPoints.Add(point);
                break;
            }
        }
    }

    // Add the snapped object to the list of objects on the plate
    public void AddObjectToPlate(GameObject objectB)
    {
        if (!objectsOnPlate.Contains(objectB))
        {
            objectsOnPlate.Add(objectB);
        }
    }

    // Method to clear all objects on the plate
    public void ClearAllObjects()
    {
        foreach (var objectB in objectsOnPlate)
        {
            if (objectB != null)
            {
                // Free the snap point and destroy the object
                FreeSnapPoint(objectB.transform.position);
                Destroy(objectB);
            }
        }
        objectsOnPlate.Clear(); // Clear the list
    }

    // Method to get the snapped position of the object B
    public Vector3 GetSnappedPosition()
    {
        return snappedPosition;
    }

    // Method to free a snap point if Object B is removed or unsnapped
    public void FreeSnapPoint(Vector3 position)
    {
        foreach (var point in snapPoints)
        {
            if (Vector3.Distance(point.position, position) < 0.01f)
            {
                occupiedSnapPoints.Remove(point);
                break;
            }
        }
    }
}



