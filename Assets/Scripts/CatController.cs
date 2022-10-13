using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    private Rigidbody rb;
    Boolean isGrounded = true;
    public float jumpForce = 10f;
    public float speed;
    private Camera cam;
    private Animator _animator;
    private static readonly int VerticalAxis = Animator.StringToHash("Blend");

    private void Start()
    {
        //get rigidbody component
        rb = GetComponent<Rigidbody>();
        //get camera component
        cam = Camera.main;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        //check if cat collides with ground
        //movement of the cat
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            _animator.SetFloat(VerticalAxis, 1f);
        }
        else
        {
            _animator.SetFloat(VerticalAxis, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        //change rotation of player to camera
        transform.rotation = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);
        //jumping of the cat while grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (isGrounded)
        {
            Debug.Log("Grounded");
        }
        else Debug.Log("Not Grounded");
    }
    
    //check if cat touches ground
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
