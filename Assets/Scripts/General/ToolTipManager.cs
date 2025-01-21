using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToolTipManager : MonoBehaviour
{
    public static ToolTipManager _instance; 

    public TextMeshProUGUI textComponent; 

    private void Awake()
    {
        if (_instance != null && _instance != this) //To avoid tooltip manager to be created multiple times when we only want to use once
        {
            Destroy(this.gameObject); 
        }
        else
        {
            _instance = this; 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void SetAndShowToolTip(string message) //To show the ingredient name
    {
        gameObject.SetActive(true);
        textComponent.text = message;
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
        textComponent.text = string.Empty;
    }


}
