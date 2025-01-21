/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] characters; // Array of characters to spawn
    [SerializeField] private Transform tablePosition; // Target table position
    [SerializeField] private float animationSpeed = 2f; // Speed of animation

    private GameObject currentCharacter;

    private void Start()
    {
        SpawnRandomCharacter();
    }

    public void SpawnRandomCharacter()
    {
        // Ensure there's no previously spawned character
        if (currentCharacter != null)
        {
            Destroy(currentCharacter);
        }

        // Pick a random character from the array
        int randomIndex = Random.Range(0, characters.Length);
        GameObject selectedCharacter = characters[randomIndex];

        // Instantiate the character at the spawner's position
        currentCharacter = Instantiate(selectedCharacter, transform.position, Quaternion.identity);

        // Animate the character to the table
        StartCoroutine(AnimateToTable(currentCharacter));
    }

    private System.Collections.IEnumerator AnimateToTable(GameObject character)
    {
        while (Vector2.Distance(character.transform.position, tablePosition.position) > 0.01f)
        {
            character.transform.position = Vector2.MoveTowards(
                character.transform.position,
                tablePosition.position,
                animationSpeed * Time.deltaTime
            );
            yield return null;
        }

        character.transform.position = tablePosition.position; // Ensure it snaps to the position
    }
} */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] characters; // Array of characters to spawn
    [SerializeField] private Transform tablePosition; // Target table position
    [SerializeField] private float animationSpeed = 2f; // Speed of animation
    [SerializeField] private GameObject speechBubblePrefab; // Speech bubble prefab
    [SerializeField] private Transform speechBubbleOffset; // Offset position for the speech bubble
    [SerializeField] private GameObject[] speechBubbleContents; // Array of objects to spawn in the speech bubble
    [SerializeField] private float fadeInDuration = 1f; // Duration for the fade-in animation
    [SerializeField] private int maxBubbleContent = 3; // Maximum number of objects to spawn in the bubble

    private GameObject currentCharacter;
    private GameObject currentSpeechBubble;

    private void Start()
    {
        SpawnRandomCharacter();
    }

    public void SpawnRandomCharacter()
    {
        // Ensure there's no previously spawned character
        if (currentCharacter != null)
        {
            Destroy(currentCharacter);
        }
        if (currentSpeechBubble != null)
        {
            Destroy(currentSpeechBubble);
        }

        // Pick a random character from the array
        int randomIndex = Random.Range(0, characters.Length);
        GameObject selectedCharacter = characters[randomIndex];

        // Instantiate the character at the spawner's position
        currentCharacter = Instantiate(selectedCharacter, transform.position, Quaternion.identity);

        // Animate the character to the table
        StartCoroutine(AnimateToTable(currentCharacter));
    }

    private System.Collections.IEnumerator AnimateToTable(GameObject character)
    {
        while (Vector2.Distance(character.transform.position, tablePosition.position) > 0.01f)
        {
            character.transform.position = Vector2.MoveTowards(
                character.transform.position,
                tablePosition.position,
                animationSpeed * Time.deltaTime
            );
            yield return null;
        }

        character.transform.position = tablePosition.position; // Ensure it snaps to the position

        // Spawn and fade in the speech bubble
        SpawnSpeechBubble(character);
    }

    private void SpawnSpeechBubble(GameObject character)
    {
        // Instantiate the speech bubble next to the character
        Vector3 bubblePosition = character.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);
        currentSpeechBubble = Instantiate(speechBubblePrefab, bubblePosition, Quaternion.identity);

        // Set initial transparency to 0
        CanvasGroup bubbleCanvasGroup = currentSpeechBubble.GetComponent<CanvasGroup>();
        if (bubbleCanvasGroup != null)
        {
            bubbleCanvasGroup.alpha = 0;
            StartCoroutine(FadeInSpeechBubble(bubbleCanvasGroup));
        }

        // Randomly spawn content in the speech bubble
        SpawnRandomBubbleContent(currentSpeechBubble.transform);
    }

    private System.Collections.IEnumerator FadeInSpeechBubble(CanvasGroup canvasGroup)
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeInDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, elapsedTime / fadeInDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1; // Ensure full opacity
    }

    private void SpawnRandomBubbleContent(Transform bubbleTransform)
{
    int gridSize = 3; // 3x3 grid
    float cellSpacing = 1f; // Space between cells
    Vector3 bubbleCenter = bubbleTransform.position; // Bubble's center position

    // Track used grid cells to prevent reuse
    HashSet<(int, int)> usedCells = new HashSet<(int, int)>();
    // Track used content indices to prevent duplicate objects
    HashSet<int> usedIndices = new HashSet<int>();

    // Randomly decide how many objects to spawn
    int contentCount = Random.Range(1, Mathf.Min(maxBubbleContent, gridSize * gridSize) + 1);

    for (int i = 0; i < contentCount; i++)
    {
        // Randomly pick a grid cell
        (int row, int col) randomCell;
        do
        {
            randomCell = (Random.Range(0, gridSize), Random.Range(0, gridSize));
        } while (usedCells.Contains(randomCell));
        usedCells.Add(randomCell);

        // Calculate the position of the chosen grid cell
        float xOffset = (randomCell.col - (gridSize - 1) / 2f) * cellSpacing; // Horizontal offset
        float yOffset = ((gridSize - 1) / 2f - randomCell.row) * cellSpacing; // Vertical offset
        Vector3 spawnPosition = bubbleCenter + new Vector3(xOffset, yOffset, 0);

        // Pick a random content from the available pool, ensuring it's unique
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, speechBubbleContents.Length);
        } while (usedIndices.Contains(randomIndex));
        usedIndices.Add(randomIndex);

        GameObject selectedContent = speechBubbleContents[randomIndex];

        // Instantiate the content in the chosen grid cell
        Instantiate(selectedContent, spawnPosition, Quaternion.identity, bubbleTransform);
    }
}




}

