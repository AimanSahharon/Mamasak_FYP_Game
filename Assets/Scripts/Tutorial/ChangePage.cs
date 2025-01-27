using UnityEngine;
using UnityEngine.UI;

public class ChangePage : MonoBehaviour
{
    public GameObject[] pages; // Array of pages to navigate
    public Button nextButton; // Reference to the Next button
    public Button previousButton; // Reference to the Previous button

    private int currentPageIndex = 0; // Tracks the currently active page

    void Start()
    {
        // Initialize buttons and pages
        UpdatePageVisibility();

        nextButton.onClick.AddListener(GoToNextPage);
        previousButton.onClick.AddListener(GoToPreviousPage);
    }

    void GoToNextPage()
    {
        if (currentPageIndex < pages.Length - 1)
        {
            pages[currentPageIndex].SetActive(false);
            currentPageIndex++;
            pages[currentPageIndex].SetActive(true);
        }
        UpdateButtonInteractivity();
    }

    void GoToPreviousPage()
    {
        if (currentPageIndex > 0)
        {
            pages[currentPageIndex].SetActive(false);
            currentPageIndex--;
            pages[currentPageIndex].SetActive(true);
        }
        UpdateButtonInteractivity();
    }

    void UpdatePageVisibility()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == currentPageIndex);
        }
        UpdateButtonInteractivity();
    }

    void UpdateButtonInteractivity()
    {
        nextButton.interactable = currentPageIndex < pages.Length - 1;
        previousButton.interactable = currentPageIndex > 0;
    }
}
