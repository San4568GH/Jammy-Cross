using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]public string scene;
    [SerializeField] private Rigidbody player;
   public void Res(){

        //SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    //PlayerMovNew.playerRigid.isKinematic = false;
    player.isKinematic = false;
        
        PlayerMovNew.IsPause = false;
    DeathCount.Remainingdeath = 10;
   }
}
