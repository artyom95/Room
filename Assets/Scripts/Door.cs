using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] 
    private Collider _collider;
    private Animator _animator;
    private bool _isOpen;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (_collider.Raycast(ray, out var hitInfo, 2f))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SwitchDoorState();
            }
        }
    }

    public void SwitchDoorState()
    {
        _isOpen = !_isOpen;
        _animator.SetBool("isOpen", _isOpen);
    }
}