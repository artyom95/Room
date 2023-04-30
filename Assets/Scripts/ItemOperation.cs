using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemOperation : MonoBehaviour
{
    [SerializeField]
    private Collider _collider;
    [SerializeField] 
    private Transform _parent;
    [SerializeField]
    private Transform _newParent;
    
    private bool _isItemInHand = false;
    private Transform _itemInHand;
[SerializeField]
    private Rigidbody _rigidbodyGameObject;

    private float _force = 1000f;
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbodyGameObject = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (_collider.Raycast(ray, out var hitInfo, 5f))
        {
            if (Input.GetKeyDown(KeyCode.E) && !_isItemInHand)
            {
                TakeItem();
               
                return;
            }
        }
    if  (Input.GetKeyDown(KeyCode.E) && _itemInHand !=null )
        { 
            PutDown(); 
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && _isItemInHand ) 
        { 
            Discard();
        }
    }

    private void TakeItem()
    {
        transform.SetParent(_parent, false);
        _isItemInHand = true;
        _itemInHand = transform;
        transform.position = _parent.position;
        transform.rotation = _parent.rotation;
        _rigidbodyGameObject.isKinematic = true;

        Debug.Log("Set New Parent");
    }
     private void PutDown()
    {
       _itemInHand.SetParent(_newParent, true);
       _isItemInHand = false;
       _rigidbodyGameObject.isKinematic = false;
       _itemInHand = null;
       Debug.Log("Item Put Down");
    }

    private void Discard()
    {
       // 
        _rigidbodyGameObject.isKinematic = false;
        _rigidbodyGameObject.AddForce(- Vector3.forward * _force);
        transform.SetParent(_newParent);
        _itemInHand = null;
        _isItemInHand = false;
       
       Debug.Log("Item Discard");
    }
}
