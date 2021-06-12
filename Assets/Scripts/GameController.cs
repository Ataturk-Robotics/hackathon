using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public bool otomatik = false;
    public bool pause = false;
    public GameObject pauseMenu;
    public GameObject player;
    public GameObject start;
    public GameObject mainCam;
    public bool gameOver = false;
    public GameObject gameOverScreen;
    public sfxManager sfx;

    [Range(0, 3)]
    public int can = 3;
    public int maxCan = 3;
    public int puan;

    void LateUpdate()
    {
        otomatik = (player.transform.position.x > start.transform.position.x) && !pause;
        if (!gameOver)
            puan = (int)Mathf.Clamp(player.transform.position.x - start.transform.position.x, 0, 99999);
        pauseMenu.SetActive(pause);

        if (can < 1) gameOver = true;

        mainCam.GetComponent<CameraFollow>().enabled = !gameOver;
        gameOverScreen.SetActive(gameOver);

        if(Input.GetKeyDown(KeyCode.Escape)) pauseSet(!pause);

    }

    public void pauseSet(bool p)
    {
        pause = p;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }


}
