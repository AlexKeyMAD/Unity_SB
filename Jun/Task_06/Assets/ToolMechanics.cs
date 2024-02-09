using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToolMechanics : MonoBehaviour
{
    private int Pin1;
    private int Pin2;
    private int Pin3;

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

        Pin1 = 0;
        Pin2 = 0;
        Pin3 = 0;

        GeneratePass();

        UpdateTextPins();

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

    private void CheckResult()
    {
        if (pass[0] == Pin1 && pass[1] == Pin2 && pass[2] == Pin3) Win();
    }

    private void UpdateTextPins()
    {
        TextPin1.text = Pin1.ToString();
        TextPin2.text = Pin2.ToString();
        TextPin3.text = Pin3.ToString();

        CheckResult();
    }

    private int ShiftPin(int pin)
    {
        if (pin < 0) return 0;
        else if (pin > 10) return 10;
        else return pin;
    }

    public void Drill()
    {
        if (!timerON) return;

        Pin1 = ShiftPin(Pin1 + 1);
        Pin2 = ShiftPin(Pin2 - 1);

        UpdateTextPins();
    }

    public void Hummer()
    {
        if (!timerON) return;

        Pin1 = ShiftPin(Pin1 - 1);
        Pin2 = ShiftPin(Pin2 + 2);
        Pin3 = ShiftPin(Pin3 - 1);

        UpdateTextPins();
    }

    public void Picklock()
    {
        if (!timerON) return;

        Pin1 = ShiftPin(Pin1 - 1);
        Pin2 = ShiftPin(Pin2 + 1);
        Pin3 = ShiftPin(Pin3 + 1);

        UpdateTextPins();
    }

}
