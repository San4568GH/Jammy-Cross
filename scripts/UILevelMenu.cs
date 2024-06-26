using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string level;

    public void OpenLevel(){
        Time.timeScale = 1f;
        if(level=="Main Menu New")
        {
            DeathCount.Remainingdeath = 10;
        }
        SceneManager.LoadScene(level);
        PlayerMovNew.IsPause = false;

    }
   
}
