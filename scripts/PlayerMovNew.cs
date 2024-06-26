using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PlayerMovNew : MonoBehaviour
{
    public Animator playerAnimator;
    public Rigidbody playerRigid;
    public Transform playerTransform;
    //public float moveSpeed=3f;
   // public float g=9.81f;
    public bool front=true, right=false,left=false,back=false;
    public static bool IsGrounded = true, IsPause = false;
    public GameObject PauseMenu;
    public GameObject Victory;
    [SerializeField]public float dist;

     public AudioSource jump;
     public AudioSource destruction;
    

    public float CalCulateVelocity(float dist){
        float g = Physics.gravity.magnitude;
        float velocity = Mathf.Sqrt(g*dist);
        return velocity;
    }
    
    public float angle = 45f*Mathf.Deg2Rad;
    
    void Start(){
        Victory.SetActive(false);
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;

    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !IsPause)
        {
            PauseMenu.SetActive(true);
            Debug.Log("dfdf");
            Time.timeScale = 0f;
            IsPause = true;

        }


        if (Input.GetKeyDown(KeyCode.W) && IsGrounded)
        {
            // jump.Play();
             float vel=CalCulateVelocity(dist);
            playerAnimator.SetTrigger("Jumping");
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
            //playerTransform.Translate(new Vector3(0,0,1) * moveSpeed * Time.deltaTime);
             
            Vector3 initialVelocity = new Vector3(vel*Mathf.Cos(angle),vel*Mathf.Sin(angle),0);
            playerRigid.velocity = initialVelocity;
            IsGrounded  = false;
          
        } 
        else if(Input.GetKeyDown(KeyCode.S) && IsGrounded) 
        {
            float vel=CalCulateVelocity(dist);
            playerAnimator.SetTrigger("Jumping");
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
             //jump.Play();
             Vector3 initialVelocity = new Vector3(-vel*Mathf.Cos(angle),vel*Mathf.Sin(angle),0);
            playerRigid.velocity = initialVelocity;
            IsGrounded  = false;
           

        }
        else if(Input.GetKeyDown(KeyCode.D) && IsGrounded)
        {
            float vel=CalCulateVelocity(dist);
            playerAnimator.SetTrigger("Jumping");
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
           // jump.Play();
             Vector3 initialVelocity = new Vector3(0,vel*Mathf.Sin(angle),-vel*Mathf.Cos(angle));
            playerRigid.velocity = initialVelocity;
            IsGrounded  = false;
            
        }
        else if(Input.GetKeyDown(KeyCode.A) && IsGrounded)
        {
            float vel=CalCulateVelocity(dist);
            playerAnimator.SetTrigger("Jumping");
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
           // jump.Play();
            Vector3 initialVelocity = new Vector3(0,vel*Mathf.Sin(angle),vel*Mathf.Cos(angle));
            playerRigid.velocity = initialVelocity;
            IsGrounded  = false;
            
        }
        else
        {
            if(IsGrounded)
            {
                playerAnimator.SetTrigger("Idle");
                playerAnimator.ResetTrigger("Jumping");
            }
        }
    }

    public async void OnCollisionEnter(Collision other){
         if(other.gameObject.CompareTag("trap")){

            playerAnimator.SetTrigger("Idle");
            playerAnimator.ResetTrigger("Jumping");
            IsGrounded = false;
            BoxCollider box = other.gameObject.GetComponent<BoxCollider>();
            // System.Threading.Thread.Sleep(2000);

            destruction.Play();
            await Task.Delay(100);
            Destroy(other.gameObject);
            await Task.Delay(1000);
            
        }
        else if(other.gameObject.CompareTag("End")){
            Victory.SetActive(true);
            playerRigid.isKinematic = true;
        }
        else IsGrounded = true;
    }


    public void PauseGame()
    {
       

    }




}
