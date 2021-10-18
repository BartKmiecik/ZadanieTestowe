using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionIndicator : MonoBehaviour
{
    private Renderer rend;
    private Color defaultColor;
    [SerializeField] private Color selectedColor;

    public void SelectAgent(GameObject agent)
    {
        if(rend != null)
        {
            DeselectAgent();
        }
        rend = agent.GetComponent<Renderer>();
        defaultColor = rend.material.color;
        rend.material.color = selectedColor;
    }

    public void DeselectAgent()
    {
        if(rend != null)
        {
            rend.material.color = defaultColor;
            rend = null;
        }
    }
}
