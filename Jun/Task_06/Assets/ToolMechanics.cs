using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToolMechanics : MonoBehaviour
{
    private int Pin1 = 0;
    private int Pin2 = 0;
    private int Pin3 = 0;

    private int[] pass = new int[3];

    [SerializeField] private Text TextPin1;
    [SerializeField] private Text TextPin2;
    [SerializeField] private Text TextPin3;

    public Text timerText;

    void Start()
    {
        timerText.text = "60";

        GeneratePass();

        UpdateTextPins();
    }

    private void GeneratePass()
    {
        for (int i = 0; i < pass.Length; i++)
        {
            pass[i] = Random.Range(0,11);            
        }

        Debug.Log($"pass = {string.Join(" - ",pass)}");
    }

    private void Win()
    {
    }

    private void Loss()
    {
    }

    private void CheckResult()
    {
        if (pass[0] == Pin1 && pass[0] == Pin1 && pass[0] == Pin1) Win();
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
        Pin1 = ShiftPin(Pin1 + 1);
        Pin2 = ShiftPin(Pin2 - 1);

        UpdateTextPins();
    }

    public void Hummer()
    {
        Pin1 = ShiftPin(Pin1 - 1);
        Pin2 = ShiftPin(Pin2 + 2);
        Pin3 = ShiftPin(Pin3 - 1);

        UpdateTextPins();
    }

    public void Picklock()
    {
        Pin1 = ShiftPin(Pin1 - 1);
        Pin2 = ShiftPin(Pin2 + 1);
        Pin3 = ShiftPin(Pin3 + 1);

        UpdateTextPins();
    }

}
