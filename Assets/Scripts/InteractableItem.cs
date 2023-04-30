using System;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [SerializeField]
    private int _highlightIntensity = 4;

    
   
    private Collider _collider;
    
    private Outline _outline;
   

    private void Awake()
    {
        _outline = GetComponent<Outline>();
        _collider = GetComponent<Collider>();
    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var isCameraLookingAtTheItem = _collider.Raycast(ray, out var hitInfo, 5f);
        IlluminateObject(isCameraLookingAtTheItem);
    }

    private void IlluminateObject(bool cameraState)
    {
        if (cameraState)
        {
            SetFocus();
        }
        else
        {
            RemoveFocus();
        }
    }
    public void SetFocus()
    {
        _outline.OutlineWidth = _highlightIntensity;
    }
    
    public void RemoveFocus()
    {
        _outline.OutlineWidth = 0;
    }
}