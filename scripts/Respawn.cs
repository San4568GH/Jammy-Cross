using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private string canvasName;
    [SerializeField] private Rigidbody playerRig;
     //public Rigidbody playerRigid;
     public GameObject gameOver ;
     public AudioSource audioSource;
     public AudioSource respawnAudio;
     public AudioSource deathAudio;
     
    void Start(){
        
        
         gameOver.SetActive(false);
    }

    private async void OnTriggerEnter(Collider other){
       
        if(other.CompareTag("Player")){
             //respawnAudio.Play();
            DeathCount.Remainingdeath--;
            if(DeathCount.Remainingdeath==0){
                playerRig.isKinematic = true;
                
                 gameOver.SetActive(true);
                 if(audioSource.isPlaying){
                    audioSource.Pause();
                 }
                 
                 
            }
          //  await Task.Delay(500);
            
            
            player.transform.position = respawnPoint.transform.position;
            
            Physics.SyncTransforms();
            PlayerMovNew.IsGrounded = true;
            await Task.Delay(100);
            //respawnAudio.Play();
            
        }
    }
    
}
