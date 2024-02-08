using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{

    [SerializeField] private GameObject CalcScreen;
    [SerializeField] private GameObject CompScreen;
    [SerializeField] private Button ButtonCalc;
    [SerializeField] private Button ButtonCom;

    private GameObject CurrentScreen;

    private void InteractableButtons()
    {
        bool isCalc = (CurrentScreen == CalcScreen);

        ButtonCalc.interactable = !isCalc;
        ButtonCom.interactable = isCalc;
    }

    private void Start()
    {
        CalcScreen.SetActive(true);
        CurrentScreen = CalcScreen;
        InteractableButtons();
    }

    public void ChangeScreens(GameObject Screen)
    { 
        if (CurrentScreen != null)
        {
            CurrentScreen.SetActive(false);
            Screen.SetActive(true);
            CurrentScreen = Screen;
            InteractableButtons();
        }
    }
}
