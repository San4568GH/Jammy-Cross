using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Animator playerAnimator;
    public Rigidbody playerRigid;
    public Transform playerTransform;
    //public PlayerController playerController;
    public float moveSpeed=5f;
    public bool front=true, right=false,left=false,back=false,IsGrounded=true;
    [SerializeField] private float Jumpforce;
    [SerializeField] private float force;


    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && IsGrounded){
                playerRigid.AddForce(new Vector3(0,force,0), ForceMode.Impulse);
                IsGrounded=false;
            }
        
        if(Input.GetKey(KeyCode.W))
        {
            playerAnimator.SetTrigger("Running");
            playerAnimator.ResetTrigger("Idle");
            if (back == true)
            {
                playerTransform.Rotate(new Vector3(0, 180, 0));
            }
            else if (right == true)
            {
                playerTransform.Rotate(new Vector3(0, -90, 0));
            }
            else if (left == true)
            {
                playerTransform.Rotate(new Vector3(0, 90, 0));
            }
            front = true;
            right = false;
            left = false;
            back = false;
              
            
                
            
            
            playerTransform.Translate(new Vector3(0,0,1) * moveSpeed * Time.deltaTime);
            if(Input.GetButtonDown("Jump") && IsGrounded){
                playerRigid.AddForce(new Vector3(0,force,0), ForceMode.Impulse);
               // playerController.DisableMovement();
                IsGrounded=false;
              //  StartCoroutine(OnCollisionEnter(other));
            }
          
             
            
        } 
        else if(Input.GetKey(KeyCode.S)) 
        {
            playerAnimator.SetTrigger("Running");
            playerAnimator.ResetTrigger("Idle");
            if (front==true) 
            {
                playerTransform.Rotate(new Vector3(0, 180, 0));
            } 
            else if(right==true) 
            {
                playerTransform.Rotate(new Vector3(0, 90, 0));
            } 
            else if (left == true)
            {
                playerTransform.Rotate(new Vector3(0, -90, 0));
            }
            front = false;
            right = false;
            left = false;
            back = true;
            playerTransform.Translate(new Vector3(0,0,1) * moveSpeed * Time.deltaTime);
             if(Input.GetButtonDown("Jump") && IsGrounded){
                playerRigid.AddForce(new Vector3(0,force,0), ForceMode.Impulse);
               
                IsGrounded=false;
            }
        }
        else if(Input.GetKey(KeyCode.D))
        {
            playerAnimator.SetTrigger("Running");
            playerAnimator.ResetTrigger("Idle");
            if (front == true)
            {
                playerTransform.Rotate(new Vector3(0, 90, 0));
            }
            else if (back == true)
            {
                playerTransform.Rotate(new Vector3(0, -90, 0));
            }
            else if (left == true)
            {
                playerTransform.Rotate(new Vector3(0, 180, 0));
            }
            front = false;
            right = true;
            left = false;
            back = false;
            playerTransform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);
             if(Input.GetButtonDown("Jump") && IsGrounded){
                playerRigid.AddForce(new Vector3(0,force,0), ForceMode.Impulse);
                IsGrounded=false;
            }
        }
        else if(Input.GetKey(KeyCode.A))
        {
            playerAnimator.SetTrigger("Running");
            playerAnimator.ResetTrigger("Idle");
            if (front == true)
            {
                playerTransform.Rotate(new Vector3(0, -90, 0));
            }
            else if (right == true)
            {
                playerTransform.Rotate(new Vector3(0, 180, 0));
            }
            else if (back == true)
            {
                playerTransform.Rotate(new Vector3(0, 90, 0));
            }
            front = false;
            right = false;
            left = true;
            back = false;
            playerTransform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);
             if(Input.GetButtonDown("Jump") && IsGrounded){
                playerRigid.AddForce(new Vector3(0,force,0), ForceMode.Impulse);
                IsGrounded=false;
            }
        }
        else
        {
                playerAnimator.SetTrigger("Idle");
                playerAnimator.ResetTrigger("Running");
                playerAnimator.ResetTrigger("Falling");
        }
    }
    void OnCollisionEnter(Collision other){
                
                    IsGrounded = true;
                    
            }
    
}
