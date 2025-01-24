/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

private class CustomerSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] characters; // Array of characters to spawn
    [SerializeField] public Transform tablePosition; // Target table position
    [SerializeField] public float animationSpeed = 2f; // Speed of animation

    public GameObject currentCharacter;

    public void Start()
    {
        SpawnRandomCharacter();
    }

    private void SpawnRandomCharacter()
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

    public System.Collections.IEnumerator AnimateToTable(GameObject character)
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


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


private class CustomerSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] characters; // Array of characters to spawn
    [SerializeField] public Transform tablePosition; // Target table position
    [SerializeField] public float animationSpeed = 2f; // Speed of animation
    [SerializeField] public GameObject speechBubblePrefab; // Speech bubble prefab
    [SerializeField] public Transform speechBubbleOffset; // Offset position for the speech bubble
    [SerializeField] public GameObject[] speechBubbleContents; // Array of objects to spawn in the speech bubble
    [SerializeField] public float fadeInDuration = 1f; // Duration for the fade-in animation
    [SerializeField] public int maxBubbleContent = 3; // Maximum number of objects to spawn in the bubble

    public GameObject currentCharacter;
    public GameObject currentSpeechBubble;

    public void Start()
    {
        SpawnRandomCharacter();
    }

    private void SpawnRandomCharacter()
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

    public System.Collections.IEnumerator AnimateToTable(GameObject character)
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

    public void SpawnSpeechBubble(GameObject character)
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

    public System.Collections.IEnumerator FadeInSpeechBubble(CanvasGroup canvasGroup)
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

    public void SpawnRandomBubbleContent(Transform bubbleTransform)
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




} */

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

private class CustomerSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] characters; // Array of characters to spawn
    [SerializeField] public Transform tablePosition; // Target table position
    [SerializeField] public float animationSpeed = 2f; // Speed of animation
    [SerializeField] public GameObject[] speechBubbleVariants; // Array of speech bubble variants
    [SerializeField] public Transform speechBubbleOffset; // Offset position for the speech bubble
    [SerializeField] public float fadeInDuration = 1f; // Duration for the fade-in animation

    public GameObject currentCharacter;
    public GameObject currentSpeechBubble;

    public void Start()
    {
        SpawnRandomCharacter();
    }

    private void SpawnRandomCharacter()
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

    public IEnumerator AnimateToTable(GameObject character)
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

    public void SpawnSpeechBubble(GameObject character)
    {
        // Pick a random speech bubble variant
        int randomIndex = Random.Range(0, speechBubbleVariants.Length);
        GameObject selectedSpeechBubble = speechBubbleVariants[randomIndex];

        // Instantiate the speech bubble next to the character
        Vector3 bubblePosition = character.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);
        currentSpeechBubble = Instantiate(selectedSpeechBubble, bubblePosition, Quaternion.identity);

        // Set initial transparency to 0
        CanvasGroup bubbleCanvasGroup = currentSpeechBubble.GetComponent<CanvasGroup>();
        if (bubbleCanvasGroup != null)
        {
            bubbleCanvasGroup.alpha = 0;
            StartCoroutine(FadeInSpeechBubble(bubbleCanvasGroup));
        }
    }

    public IEnumerator FadeInSpeechBubble(CanvasGroup canvasGroup)
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
} */

/* V3
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] characters; // Array of characters to spawn
    [SerializeField] public Transform tablePosition; // Target table position
    [SerializeField] public float animationSpeed = 2f; // Speed of animation
    [SerializeField] public GameObject[] speechBubbleVariants; // Array of speech bubble variants
    [SerializeField] public Transform speechBubbleOffset; // Offset position for the speech bubble
    [SerializeField] public float fadeInDuration = 1f; // Duration for the fade-in animation

    public GameObject currentCharacter;
    public GameObject currentSpeechBubble;

    public int lastBubbleIndex = -1; // Track the last spawned bubble
    public int repeatCount = 0; // Count of consecutive same bubbles

    public void Start()
    {
        SpawnRandomCharacter();
    }

    private void SpawnRandomCharacter()
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

    public IEnumerator AnimateToTable(GameObject character)
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

    public void SpawnSpeechBubble(GameObject character)
    {
        // Pick a random speech bubble variant, ensuring no repeats for 3 consecutive times
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, speechBubbleVariants.Length);
        } while (randomIndex == lastBubbleIndex && repeatCount >= 2);

        // Update repeat tracking
        if (randomIndex == lastBubbleIndex)
        {
            repeatCount++;
        }
        else
        {
            repeatCount = 0;
        }
        lastBubbleIndex = randomIndex;

        GameObject selectedSpeechBubble = speechBubbleVariants[randomIndex];

        // Instantiate the speech bubble next to the character
        Vector3 bubblePosition = character.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);
        currentSpeechBubble = Instantiate(selectedSpeechBubble, bubblePosition, Quaternion.identity);

        // Set initial transparency to 0
        CanvasGroup bubbleCanvasGroup = currentSpeechBubble.GetComponent<CanvasGroup>();
        if (bubbleCanvasGroup != null)
        {
            bubbleCanvasGroup.alpha = 0;
            StartCoroutine(FadeInSpeechBubble(bubbleCanvasGroup));
        }
    }

    public IEnumerator FadeInSpeechBubble(CanvasGroup canvasGroup)
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
} */


/*V4

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] characters; // Array of characters to spawn
    [SerializeField] public Transform tablePosition; // Target table position
    [SerializeField] public float animationSpeed = 2f; // Speed of animation
    [SerializeField] public GameObject[] speechBubbleVariants; // Array of speech bubble variants
    [SerializeField] public Transform speechBubbleOffset; // Offset position for the speech bubble
    [SerializeField] public float fadeInDuration = 1f; // Duration for the fade-in animation

    public GameObject currentCharacter;
    public GameObject currentSpeechBubble;

    public int lastBubbleIndex = -1; // Track the last spawned bubble
    public int repeatCount = 0; // Count of consecutive same bubbles

    public void Start()
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

    public IEnumerator AnimateToTable(GameObject character)
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

    public void SpawnSpeechBubble(GameObject character)
    {
        // Pick a random speech bubble variant, ensuring no repeats for 3 consecutive times
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, speechBubbleVariants.Length);
        } while (randomIndex == lastBubbleIndex && repeatCount >= 2);

        // Update repeat tracking
        if (randomIndex == lastBubbleIndex)
        {
            repeatCount++;
        }
        else
        {
            repeatCount = 0;
        }
        lastBubbleIndex = randomIndex;

        GameObject selectedSpeechBubble = speechBubbleVariants[randomIndex];

        // Instantiate the speech bubble next to the character
        Vector3 bubblePosition = character.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);
        currentSpeechBubble = Instantiate(selectedSpeechBubble, bubblePosition, Quaternion.identity);

        // Set initial transparency to 0
        CanvasGroup bubbleCanvasGroup = currentSpeechBubble.GetComponent<CanvasGroup>();
        if (bubbleCanvasGroup != null)
        {
            bubbleCanvasGroup.alpha = 0;
            StartCoroutine(FadeInSpeechBubble(bubbleCanvasGroup));
        }
    }

    public IEnumerator FadeInSpeechBubble(CanvasGroup canvasGroup)
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

    

public void RemoveCustomerAndSpeechBubble()
{
    if (currentCharacter != null)
    {
        Destroy(currentCharacter);
    }
    if (currentSpeechBubble != null)
    {
        Destroy(currentSpeechBubble);
    }
    Debug.Log("Customer and speech bubble removed.");
}




} */



/* V5
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] characters; // Array of characters to spawn
    [SerializeField] public Transform tablePosition; // Target table position
    [SerializeField] public float animationSpeed = 2f; // Speed of animation
    [SerializeField] public GameObject[] speechBubbleVariants; // Array of speech bubble variants
    [SerializeField] public Transform speechBubbleOffset; // Offset position for the speech bubble
    [SerializeField] public float fadeInDuration = 1f; // Duration for the fade-in animation

    public GameObject currentCharacter;
    public GameObject currentSpeechBubble;

    public int lastBubbleIndex = -1; // Track the last spawned bubble
    public int repeatCount = 0; // Count of consecutive same bubbles

    public void Start()
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

    public IEnumerator AnimateToTable(GameObject character)
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

    public void SpawnSpeechBubble(GameObject character)
    {
        // Pick a random speech bubble variant, ensuring no repeats for 3 consecutive times
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, speechBubbleVariants.Length);
        } while (randomIndex == lastBubbleIndex && repeatCount >= 2);

        // Update repeat tracking
        if (randomIndex == lastBubbleIndex)
        {
            repeatCount++;
        }
        else
        {
            repeatCount = 0;
        }
        lastBubbleIndex = randomIndex;

        GameObject selectedSpeechBubble = speechBubbleVariants[randomIndex];

        // Instantiate the speech bubble next to the character
        Vector3 bubblePosition = character.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);
        currentSpeechBubble = Instantiate(selectedSpeechBubble, bubblePosition, Quaternion.identity);

        // Set initial transparency to 0
        CanvasGroup bubbleCanvasGroup = currentSpeechBubble.GetComponent<CanvasGroup>();
        if (bubbleCanvasGroup != null)
        {
            bubbleCanvasGroup.alpha = 0;
            StartCoroutine(FadeInSpeechBubble(bubbleCanvasGroup));
        }
    }

    public IEnumerator FadeInSpeechBubble(CanvasGroup canvasGroup)
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

    

public void RemoveCustomerAndSpeechBubble()
{
    if (currentCharacter != null)
    {
        Destroy(currentCharacter);
    }
    if (currentSpeechBubble != null)
    {
        Destroy(currentSpeechBubble);
    }

    Debug.Log("Customer and speech bubble removed.");
    SpawnRandomCharacter(); // Spawn the next customer and speech bubble
}





} */


/* V5: With reaction
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] characters; // Array of characters to spawn
    [SerializeField] public Transform tablePosition; // Target table position
    [SerializeField] public float animationSpeed = 2f; // Speed of animation
    [SerializeField] public GameObject[] speechBubbleVariants; // Array of speech bubble variants
    [SerializeField] public Transform speechBubbleOffset; // Offset position for the speech bubble
    [SerializeField] public float fadeInDuration = 1f; // Duration for the fade-in animation
    [SerializeField] public GameObject customerReactionHappy; // Happy reaction bubble
    [SerializeField] public GameObject customerReactionMad; // Mad reaction bubble
    [SerializeField] public Transform offscreenPosition; // Position to move the customer offscreen

    public GameObject currentCharacter;
    public GameObject currentSpeechBubble;

    public int lastBubbleIndex = -1; // Track the last spawned bubble
    public int repeatCount = 0; // Count of consecutive same bubbles

    public void Start()
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

    public IEnumerator AnimateToTable(GameObject character)
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

    public void SpawnSpeechBubble(GameObject character)
    {
        // Pick a random speech bubble variant, ensuring no repeats for 3 consecutive times
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, speechBubbleVariants.Length);
        } while (randomIndex == lastBubbleIndex && repeatCount >= 2);

        // Update repeat tracking
        if (randomIndex == lastBubbleIndex)
        {
            repeatCount++;
        }
        else
        {
            repeatCount = 0;
        }
        lastBubbleIndex = randomIndex;

        GameObject selectedSpeechBubble = speechBubbleVariants[randomIndex];

        // Instantiate the speech bubble next to the character
        Vector3 bubblePosition = character.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);
        currentSpeechBubble = Instantiate(selectedSpeechBubble, bubblePosition, Quaternion.identity);

        // Set initial transparency to 0
        CanvasGroup bubbleCanvasGroup = currentSpeechBubble.GetComponent<CanvasGroup>();
        if (bubbleCanvasGroup != null)
        {
            bubbleCanvasGroup.alpha = 0;
            StartCoroutine(FadeInSpeechBubble(bubbleCanvasGroup));
        }
    }

    public IEnumerator FadeInSpeechBubble(CanvasGroup canvasGroup)
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

    public void RemoveCustomerAndSpeechBubble(bool isOrderCorrect)
    {
        if (currentSpeechBubble != null)
        {
            Destroy(currentSpeechBubble);
        }

        if (currentCharacter != null)
        {
            // Change to reaction bubble
            GameObject reactionBubble = Instantiate(
                isOrderCorrect ? customerReactionHappy : customerReactionMad,
                currentCharacter.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up),
                Quaternion.identity
            );

            // Animate the customer to the right
            StartCoroutine(AnimateCustomerOffscreen(currentCharacter, reactionBubble));
        }
    }

    private IEnumerator AnimateCustomerOffscreen(GameObject customer, GameObject reactionBubble)
    {
        while (Vector2.Distance(customer.transform.position, offscreenPosition.position) > 0.01f)
        {
            customer.transform.position = Vector2.MoveTowards(
                customer.transform.position,
                offscreenPosition.position,
                animationSpeed * Time.deltaTime
            );
            reactionBubble.transform.position = customer.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);
            yield return null;
        }

        Destroy(customer);
        Destroy(reactionBubble);
        Debug.Log("Customer and reaction bubble removed.");
        SpawnRandomCharacter(); // Spawn the next customer
    }
}  */


/* V6
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] characters; // Array of characters to spawn
    [SerializeField] public Transform tablePosition; // Target table position
    [SerializeField] public float animationSpeed = 2f; // Speed of animation
    [SerializeField] public GameObject[] speechBubbleVariants; // Array of speech bubble variants
    [SerializeField] public Transform speechBubbleOffset; // Offset position for the speech bubble
    [SerializeField] public float fadeInDuration = 1f; // Duration for the fade-in animation

    public GameObject currentCharacter;
    public GameObject currentSpeechBubble;

    public int lastBubbleIndex = -1; // Track the last spawned bubble
    public int repeatCount = 0; // Count of consecutive same bubbles

    public void Start()
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

    public IEnumerator AnimateToTable(GameObject character)
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

    public void SpawnSpeechBubble(GameObject character)
    {
        // Pick a random speech bubble variant, ensuring no repeats for 3 consecutive times
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, speechBubbleVariants.Length);
        } while (randomIndex == lastBubbleIndex && repeatCount >= 2);

        // Update repeat tracking
        if (randomIndex == lastBubbleIndex)
        {
            repeatCount++;
        }
        else
        {
            repeatCount = 0;
        }
        lastBubbleIndex = randomIndex;

        GameObject selectedSpeechBubble = speechBubbleVariants[randomIndex];

        // Instantiate the speech bubble next to the character
        Vector3 bubblePosition = character.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);
        currentSpeechBubble = Instantiate(selectedSpeechBubble, bubblePosition, Quaternion.identity);

        // Set initial transparency to 0
        CanvasGroup bubbleCanvasGroup = currentSpeechBubble.GetComponent<CanvasGroup>();
        if (bubbleCanvasGroup != null)
        {
            bubbleCanvasGroup.alpha = 0;
            StartCoroutine(FadeInSpeechBubble(bubbleCanvasGroup));
        }
    }

    public IEnumerator FadeInSpeechBubble(CanvasGroup canvasGroup)
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

    

public void RemoveCustomerAndSpeechBubble()
{
    if (currentCharacter != null)
    {
        Destroy(currentCharacter);
    }
    if (currentSpeechBubble != null)
    {
        Destroy(currentSpeechBubble);
    }

    Debug.Log("Customer and speech bubble removed.");
    SpawnRandomCharacter(); // Spawn the next customer and speech bubble
}





} */

/* V6: Fix reaction but happy customer move slow
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] characters; // Array of characters to spawn
    [SerializeField] public Transform tablePosition; // Target table position
    [SerializeField] public float animationSpeed = 2f; // Speed of animation
    [SerializeField] public GameObject[] speechBubbleVariants; // Array of speech bubble variants
    [SerializeField] public Transform speechBubbleOffset; // Offset position for the speech bubble
    [SerializeField] public float fadeInDuration = 1f; // Duration for the fade-in animation
    [SerializeField] public GameObject customerReactionHappy; // Happy reaction bubble
    [SerializeField] public GameObject customerReactionMad; // Mad reaction bubble
    [SerializeField] public Transform offscreenPosition; // Position to move the customer offscreen

    public GameObject currentCharacter;
    public GameObject currentSpeechBubble;

    public int lastBubbleIndex = -1; // Track the last spawned bubble
    public int repeatCount = 0; // Count of consecutive same bubbles

    public void Start()
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

    public IEnumerator AnimateToTable(GameObject character)
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

    public void SpawnSpeechBubble(GameObject character)
    {
        // Pick a random speech bubble variant, ensuring no repeats for 3 consecutive times
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, speechBubbleVariants.Length);
        } while (randomIndex == lastBubbleIndex && repeatCount >= 2);

        // Update repeat tracking
        if (randomIndex == lastBubbleIndex)
        {
            repeatCount++;
        }
        else
        {
            repeatCount = 0;
        }
        lastBubbleIndex = randomIndex;

        GameObject selectedSpeechBubble = speechBubbleVariants[randomIndex];

        // Instantiate the speech bubble next to the character
        Vector3 bubblePosition = character.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);
        currentSpeechBubble = Instantiate(selectedSpeechBubble, bubblePosition, Quaternion.identity);

        // Set initial transparency to 0
        CanvasGroup bubbleCanvasGroup = currentSpeechBubble.GetComponent<CanvasGroup>();
        if (bubbleCanvasGroup != null)
        {
            bubbleCanvasGroup.alpha = 0;
            StartCoroutine(FadeInSpeechBubble(bubbleCanvasGroup));
        }
    }

    public IEnumerator FadeInSpeechBubble(CanvasGroup canvasGroup)
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

    public void RemoveCustomerAndSpeechBubble(bool isOrderCorrect)
{
    if (currentSpeechBubble != null)
    {
        Destroy(currentSpeechBubble);
    }

    if (currentCharacter != null)
    {
        // Change to reaction bubble
        GameObject reactionBubble = Instantiate(
            isOrderCorrect ? customerReactionHappy : customerReactionMad,
            currentCharacter.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up),
            Quaternion.identity
        );

        // Animate the customer to the right with consistent speed
        StartCoroutine(AnimateCustomerOffscreen(currentCharacter, reactionBubble));
    }
}

private IEnumerator AnimateCustomerOffscreen(GameObject customer, GameObject reactionBubble)
{
    // Ensure the customer moves at a consistent speed regardless of the reaction bubble
    while (Vector2.Distance(customer.transform.position, offscreenPosition.position) > 0.01f)
    {
        // Move the customer to the offscreen position
        customer.transform.position = Vector2.MoveTowards(
            customer.transform.position,
            offscreenPosition.position,
            animationSpeed * Time.deltaTime
        );
        
        // Ensure the reaction bubble follows the customer at the same pace (no added offset or different logic)
        reactionBubble.transform.position = customer.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);

        yield return null;
    }

    // After the animation completes, destroy the customer and the reaction bubble
    Destroy(customer);
    Destroy(reactionBubble);
    Debug.Log("Customer and reaction bubble removed.");
    SpawnRandomCharacter(); // Spawn the next customer
}


} */

/*V7
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] characters; // Array of characters to spawn
    [SerializeField] public Transform tablePosition; // Target table position
    [SerializeField] public float animationSpeed = 2f; // Speed of animation
    [SerializeField] public GameObject[] speechBubbleVariants; // Array of speech bubble variants
    [SerializeField] public Transform speechBubbleOffset; // Offset position for the speech bubble
    [SerializeField] public float fadeInDuration = 1f; // Duration for the fade-in animation
    [SerializeField] public GameObject customerReactionHappy; // Happy reaction bubble
    [SerializeField] public GameObject customerReactionMad; // Mad reaction bubble
    [SerializeField] public Transform offscreenPosition; // Position to move the customer offscreen

    public GameObject currentCharacter;
    public GameObject currentSpeechBubble;

    public int lastBubbleIndex = -1; // Track the last spawned bubble
    public int repeatCount = 0; // Count of consecutive same bubbles

    public void Start()
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

    public IEnumerator AnimateToTable(GameObject character)
{
    // Check if the character is null at the start
    if (character == null)
    {
        yield break; // Exit early if the character is already destroyed
    }

    // Loop to move the character towards the table position
    while (Vector2.Distance(character.transform.position, tablePosition.position) > 0.01f)
    {
        // Additional check during the loop to ensure the character is still valid
        if (character == null)
        {
            yield break; // Exit the coroutine if the character is destroyed during the animation
        }

        character.transform.position = Vector2.MoveTowards(
            character.transform.position,
            tablePosition.position,
            animationSpeed * Time.deltaTime
        );

        yield return null; // Wait for the next frame
    }

    // Final check after the loop to ensure character still exists before final placement
    if (character != null)
    {
        character.transform.position = tablePosition.position;
        SpawnSpeechBubble(character);
    }
    else
    {
        // If character was destroyed, ensure no further actions are performed
        Debug.LogWarning("Character was destroyed before reaching the table.");
    }
}



    public void SpawnSpeechBubble(GameObject character)
    {
        // Pick a random speech bubble variant, ensuring no repeats for 3 consecutive times
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, speechBubbleVariants.Length);
        } while (randomIndex == lastBubbleIndex && repeatCount >= 2);

        // Update repeat tracking
        if (randomIndex == lastBubbleIndex)
        {
            repeatCount++;
        }
        else
        {
            repeatCount = 0;
        }
        lastBubbleIndex = randomIndex;

        GameObject selectedSpeechBubble = speechBubbleVariants[randomIndex];

        // Instantiate the speech bubble next to the character
        Vector3 bubblePosition = character.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);
        currentSpeechBubble = Instantiate(selectedSpeechBubble, bubblePosition, Quaternion.identity);

        // Set initial transparency to 0
        CanvasGroup bubbleCanvasGroup = currentSpeechBubble.GetComponent<CanvasGroup>();
        if (bubbleCanvasGroup != null)
        {
            bubbleCanvasGroup.alpha = 0;
            StartCoroutine(FadeInSpeechBubble(bubbleCanvasGroup));
        }
    }

    public IEnumerator FadeInSpeechBubble(CanvasGroup canvasGroup)
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

   public void RemoveCustomerAndSpeechBubble(bool isOrderCorrect)
{
    if (currentSpeechBubble != null)
    {
        Destroy(currentSpeechBubble);
    }

    if (currentCharacter != null)
    {
        // Change to reaction bubble
        GameObject reactionBubble = Instantiate(
            isOrderCorrect ? customerReactionHappy : customerReactionMad,
            currentCharacter.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up),
            Quaternion.identity
        );

        // Animate the customer to the right with consistent speed
        StartCoroutine(AnimateCustomerOffscreen(currentCharacter, reactionBubble));
    }
}


private IEnumerator AnimateCustomerOffscreen(GameObject customer, GameObject reactionBubble)
{
    // Ensure the customer moves at a consistent speed regardless of the reaction bubble
    while (Vector2.Distance(customer.transform.position, offscreenPosition.position) > 0.01f)
    {
        // Move the customer to the offscreen position
        customer.transform.position = Vector2.MoveTowards(
            customer.transform.position,
            offscreenPosition.position,
            animationSpeed * Time.deltaTime
        );
        
        // Ensure the reaction bubble follows the customer at the same pace (no added offset or different logic)
        reactionBubble.transform.position = customer.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);

        yield return null;
    }

    // After the animation completes, destroy the customer and the reaction bubble
    Destroy(customer);
    Destroy(reactionBubble);  // Ensure this removes the mad or happy bubble
    Debug.Log("Customer and reaction bubble removed.");
    SpawnRandomCharacter(); // Spawn the next customer
}





} */


/*V8
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] characters; // Array of characters to spawn
    [SerializeField] public Transform tablePosition; // Target table position
    [SerializeField] public float animationSpeed = 2f; // Speed of animation
    [SerializeField] public GameObject[] speechBubbleVariants; // Array of speech bubble variants
    [SerializeField] public Transform speechBubbleOffset; // Offset position for the speech bubble
    [SerializeField] public float fadeInDuration = 1f; // Duration for the fade-in animation
    [SerializeField] public GameObject customerReactionHappy; // Happy reaction bubble
    [SerializeField] public GameObject customerReactionMad; // Mad reaction bubble
    [SerializeField] public Transform offscreenPosition; // Position to move the customer offscreen

    public GameObject currentCharacter;
    public GameObject currentSpeechBubble;

    public int lastBubbleIndex = -1; // Track the last spawned bubble
    public int repeatCount = 0; // Count of consecutive same bubbles

    public void Start()
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

    public IEnumerator AnimateToTable(GameObject character)
{
    // Check if the character is null at the start
    if (character == null)
    {
        yield break; // Exit early if the character is already destroyed
    }

    // Loop to move the character towards the table position
    while (Vector2.Distance(character.transform.position, tablePosition.position) > 0.01f)
    {
        // Additional check during the loop to ensure the character is still valid
        if (character == null)
        {
            yield break; // Exit the coroutine if the character is destroyed during the animation
        }

        character.transform.position = Vector2.MoveTowards(
            character.transform.position,
            tablePosition.position,
            animationSpeed * Time.deltaTime
        );

        yield return null; // Wait for the next frame
    }

    // Final check after the loop to ensure character still exists before final placement
    if (character != null)
    {
        character.transform.position = tablePosition.position;
        SpawnSpeechBubble(character);
    }
    else
    {
        // If character was destroyed, ensure no further actions are performed
        Debug.LogWarning("Character was destroyed before reaching the table.");
    }
}



    public void SpawnSpeechBubble(GameObject character)
    {
        // Pick a random speech bubble variant, ensuring no repeats for 3 consecutive times
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, speechBubbleVariants.Length);
        } while (randomIndex == lastBubbleIndex && repeatCount >= 2);

        // Update repeat tracking
        if (randomIndex == lastBubbleIndex)
        {
            repeatCount++;
        }
        else
        {
            repeatCount = 0;
        }
        lastBubbleIndex = randomIndex;

        GameObject selectedSpeechBubble = speechBubbleVariants[randomIndex];

        // Instantiate the speech bubble next to the character
        Vector3 bubblePosition = character.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);
        currentSpeechBubble = Instantiate(selectedSpeechBubble, bubblePosition, Quaternion.identity);

        // Set initial transparency to 0
        CanvasGroup bubbleCanvasGroup = currentSpeechBubble.GetComponent<CanvasGroup>();
        if (bubbleCanvasGroup != null)
        {
            bubbleCanvasGroup.alpha = 0;
            StartCoroutine(FadeInSpeechBubble(bubbleCanvasGroup));
        }
    }

    public IEnumerator FadeInSpeechBubble(CanvasGroup canvasGroup)
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

   public void RemoveCustomerAndSpeechBubble(bool isOrderCorrect)
{
    if (currentSpeechBubble != null)
    {
        Destroy(currentSpeechBubble);
    }

    if (currentCharacter != null)
    {
        // Change to reaction bubble
        GameObject reactionBubble = Instantiate(
            isOrderCorrect ? customerReactionHappy : customerReactionMad,
            currentCharacter.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up),
            Quaternion.identity
        );

        // Animate the customer to the right with consistent speed
        StartCoroutine(AnimateCustomerOffscreen(currentCharacter, reactionBubble));
    }
}


private IEnumerator AnimateCustomerOffscreen(GameObject customer, GameObject reactionBubble)
{
    // Ensure the customer moves at a consistent speed regardless of the reaction bubble
    while (Vector2.Distance(customer.transform.position, offscreenPosition.position) > 0.01f)
    {
        // Move the customer to the offscreen position
        customer.transform.position = Vector2.MoveTowards(
            customer.transform.position,
            offscreenPosition.position,
            animationSpeed * Time.deltaTime
        );
        
        // Ensure the reaction bubble follows the customer at the same pace (no added offset or different logic)
        reactionBubble.transform.position = customer.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);

        yield return null;
    }

    // After the animation completes, destroy the customer and the reaction bubble
    Destroy(customer);
    Destroy(reactionBubble);  // Ensure this removes the mad or happy bubble
    Debug.Log("Customer and reaction bubble removed.");
    SpawnRandomCharacter(); // Spawn the next customer
}





} */

/*V9
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] characters; // Array of characters to spawn
    [SerializeField] public Transform tablePosition; // Target table position
    [SerializeField] public float animationSpeed = 2f; // Speed of animation
    [SerializeField] public GameObject[] speechBubbleVariants; // Array of speech bubble variants
    [SerializeField] public Transform speechBubbleOffset; // Offset position for the speech bubble
    [SerializeField] public float fadeInDuration = 1f; // Duration for the fade-in animation
    [SerializeField] public GameObject customerReactionHappy; // Happy reaction bubble
    [SerializeField] public GameObject customerReactionMad; // Mad reaction bubble
    [SerializeField] public Transform offscreenPosition; // Position to move the customer offscreen

    public GameObject currentCharacter;
    public GameObject currentSpeechBubble;

    public int lastBubbleIndex = -1; // Track the last spawned bubble
    public int repeatCount = 0; // Count of consecutive same bubbles

    public void Start()
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

    public IEnumerator AnimateToTable(GameObject character)
{
    // Check if the character is null at the start
    if (character == null)
    {
        yield break; // Exit early if the character is already destroyed
    }

    // Loop to move the character towards the table position
    while (Vector2.Distance(character.transform.position, tablePosition.position) > 0.01f)
    {
        // Additional check during the loop to ensure the character is still valid
        if (character == null)
        {
            yield break; // Exit the coroutine if the character is destroyed during the animation
        }

        character.transform.position = Vector2.MoveTowards(
            character.transform.position,
            tablePosition.position,
            animationSpeed * Time.deltaTime
        );

        yield return null; // Wait for the next frame
    }

    // Final check after the loop to ensure character still exists before final placement
    if (character != null)
    {
        character.transform.position = tablePosition.position;
        SpawnSpeechBubble(character);
    }
    else
    {
        // If character was destroyed, ensure no further actions are performed
        Debug.LogWarning("Character was destroyed before reaching the table.");
    }
}



    public void SpawnSpeechBubble(GameObject character)
    {
        // Pick a random speech bubble variant, ensuring no repeats for 3 consecutive times
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, speechBubbleVariants.Length);
        } while (randomIndex == lastBubbleIndex && repeatCount >= 2);

        // Update repeat tracking
        if (randomIndex == lastBubbleIndex)
        {
            repeatCount++;
        }
        else
        {
            repeatCount = 0;
        }
        lastBubbleIndex = randomIndex;

        GameObject selectedSpeechBubble = speechBubbleVariants[randomIndex];

        // Instantiate the speech bubble next to the character
        Vector3 bubblePosition = character.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);
        currentSpeechBubble = Instantiate(selectedSpeechBubble, bubblePosition, Quaternion.identity);

        // Set initial transparency to 0
        CanvasGroup bubbleCanvasGroup = currentSpeechBubble.GetComponent<CanvasGroup>();
        if (bubbleCanvasGroup != null)
        {
            bubbleCanvasGroup.alpha = 0;
            StartCoroutine(FadeInSpeechBubble(bubbleCanvasGroup));
        }
    }

    public IEnumerator FadeInSpeechBubble(CanvasGroup canvasGroup)
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

   public void RemoveCustomerAndSpeechBubble(bool isOrderCorrect)
{
    if (currentSpeechBubble != null)
    {
        Destroy(currentSpeechBubble);
    }

    if (currentCharacter != null)
    {
        // Change to reaction bubble
        GameObject reactionBubble = Instantiate(
            isOrderCorrect ? customerReactionHappy : customerReactionMad,
            currentCharacter.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up),
            Quaternion.identity
        );

        // Animate the customer to the right with consistent speed
        StartCoroutine(AnimateCustomerOffscreen(currentCharacter, reactionBubble));
    }
}


private IEnumerator AnimateCustomerOffscreen(GameObject customer, GameObject reactionBubble)
{
    // Ensure the customer moves at a consistent speed regardless of the reaction bubble
    while (Vector2.Distance(customer.transform.position, offscreenPosition.position) > 0.01f)
    {
        // Move the customer to the offscreen position
        customer.transform.position = Vector2.MoveTowards(
            customer.transform.position,
            offscreenPosition.position,
            animationSpeed * Time.deltaTime
        );
        
        // Ensure the reaction bubble follows the customer at the same pace (no added offset or different logic)
        reactionBubble.transform.position = customer.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);

        yield return null;
    }

    // After the animation completes, destroy the customer and the reaction bubble
    Destroy(customer);
    Destroy(reactionBubble);  // Ensure this removes the mad or happy bubble
    Debug.Log("Customer and reaction bubble removed.");
    SpawnRandomCharacter(); // Spawn the next customer
}





} */


/*V10: With happiness bar
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] characters; // Array of characters to spawn
    [SerializeField] public Transform tablePosition; // Target table position
    [SerializeField] public float animationSpeed = 2f; // Speed of animation
    [SerializeField] public GameObject[] speechBubbleVariants; // Array of speech bubble variants
    [SerializeField] public Transform speechBubbleOffset; // Offset position for the speech bubble
    [SerializeField] public float fadeInDuration = 1f; // Duration for the fade-in animation
    [SerializeField] public GameObject customerReactionHappy; // Happy reaction bubble
    [SerializeField] public GameObject customerReactionMad; // Mad reaction bubble
    [SerializeField] public Transform offscreenPosition; // Position to move the customer offscreen

    public GameObject currentCharacter;
    public GameObject currentSpeechBubble;

    public int lastBubbleIndex = -1; // Track the last spawned bubble
    public int repeatCount = 0; // Count of consecutive same bubbles

    public void Start()
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

    public HappinessBar happinessBar; // Reference to the HappinessBar script

public IEnumerator AnimateToTable(GameObject character)
{
    // Check if the character is null at the start
    if (character == null)
    {
        yield break; // Exit early if the character is already destroyed
    }

    // Loop to move the character towards the table position
    while (Vector2.Distance(character.transform.position, tablePosition.position) > 0.01f)
    {
        // Additional check during the loop to ensure the character is still valid
        if (character == null)
        {
            yield break; // Exit the coroutine if the character is destroyed during the animation
        }

        character.transform.position = Vector2.MoveTowards(
            character.transform.position,
            tablePosition.position,
            animationSpeed * Time.deltaTime
        );

        yield return null; // Wait for the next frame
    }

    // Final check after the loop to ensure character still exists before final placement
    if (character != null)
    {
        character.transform.position = tablePosition.position;
        SpawnSpeechBubble(character);

        // Start the happiness bar when the customer reaches the table
        if (happinessBar != null)
        {
            happinessBar.StartHappinessBar(); // Call a method in HappinessBar to start the timer
        }
    }
    else
    {
        // If character was destroyed, ensure no further actions are performed
        Debug.LogWarning("Character was destroyed before reaching the table.");
    }
}




    public void SpawnSpeechBubble(GameObject character)
    {
        // Pick a random speech bubble variant, ensuring no repeats for 3 consecutive times
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, speechBubbleVariants.Length);
        } while (randomIndex == lastBubbleIndex && repeatCount >= 2);

        // Update repeat tracking
        if (randomIndex == lastBubbleIndex)
        {
            repeatCount++;
        }
        else
        {
            repeatCount = 0;
        }
        lastBubbleIndex = randomIndex;

        GameObject selectedSpeechBubble = speechBubbleVariants[randomIndex];

        // Instantiate the speech bubble next to the character
        Vector3 bubblePosition = character.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);
        currentSpeechBubble = Instantiate(selectedSpeechBubble, bubblePosition, Quaternion.identity);

        // Set initial transparency to 0
        CanvasGroup bubbleCanvasGroup = currentSpeechBubble.GetComponent<CanvasGroup>();
        if (bubbleCanvasGroup != null)
        {
            bubbleCanvasGroup.alpha = 0;
            StartCoroutine(FadeInSpeechBubble(bubbleCanvasGroup));
        }
    }

    public IEnumerator FadeInSpeechBubble(CanvasGroup canvasGroup)
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

   public void RemoveCustomerAndSpeechBubble(bool isOrderCorrect)
{
    if (currentSpeechBubble != null)
    {
        Destroy(currentSpeechBubble);
    }

    if (currentCharacter != null)
    {
        // Change to reaction bubble
        GameObject reactionBubble = Instantiate(
            isOrderCorrect ? customerReactionHappy : customerReactionMad,
            currentCharacter.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up),
            Quaternion.identity
        );

        // Animate the customer to the right with consistent speed
        StartCoroutine(AnimateCustomerOffscreen(currentCharacter, reactionBubble));
    }
}


private IEnumerator AnimateCustomerOffscreen(GameObject customer, GameObject reactionBubble)
{
    // Ensure the customer moves at a consistent speed regardless of the reaction bubble
    while (Vector2.Distance(customer.transform.position, offscreenPosition.position) > 0.01f)
    {
        // Move the customer to the offscreen position
        customer.transform.position = Vector2.MoveTowards(
            customer.transform.position,
            offscreenPosition.position,
            animationSpeed * Time.deltaTime
        );
        
        // Ensure the reaction bubble follows the customer at the same pace (no added offset or different logic)
        reactionBubble.transform.position = customer.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);

        yield return null;
    }

    // After the animation completes, destroy the customer and the reaction bubble
    Destroy(customer);
    Destroy(reactionBubble);  // Ensure this removes the mad or happy bubble
    Debug.Log("Customer and reaction bubble removed.");
    SpawnRandomCharacter(); // Spawn the next customer
}





} */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] characters; // Array of characters to spawn
    [SerializeField] public Transform tablePosition; // Target table position
    [SerializeField] public float animationSpeed = 2f; // Speed of animation
    [SerializeField] public GameObject[] speechBubbleVariants; // Array of speech bubble variants
    [SerializeField] public Transform speechBubbleOffset; // Offset position for the speech bubble
    [SerializeField] public float fadeInDuration = 1f; // Duration for the fade-in animation
    [SerializeField] public GameObject customerReactionHappy; // Happy reaction bubble
    [SerializeField] public GameObject customerReactionMad; // Mad reaction bubble
    [SerializeField] public Transform offscreenPosition; // Position to move the customer offscreen

    public GameObject currentCharacter;
    public GameObject currentSpeechBubble;

    public int lastBubbleIndex = -1; // Track the last spawned bubble
    public int repeatCount = 0; // Count of consecutive same bubbles

    public void Start()
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

    public IEnumerator AnimateToTable(GameObject character)
{
    // Check if the character is null at the start
    if (character == null)
    {
        yield break; // Exit early if the character is already destroyed
    }

    // Loop to move the character towards the table position
    while (Vector2.Distance(character.transform.position, tablePosition.position) > 0.01f)
    {
        // Additional check during the loop to ensure the character is still valid
        if (character == null)
        {
            yield break; // Exit the coroutine if the character is destroyed during the animation
        }

        character.transform.position = Vector2.MoveTowards(
            character.transform.position,
            tablePosition.position,
            animationSpeed * Time.deltaTime
        );

        yield return null; // Wait for the next frame
    }

    // Final check after the loop to ensure character still exists before final placement
    if (character != null)
    {
        character.transform.position = tablePosition.position;
        SpawnSpeechBubble(character);
    }
    else
    {
        // If character was destroyed, ensure no further actions are performed
        Debug.LogWarning("Character was destroyed before reaching the table.");
    }
}



    public void SpawnSpeechBubble(GameObject character)
    {
        // Pick a random speech bubble variant, ensuring no repeats for 3 consecutive times
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, speechBubbleVariants.Length);
        } while (randomIndex == lastBubbleIndex && repeatCount >= 2);

        // Update repeat tracking
        if (randomIndex == lastBubbleIndex)
        {
            repeatCount++;
        }
        else
        {
            repeatCount = 0;
        }
        lastBubbleIndex = randomIndex;

        GameObject selectedSpeechBubble = speechBubbleVariants[randomIndex];

        // Instantiate the speech bubble next to the character
        Vector3 bubblePosition = character.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);
        currentSpeechBubble = Instantiate(selectedSpeechBubble, bubblePosition, Quaternion.identity);

        // Set initial transparency to 0
        CanvasGroup bubbleCanvasGroup = currentSpeechBubble.GetComponent<CanvasGroup>();
        if (bubbleCanvasGroup != null)
        {
            bubbleCanvasGroup.alpha = 0;
            StartCoroutine(FadeInSpeechBubble(bubbleCanvasGroup));
        }
    }

    public IEnumerator FadeInSpeechBubble(CanvasGroup canvasGroup)
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

   public void RemoveCustomerAndSpeechBubble(bool isOrderCorrect)
{
    if (currentSpeechBubble != null)
    {
        Destroy(currentSpeechBubble);
    }

    if (currentCharacter != null)
    {
        // Change to reaction bubble
        GameObject reactionBubble = Instantiate(
            isOrderCorrect ? customerReactionHappy : customerReactionMad,
            currentCharacter.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up),
            Quaternion.identity
        );

        // Animate the customer to the right with consistent speed
        StartCoroutine(AnimateCustomerOffscreen(currentCharacter, reactionBubble));
    }
}


private IEnumerator AnimateCustomerOffscreen(GameObject customer, GameObject reactionBubble)
{
    // Ensure the customer moves at a consistent speed regardless of the reaction bubble
    while (Vector2.Distance(customer.transform.position, offscreenPosition.position) > 0.01f)
    {
        // Move the customer to the offscreen position
        customer.transform.position = Vector2.MoveTowards(
            customer.transform.position,
            offscreenPosition.position,
            animationSpeed * Time.deltaTime
        );
        
        // Ensure the reaction bubble follows the customer at the same pace (no added offset or different logic)
        reactionBubble.transform.position = customer.transform.position + (speechBubbleOffset != null ? speechBubbleOffset.position : Vector3.up);

        yield return null;
    }

    // After the animation completes, destroy the customer and the reaction bubble
    Destroy(customer);
    Destroy(reactionBubble);  // Ensure this removes the mad or happy bubble
    Debug.Log("Customer and reaction bubble removed.");
    SpawnRandomCharacter(); // Spawn the next customer
}





}