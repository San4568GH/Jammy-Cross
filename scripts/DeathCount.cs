using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathCount : MonoBehaviour
{
    // Start is called before the first frame update
    public static int  Remainingdeath = 10;
   // public TextMeshProUGUI score;
    public Image[] hearts;
    //public Sprite fullHeart;
  

    // Update is called once per frame
    void Update()
    {
       for(int i=0;i<hearts.Length;i++){
        if(i<Remainingdeath){
            hearts[i].enabled = true;
        }
        else hearts[i].enabled = false;
       }
    }
}
