using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Transform orientation;

    float HorizontalInput;
    float VerticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    public float PlayerHeight;
    public LayerMask Ground;
    bool grounded;
    public float grounddrag;


    private void Start(){
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update(){

        grounded = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * 0.5f + 0.2f, Ground);
        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        MyInput();
    }
    private void FixedUpdate(){
        MovePlayer();
    }
    
    private void MyInput(){
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
    }
    private void MovePlayer(){
        moveDirection = orientation.forward * VerticalInput + orientation.right * HorizontalInput;
        rb.velocity = moveDirection * moveSpeed;
        
    }






}
