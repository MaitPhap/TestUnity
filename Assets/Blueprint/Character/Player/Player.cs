using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    BoxCollider bCollider;
    public Transform gunTransform;
    [Header("Movement")]
    public float moveSpeed;
    public float rotationSpeed;
    public float translate;
    public float rotation;
    [Space]
    public LayerMask layerMask;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAim();
        translate = Input.GetAxis("Vertical") * moveSpeed;
        if(translate < 0)
        {
            rotation = -Input.GetAxis("Horizontal") * rotationSpeed;
        }
        else
        {
            rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        }
        
    }

    private void FixedUpdate()
    {
        
        rb.velocity = transform.forward * translate;
        transform.Rotate(0, rotation, 0);
    }

    void UpdateAim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            gunTransform.Rotate(0, hit.point.normalized.x, 0);
        }
    }
}
