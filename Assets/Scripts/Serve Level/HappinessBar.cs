/* V8
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HappinessBar : MonoBehaviour
{
    public Slider happinessSlider;
    public float sliderTimer = 60f;
    private bool stopTimer = false;

    void Start()
    {
        happinessSlider.maxValue = sliderTimer;
        happinessSlider.value = sliderTimer;
        StartCoroutine(StartTheTimerTicker());
    }

    IEnumerator StartTheTimerTicker()
    {
        while (!stopTimer && sliderTimer > 0)
        {
            sliderTimer -= Time.deltaTime;
            happinessSlider.value = sliderTimer;
            UpdateSliderColor();
            yield return null;
        }

        if (sliderTimer <= 0)
        {
            stopTimer = true;
            //OnHappinessDepleted();
        }
    }

    private void UpdateSliderColor()
    {
        if (happinessSlider.value <= sliderTimer * 0.2f)
        {
            happinessSlider.fillRect.GetComponent<Image>().color = Color.red;
        }
        else if (happinessSlider.value <= sliderTimer * 0.5f)
        {
            happinessSlider.fillRect.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            happinessSlider.fillRect.GetComponent<Image>().color = Color.green;
        }
    }

    private void OnHappinessDepleted()
    {
        CustomerSpawner customerSpawner = FindObjectOfType<CustomerSpawner>();
        if (customerSpawner != null)
        {
            customerSpawner.HandleHappinessDepleted();
        }
    } 

    public void StopTimer()
    {
        stopTimer = true;
    }
} */

/*V9
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessBar : MonoBehaviour
{
    public Slider happinessSlider; // Assign via Inspector
    public float sliderTimer = 60f; // Duration for the slider
    private bool stopTimer = false;

    void Start()
    {
        if (happinessSlider == null)
        {
            Debug.LogError("Happiness Slider is not assigned in the Inspector!");
            return;
        }

        // Initialize slider values
        happinessSlider.maxValue = sliderTimer;
        happinessSlider.value = sliderTimer;

        // Start decreasing slider over time
        StartCoroutine(StartTheTimerTicker());
    }

    IEnumerator StartTheTimerTicker()
    {
        while (!stopTimer && sliderTimer > 0)
        {
            sliderTimer -= Time.deltaTime; // Decrease timer
            happinessSlider.value = sliderTimer; // Update slider value
            UpdateSliderColor(); // Change slider color based on value
            yield return null; // Wait for the next frame
        }

        // Stop timer when it reaches 0
        if (sliderTimer <= 0)
        {
            stopTimer = true;
        }
    }

    private void UpdateSliderColor()
    {
        // Check if the fillRect is properly assigned
        if (happinessSlider.fillRect == null)
        {
            Debug.LogError("Fill Rect is not assigned in the Slider!");
            return;
        }

        // Access the Image component of the Fill Rect
        Image fillImage = happinessSlider.fillRect.GetComponent<Image>();
        if (fillImage == null)
        {
            Debug.LogError("Fill Rect does not have an Image component!");
            return;
        }

        // Change color based on the slider's value
        float percentage = happinessSlider.value / happinessSlider.maxValue; // Calculate percentage

        if (percentage <= 0.2f)
        {
            fillImage.color = Color.red; // Danger zone
        }
        else if (percentage <= 0.5f)
        {
            fillImage.color = Color.yellow; // Warning zone
        }
        else
        {
            fillImage.color = Color.green; // Safe zone
        }
    }

    public void StopTimer()
    {
        stopTimer = true; // Stop the timer manually
    }
}
*/

/*V10
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HappinessBar : MonoBehaviour
{
    public Slider happinessSlider; // Assign via Inspector
    public float sliderTimer = 60f; // Duration for the slider
    private bool stopTimer = false;

    void Start()
    {
        if (happinessSlider == null)
        {
            Debug.LogError("Happiness Slider is not assigned in the Inspector!");
            return;
        }

        // Initialize slider values
        happinessSlider.maxValue = sliderTimer;
        happinessSlider.value = sliderTimer;
    }

    public void StartHappinessBar()
    {
        // Start the happiness bar's timer if not already running
        if (!stopTimer)
        {
            StartCoroutine(StartTheTimerTicker());
        }
    }

    IEnumerator StartTheTimerTicker()
    {
        // Loop to decrease the slider value over time
        while (sliderTimer > 0)
        {
            sliderTimer -= Time.deltaTime; // Decrease timer
            happinessSlider.value = sliderTimer; // Update slider value
            UpdateSliderColor(); // Change slider color based on value

            // Prevent sliderTimer from going negative
            if (sliderTimer <= 0)
            {
                sliderTimer = 0;
            }

            yield return null; // Wait for the next frame
        }

        // Stop the timer when it reaches 0
        stopTimer = true;
    }

    private void UpdateSliderColor()
    {
        // Check if the fillRect is properly assigned
        if (happinessSlider.fillRect == null)
        {
            Debug.LogError("Fill Rect is not assigned in the Slider!");
            return;
        }

        // Access the Image component of the Fill Rect
        Image fillImage = happinessSlider.fillRect.GetComponent<Image>();
        if (fillImage == null)
        {
            Debug.LogError("Fill Rect does not have an Image component!");
            return;
        }

        // Change color based on the slider's value
        float percentage = happinessSlider.value / happinessSlider.maxValue; // Calculate percentage

        if (percentage <= 0.2f)
        {
            fillImage.color = Color.red; // Danger zone
        }
        else if (percentage <= 0.5f)
        {
            fillImage.color = Color.yellow; // Warning zone
        }
        else
        {
            fillImage.color = Color.green; // Safe zone
        }
    }

    public void StopTimer()
    {
        stopTimer = true; // Stop the timer manually
    }
} */


/*V11: Color change
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessBar : MonoBehaviour
{
    public Slider happinessSlider; // Assign via Inspector
    public float sliderTimer = 60f; // Duration for the slider
    private bool stopTimer = false;

    void Start()
    {
        if (happinessSlider == null)
        {
            Debug.LogError("Happiness Slider is not assigned in the Inspector!");
            return;
        }

        // Initialize slider values
        happinessSlider.maxValue = sliderTimer;
        happinessSlider.value = sliderTimer;

        // Start decreasing slider over time
        StartCoroutine(StartTheTimerTicker());
    }

    IEnumerator StartTheTimerTicker()
    {
        while (!stopTimer && sliderTimer > 0)
        {
            sliderTimer -= Time.deltaTime; // Decrease timer
            happinessSlider.value = sliderTimer; // Update slider value
            UpdateSliderColor(); // Change slider color based on value
            yield return null; // Wait for the next frame
        }

        // Stop timer when it reaches 0
        if (sliderTimer <= 0)
        {
            stopTimer = true;
        }
    }

    private void UpdateSliderColor()
    {
        // Check if the fillRect is properly assigned
        if (happinessSlider.fillRect == null)
        {
            Debug.LogError("Fill Rect is not assigned in the Slider!");
            return;
        }

        // Access the Image component of the Fill Rect
        Image fillImage = happinessSlider.fillRect.GetComponent<Image>();
        if (fillImage == null)
        {
            Debug.LogError("Fill Rect does not have an Image component!");
            return;
        }

        // Change color based on the slider's value
        float percentage = happinessSlider.value / happinessSlider.maxValue; // Calculate percentage

        if (percentage <= 0.2f)
        {
            fillImage.color = Color.red; // Danger zone
        }
        else if (percentage <= 0.5f)
        {
            fillImage.color = Color.yellow; // Warning zone
        }
        else
        {
            fillImage.color = Color.green; // Safe zone
        }
    }

    public void StopTimer()
    {
        stopTimer = true; // Stop the timer manually
    }
} */


/* V1: can change color
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessBar : MonoBehaviour
{
    public Slider happinessSlider; // Assign via Inspector
    public float sliderTimer = 60f; // Duration for the slider
    private bool stopTimer = false;

    void Start()
    {
        if (happinessSlider == null)
        {
            Debug.LogError("Happiness Slider is not assigned in the Inspector!");
            return;
        }

        // Initialize slider values
        happinessSlider.maxValue = sliderTimer;
        happinessSlider.value = sliderTimer;

        // Start decreasing slider over time
        StartCoroutine(StartTheTimerTicker());
    }

    IEnumerator StartTheTimerTicker()
    {
        while (!stopTimer && sliderTimer > 0)
        {
            sliderTimer -= Time.deltaTime; // Decrease timer
            happinessSlider.value = sliderTimer; // Update slider value
            UpdateSliderColor(); // Change slider color based on value
            yield return null; // Wait for the next frame
        }

        // Stop timer when it reaches 0
        if (sliderTimer <= 0)
        {
            stopTimer = true;
        }
    }

    private void UpdateSliderColor()
    {
        // Check if the fillRect is properly assigned
        if (happinessSlider.fillRect == null)
        {
            Debug.LogError("Fill Rect is not assigned in the Slider!");
            return;
        }

        // Access the Image component of the Fill Rect
        Image fillImage = happinessSlider.fillRect.GetComponent<Image>();
        if (fillImage == null)
        {
            Debug.LogError("Fill Rect does not have an Image component!");
            return;
        }

        // Change color based on the slider's value
        float percentage = happinessSlider.value / happinessSlider.maxValue; // Calculate percentage

        if (percentage <= 0.2f)
        {
            fillImage.color = Color.red; // Danger zone
        }
        else if (percentage <= 0.5f)
        {
            fillImage.color = Color.yellow; // Warning zone
        }
        else
        {
            fillImage.color = Color.green; // Safe zone
        }
    }

    public void StopTimer()
    {
        stopTimer = true; // Stop the timer manually
    }
} */

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HappinessBar : MonoBehaviour
{
    public Slider happinessSlider; // Assign via Inspector
    public float sliderTimer = 60f; // Duration for the slider
    private bool stopTimer = true; // Start with the timer stopped

    void Start()
    {
        if (happinessSlider == null)
        {
            Debug.LogError("Happiness Slider is not assigned in the Inspector!");
            return;
        }

        InitializeSlider();
    }

    private void InitializeSlider()
    {
        // Initialize slider values
        happinessSlider.maxValue = sliderTimer;
        happinessSlider.value = sliderTimer;
    }

    IEnumerator TimerTicker()
    {
        while (!stopTimer && sliderTimer > 0)
        {
            sliderTimer -= Time.deltaTime; // Decrease timer
            happinessSlider.value = sliderTimer; // Update slider value
            UpdateSliderColor(); // Update slider color based on value
            yield return null;
        }

        if (sliderTimer <= 0)
        {
            Debug.Log("Order failed: Happiness bar reached zero.");
            CustomerSpawner customerSpawner = FindObjectOfType<CustomerSpawner>();
            if (customerSpawner != null)
            {
                customerSpawner.RemoveCustomerAndSpeechBubble(false); // Treat as wrong order
            }
        }
    }

    private void UpdateSliderColor()
    {
        if (happinessSlider.fillRect == null) return;

        Image fillImage = happinessSlider.fillRect.GetComponent<Image>();
        if (fillImage == null) return;

        float percentage = happinessSlider.value / happinessSlider.maxValue;

        if (percentage <= 0.2f)
        {
            fillImage.color = Color.red; // Danger zone
        }
        else if (percentage <= 0.5f)
        {
            fillImage.color = Color.yellow; // Warning zone
        }
        else
        {
            fillImage.color = Color.green; // Safe zone
        }
    }

    public void StartTimer()
    {
        stopTimer = false;
        StartCoroutine(TimerTicker());
    }

    public void PauseTimer()
    {
        stopTimer = true;
    }

    public void ResetTimer()
    {
        PauseTimer();
        sliderTimer = happinessSlider.maxValue;
        happinessSlider.value = sliderTimer;
    }
}
