using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayColorBlend : MonoBehaviour
{
    [SerializeField] private TargetColor _assignTargetColor;
    [SerializeField] private List<Renderer> _renderersOneDisplay;
    [SerializeField] private List<Renderer> _renderersTwoDisplay;

    private void OnEnable()
    {
        _assignTargetColor.ColorAssignedBlend += OnDispayColor;
    }

    private void OnDisable()
    {
        _assignTargetColor.ColorAssignedBlend -= OnDispayColor;
    }

    private void OnDispayColor(Color colorOne, Color colorTwo)
    {
        DisplayColor(_renderersOneDisplay, colorOne);
        DisplayColor(_renderersTwoDisplay, colorTwo);
    }

    private void DisplayColor(List<Renderer> renderers, Color color)
    {
        foreach (Renderer renderer in renderers)
        {
            foreach (Material material in renderer.materials)
            {
                material.color = color;
            }
        }
    }
}
