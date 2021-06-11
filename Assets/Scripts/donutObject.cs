using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donutObject : MonoBehaviour
{
    public GameController game;
    public float RotationSpeed = 30;
    public float yPos = 0;

    private void Start()
    {
        yPos = transform.position.y;
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    public AnimationCurve myCurve;
    void Update()
    {
        transform.Rotate(Vector3.forward * (RotationSpeed * Time.deltaTime));
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)) / 4 - 1 + yPos, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            game.sfx.playSoundById(game.can == 1 ? 2 : 3);
            game.can -= 1;
            game.player.GetComponent<Player>().donutSayısı += 1;
            Destroy(this.gameObject);
        }
    }
}
