using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    // get classes
    private Movement movement;
    private RandomManagers randomManagers;
    private Mess mess;
    private MainGameManager mainGameManager;

    // get class components
    private void Awake()
    {
        movement = GetComponent<Movement>();
        randomManagers = GetComponent<RandomManagers>();
        mainGameManager = GetComponent<MainGameManager>();
        mess = GetComponent<Mess>();
    }

    // checks what object the player touches
    private void OnTriggerEnter(Collider other)
    {
        // speedBoost gives player temporary speed+, destroys object, and calls timer
        if (other.gameObject.tag == "SpeedPwr")
        {
            movement.speedBoost();
            Destroy(other.gameObject);
            StartCoroutine(randomManagers.spawnTimerSpeed());
        }
        // jumpBoost gives player temporary jumpheight+, destroys object,
        // and calls timer
        else if (other.gameObject.tag == "JumpPwr")
        {
            movement.jumpBoost();
            Destroy(other.gameObject);
            StartCoroutine(randomManagers.spawnTimerJump());
        }
        // Mess decreases the amount of dirt spots left and destroys object
        else if (other.gameObject.tag == "Mess")
        {
            
            Mess.dirtLeft -= 1;
            Destroy(other.gameObject);
        }
        // When there's no dirt left, player touches van to win
        else if (other.gameObject.tag == "UtilityVan")
        {
            // player gets win message and gets sent to main menu
            if (Mess.dirtLeft == 0)
            {
                //mainGameManager.win();
                //mess.totalDirt.text = "You Win!";
                Time.timeScale = 0f;
                GameSceneManager.Instance.LoadScene("MainMenu");
            }
        }
    }
}
