/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OpenBook : MonoBehaviour
{
    [SerializeField] Button openButton; //declare Open Book button
    [SerializeField] GameObject openedBook;
    [SerializeField] GameObject insideBackCover;
    [SerializeField] AudioSource audioSFX; //declare audiosource
    [SerializeField] AudioClip openBook; //declare the file to play the sound

    private Vector3 rotationVector; //declare variable to rotate objects
    private bool isOpenClicked; //boolean type variable to check the state if it has been clicked or not
    private bool isClosedClicked;
    private DateTime startTime; //to get start time of the animation
    private DateTime endTime; //to get end time of the animation

    void Start()
    {
        if (openButton != null) //if button has been assigned and once the button is clicked then call the openButton_Click() function
        {
            openButton.onClick.AddListener(() => openButton_Click());
        }

        AppEvents.CloseBook += new EventHandler(closeBook_Click);   
        
    }

    void Update()
    {
        if (isOpenClicked || isClosedClicked) //once the user clicks the button start the animation/rotation of the object
        {
            transform.Rotate(rotationVector * Time.deltaTime);
            endTime = DateTime.Now;

            if (isOpenClicked)
            {
                if ((endTime - startTime).TotalSeconds >= 1) //after one second of rotating, then stop
                {
                    isOpenClicked = false;
                    insideBackCover.SetActive(false);
                    openedBook.SetActive(true);
                    // Don't deactivate the book here!
                }
            }

            if (isClosedClicked)
            {
                if ((endTime - startTime).TotalSeconds >= 1) //after one second of rotating, then stop
                {
                    isClosedClicked = false;
                }
            }
        }
    }

    private void openButton_Click()
    {
        isOpenClicked = true;
        startTime = DateTime.Now; //start the time
        rotationVector = new Vector3(0, 180, 0); //rotate the object of the Y axis to 180 degree
        PlaySound(); //As the object rotates, play a sound
    }

    private void closeBook_Click(object sender, EventArgs e)
    {
        if (!gameObject.activeInHierarchy) return; // Make sure the object is active

        openedBook.SetActive(false); // Hide the opened book
        insideBackCover.SetActive(true); // Show the inside back cover
        isClosedClicked = true;
        startTime = DateTime.Now; // Reset start time
        rotationVector = new Vector3(0, -180, 0); // Rotate in the opposite direction
        PlaySound();
    }

    private void PlaySound()
    {
        if (audioSFX != null && openBook != null) //if audioSFX and openBook have been assigned, then play the audio
        {
            audioSFX.PlayOneShot(openBook); //only play the sound once
        }
    }

    void OnDestroy()
{
    AppEvents.CloseBook -= closeBook_Click;
}
} */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OpenBook : MonoBehaviour
{
    [SerializeField] Button openButton; //declare Open Book button
    [SerializeField] GameObject openedBook;
    [SerializeField] GameObject insideBackCover;
    [SerializeField] AudioSource audioSFX; //declare audiosource
    [SerializeField] AudioClip openBook; //declare the file to play the sound

    private Vector3 rotationVector; //declare variable to rotate objects
    private bool isOpenClicked; //boolean type variable to check the state if it has been clicked or not
    private bool isClosedClicked;
    private DateTime startTime; //to get start time of the animation
    private DateTime endTime; //to get end time of the animation

    void Start()
    {
        if (openButton != null) //if button has been assigned and once the button is clicked then call the openButton_Click() function
        {
            openButton.onClick.AddListener(() => openButton_Click());
        }

        AppEvents.CloseBook += new EventHandler(closeBook_Click);   
        
    }

    void Update()
    {
        if (isOpenClicked || isClosedClicked) //once the user clicks the button start the animation/rotation of the object
        {
            transform.Rotate(rotationVector * Time.deltaTime);
            endTime = DateTime.Now;

            if (isOpenClicked)
            {
                if ((endTime - startTime).TotalSeconds >= 1) //after one second of rotating, then stop
                {
                    isOpenClicked = false;
                    insideBackCover.SetActive(false);
                    openedBook.SetActive(true);
                    // Don't deactivate the book here!
                }
            }

            if (isClosedClicked)
            {
                if ((endTime - startTime).TotalSeconds >= 1) //after one second of rotating, then stop
                {
                    isClosedClicked = false;
                }
            }
        }
    }

    private void openButton_Click()
    {
        isOpenClicked = true;
        startTime = DateTime.Now; //start the time
        rotationVector = new Vector3(0, 180, 0); //rotate the object of the Y axis to 180 degree
        PlaySound(); //As the object rotates, play a sound
    }

    private void closeBook_Click(object sender, EventArgs e)
    {
        if (!gameObject.activeInHierarchy) return; // Make sure the object is active

        openedBook.SetActive(false); // Hide the opened book
        insideBackCover.SetActive(true); // Show the inside back cover
        isClosedClicked = true;
        startTime = DateTime.Now; // Reset start time
        rotationVector = new Vector3(0, -180, 0); // Rotate in the opposite direction
        PlaySound();
    }

    private void PlaySound()
    {
        if (audioSFX != null && openBook != null) //if audioSFX and openBook have been assigned, then play the audio
        {
            audioSFX.PlayOneShot(openBook); //only play the sound once
        }
    }

    void OnDestroy()
{
    AppEvents.CloseBook -= closeBook_Click;
}
}