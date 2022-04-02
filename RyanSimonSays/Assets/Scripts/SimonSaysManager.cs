using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSaysManager : MonoBehaviour
{
    // variables set here
    public List<SimonSaysObject> allButtons = new List<SimonSaysObject>();
    private List<Button> simonButtonsPressed = new List<Button>();
    private List<Button> playerButtonsPressed = new List<Button>();
    public static int numberOfPresses = 4;
    public bool redo = false;
    private int playerPresses = 0;
    public int id;
    public static bool signal = false;

    public static SimonSaysManager Instance;

    // Start is called before the first frame update
    public void Start()
    {
        // the game starts with the first round
        StartRound();
    }

    // call this method to start a round
    public void StartRound()
    {
        // checks if the signal to completely reset is given
        if(signal == true)
        {
            // starts to call for reset
            StartCoroutine(reset());
            // signal changes back to false
            signal = false;
            Debug.Log("Game Reset!");
        }
        // gets the input from Simon
        StartCoroutine(PressButtons());
    }

    IEnumerator PressButtons()
    {
        // find canvas and disable input to canvas
        Canvas canvas = FindObjectOfType<Canvas>();
        canvas.GetComponent<GraphicRaycaster>().enabled = false;

        // Disable buttons
        for (int i = 0; i < allButtons.Count; i++)
        {
            allButtons[i].button.enabled = false;
        }

        // allButtons list and Simon's button list are filled here 
        for (int i = 0; i < numberOfPresses; i++)
        {
            int randomButton = Random.Range(0, allButtons.Count - 1);
            allButtons[randomButton].SelectButton();
            simonButtonsPressed.Add(allButtons[randomButton].button);
            yield return new WaitForSeconds(1f);
            allButtons[randomButton].DeselectButton();
            yield return new WaitForSeconds(1f);
            Debug.Log("Pressed Buttons: " + i + " times");
            Debug.Log("allButtons = " + allButtons[i]);
            Debug.Log("SimonButtonsPressed = " + simonButtonsPressed[i]);
        }

        
        
        // after lists are filled, player can now use buttons
        for (int i = 0; i < allButtons.Count; i++)
        {
            allButtons[i].button.enabled = true;
        }
        canvas.GetComponent<GraphicRaycaster>().enabled = true;
    }

    // the method to clear the lists
    IEnumerator reset()
    {
        allButtons.Clear();
        simonButtonsPressed.Clear();
        playerButtonsPressed.Clear();
        yield return new WaitForSeconds(1f);
    }

    // along with reset, the variables affected by incrementing rounds are reset
    public static void giveUp()
    {
        signal = true;
        numberOfPresses = 4;
        RoundIndicator.round = 1;
    }

    // transitioning from static to non-static
    public void gate()
    {
        if(signal == true)
        {
            StartRound();
        }
    }

    // when called, a new round is given, and another symbol is added
    public void newRound()
    {   
        RoundIndicator.round++;
        numberOfPresses++;

        // checks if the maximum amount of rounds were reached
        if(RoundIndicator.round == 4)
        {
            // game completely resets, and brings player to the main menu
            StartCoroutine(reset());
            numberOfPresses = 4;
            RoundIndicator.round = 1;
            GameSceneManager.Instance.LoadScene("MainMenuScene");
        }
        else
        {
            // new round gets started
            StartCoroutine(reset());
            StartRound();
        }
    }

    // when allowed, the player interacts here
    public void playerTurn()
    {
        // whatever button the player presses is added to a list
        playerButtonsPressed.Add(allButtons[SimonSaysObject.buttonNum].button);
        Debug.Log("Player pressed the " + allButtons[SimonSaysObject.buttonNum].button + " button");

        // adds the total number of presses
        for (int i = 0; i < numberOfPresses; i++)
        {
            playerPresses++;
        }

        // checks if it is time to match lists
        if (playerPresses == numberOfPresses)
        {
            pressCheck();
        }
    }


    // a check is given to determine if the player matched with Simon
    public void pressCheck()
    {
        // if correct, the game gives a new round
        if (playerButtonsPressed == simonButtonsPressed)
        {
            Debug.Log("Correct");
            redo = false;
            StartCoroutine(reset());
            playerPresses = 0;
            newRound();
        }
        else
        {
            // if incorrect, the game will let the player try again
            Debug.Log("Incorrect. Try again.");
            redo = true;
            StartCoroutine(reset());
            playerPresses = 0;
            StartRound();
        }
    }
    
}
