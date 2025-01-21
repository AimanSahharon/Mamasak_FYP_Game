/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public bool mouseclick = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if mouse is clicked then move the object
        if (mouseclick == true)
        {
            Vector2 mousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y); //to store coordinates of the mouse, update the value based on the mouse position in screen coordinates
            Vector2 objPosition = Camera.main.ScreenToWorldPoint (mousePosition); //to translate coordinates of the mouse to UNITY value or World value
            transform.position = objPosition; //to move the object that has this script attached
        }
        
    }

    void OnMouseDown()
    {
        mouseclick = !mouseclick; //if the mouse is clicked down again then set the object at the current mouse location or if the object is being click for the first time then move the object. TLDR: click the mouse to change state
    }
} */

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public bool mouseclick = false;
    private int originalSortingOrder;
    private SpriteRenderer spriteRenderer;
    private static int topSortingOrder = 100; // Adjust this if needed

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalSortingOrder = spriteRenderer.sortingOrder;
        }
    }

    void Update()
    {
        // If mouseclick is true, move the object with the mouse
        if (mouseclick)
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }

    void OnMouseDown()
    {
        mouseclick = !mouseclick;

        if (mouseclick)
        {
            // Bring the object to the top by setting a high sorting order
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = topSortingOrder;
            }
        }
        else
        {
            // Reset to the original sorting order when deselected
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = originalSortingOrder;
            }
        }
    }
} */


/* V1.1: Makes the selected object always the top layer
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public bool mouseclick = false;
    private SpriteRenderer spriteRenderer;
    private static int topSortingOrder = 100; // Starting point for sorting order

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // If mouseclick is true, move the object with the mouse
        if (mouseclick)
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }

    void OnMouseDown()
    {
        mouseclick = !mouseclick;

        if (mouseclick)
        {
            // Increment the top sorting order and assign it to the current object
            topSortingOrder++;
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = topSortingOrder;
            }
        }
    }
} */

/* V1.2: When to object touches each other it will turn into the object in the serializefield 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public bool mouseclick = false;

    [SerializeField] private GameObject newObjectPrefab; // Drag the prefab here in the Inspector
    private SpriteRenderer spriteRenderer;
    private static int topSortingOrder = 100; // Starting point for sorting order

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // If mouseclick is true, move the object with the mouse
        if (mouseclick)
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }

    void OnMouseDown()
    {
        mouseclick = !mouseclick;

        if (mouseclick)
        {
            // Increment the top sorting order and assign it to the current object
            topSortingOrder++;
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = topSortingOrder;
            }
        }
    }

    // This method is called when the object collides with another object with a Collider2D
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other object is the one you want to combine with
        if (other.CompareTag("Blender2")) // Make sure the object has this tag
        {
            // Instantiate a new object at the collision point
            Vector3 collisionPoint = transform.position;
            Instantiate(newObjectPrefab, collisionPoint, Quaternion.identity);

            // Optionally, destroy the current objects
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
} */



/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public bool mouseclick = false;
    private bool readyToCombine = false; // Indicates if the object is ready to combine
    private GameObject otherObject; // Reference to the other object in collision

    [SerializeField] private GameObject newObjectPrefab; // Drag the prefab here in the Inspector
    private SpriteRenderer spriteRenderer;
    private static int topSortingOrder = 100; // Starting point for sorting order

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // If mouseclick is true, move the object with the mouse
        if (mouseclick)
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }

    void OnMouseDown()
    {
        if (readyToCombine && otherObject != null)
        {
            // Combine the objects by instantiating the new object at the collision point
            Vector3 collisionPoint = transform.position;
            Instantiate(newObjectPrefab, collisionPoint, Quaternion.identity);

            // Destroy both the current object and the other object
            Debug.Log("Destroying both objects");
            Destroy(gameObject);
            Destroy(otherObject);
        }
        else
        {
            // Toggle the mouse click state
            mouseclick = !mouseclick;

            if (mouseclick)
            {
                // Increment the top sorting order and assign it to the current object
                topSortingOrder++;
                if (spriteRenderer != null)
                {
                    spriteRenderer.sortingOrder = topSortingOrder;
                }
            }
        }
    }

    // This method is called when the object collides with another object with a Collider2D
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other object has the correct tag and set it ready to combine
        if (other.CompareTag("Blender2")) // Ensure the other object has this tag
        {
            Debug.Log("Collision detected with Blender2");
            readyToCombine = true;
            otherObject = other.gameObject; // Store the reference to the other object
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Reset the readyToCombine flag if the objects separate
        if (other.CompareTag("Blender2"))
        {
            Debug.Log("Objects separated");
            readyToCombine = false;
            otherObject = null; // Clear the reference to the other object
        }
    }
} */


/* USE THIS ONE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public bool mouseclick = false;
    private SpriteRenderer spriteRenderer;
    private static int topSortingOrder = 100; // Starting point for sorting order

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // If mouseclick is true, move the object with the mouse
        if (mouseclick)
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }

    void OnMouseDown()
    {
        mouseclick = !mouseclick;

        if (mouseclick)
        {
            // Increment the top sorting order and assign it to the current object
            topSortingOrder++;
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = topSortingOrder;
            }
        }
    }
} */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public bool mouseclick = false;
    private SpriteRenderer spriteRenderer;
    private static int topSortingOrder = 100; // Starting point for sorting order

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // If mouseclick is true, move the object with the mouse
        if (mouseclick)
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }

   void OnMouseDown()
{
    mouseclick = !mouseclick;

    if (mouseclick)
    {
        // Increment the top sorting order
        topSortingOrder++;

        // Update sorting order for the current object
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = topSortingOrder;
        }

        // Update sorting order for all child objects
        foreach (SpriteRenderer childSpriteRenderer in GetComponentsInChildren<SpriteRenderer>())
        {
            childSpriteRenderer.sortingOrder = topSortingOrder;
        }
    }
}

}


