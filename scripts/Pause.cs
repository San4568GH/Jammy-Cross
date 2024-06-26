using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PauseMenu;
    //public static bool IsPause = false;

   
    public void UnPause(){
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        PlayerMovNew.IsPause = false;
    }
}
