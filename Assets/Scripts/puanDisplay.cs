using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puanDisplay : MonoBehaviour
{
    public GameController game;

    void Update(){
        this.GetComponent<Text>().text = "Puan " + game.puan.ToString().PadLeft(5,'0');
    }
}
