using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToolMechanics : MonoBehaviour
{
    private int[] pass = new int[3];

    [SerializeField] private Text TextPin1;
    [SerializeField] private Text TextPin2;
    [SerializeField] private Text TextPin3;
    [SerializeField] private Text ResultText;

    [SerializeField] private GameObject WinLossPanel;

    [SerializeField] private Text timerText;
    private float timerTime;
    private bool timerON;

    void Start()
    {
        StartNewGame();
    }

    void Update()
    {
        if (timerON)
        {
            timerTime -= Time.deltaTime;
            UpdateTimer();

            if (Convert.ToInt32(timerTime) == 0) Loss();
        }
    }

    private void UpdateTimer()
    {
        timerText.text = Convert.ToInt32(timerTime).ToString();
    }

    private void StartNewGame()
    {   
        timerTime = 60f;
        timerON = true;
        UpdateTimer();

        for (int i = 0; i < pass.Length; i++)
        {
            pass[i] = 0;
        }

        GeneratePass();

        UpdateTextPins(0, 0, 0);

        WinLossPanel.SetActive(false);
    }

    public void RestartGame()
    {
        StartNewGame();
    }

    private void GeneratePass()
    {
        for (int i = 0; i < pass.Length; i++)
        {
            pass[i] = UnityEngine.Random.Range(0,11);            
        }

        Debug.Log($"pass = {string.Join(" - ",pass)}");
    }

    private void Win()
    {
        ResultText.text = "Вы выиграли";
        WinLossPanel.SetActive(true);
        timerON = false;
    }

    private void Loss()
    {
        ResultText.text = "Вы проиграли";
        WinLossPanel.SetActive(true);
        timerON = false;
    }

    private void CheckResult(int Pin1, int Pin2, int Pin3)
    {
        if (pass[0] == Pin1 && pass[1] == Pin2 && pass[2] == Pin3) Win();
    }

    private void UpdateTextPins(int Pin1, int Pin2, int Pin3)
    {
        TextPin1.text = Pin1.ToString();
        TextPin2.text = Pin2.ToString();
        TextPin3.text = Pin3.ToString();

        CheckResult(Pin1, Pin2, Pin3);
    }

    private int ShiftPin(int pin)
    {
        if (pin < 0) return 0;
        else if (pin > 10) return 10;
        else return pin;
    }

    public void Tools(int indexTools)
    {
        switch (indexTools)
        {
            case 0:
                Drill(Convert.ToInt32(TextPin1.text)
                            , Convert.ToInt32(TextPin2.text)
                            , Convert.ToInt32(TextPin3.text));
                break;
            case 1:
                Hummer(Convert.ToInt32(TextPin1.text)
                            , Convert.ToInt32(TextPin2.text)
                            , Convert.ToInt32(TextPin3.text));
                break;
            case 2:
                Picklock(Convert.ToInt32(TextPin1.text)
                            , Convert.ToInt32(TextPin2.text)
                            , Convert.ToInt32(TextPin3.text));
                break;
            default: break;
        }
    }

    private void Drill(int Pin1, int Pin2, int Pin3)
    {
        if (!timerON) return;

        Pin1 = ShiftPin(Pin1 + 1);
        Pin2 = ShiftPin(Pin2 - 1);

        UpdateTextPins(Pin1, Pin2, Pin3);
    }

    private void Hummer(int Pin1, int Pin2, int Pin3)
    {
        if (!timerON) return;

        Pin1 = ShiftPin(Pin1 - 1);
        Pin2 = ShiftPin(Pin2 + 2);
        Pin3 = ShiftPin(Pin3 - 1);

        UpdateTextPins(Pin1, Pin2, Pin3);
    }

    private void Picklock(int Pin1, int Pin2, int Pin3)
    {
        if (!timerON) return;

        Pin1 = ShiftPin(Pin1 - 1);
        Pin2 = ShiftPin(Pin2 + 1);
        Pin3 = ShiftPin(Pin3 + 1);

        UpdateTextPins(Pin1, Pin2, Pin3);
    }
}
