using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mess : MonoBehaviour
{
    // variables set
    public Text totalDirt;
    public static int dirtLeft = 10;
    //public int finalDirt = 1;
    public bool isDone = false;

    // when called, the amount of dirt spots left will decrease
    public void getDirt()
    {
        dirtLeft--;
    }
    // Start is called before the first frame update
    void Start()
    {
        // looks for the text in Inspector
        totalDirt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // displays the amount of dirtspots left on text box
        totalDirt.text = dirtLeft + " messes left!";

        // tell the player to go to the van
        if(dirtLeft == 0)
        {
            isDone = true;
            totalDirt.text = "Get to the van!";
        }
    }
}