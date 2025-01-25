/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //To use Unity UI e.g button
using System; //to use the date time 


public class FlipPage : MonoBehaviour
{
    private enum ButtonType
    {
        NextButton,
        PreviousButton
    }
    [SerializeField] Button nextButton; //declare Next Button
    [SerializeField] Button previousButton; //Declare Previous Button
    //[SerializeField] Button closeButton; //Declare Previous Button

    [SerializeField] AudioSource audioSFX; //declare audiosource
    [SerializeField] AudioClip flipBook; //declare the file to play the sound

    [SerializeField] Button closeButton;

    //[SerializeField] GameObject openedBook;
    // [SerializeField] GameObject insideBackCover;

    private Vector3 rotationVector; //declare variable to rotate objects

    private Vector3 startPosition;
    private Quaternion startRotation;

    private bool isClicked; //boolean type variable to check the state if it has been clicked or not

    private DateTime startTime; //to get start time
    private DateTime endTime; //to get end time

    

    // Start is called before the first frame update
    void Start()
    {

        startRotation = transform.rotation;
        startPosition = transform.position;
         if (nextButton != null)
        {
            nextButton.onClick.AddListener(() => turnOnePageButton_Click(ButtonType.NextButton));
        }
         if (previousButton != null)
        {
            previousButton.onClick.AddListener(() => turnOnePageButton_Click(ButtonType.PreviousButton));
        }
         if (closeButton != null)
        {
            closeButton.onClick.AddListener(() => closeButton_Click());
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            transform.Rotate(rotationVector * Time.deltaTime);
            endTime = DateTime.Now;
            if ((endTime - startTime).TotalSeconds >= 1)
            {
                isClicked = false;
                transform.rotation = startRotation;
                transform.position = startPosition;
            }
        }
    }

    private void turnOnePageButton_Click(ButtonType type)
    {
        isClicked = true;
        startTime = DateTime.Now;
        if (type == ButtonType.NextButton)
        {
            rotationVector = new Vector3(0, 180, 0);

        }
        else
        if (type == ButtonType.PreviousButton)
        {
            Vector3 newRotation = new Vector3(startRotation.x, 180, startRotation.z);
            transform.rotation = Quaternion.Euler(newRotation);
            rotationVector = new Vector3(0, -180, 0);
        }
        PlaySound(); //As the object rotate, play a sound
    }

    private void PlaySound()
    {
        if ((audioSFX != null && (flipBook != null))) //if audioSFX and openBook has been assigned then ply the audio
        {
            audioSFX.PlayOneShot(flipBook); //only play the sound once
        }
    }

    private void closeButton_Click()
    {
        AppEvents.CloseBookFunction();
    }
    
} */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //To use Unity UI e.g button
using System; //to use the date time 


public class FlipPage : MonoBehaviour
{
    private enum ButtonType
    {
        NextButton,
        PreviousButton
    }
    [SerializeField] Button nextButton; //declare Next Button
    [SerializeField] Button previousButton; //Declare Previous Button
    //[SerializeField] Button closeButton; //Declare Previous Button

    [SerializeField] AudioSource audioSFX; //declare audiosource
    [SerializeField] AudioClip flipBook; //declare the file to play the sound

    [SerializeField] Button closeButton;

    //[SerializeField] GameObject openedBook;
    // [SerializeField] GameObject insideBackCover;

    private Vector3 rotationVector; //declare variable to rotate objects

    private Vector3 startPosition;
    private Quaternion startRotation;

    private bool isClicked; //boolean type variable to check the state if it has been clicked or not

    private DateTime startTime; //to get start time
    private DateTime endTime; //to get end time

    

    // Start is called before the first frame update
    void Start()
    {

        startRotation = transform.rotation;
        startPosition = transform.position;
         if (nextButton != null)
        {
            nextButton.onClick.AddListener(() => turnOnePageButton_Click(ButtonType.NextButton));
        }
         if (previousButton != null)
        {
            previousButton.onClick.AddListener(() => turnOnePageButton_Click(ButtonType.PreviousButton));
        }
         if (closeButton != null)
        {
            closeButton.onClick.AddListener(() => closeButton_Click());
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            transform.Rotate(rotationVector * Time.deltaTime);
            endTime = DateTime.Now;
            if ((endTime - startTime).TotalSeconds >= 1)
            {
                isClicked = false;
                transform.rotation = startRotation;
                transform.position = startPosition;
            }
        }
    }

    private void turnOnePageButton_Click(ButtonType type)
    {
        isClicked = true;
        startTime = DateTime.Now;
        if (type == ButtonType.NextButton)
        {
            rotationVector = new Vector3(0, 180, 0);

        }
        else
        if (type == ButtonType.PreviousButton)
        {
            Vector3 newRotation = new Vector3(startRotation.x, 180, startRotation.z);
            transform.rotation = Quaternion.Euler(newRotation);
            rotationVector = new Vector3(0, -180, 0);
        }
        PlaySound(); //As the object rotate, play a sound
    }

    private void PlaySound()
    {
        if ((audioSFX != null && (flipBook != null))) //if audioSFX and openBook has been assigned then ply the audio
        {
            audioSFX.PlayOneShot(flipBook); //only play the sound once
        }
    }

    private void closeButton_Click()
    {
        AppEvents.CloseBookFunction();
    }
    
} 