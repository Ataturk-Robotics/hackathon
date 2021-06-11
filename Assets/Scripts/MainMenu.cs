using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource clickSound;
    public static AudioSource ClickSound;

    public static void onPlayClick(){
        SceneManager.LoadScene("Game");
    }
    
}
