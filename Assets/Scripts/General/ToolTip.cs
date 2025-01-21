using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    public string message; 

    void OnMouseEnter()
    {
        ToolTipManager._instance.SetAndShowToolTip(message);
    }

    void OnMouseExit()
    {
        ToolTipManager._instance.HideToolTip();
    }

    void OnMouseDown()
    {
        // Hide the tooltip when the user clicks
        ToolTipManager._instance.HideToolTip();
    }
}
