using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class donutDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateDonutDisplay();
    }

    public GameController game;
    public List<Image> donutlar = new List<Image>(3);
    public List<Sprite> donutResimleri = new List<Sprite>(2);
    void updateDonutDisplay()
    {
        for (int i = 0; i < donutlar.Capacity; i++)
        {
            donutlar[i].sprite = donutResimleri[(game.can >= 3 - i) ? 0 : 1];
            donutlar[i].canvasRenderer.SetColor(new Color(1, 1, 1, (game.can >= game.maxCan - i) ? 1 : 0.5f));
        }
    }
}
