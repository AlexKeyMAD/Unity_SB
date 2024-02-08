using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class CalcScript : MonoBehaviour
{
    public InputField FirstNum;
    public InputField SecondNum;
    public InputField AnswerNum;

    public void Addition()
    {
        AnswerNum.text = (double.Parse(FirstNum.text) + double.Parse(SecondNum.text)).ToString();
    }

    public void Subtraction()
    {
        AnswerNum.text = (double.Parse(FirstNum.text) - double.Parse(SecondNum.text)).ToString();
    }

    public void Multiplication()
    {
        AnswerNum.text = (double.Parse(FirstNum.text) * double.Parse(SecondNum.text)).ToString();
    }

    public void Division()
    {
        if (double.Parse(SecondNum.text) == 0) AnswerNum.text = "/ на 0";
        else AnswerNum.text = (double.Parse(FirstNum.text) / double.Parse(SecondNum.text)).ToString();
    }
}
