
using System;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private Color _selectedStateColor;
   
    private Color _standardStateColor;
    private Renderer _renderer;
    private Collider _collider;
    private Camera _mainCamera;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<Renderer>();
        _standardStateColor = _renderer.material.color;
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (_collider.Raycast(ray, out var hitInfo, 30f))
        {
            if (hitInfo.transform.CompareTag("Interactable"))
            {
                _renderer.material.color = _selectedStateColor;
            }
        }
        else
        {
            _renderer.material.color = _standardStateColor;
        }
    }
    
}
