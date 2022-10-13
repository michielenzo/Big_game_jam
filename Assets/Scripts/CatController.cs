using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    private Rigidbody rb;
    Boolean isGrounded = true;
    public float jumpForce = 10f;
    private Camera cam;

    private void Start()
    {
        //get rigidbody component
        rb = GetComponent<Rigidbody>();
        //get camera component
        cam = Camera.main;
    }

    void Update()
    {
        //check if cat collides with ground
        //movement of the cat
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 5);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * 5);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 5);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 5);
        }
        //change rotation of player to camera
        transform.rotation = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);
        //jumping of the cat while grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    
    //check if cat collides with ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
