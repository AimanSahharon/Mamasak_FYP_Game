/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OrderManager : MonoBehaviour
{
    public PlateHover plateHover; // Reference to PlateHover script
    public CustomerSpawner customerSpawner; // Reference to CustomerSpawner script

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            // Check the current order in the speech bubble
            if (customerSpawner.currentSpeechBubble != null)
            {
                string orderText = customerSpawner.currentSpeechBubble.name; // Assuming the bubble name contains the order
                List<string> expectedItems = new List<string>();

                if (orderText == "order_2")
                {
                    expectedItems.Add("roti_canai");
                }

                // Validate the plate contents
                if (plateHover.ValidateOrder(expectedItems))
                {
                    Debug.Log("Correct order!");

                    // Remove the current customer and speech bubble
                    Destroy(customerSpawner.currentCharacter);
                    Destroy(customerSpawner.currentSpeechBubble);

                    // Spawn the next customer
                    customerSpawner.SpawnRandomCharacter();
                }
                else
                {
                    Debug.Log("wrong order");
                }
            }
        }
    }
} */
