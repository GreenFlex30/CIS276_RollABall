using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSaysObject : MonoBehaviour
{
    // variables set here
    public Color selectedColor;
    private Color originalColor;
    public Button button;
    private Image buttonImage;
    public static int buttonNum;




    // when loaded, the button gets loaded
    private void Awake()
    {
        buttonImage = GetComponent<Image>();
        button = GetComponent<Button>();
        originalColor = buttonImage.color;
    }

    // activates when button is pressed by player or ai
    public void SelectButton()
    {
        buttonImage.color = selectedColor;
        button.onClick.Invoke();
    }

    // activates after clicking a button (mostly for visual effect)
    public void DeselectButton()
    {
        buttonImage.color = originalColor;
    }
}
