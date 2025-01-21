using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TO OPEN AND CLOSE RECIPE BOOK
public class RecipeBook : MonoBehaviour
{
    [SerializeField] GameObject recipeBook;
    [SerializeField] AudioSource audioSFX;
    [SerializeField] AudioSource audioSFX2;
    [SerializeField] AudioClip openRecipeBook;
    [SerializeField] AudioClip closeRecipeBook;

    public void OpenRecipe()
    {
        recipeBook.SetActive(true);
        if (openRecipeBook != null && audioSFX != null)
        {
            audioSFX.PlayOneShot(openRecipeBook);
        }
    }

    public void CloseRecipe()
    {
        recipeBook.SetActive(false);
        if (closeRecipeBook != null && audioSFX2 != null)
        {
            audioSFX2.PlayOneShot(closeRecipeBook);
        }
    }
}
