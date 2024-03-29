using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Transform orientation;

    public int SnusCount;

    float HorizontalInput;
    float VerticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    public GameObject ventsource;
    public AudioClip clip;

    private void Start(){
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update(){

        MyInput();
        if(Input.GetKeyDown(KeyCode.U)){
            ventsource.GetComponent<NouseAudioSc>().NoiseChange(clip);
        }
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
