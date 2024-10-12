using System.Collections;
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
}
