using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSaysManager : MonoBehaviour
{
    public List<SimonSaysObject> allButtons = new List<SimonSaysObject>();
    private List<Button> simonButtonsPressed = new List<Button>();
    private List<Button> playerButtonsPressed = new List<Button>();
    private int numberOfPresses = 4;

    //public static SimonSaysManager Instance;

    // Start is called before the first frame update
    public void Start()
    {
        StartRound();
    }

    public void StartRound()
    {
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

        for (int i = 0; i < numberOfPresses; i++)
        {
            int randomButton = Random.Range(0, allButtons.Count - 1);
            allButtons[randomButton].SelectButton();
            simonButtonsPressed.Add(allButtons[randomButton].button);
            yield return new WaitForSeconds(1f);
            allButtons[randomButton].DeselectButton();
            yield return new WaitForSeconds(1f);
            Debug.Log("Pressed Buttons: " + i + " times");
        }

        for (int i = 0; i < allButtons.Count; i++)
        {
            allButtons[i].button.enabled = true;
        }
        canvas.GetComponent<GraphicRaycaster>().enabled = true;
    }
}
