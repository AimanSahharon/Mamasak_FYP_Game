using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; //to use the date time 

public class OpenBook : MonoBehaviour
{

    [SerializeField] Button openButton; //declare Open Book button
    [SerializeField] AudioSource audioSFX; //declare audiosource
    [SerializeField] AudioClip openBook; //declare the file to play the sound

    private Vector3 rotationVector; //declare variable to rotate objects

    private bool isOpenClicked; //boolean type variable to check the state if it has been clicked or not

    private DateTime startTime; //to get start time of the animation
    private DateTime endTime; //to get end time of the animation

    // Start is called before the first frame update
    void Start()
    {
        if (openButton != null) //if button has been assigned and once the button is clicked then call the openButton_Click() function
        {
            openButton.onClick.AddListener(() => openButton_Click());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpenClicked) //once the user click on the button start the animation/rotation of the object
        {

            transform.Rotate(rotationVector * Time.deltaTime);
            endTime = DateTime.Now;

            if ((endTime - startTime).TotalSeconds >= 1) //after one second of rotating then stop
            {
                isOpenClicked = false;
            }
        }
    }

    private void openButton_Click()
    {
        isOpenClicked = true;
        startTime = DateTime.Now; //start the time
        rotationVector = new Vector3(0, 180, 0); //rotate the object of the Y axis to 180 degree

        PlaySound(); //As the object rotate, play a sound
    }

    private void PlaySound()
    {
        if ((audioSFX != null && (openBook != null))) //if audioSFX and openBook has been assigned then ply the audio
        {
            audioSFX.PlayOneShot(openBook); //only play the sound once
        }
    }
}
